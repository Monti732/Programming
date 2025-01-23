#include <iostream>

int main() {
    int array[5] = {7,3,8,9,4};
    for (int i = 0; i< 5; i++) {
        for (int j = 0; j < 5 - i - 1; ++j) {
            if (array[j] > array[j + 1]) {
                std::swap(array[j], array[j + 1]);
            }
        }
    }
    for (int i = 0; i < 5; i++) {
        std::cout << array[i] << " ";
    }
}