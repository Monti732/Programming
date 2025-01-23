#include <iostream>

int main() {
    int array[5]{1,7,3,8,30};
    int sum, product;
    for (int i = 0; i < 5; ++i) {
        sum += array[i];
        product *= array[i];
    }
    std::cout << sum << '\n' << product;
}