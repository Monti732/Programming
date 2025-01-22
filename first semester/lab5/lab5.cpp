#include <iostream>
#include <ctime>
#include <cmath>

using namespace std;

void fillArrays(int array[], int size) {
	srand(time(0));
	for (int i = 0; i < size; ++i) {
		array[i] = rand() / 100;
	}
}

int sumOfSquares(int array[], int size) {
	int sum = 0;
	for (int i = 0; i < size; ++i) {
		sum += pow(array[i], 2);
	}
	return sum;
}

int main() {
	int const sizeP = 5;
	int const sizeG = 10;
	int P[sizeP];
	int G[sizeG];
	fillArrays(P, sizeP);
	fillArrays(G, sizeG);
	cout << sumOfSquares(P, sizeP) << endl;
	cout << sumOfSquares(G, sizeG) << endl;
}