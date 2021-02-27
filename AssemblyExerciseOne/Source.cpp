#include <iostream>
using namespace std;

int testasm(int a,int b) {
	int result = 0;
	__asm {
		mov eax, a
		add eax, b
		mov result, eax
	}
	return result;
}

//triangle perimeter
int triangleP(int a, int b, int c) {
	int result = 0;
	__asm {
		mov eax, a
		add eax, b
		add eax, c
		mov result, eax
	}
	return result;
}

int triangleTwoEqSides(int a, int b) {
	__asm {
		mov eax, a
		iMul eax
		add eax, b
	}
}

int squareP(int a) {
	__asm {
		mov eax, a
		mov ebx, 4
		mul ebx
	}
}

int fourP(int a,int b){
	__asm {
	mov eax, a
	add eax,b
	mov ebx, 2
	mul ebx
    }
}

int formula(int a, int b,int c) {
	__asm {
		mov eax, a
		inc eax
		mul b
		mov ebx, a
		dec ebx
		sub ebx, b
		mov edx, 0 //tuk se zapisva ostatuka
		div ebx
		mul c
	}
}

int main() {
	cout << testasm(2, 2) << endl;

	cout << triangleP(2, 3, 4) << endl;
	cout << triangleTwoEqSides(2, 3) << endl;
	cout << squareP(6) << endl;
	cout << fourP(5, 2) << endl;
	cout << formula(4, 2, 3) << endl;
	system("pause");
	return 0;
}