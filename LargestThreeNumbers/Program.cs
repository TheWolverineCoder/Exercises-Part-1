using System;
using System.Linq;

namespace LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your list of numbers: ");
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbersSorted = numbers.OrderByDescending(n => n).ToArray();
            for(int i = 0; i < 3; i++)
            {
                Console.Write(numbersSorted[i] + " ");
            }
        }
    }
}
