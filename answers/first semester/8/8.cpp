#include <iostream>
#include <vector>
#include <algorithm>

int main() {
    std::vector<std::vector<int>> array;
    int numberOfLines, numberOfColumns;
    std::cout << "Enter number of lines ";
    std::cin >> numberOfLines;
    std::cout << "Enter number of columns ";
    std::cin >> numberOfColumns;
    std::cout << "Enter elements";
    for (int i = 0; i < numberOfLines; ++i) {
        std::vector<int> line;
        for (int j = 0; j < numberOfColumns; ++j) {
            int element;
            std::cin >> element;
            line.push_back(element);
        }
        array.push_back(line);
    }
    std::cout << "\nOriginal array";
    for (int i = 0; i < numberOfLines; ++i) {
        std::cout << '\n';
        for (int j = 0; j < numberOfColumns; ++j) {
            std::cout << array[i][j] << " ";
        }
    }
    for (int i = 0; i < numberOfLines; ++i) {
        for (int j = i; j < numberOfColumns; ++j) {
            std::swap(array[i][j], array[j][i]);
        }
    }
    for (int i = 0; i < numberOfLines; ++i) {
        std::reverse(array[i].begin(), array[i].end());
    }
    std::cout << "\n\nChanged array";
    for (int i = 0; i < numberOfLines; ++i) {
        std::cout << '\n';
        for (int j = 0; j < numberOfColumns; ++j) {
            std::cout << array[i][j] << " ";
        }
    }
}