#include <iostream>
#include <vector>

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
    int sumOnMainDiagonal = 0;
    int sumOnSecondaryDiagonal = 0;
    for (int i = 0; i < numberOfLines; ++i) {
        sumOnMainDiagonal += array[i][i];
        sumOnSecondaryDiagonal += array[i][numberOfColumns - 1 - i];
    }
    std::cout << "sum on main diagonal = " << sumOnMainDiagonal << '\n';
    std::cout << "sum on secondary diagonal = " << sumOnSecondaryDiagonal << '\n';
}