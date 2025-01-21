#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>
#include <algorithm>
#include <limits>

struct Apartment {
    int number;
    std::string owner;
    double area;
    int rooms;
};

std::vector<Apartment> load_apartments(const std::string& filename) {
    std::vector<Apartment> apartments;
    std::ifstream file(filename);
    if (!file.is_open()) {
        std::cerr << "Ошибка: не удалось открыть файл " << filename << "\n";
        return apartments;
    }

    std::string line;
    while (std::getline(file, line)) {
        std::istringstream iss(line);
        Apartment apt;
        if (iss >> apt.number >> apt.owner >> apt.area >> apt.rooms) {
            apartments.push_back(apt);
        }
        else {
            std::cerr << "Ошибка: некорректная строка данных\n";
        }
    }
    return apartments;
}

// Функция для поиска квартир с общей площадью более заданной величины
std::vector<Apartment> find_apartments_by_area(const std::vector<Apartment>& apartments, double min_area) {
    std::vector<Apartment> result;
    std::copy_if(apartments.begin(), apartments.end(), std::back_inserter(result),
        [min_area](const Apartment& apt) { return apt.area > min_area; });
    return result;
}

// Функция для поиска квартиры с наименьшим числом комнат
Apartment find_min_rooms_apartment(const std::vector<Apartment>& apartments) {
    return *std::min_element(apartments.begin(), apartments.end(),
        [](const Apartment& a, const Apartment& b) {
            return a.rooms < b.rooms;
        });
}

// Функция для вычисления средней площади квартир с заданным числом комнат
double average_area_by_rooms(const std::vector<Apartment>& apartments, int room_count) {
    double total_area = 0;
    int count = 0;
    for (const auto& apt : apartments) {
        if (apt.rooms == room_count) {
            total_area += apt.area;
            count++;
        }
    }
    return (count == 0) ? 0 : total_area / count;
}

int main() {
    setlocale(LC_ALL, "ru");

    std::string filename = "C:\\Users\\Пользователь\\Desktop\\1.txt"; 
    double min_area;
    int room_count;

    std::cout << "Введите минимальную площадь: ";
    std::cin >> min_area;
    std::cout << "Введите количество комнат для расчета средней площади: ";
    std::cin >> room_count;

    std::vector<Apartment> apartments = load_apartments(filename);
    if (apartments.empty()) {
        std::cerr << "Нет данных для обработки.\n";
        return 1;
    }

    auto large_apartments = find_apartments_by_area(apartments, min_area);
    std::cout << "Квартиры с площадью больше " << min_area << ":\n";
    for (const auto& apt : large_apartments) {
        std::cout << "№: " << apt.number << ", Фамилия: " << apt.owner << ", Площадь: " << apt.area << ", Комнат: " << apt.rooms << "\n";
    }

    if (!large_apartments.empty()) {
        auto min_room_apt = find_min_rooms_apartment(large_apartments);
        std::cout << "Квартира с наименьшим числом комнат: №" << min_room_apt.number << ", Фамилия: " << min_room_apt.owner << ", Комнат: " << min_room_apt.rooms << "\n";
    }

    double avg_area = average_area_by_rooms(apartments, room_count);
    std::cout << "Средняя площадь для квартир с " << room_count << " комнатами: " << avg_area << " м^2\n";

    return 0;
}