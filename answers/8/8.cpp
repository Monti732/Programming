#include <iostream>

int main() {
    int array[5][5] = { {1, 2, 3, 4, 5},
                        {6, 7, 8, 9, 1},
                        {1, 2, 3, 4, 1},
                        {6, 1, 8, 0, 9},
                        {5, 7, 5, 4, 2}};
    for (int i = 0; i < 5; ++i) {
        std::cout << '\n';
        for (int j = 0; j < 5; ++j) {
            std::cout << array[i][j] << " ";
        }
    }
    std::cout << "\n\n";
    for (int i = 0; i < 5; ++i) {
        for (int j = 0; j < 5; ++j) {
            array[j][5 - i - 1] = array[i][j];
        }
    }
    for (int i = 0; i < 5; ++i) {
        std::cout << '\n';
        for (int j = 0; j < 5; ++j) {
            std::cout << array[i][j] << " ";
        }
    }
}