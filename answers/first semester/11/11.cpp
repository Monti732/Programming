#include <iostream>
#include <cmath>

int main() {
    int aSide, bSide, cSide;
    std::cout << "Enter the sides of triangle ";
    std::cin >> aSide >> bSide >> cSide;
    int halfPerimeter = (aSide + bSide + cSide) / 2 * 1.0;
    if ((aSide + bSide > cSide) && (aSide + cSide > bSide) && (bSide + cSide > aSide)) {
        std::cout << "YES\n";
        int area = sqrt(halfPerimeter * (halfPerimeter - aSide) * (halfPerimeter - bSide) * (halfPerimeter - cSide));
        std::cout << "area = " << area;
    }
    else {
        std::cout << "NO";
    }
}