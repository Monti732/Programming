#include <iostream>
#include <vector>
#include <algorithm>

int main() {
    std::vector<std::vector<int>> array = {{1,2,3,4,5}, {6,7,8,9,1}, {2,3,4,5,6}, {7,8,9,1,2}, {3,4,5,6,7}};
    for (int i = 0; i < 5; ++i) {
        for (int j = i + 1; j < 5; ++j) {
            std::swap(array[i][j], array[j][i]);
        }
    }
    for (int i = 0; i < 5; ++i) {
        std::reverse(array[i].begin(), array[i].end());
    }
    for (int i = 0; i < 5; ++i) {
        int midSumInColomn = 0;
        for (int j = 0; j < 5;++j) {
            midSumInColomn += array[i][j];
        }
        std::cout << "mid sum in colomn " << i + 1 << "= " << midSumInColomn / (5 * 1.0) << '\n';
    }

}