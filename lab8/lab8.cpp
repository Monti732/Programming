#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <limits>

std::string arabicToRoman(int number) {
    if (number <= 0 || number > 3999) {
        return "Число должно быть в диапазоне от 1 до 3999.";
    }

    std::vector<std::pair<int, std::string>> romanSymbols = {
        {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
        {100, "C"},  {90, "XC"},  {50, "L"},  {40, "XL"},
        {10, "X"},   {9, "IX"},   {5, "V"},   {4, "IV"},
        {1, "I"}
    };

    std::string result;

    for (auto [value, symbol] : romanSymbols) {
        while (number >= value) {
            result += symbol;
            number -= value;
        }
    }
    return result;
}

int romanToArabic(std::string roman) {
    std::map<char, int> romanMap = {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
    };

    int arabicNumber = 0;
    int prevValue = 0;

    for (int i = roman.size() - 1; i >= 0; --i) {
        char currentChar = roman[i];
        int currentValue = romanMap[currentChar];

        if (currentValue < prevValue) {
            arabicNumber -= currentValue;
        }
        else {
            arabicNumber += currentValue;
        }
        prevValue = currentValue;
    }
    return arabicNumber;
}

int main() {
    setlocale(LC_ALL, "ru");
    while (true) {
        int choice;
        std::cout << "1.Из арабских в римские" << std::endl;
        std::cout << "2.Из римских в арабские" << std::endl;
        std::cout << "3.Выход" << std::endl;
        std::cout << "\nВаш выбор ";
        std::cin >> choice;

        if (std::cin.fail()) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Неверный ввод, введите цифру" << std::endl;
            continue;
        }

        switch (choice) {
        case 1:
        {
            int arabicNumber;
            std::cout << "Введите арабское число ";
            std::cin >> arabicNumber;

            std::string romanNumber = arabicToRoman(arabicNumber);
            std::cout << "Римское число " << romanNumber << std::endl;
            break;
        }
        case 2:
        {
            std::string romanNumber;
            std::cout << "Введите римское число";
            std::cin >> romanNumber;

            int arabicNumber = romanToArabic(romanNumber);
            std::cout << "Арабское число" << arabicNumber << std::endl;
            break;
        }
        case 3:
            return 0;
        default:
            std::cout << "Неверный ввод, введите цифру от 1 до 3" << std::endl;
            break;
        }
    }
}