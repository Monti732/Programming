#include <iostream>

int main() {
    int array[5][5]{{1,3,57,2,7},{6,2,7,9,2},{38,29,9,49,10},{1,4,1,6,0},{ 20,6,2,9,2}};
    int max = array[0][0];
    int min = array[0][0];
    for (int i = 0; i < 5; ++i) {
        std::cout << std::endl;
        for (int j = 0; j < 5; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
    for (int i = 0; i < 5; ++i) {
        for (int j = 0; j < 5; ++j) {
            if (max < array[i][j]) {
                max = array[i][j];
            }
            if (min > array[i][j]) {
                min = array[i][j];
            }
        }
    }
    for (int i = 0; i < 5; ++i) {
        for (int j = 0; j < 5; ++j) {
            if (array[i][j] == min) {
                array[i][j] = max;
                break;
            }
            if (array[i][j] == max) {
                array[i][j] = min;
                break;
            }
        }
    }
    std::cout << "\n" << "\n";
    for (int i = 0; i < 5; ++i) {
        std::cout << std::endl;
        for (int j = 0; j < 5; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
}