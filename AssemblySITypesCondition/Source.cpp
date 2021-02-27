#include <iostream>
using namespace std;

int do_tests(int a) {
    char p1;
    short p2;
    int p4;
    _asm {
        mov al, byte ptr p2; get the lowest byte from p2and assign it to al
        mov ax, word ptr p4; get the lowest 2 bytes from p4 and assign to ax
        mov p1, bl
        mov p2, bx
    }
    return a;
}


int do_negative_tests(int a) {
    char p1;
    short p2;
    int p4;
    _asm {
        ; movsx p4, al; improper operand type, smaller to bigger negative
        ; // https://c9x.me/x86/html/file_module_x86_id_206.html
        movsx eax, p1; smaller to bigger negative
            mov byte ptr p2, al
            mov byte ptr p4, ah
            mov ax, word ptr p4
            mov eax, dword ptr p4
    }
    return a;
}

//Write function int avg_int(int a, int b, int c) to calculate the average value of these three int numbers.Try that it works correctly for both positive and negative numbers(including their mix).
int avg_int(int a, int b, int c) {
    _asm {
        movsx eax, a; // movsx to work with negative values
        add eax, b;
        add eax, c;
        mov ecx, 3;
        mov edx, 0; // the rest is stored here in edx
        div ecx;
    }
    // eax is the returned value. This compiler does it
    // return a;
}

//Write the function short avg_short(short a, short b, short c) to calculate the average value of these three short numbers.Try that it works correctly for both positive and negative numbers(including their mix).
short avg_short(short a, short b, short c) {
    _asm {
        // mov ax, a; // notice 2 bytes register 2 bytes value
        movsx ax, a; // movsx because we need signed value
        add ax, b;
        add ax, c;
        mov cx, 3; // the divider
        mov dx, 0;
        div cx;
    }
    // return a; // the compiler returns eax
}


//Write function int sgn(int i), which returns values - 1, 0, 1, depending on whether the value is negative, zero or positive.
int sgn(int i) {
    _asm {
        mov eax, 1;
        cmp eax, i;
        jle return; //  if eax <= i go to the label return
        mov eax, 0;
        cmp eax, i;
        je return;
        mov eax, -1;
        return:
    }
    // return i; the compiler return eax
}

//Write function int min3 function(unsigned char a, short b, int c) that returns the smallest value from these three passed parameters.
int min3(unsigned char a, short b, int c) {
    // int result = 0;
    _asm {
        mov al, a;
        movsx bx, b;
        movsx ecx, c;
        cbw; // extends al to ax al -> ax
        cmp ax, bx; // if ax <= bx
        jle ccc; // if ax <= bx
        mov ax, bx; // we alwais keep the smallest in eax
    ccc:
        cwde; // extends ax -> eax
        cmp eax, ecx;
        jle return;
        mov eax, ecx;
        return:
    }
    // return result; // the compiler returns eax
}

//Write function int positive(int a, int b, int c), which returns 1 if all arguments are positive, otherwise 0.
int positive(int a, int b, int c) {
    _asm {
        mov eax, 0;
        cmp eax, a;
        jg return;// If 0 is greater than a another words a is negative
        cmp eax, b;
        jg return;
        cmp eax, c;
        jg return;
        mov eax, 1;
        return:
    }
    // return a;
}

//Write function int power(int n, unsigned int m) returning the n to the power of m
int power(int n, unsigned int m) {
    _asm {
        mov eax, n;
        mov ecx, m; // ecx will be a counter of a cycle
        for:
        cmp ecx, 1;
        jle return;
        mul n;
        dec ecx;
        jmp for;
        return:
    }
    // return n;
}


int main()
{
	cout << "Hello world!";
	char answer = 0;
    int myInt = 3; //the variable
    int* ptr2Int; //pointer to int
    ptr2Int = &myInt;
    int& ref2int = myInt; // reference requires initialization
    cout << ptr2Int << endl; //The address
    cout << *ptr2Int << endl; // 3 Dereference
    cout << ref2int << endl; //3
    cout << &ref2int << endl; //the reference point to the same memory cell as myInt
    cout << &myInt << endl; // the address of the valuable
    myInt = 12;
    cout << myInt << endl;
    cout << ref2int << endl;
    int mySecondInt = 5;
    ref2int = mySecondInt; // now, we change the value of ref2int AND !!! myInt !!! From now on, myInt = mySecondInd = 5
    cout << mySecondInt << endl; // 5
    cout << ref2int << endl; // 5
    cout << &mySecondInt << endl; // 008FF82C
    cout << &ref2int << endl; // but 006FFB24 !!! it still points to the first variable 'myInt'
    mySecondInt = 7;
    cout << mySecondInt << endl; // 7
    cout << ref2int << endl; // 5
    cout << *(&ref2int) << endl; // 5

    // hard conversions
    // &myInt means, give me the address of myInt, 
    // (char*) means explicit type conversion to pointer to char, 
    // * - means dereference - give me the value 
    cout << *(char*)&myInt << endl; // Strange symbol, Hard convert to 1 byte, Assembly byte ptr
    cout << *(short*)&myInt << endl; // 5, Hard convert to 2 bytes, Assembly word ptr
    cout << *(int*)&myInt << endl; // 5, Hard convert to 4 bytes, Assembly dword ptr
    cout << avg_int(2, -1, 5) << endl; //2
    cout << avg_short(-1, 2, 5) << endl; // 2
    cout << sgn(-10) << ", " << sgn(0) << ", " << sgn(10) << endl;
    cout << min3(1, -4, 5) << endl; // -4
    cout << positive(-1, 2, 5) << ", " << positive(1, 2, 3) << ", " << positive(0, 1, 0) << endl; // -1, 1, 1
    cout << power(2, 4) << endl; // 16
	cin >> answer;
}