#include<iostream>
using namespace std;
static int A[5] = {1,2,3,4,5};
static int F[5] = {1,2,3,4,5};



int arrone[10];
int arrtwo[10];


int test(int len) { //This function mirrors an array
	_asm {
		mov ecx, 0
		mov edx, len
		aa :
		mov eax, [arrone + 4 * ecx]
			mov[arrtwo + 4 * edx], eax
			inc ecx
			dec edx
			cmp ecx, len
			jle aa
	}
}


int testt(int a) { //Checks if an array is mirrored
	_asm {
		mov ecx, 0
		mov edx, a
		aa :
		mov eax, [arrone + 4 * ecx]
			mov ebx, [arrtwo + 4 * edx]
			cmp eax, ebx
			jne neravno
			inc ecx
			dec edx
			cmp ecx, a
			jl aa
			mov eax, 1
			jmp return
			neravno:
		mov eax, -1
			return :
	}
}

int PrintArr(int* array, int lenght) {
	for (int i = 0; i < lenght; i++) {
		cout << array[i] << ", ";
	}
	cout << endl;
	return 1;
}

int main() {
	arrone[0] = 0;
	arrone[1] = 1;
	arrone[2] = 2;
	arrone[3] = 3;
	arrone[4] = 4;
	arrone[5] = 5;
	arrtwo[0] = 5;
	arrtwo[1] = 4;
	arrtwo[2] = 3;
	arrtwo[3] = 2;
	arrtwo[4] = 1;
	arrtwo[5] = 0;

	cout << test(5) << endl;
	PrintArr(arrtwo, 5);
}