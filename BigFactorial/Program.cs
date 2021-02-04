using System;
using System.Numerics;

namespace BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number here(1-1000): ");
            int number = int.Parse(Console.ReadLine());

            BigInteger bigInteger = 1;
            for(int i = number; i > 0; i--)
            {
                bigInteger *= i;
            }

            Console.WriteLine("The factorial is: ");
            Console.WriteLine(bigInteger);
        }
    }
}
