#include <iostream>
#include <string>

int main() {
    std::string str;
    std::cout << "Enter full name ";
    std::getline(std::cin, str);
    size_t firstSpace = str.find_first_of(' ');
    size_t lastSpace = str.find_last_of(' ');
    for (int i = 0; i < firstSpace; ++i) {
        std::cout << str[i];
    }
    std::cout << ' ' << str[firstSpace + 1] << ". " << str[lastSpace + 1] << ".";
}