#include <iostream>
#include <vector>

int main() {
    std::vector<int> array;
    int sizeOfArray;
    std::cout << "Enter the size of array ";
    std::cin >> sizeOfArray;
    std::cout << "Enter the elements of array ";
    for (int i = 0; i < sizeOfArray; ++i) {
        int element;
        std::cin >> element;
        array.push_back(element);
    }
    int min = array[0];
    int max = array[0];
    for (int i = 0; i < sizeOfArray; ++i) {
        if (max < array[i]) {
            max = array[i];
        }
        if (min > array[i]) {
            min = array[i];
        }
    }
    std::cout << "Max element of array " << max << "\nMin element of array " << min;
}