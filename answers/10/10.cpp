#include <iostream>

int main() {
    int x1, y1, x2, y2, x3, y3, x4, y4;
    std::cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> x4 >> y4;
    int mid1_x = (x1 + x3) / 2;
    int mid1_y = (y1 + y3) / 2;
    int mid2_x = (x2 + x4) / 2;
    int mid2_y = (y2 + y4) / 2;
    if ((mid1_x == mid2_x) && (mid1_y == mid2_y)) {
        std::cout << "YES";
    }
    else {
        std::cout << "NO";
    }
}