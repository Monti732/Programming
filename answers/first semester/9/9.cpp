#include <iostream>
#include <vector>

int main() {
    std::vector<int> array;
    int numberOfElements;
    std::cout << "Enter number of elements ";
    std::cin >> numberOfElements;
    std::cout << "Enter elements ";
    for (int i = 0; i < numberOfElements; ++i) {
        int element;
        std::cin >> element;
        array.push_back(element);
    }
    for (int i = 0; i < numberOfElements; i++) {
        for (int j = 0; j < numberOfElements - i - 1; ++j) {
            if (array[j] > array[j + 1]) {
                std::swap(array[j], array[j + 1]);
            }
        }
    }
    for (int i = 0; i < numberOfElements; i++) {
        std::cout << array[i] << " ";
    }
}