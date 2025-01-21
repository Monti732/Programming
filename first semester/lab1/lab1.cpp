#include <iomanip>
#include <cmath>
#include <iostream>
using namespace std;

int main() {
	double a = 3.244, b = 1.72;
	double eccen = sqrt(1 - (pow(b, 2) / pow(a, 2) * 1.0));
	double pi = 3.14159;
	
	double s1 = 2 * pi * (pow(b, 2) + (a * b * asin(eccen)) / eccen);
	double v1 = 4 / (3 * 1.0) * pi * a * pow(b, 2);
	double s2 = 2 * pi * (pow(a, 2) + (pow(b, 2) * log((1 + eccen) / (1 - eccen))) / (2 * eccen * 1.0));
	double v2 = 4 / (3 * 1.0) * pi * pow(a, 2) * b;
	
	cout << setprecision(4) << "s1 = " << s1 << endl; //  нужно ли было переводить ответ в квадратные и кубические метры?
	cout << "v1 = " << v1 << endl;
	cout << setprecision(4) << "s2 = " << s2 << endl;
	cout << "v2 = " << v2 << endl;
}