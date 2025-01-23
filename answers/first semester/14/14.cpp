#include <iostream>
#include <vector>
#include <algorithm>

int main() {
    std::vector<std::vector<int>> array ={
        {-1, -2, 3, -4, 5},
        {6, 7, -8, 9, -10},
        {-11, 12, -13, -14, -15},
        {16, -17, 18, 19, 20},
        {-21, -22, -23, -24, -25}
    };
    for (int i = 0; i < 5; ++i) {
        for (int j = i + 1; j < 5; ++j) {
            std::swap(array[i][j], array[j][i]);
        }
    }
    for (int i = 0; i < 5; ++i) {
        std::reverse(array[i].begin(), array[i].end());
    }
    for (int i = 0; i < 5; ++i) {
        int sum = 0;
        for (int j = 0; j < 5; ++j) {
            if (array[i][j] < 0) {
                sum += array[i][j];
            }
        }
        std::cout << "sum of neg nums in colomn " << i + 1 << "= " << sum << '\n';
    }
}