using System;
using System.Globalization;
using System.Linq;

namespace OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Enter an array of numbers separated with space: ");
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result = result ^ numbers[i];
            }

            Console.WriteLine("The number which occurs odd number of times is: ");
            Console.WriteLine(result);
            Console.WriteLine("Enter your number here: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the position of the first out of 3 bits you want to invert: ");
            int firstPos = int.Parse(Console.ReadLine());
            int helpNum = 7 << firstPos;
            int invertedNumber = number^helpNum;
            Console.WriteLine(invertedNumber);*/

            CultureInfo provider = CultureInfo.InvariantCulture;
            Console.WriteLine("Enter a date in the format dd-mm-yyyy: ");
            string input = Console.ReadLine();
            DateTime dateTime = DateTime.ParseExact(input,"dd-MM-yyyy",provider);
            string dayOfWeek = dateTime.DayOfWeek.ToString();
            Console.WriteLine("The day of week on this day was: " + dayOfWeek);
        }
    }
}
