#include<iostream>
using namespace std;
static int arr[10];
static int F[10];
int function(int n) {
	_asm {
		mov eax, n
		mov ecx, 0
		for:
		mov[arr + 4 * ecx], eax
			add eax, n
			inc ecx
			cmp ecx, 10
			jl for
	}
}
int pow() {
	_asm {
		mov ecx, 0
		for:
		mov eax, [arr + 4 * ecx]
			mul eax
			mov[arr + 4 * ecx], eax
			inc ecx
			cmp ecx, 10
			jl for
	}
}
int PrintArr(int* array, int lenght) {
	for (int i = 0; i < lenght; i++) {
		cout << array[i] << ", ";
	}
	cout << endl;
	return 1;
}

int Fibonaci(int n) {
	_asm {
		mov ecx, 0
		for:
		mov eax, [F + 4 * ecx];
		add eax, [F + 4 + 4 * ecx];
		mov[F + 8 + 4 * ecx], eax
			inc ecx
			cmp ecx, n
			jle for

	}
}

int FibonaciSum(int n) {
	int i = n - 1;
	int sum = 0;
	_asm {
		mov ecx, 0
		findf:
		mov eax, [F + 4 * ecx];
		add eax, [F + 4 + 4 * ecx];
		mov[F + 8 + 4 * ecx], eax
			inc ecx
			cmp ecx, i
			jle findf

			mov eax, [F]; F[0]
			mov ecx, 1
			sumf:
		add eax, [F + 4 * ecx]
			inc ecx
			cmp ecx, i
			jle sumf

			mov sum, eax
	}
	cout << sum << endl;
}

int fibonacciFormula(int n, int k, int c) {
	_asm {
		mov ecx, 0
		for:
		mov eax, [F + 4 * ecx];
		add eax, [F + 4 + 4 * ecx];
		mov[F + 8 + 4 * ecx], eax
			inc ecx
			cmp ecx, n+k
			jle for


	}
}

int factnk(int n, int k) {
	_asm {
		mov eax, 1
		mov ecx, 1

		for:
		imul eax, ecx
			inc ecx
			cmp n, ecx
			jge for;

		mov ebx, 1
			mov ecx, 1
			fork:
		imul ebx, ecx
			inc ecx
			cmp k, ecx
			jge fork

			mov edx, 0
			idiv ebx

	}
}

int factnk2(int n, int k) {
	_asm {
		mov ecx, n
		mov eax, 1
		for:
		mul ecx
			dec ecx
			cmp ecx, k
			jg for;

	}
}
int main() {
	//function(2);
	/*arr[0] = 1;
	arr[1]= 2;
	arr[2] = 3;
	arr[3] = 4;
	arr[4] = 4;
	arr[5] = 4;
	arr[6] = 4;
	arr[7] = 4;
	arr[8] = 4;
	arr[9] = 4;
	arr[10] = 4;

	pow();
	*/

	F[0] = 1;
	F[1] = 1;
	//Fibonaci(5);
	//PrintArr(F, 5);
	cout << FibonaciSum(5) << endl;
	cout << factnk(3, 2) << endl;
	//system("pause");
	//return 0;
}