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
    std::cout << "Enter elements ";
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
        for (int j = i + 1; j < numberOfColumns; ++j) {
            std::swap(array[i][j], array[j][i]);
        }
    }
    for (int i = 0; i < numberOfLines; ++i) {
        std::reverse(array[i].begin(), array[i].end());
    }
    for (int i = 0; i < numberOfLines; ++i) {
        int midSumInColomn = 0;
        for (int j = 0; j < numberOfColumns;++j) {
            midSumInColomn += array[i][j];
        }
        std::cout << "mid sum in colomn " << i + 1 << " = " << midSumInColomn / (numberOfColumns * 1.0) << '\n';
    }

}