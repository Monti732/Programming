#include <iostream>
#include <string>

int main() {
    std::string telegramma;
    std::getline(std::cin, telegramma);
    std::cout << telegramma.size() * 3;
}