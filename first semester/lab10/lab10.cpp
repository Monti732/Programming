#include <iostream>
#include <string>
#include <algorithm>

std::string addNumbers(std::string number1, std::string number2) {
    std::string result;
    int carry = 0;
    int i = number1.size() - 1;
    int j = number2.size() - 1;
    while (i >= 0 || j >= 0 || carry > 0) {
        int digit1 = (i >= 0) ? number1[i] - '0' : 0;
        int digit2 = (j >= 0) ? number2[j] - '0' : 0;

        int sum = digit1 + digit2 + carry;
        carry = sum / 10;
        result.push_back((sum % 10) + '0');

        --i;
        --j;
    }
    std::reverse(result.begin(), result.end());
    return result;
}

std::string subNumbers(std::string number1, std::string number2) {
    std::string result;
    int borrow = 0;
    int diff;

    while (number1.size() != number2.size()) {
        number2.insert(number2.begin(), '0');
    }

    for (int i = number1.size() - 1; i >= 0; --i) {
        int digit1 = number1[i] - '0';
        int digit2 = number2[i] - '0';
        digit1 -= borrow;
        if (digit1 < digit2) {
            digit1 += 10;
            borrow = 1;
        }
        else {
            borrow = 0;
        }
        diff = digit1 - digit2;
        result.insert(result.begin(), diff + '0');
    }
    result.erase(0, result.find_first_not_of('0'));
    if (result.empty()) {
        return "0";
    }
    return result;
}

std::string multNumbers(std::string number1, std::string number2) {
    std::string result = "0";
    std::string current = "0";

    for (int i = number2.size() - 1; i >= 0; --i) {
        int digit = number2[i] - '0';
        for (int j = 0; j < digit; ++j) {
            current = addNumbers(current, number1);
        }
        for (int k = 0; k < (number2.size() - 1 - i); ++k) {
            current += "0";
        }
        result = addNumbers(current, number1);
        current = "0";
    }
    return result;
}

std::string compNumbers(std::string number1, std::string number2) {
    std::string result;
    if (number1 == number2) {
        return "Числа равны";
    }
    if (number1.size() == number2.size()) {
        int i = 0;

        do {
            int digit1 = number1[i] - '0';
            int digit2 = number2[i] - '0';
            if (digit1 != digit2) {
                if (digit1 > digit2) {
                    result = number1;
                    break;
                }
                else {
                    result = number2;
                    break;
                }
            }
            else {
                ++i;
                continue;
            }
        } while (i < number1.size());
    }
    else {
        if (number1.size() > number2.size()) {
            result = number1;
        }
        else {
            result = number2;
        }
    }
    return result;
}

bool doWhileDiv(std::string current, std::string number2) {
    if (compNumbers(current, number2) == number2) {
        return false;
    }
    else {
        return true;
    }
}

std::string divNumbers(std::string number1, std::string number2) {
    if (compNumbers(number1, number2) == number2 || number1 == "0") {
        return "0";
    }
    if (number1 == number2) {
        return "1";
    }
    if (number2 == "0") {
        return "На ноль делить нельзя";
    }
    std::string result = "0";
    std::string current = number1;
    while (doWhileDiv(current, number2)) {
        current = subNumbers(current, number2);
        result = addNumbers(result, "1");
        std::cout << result << std::endl;
    }

    return result;
}

int main() {
    setlocale(LC_ALL, "ru");

    int choice;

    std::string number1, number2;
    while (true) {
        std::cout << "1.Сложение\n2.Вычитание\n3.Умножение\n4.Деление(целочисленное)\n5.Сравнение\n6.Выход\n\nВаш выбор: ";
        std::cin >> choice;

        switch (choice) {
        case 1:
        {
            std::cout << "Введите первое число: ";
            std::cin >> number1;
            std::cout << "Введите второе число: ";
            std::cin >> number2;

            std::string result = addNumbers(number1, number2);
            std::cout << result << std::endl;
            break;
        }

        case 2:
        {
            std::cout << "Введите первое число: ";
            std::cin >> number1;
            std::cout << "Введите второе число: ";
            std::cin >> number2;

            if (compNumbers(number1, number2) == number2) {
                std::cout << "Первое число должно быть больше второго" << std::endl;
                break;
            }

            std::string result = subNumbers(number1, number2);
            std::cout << result << std::endl;
            break;
        }

        case 3:
        {
            std::cout << "Введите первое число: ";
            std::cin >> number1;
            std::cout << "Введите второе число: ";
            std::cin >> number2;

            std::string result = multNumbers(number1, number2);
            std::cout << result << std::endl;
            break;
        }

        case 4:
        {
            std::cout << "Введите первое число: ";
            std::cin >> number1;
            std::cout << "Введите второе число: ";
            std::cin >> number2;
            std::string result = divNumbers(number1, number2);
            std::cout << result << std::endl;
            break;
        }

        case 5:
        {
            std::cout << "Введите первое число: ";
            std::cin >> number1;
            std::cout << "Введите второе число: ";
            std::cin >> number2;

            if (number1 == number2) {
                std::cout << "Числа равны" << std::endl;
                break;
            }

            std::string result = compNumbers(number1, number2);
            std::cout << "Большее число: " << result << std::endl;
            break;
        }

        case 6:
        {
            return 0;
        }

        default:
        {
            std::cout << "Введите число от 1 до 6" << std::endl;
            break;
        }
        }
    }
}