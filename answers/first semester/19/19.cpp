#include <iostream>
#include <string>

int main() {
    std::string telegramma;
    std::cout << "Enter telegramma ";
    std::getline(std::cin, telegramma);
    int price;
    std::cout << "Enter price for ont letter ";
    std::cin >> price;
    std::cout << "Telegramma price " << telegramma.size() * price;
}