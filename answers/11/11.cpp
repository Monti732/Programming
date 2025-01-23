#include <iostream>
#include <cmath>

int main() {
    int a, b, c;
    std::cin >> a >> b >> c;
    int halfPerimeter = (a + b + c) / 2 * 1.0;
    if ((a + b > c) && (a + c > b) && (b + c > a)) {
        std::cout << "YES\n";
        int area = sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
        std::cout << "area = " << area;
    }
    else {
        std::cout << "NO";
    }
}