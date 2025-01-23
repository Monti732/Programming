#include <iostream>

int main() {
    int array[5]{1,7,3,8,30};
    int max = array[0];
    for (int i = 0; i < 5; ++i) {
        if (max < array[i]) {
            max = array[i];
        }
    }
    std::cout << max;
}