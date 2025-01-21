#include <iostream>
#include <vector>
#include <algorithm>
#include <chrono>
#include <thread>
#include <random>
#include <windows.h>

class Board {
private:
    int width;
    int height;
    std::vector<std::vector<int>> grid;

public:
    Board(int w, int h) : width(w), height(h) {
        grid.resize(height, std::vector<int>(width, 0));
    }
    void display() {
        for (const auto& row : grid) {
            for (int cell : row) {
                if (cell == 0)
                    std::cout << ". ";
                else
                    std::cout << "# ";
            }
            std::cout << std::endl;
        }
        std::cout << std::endl;
    }
    bool canPlaceTetromino(const std::vector<std::vector<int>>& tetromino, int x, int y) {
        for (size_t i = 0; i < tetromino.size(); ++i) {
            for (size_t j = 0; j < tetromino[i].size(); ++j) {
                if (tetromino[i][j] == 1) {
                    int newX = x + j;
                    int newY = y + i;
                    if (newX < 0 || newX >= width || newY < 0 || newY >= height || grid[newY][newX] == 1) {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    void addTetromino(const std::vector<std::vector<int>>& tetromino, int x, int y) {
        for (size_t i = 0; i < tetromino.size(); ++i) {
            for (size_t j = 0; j < tetromino[i].size(); ++j) {
                if (tetromino[i][j] == 1) {
                    int newX = x + j;
                    int newY = y + i;
                    grid[newY][newX] = 1;
                }
            }
        }
    }
    void clearFullLines() {
        for (int i = height - 1; i >= 0; --i) {
            if (std::all_of(grid[i].begin(), grid[i].end(), [](int cell) { return cell == 1; })) {
                grid.erase(grid.begin() + i);
                grid.insert(grid.begin(), std::vector<int>(width, 0));
                ++i;
            }
        }
    }
    void clearTetromino(const std::vector<std::vector<int>>& tetromino, int x, int y) {
        for (size_t i = 0; i < tetromino.size(); ++i) {
            for (size_t j = 0; j < tetromino[i].size(); ++j) {
                if (tetromino[i][j] == 1) {
                    int newX = x + j;
                    int newY = y + i;
                    if (newX >= 0 && newX < width && newY >= 0 && newY < height) {
                        grid[newY][newX] = 0;
                    }
                }
            }
        }
    }
};

class Tetromino {
public:
    std::vector<std::vector<std::vector<int>>> shapes;

    Tetromino() {
        shapes.push_back({ {1, 1, 1, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} }); // |
        shapes.push_back({ {0, 1, 1, 0}, {0, 1, 1, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} }); // square
        shapes.push_back({ {1, 0, 0, 0}, {1, 0, 0, 0}, {1, 1, 0, 0}, {0, 0, 0, 0} }); // L
        shapes.push_back({ {0, 1, 0, 0}, {0, 1, 0, 0}, {1, 1, 0, 0}, {0, 0, 0, 0} }); // reverse L
        shapes.push_back({ {0, 0, 1, 1}, {0, 1, 1, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} }); // S
        shapes.push_back({ {1, 1, 0, 0}, {0, 1, 1, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} }); // Z
        shapes.push_back({ {1, 1, 1, 0}, {0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} }); // T
    }

    const std::vector<std::vector<int>>& getShape(int index) {
        return shapes[index];
    }

    void rotateRight(std::vector<std::vector<int>>& shape) {
        std::vector<std::vector<int>> rotated(4, std::vector<int>(4, 0));
        for (int i = 0; i < 4; ++i) {
            for (int j = 0; j < 4; ++j) {
                rotated[j][4 - i - 1] = shape[i][j];
            }
        }
        shape = rotated;
    }
    void rotateLeft(std::vector<std::vector<int>>& shape) {
        std::vector<std::vector<int>> rotated(4, std::vector<int>(4, 0));
        for (int i = 0; i < 4; ++i) {
            for (int j = 0; j < 4; ++j) {
                rotated[4 - j - 1][i] = shape[i][j];
            }
        }
        shape = rotated;
    }
    void shiftLeft(std::vector<std::vector<int>>& shape, int& x, int y, Board& board) {
        if (board.canPlaceTetromino(shape, x - 1, y)) {
            --x;
        }
    }
    void shiftRight(std::vector<std::vector<int>>& shape, int& x, int y, Board& board) {
        if (board.canPlaceTetromino(shape, x + 1, y)) {
            ++x;
        }
    }
};

int main() {
    Tetromino tetromino;
    Board board(10, 20);
    std::random_device rd;
    std::default_random_engine gen(rd());
    std::uniform_int_distribution<int> dist(0, 6);
    while (true) {
        int x = 3;
        int y = 0;
        auto shape = tetromino.getShape(dist(gen));
        if (!board.canPlaceTetromino(shape, x, y)) {
            break;
        }
        while (true) {
            std::this_thread::sleep_for(std::chrono::milliseconds(100));
            system("cls");
            board.clearTetromino(shape, x, y);
            if (board.canPlaceTetromino(shape, x, y + 1)) {
                if (GetAsyncKeyState(68)) { // press d
                    tetromino.rotateRight(shape);
                }
                if (GetAsyncKeyState(65)) { // press a
                    tetromino.rotateLeft(shape);
                }
                if (GetAsyncKeyState(37)) { // press left arrow
                    tetromino.shiftLeft(shape, x, y, board); 
                }
                if (GetAsyncKeyState(39)) { // press right arrow
                    tetromino.shiftRight(shape, x, y, board);
                }
                ++y;
                board.addTetromino(shape, x, y);
                board.clearFullLines();
                board.display();
            }
            else {
                board.addTetromino(shape, x, y);
                std::cout << "Game Over :(";
                break;
            }
        }
    }
}