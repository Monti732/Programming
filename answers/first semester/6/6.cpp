#include <iostream>
#include <string>
#include <algorithm>

int main() {
    std::string str;
    std::cout << "Enter a string: ";
    std::getline(std::cin, str);
    int count = std::count(str.begin(), str.end(), ' ');
    std::cout << count + 1 << std::endl;
}