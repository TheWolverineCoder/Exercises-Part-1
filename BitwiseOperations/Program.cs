using System;

namespace BitwiseOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will calculate the number of the given binary digit in your number");
            Console.WriteLine("Enter your number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter '0' or '1' : ");
            int binaryNumber = int.Parse(Console.ReadLine());
            int count = 0;
            while(number> 0)
            {
                int binaryDigit = number % 2;
                if(binaryDigit == binaryNumber)
                {
                    count++;
                }
                number /= 2;
            }
            Console.WriteLine(count);
        }
    }
}
