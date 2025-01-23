#include <iostream>

int main() {
    int arrey[5][5]{
        {1, 2, 3, 4, 5},
        {6, 7, 8, 9, 8},
        {1, 2, 3, 4, 5},
        {6, 7, 8, 9, 3},
        {2, 2, 3, 4, 5}
    };
    for (int i = 0; i < 5; ++i) {
        std::cout << std::endl;
        for (int j = 0; j < 5; ++j) {
            std::cout << arrey[i][j] << " ";
        }
    }
    for (int i = 0; i < 5; ++i) {
        for (int j = 0; j < 5; ++j) {
            if (i == j) {
                arrey[i][j] = 0;
            }
        }
    }
    std::cout << "\n\n";
    for (int i = 0; i < 5; ++i) {
        std::cout << std::endl;
        for (int j = 0; j < 5; ++j) {
            std::cout << arrey[i][j] << " ";
        }
    }
}