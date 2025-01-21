#include <iostream>
#include <fstream>
#include <string>
#include <cctype>
#include <limits>
#include <algorithm>

int main() {
	setlocale(LC_ALL, "ru");

	std::ifstream inFile("C:\\Users\\Пользователь\\Desktop\\text.txt");
	if (!inFile.is_open()) {
		std::cerr << "Ошибка открытия файла";
		return 1;
	}

	bool isSameRegister = false;
	int choice;

	while (true) {
		std::cout << "1. Приводить к одному регистру?" << std::endl;
		std::cout << "2. Посмотреть кол-во букв" << std::endl;
		std::cout << "3. Посомтреть кол-во двубуквенных сочетаний" << std::endl;
		std::cout << "4. Остановить выполнение программы" << std::endl;
		std::cout << "\nВаш выбор: ";
		std::cin >> choice;

		if (std::cin.fail()) {
			std::cin.clear();
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "Неверный ввод" << std::endl;
			std::cout << "-------------------------------------------------------" << std::endl;
			continue;
		}

		switch (choice) {
		case 1: {
			if (isSameRegister) {
				isSameRegister = false;
				std::cout << "Не приводим" << std::endl;
				std::cout << "-------------------------------------------------------" << std::endl;
			}
			else {
				isSameRegister = true;
				std::cout << "Приводим" << std::endl;
				std::cout << "-------------------------------------------------------" << std::endl;
			}
			break;
		}

		case 2: {
			char ch;
			char targetChar;
			int targetCharCounter = 0;

			std::cout << "Введите букву ";
			std::cin >> targetChar;

			while (inFile.get(ch)) {
				if (isSameRegister == true) {
					targetChar = std::tolower(targetChar);
					ch = std::tolower(ch);
				}
				if (targetChar == ch) {
					++targetCharCounter;
				}
			}
			std::cout << "Количество повторений буквы " << targetChar << " " << targetCharCounter << std::endl;
			std::cout << "-------------------------------------------------------" << std::endl;

			inFile.clear();
			inFile.seekg(0, std::ios::beg);

			break;
		}

		case 3: {
			std::string str;
			std::string targetLetters;
			int targetLettersCounter = 0;

			std::cout << "Введите сочетание букв ";
			std::cin >> targetLetters;
			if (isSameRegister == true) {
				std::transform(targetLetters.begin(), targetLetters.end(), targetLetters.begin(), tolower);
			}

			while (std::getline(inFile, str)) {
				size_t pos = 0;
				if (isSameRegister == true) {
					std::transform(str.begin(), str.end(), str.begin(), tolower);
				}
				while ((pos = str.find(targetLetters, pos)) != (std::string::npos)) {
					++targetLettersCounter;
					pos += targetLetters.length();
				}
			}

			std::cout << "Количество повторений букв " << targetLetters << " " << targetLettersCounter << std::endl;
			std::cout << "-------------------------------------------------------" << std::endl;

			inFile.clear();
			inFile.seekg(0, std::ios::beg);

			break;
		}

		case 4:
			return 0;

		default:
			std::cout << "Неверный ввод" << std::endl;
			std::cout << "-------------------------------------------------------" << std::endl;
			break;
		}
	}
}