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
    for (int i = 0; i < numberOfLines; ++i) {
        int sum = 0;
        for (int j = 0; j < numberOfColumns; ++j) {
            sum += array[i][j];
        }
        std::cout << "sum of line " << i + 1 << " is " << sum << std::endl;
    }
}