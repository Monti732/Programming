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
    std::cout << "\n\nOriginal array\n";
    for (int i = 0; i < numberOfElements; ++i) {
        std::cout << array[i] << " ";
    }
    for (int i = 0; i < numberOfElements / 2; ++i) {
        std::swap(array[i], array[numberOfElements - i - 1]);
    }
    std::cout << "\n\nChanged array\n";
    for (int i = 0; i < numberOfElements; ++i) {
        std::cout << array[i] << " ";
    }
}