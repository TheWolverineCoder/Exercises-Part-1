#include<iostream>
using namespace std;

int abss(int value) {
	_asm {
		mov eax, value
		cmp eax, 0
		jge skip
		neg eax
		skip :
		mov value, eax
	}
	return value;
}

int adder(int b, int c) {
	_asm {
		mov eax, b
		add eax, c
		mov b, eax
	}
	return b;
}

int power(int x) {
	_asm {
		mov eax, x
		iMul x
		mov x, eax
	}
	return x;
}

// Write in Assembly function :  int perimeter_of_rectangle (int a, int b), which calculates perimeter of rectangle.
int perimeter_of_rectangle(int a, int b) {
    // int result;
    _asm {
        mov eax, a; // you can put ; if you like
        add eax, a; is comment
            add eax, b;
        add eax, b;
        mov a, eax; mov result, eax
    }
    return a; // return result;
}

//Write in Assembly function : int area_of_rectangle(int a, int b) that calculates the area of rectangle.
int area_of_rectangle(int a, int b) {
    // int result;
    _asm {
        mov eax, a;
        mul b;
        mov a, eax;
    }
    // return result;
    return a;
}

//Write in Assembly function : int perimeter_of_square(int a), which calculates perimeter of square.
int perimeter_of_square(int a) {
    _asm {
        mov eax, a;
        // ; mul 4; // you can not multiply by constant
        // processors works only with registers and memory
        mov ecx, 4;
        mul ecx;
        mov a, eax;
    }
    return a;
}

//Write in Assembly function : int area_of_square(int a) that calculates the area of square.
int area_of_square(int a) {
    _asm {
        mov eax, a;
        mul a; // in this case a is in memory
        mov a, eax;
    }
    return a;
}

//Write in Assembly function : int perimeter_of_triangle(int a, int b, int c), which calculates perimeter of triangle.
int perimeter_of_triangle(int a, int b, int c) {
    _asm {
        mov eax, a;
        add eax, b;
        add eax, c;
        mov a, eax;
    }
    return a;
}

//Write in Assembly function : int perimeter_of_triangle2(int a), which calculates perimeter of equilateral  triangle
int perimeter_of_triangle2(int a) {
    _asm {
        mov eax, a;
        mov ecx, 3;
        mul ecx;
        mov a, eax;
    }
    return a;
}

//Write in Assembly function : int perimeter_of_triangle3(int a, int b), which calculates perimeter of rectangular triangle.
int perimeter_of_triangle3(int a, int b) {
    int result = 0;
    int temp = 0;
    _asm {
        mov eax, a;
        mul a;
        mov ecx, eax;
        mov eax, b;
        mul b;
        add eax, ecx;
        mov temp, eax;
        mov eax, a;
        add eax, b;
        mov result, eax;
    }
    result += sqrt(temp);
    return result;
}

//Write in Assembly function : int perimeter_of_triangle4(int a, int h), which calculates perimeter of triangle  from side length and height.
int perimeter_of_triangle4(int a, int h) {
    _asm {

    }
    return a;
}

int area_of_triangle(int a, int b, int c) {
    // P = sqrt(s*(s-a)*(s-b)*(s-c) ); s = (a + b + c)/2;
    int result = 0;
    _asm {
        mov eax, a;
        add eax, b;
        add eax, c;
        mov ecx, 2;
        mov edx, 0;
        div ecx;
        mov ecx, eax;
        sub ecx, a;
        mul ecx;
        add ecx, a; // get back to s
        sub ecx, b;
        mul ecx;
        add ecx, b; // get back to s
        sub ecx, c;
        mul ecx;
        mov result, eax;

    }
    return sqrt(result);
}

//Write in Assembly function : int area_of_cube(int a), which calculates area of cube.
int area_of_cube(int a) {
    _asm {

    }
    return a;
}


int main()
{
	std::cout << "Hello world!\n";
	cout << abss(-5) << endl;
	cout << adder(3, 6) << endl;
	cout << power(5) << endl;
}