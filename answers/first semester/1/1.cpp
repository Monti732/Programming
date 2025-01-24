#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>

int main() {
    srand(time(NULL));
    int sizeOfArray;
    std::cout << "Enter the size of array ";
    std::cin >> sizeOfArray;
    std::vector<int> array;
    std::cout << "Enter the elements of array ";
    for (int i = 0; i < sizeOfArray; ++i) {
        int element;
        std::cin >> element;
        array.push_back(element);
    }
    int sum = 0;
    int product = 1;
    for (int i = 0; i < sizeOfArray; ++i) {
        sum += array[i];
        product = product * array[i];
    }
    for (int i = 0; i < sizeOfArray; ++i) {
        std::cout << array[i] << ' ';
    }
    std::cout << '\n' << sum << '\n' << product;
}