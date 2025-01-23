#include <iostream>

int main() {
    int array[5][5]{{1,2,3,4,5}, {1,2,3,4,5}, {1,2,3,4,5}, {1,2,3,4,5}, {1,2,3,4,5}};
    int sumOnMainDiagonal = 0;
    int sumOnSecondaryDiagonal = 0;
    for (int i = 0; i < 5; ++i) {
        sumOnMainDiagonal += array[i][i];
        sumOnSecondaryDiagonal += array[i][4 - i];
    }
    std::cout << "sum on main diagonal = " << sumOnMainDiagonal << '\n';
    std::cout << "sum on secondary diagonal = " << sumOnSecondaryDiagonal << '\n';
}