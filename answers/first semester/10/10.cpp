#include <iostream>

int main() {
    int x1, y1, x2, y2, x3, y3, x4, y4;
    std::cout << "Enter coordinates of points ";
    std::cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> x4 >> y4;
    int mid1X = (x1 + x3) / 2;
    int mid1Y = (y1 + y3) / 2;
    int mid2X = (x2 + x4) / 2;
    int mid2Y = (y2 + y4) / 2;
    if ((mid1X == mid2X) && (mid1Y == mid2Y)) {
        std::cout << "YES";
    }
    else {
        std::cout << "NO";
    }
}