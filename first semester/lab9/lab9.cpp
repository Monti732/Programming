#include <iostream>
#include <vector>
#include <iomanip>

bool isLeapYear(int year) {
	return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}

int getDaysInMonth(int year, int month) {
	std::vector<int> daysInMonths = { 31,28,31,30,31,30,31,31,30,31,30,31 };
	if (month == 1 && isLeapYear(year)) {
		return 29;
	}
	return daysInMonths[month];
}

int getFirstDayOfYear(int year) {
	int day = 0;
	int refYear = 1900;

	int totalDays = 0;
	if (year >= refYear) {
		for (int i = refYear; i < year; ++i) {
			totalDays += isLeapYear(i) ? 366 : 365;
		}
	}
	else {
		for (int i = year; i < refYear; ++i) {
			totalDays -= isLeapYear(i) ? 366 : 365;
		}
	}
	return (totalDays + day) % 7;
}

void printMonth(int year, int month, int& startDay) {
	std::vector<std::string> monthNames = {
		"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
		"Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
	};

	std::cout << "\n " << monthNames[month] << " " << year << "\n";
	std::cout << " Пн Вт Ср Чт Пт Сб Вс\n";

	int daysInMonth = getDaysInMonth(year, month);

	for (int i = 0; i < startDay; ++i) {
		std::cout << "   ";
	}

	for (int day = 1; day <= daysInMonth; ++day) {
		std::cout << std::setw(3) << day;
		startDay = (startDay + 1) % 7;
		
		if (startDay == 0) {
			std::cout << "\n";
		}
	}
	std::cout << "\n";
}

int main() {
	setlocale(LC_ALL, "ru");
	int year;

	std::cout << "Введите год: ";
	std::cin >> year;

	if (std::cin.fail() || year <= 0) {
		std::cout << "неверный ввод" << std::endl;
		return 1;
	}

	int startDay = getFirstDayOfYear(year);

	for (int month = 0; month < 12; ++month) {
		printMonth(year, month, startDay);
	}
	return 0;
}