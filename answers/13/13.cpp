#include <iostream>

int main() {
    int array[5][5]{
        {1, 2, 3, 4, 5},
        {6, 7, 8, 9, 8},
        {1, 2, 3, 4, 5},
        {6, 7, 8, 9, 3},
        {2, 2, 3, 4, 5}
    };
    for (int i = 0; i < 5; ++i) {
        int sum = 0;
        for (int j = 0; j < 5; ++j) {
            sum += array[i][j];
        }
        std::cout << "sum of row " << i + 1 << " is " << sum << std::endl;
    }
}