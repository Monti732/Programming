#include <iostream>

int main() {
    int numberOfFloors, numberOfFlatsOnFloor, numberOfFlat;
    std::cout << "Enter number of floors ";
    std::cin >> numberOfFloors;
    std::cout << "Enter number of flats on floor ";
    std::cin >> numberOfFlatsOnFloor;
    std::cout << "Enter number of flat ";
    std::cin >> numberOfFlat;
    if ((numberOfFlat / numberOfFlatsOnFloor) % 2 == 0) {
        std::cout << "Elevator will stop on " << numberOfFlat / numberOfFlatsOnFloor - 1 << " floor";
    }
    else {
        std::cout << "Elevator will stop on " << numberOfFlat / numberOfFlatsOnFloor << " floor";
    }
    
}