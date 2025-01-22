#include <iostream>
#include <ctime>

using namespace std;

int main() {
	srand(time(0));
	int d[5][5];
	for (int i = 0; i < 4; ++i) {
		for (int j = 0; j < 4; ++j) {
			d[i][j] = rand() / 100;
		}
	}
	int max = d[0][0];
	int min = d[0][0];
	for (int i = 0; i < 4; ++i) {
		for (int j = 0; j < 4; ++j) {
			if (max < d[i][j]) {
				max = d[i][j];
			}
			if (min > d[i][j]) {
				min = d[i][j];
			}
		}
	}
	for (int i = 0; i < 4; ++i) {
		cout << endl;
		for (int j = 0; j < 4; ++j) {
			cout << d[i][j] << ' ';
		}
	}
	cout << endl;
	d[0][0] = max;
	d[4][4] = min;
	for (int i = 0; i < 4; ++i) {
		cout << endl;
		for (int j = 0; j < 4; ++j) {
			cout << d[i][j] << ' ';
		}
	}
}