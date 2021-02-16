using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of numbers: ");
            List<int> numbers = ReadList();
            Console.WriteLine("Enter the number you want to bomb: ");
            int bombNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the power of the bomb: ");
            int bombPower = int.Parse(Console.ReadLine());
            while(numbers.Contains(bombNumber) == true)
            {
                int index = 0;
                for(int i = 0; i < numbers.Count; i++)
                {
                    if(numbers[i] == bombNumber)
                    {
                        index = numbers[i];
                        break;
                    }
                }
                if(index-bombPower >= 0)
                {
                    for (int k = index - bombPower; k <= index + bombPower; k++)
                    {
                        RemoveAt(numbers, index-bombPower);
                    }
                }
                
            }

            int sum = 0;
            foreach(int j in numbers)
            {
                sum += j;
            }
            Console.WriteLine("The sum of the remaining elements is: " + sum);
        }

        static List<int> ReadList()
        {
            List<int> list = new List<int>();
            var line = Console.ReadLine();
            list = line.Split().Select(int.Parse).ToList();
            return list;
        }

        static void RemoveAt(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }
    }
}
