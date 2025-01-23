#include <iostream>

int main() {
    int array[3][3] = {{1, 4, 2}, {7, 3, 8}, {0, 9, 4}};
    for (int i = 0; i < 3; ++i) {
        std::cout << '\n';
        for (int j = 0; j < 3; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
    for (int i = 0; i < 3; ++i) {
        for (int j = i; j < 3; ++j) {
            int buf = array[i][j];
            array[i][j] = array[j][i];
            array[j][i] = buf;
        }
    }
    std::cout << "\n\n";
    for (int i = 0; i < 3; ++i) {
        std::cout << '\n';
        for (int j = 0; j < 3; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
}