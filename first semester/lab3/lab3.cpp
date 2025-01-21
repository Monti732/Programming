#include <iostream>
#include <cmath>

using namespace std;

int main() {
	setlocale(LC_ALL, "rus");
	float tInit, tFinal, time, tMID, T{ 10.0 }; // time - время остывания, Т - время(момент времени), tMID - средняя температура

	cout << "Введите исходную темпиратуру: ";
	cin >> tInit;
	cout << "Введите температуру затвердивания: ";
	cin >> tFinal;

	time = (-1 / 0.021) * log(tFinal / (tInit * 1.0));

	while (T <= 30) {
		if (T < time) {
			tMID = tInit * pow(exp(1.0), -0.021 * T);
			cout << tMID << endl;
			T += 10;
		}
		else {
			tMID = tFinal * pow(exp(1.0), -0.015 * (T - time));
			cout << tMID << endl;
			T += 10;
		}
	}

	T = 50;
	while (T <= 100) {
		if (T < time) {
			tMID = tInit * pow(exp(1.0), -0.021 * T);
			cout << tMID << endl;
			T += 50;
		}
		else {
			tMID = tFinal * pow(exp(1.0), -0.015 * (T - time));
			cout << tMID << endl;
			T += 50;
		}
	}
}