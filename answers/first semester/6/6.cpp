#include <iostream>
#include <string>
#include <algorithm>

int main() {
    std::string str = "dfgjr sdjfweshg aofjoeif lkesfeo sdlfheof aowh fseohs";
    int count = std::count(str.begin(), str.end(), ' ');
    std::cout << count + 1 << std::endl;
}