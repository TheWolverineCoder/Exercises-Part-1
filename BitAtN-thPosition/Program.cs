using System;

namespace BitAtN_thPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the position of the bit you want: ");
            int position = int.Parse(Console.ReadLine());
            int changedNumber = number >> position;
            int bit = 0;
            if((changedNumber & 1) == 1)
            {
                bit = 1;
            }
            else
            {
                bit = 0;
            }
            Console.WriteLine("The bit at position {0} is {1}.",position,bit);
        }
    }
}
