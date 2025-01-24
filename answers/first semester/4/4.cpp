#include <iostream>
#include <vector>

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
    int max = array[0][0];
    int min = array[0][0];
    std::cout << "\nOriginal array";
    for (int i = 0; i < numberOfLines; ++i) {
        std::cout << '\n';
        for (int j = 0; j < numberOfColumns; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
    for (int i = 0; i < numberOfLines; ++i) {
        for (int j = 0; j < numberOfColumns; ++j) {
            if (max < array[i][j]) {
                max = array[i][j];
            }
            if (min > array[i][j]) {
                min = array[i][j];
            }
        }
    }
    for (int i = 0; i < numberOfLines; ++i) {
        for (int j = 0; j < numberOfColumns; ++j) {
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
    std::cout << "\n\nChanged array";
    for (int i = 0; i < numberOfLines; ++i) {
        std::cout << '\n';
        for (int j = 0; j < numberOfColumns; ++j) {
            std::cout << array[i][j] << ' ';
        }
    }
}