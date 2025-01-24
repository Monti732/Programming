#include <iostream>
#include <cmath>

int main() {
    int number;
    std::cout << "Enter number ";
    std::cin >> number;
    for (int i = 2; i <= sqrt(number); ++i) {
        if (number % i == 0) {
            std::cout << "NO PROSTOE";
            return 0;
        }
    }
    std::cout << "PROSTOE";
}