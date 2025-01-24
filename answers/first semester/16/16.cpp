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
        int midSumInColomn = 0;
        for (int j = 0; j < numberOfColumns;++j) {
            midSumInColomn += array[j][i];
        }
        std::cout << "mid sum in colomn " << i + 1 << " = " << midSumInColomn / (numberOfColumns * 1.0) << '\n';
    }

}