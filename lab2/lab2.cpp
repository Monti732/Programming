#include <iostream>
#include <cmath>

using namespace std;

int main() {
	float a, b, v{}, t, p;
	
	
	cin >> a; // 0.0288
	cin >> b; // 0.032
	cin >> t; // 15.7
	while (v <= 0.2) {
		v += 0.05;
		p = 0.0635 * t / (v - b) * 1.0 - a / pow(v, 2);
		cout << v << "   " << p << endl;
	}
	while (v < 1) {
		v += 0.2;
		p = 0.0635 * t / (v - b) * 1.0 - a / pow(v, 2);
		cout << v << "   " << p << endl;
	}
}