using System;
using System.Collections.Generic;
using System.Linq;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your input here: ");
            List<string> inputList = Console.ReadLine()
                                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();
            decimal sum = 0;

            foreach(var str in inputList)
            {
                if(str.Length >= 3 && char.IsLetter(str[0]) && char.IsLetter(str.Last()))
                {
                    long number = int.Parse(str.Substring(1, str.Length - 2));
                    decimal currentResult = 0;
                    if (char.IsUpper(str[0]))
                    {
                        int position = str[0] - 'A' + 1;
                        currentResult += number / (decimal)position;
                    }
                    else
                    {
                        int position = str[0] - 'a' + 1;
                        currentResult += number * (decimal)position;
                    }

                    if (char.IsUpper(str.Last()))
                    {
                        int position = str.Last() - 'A' + 1;
                        currentResult -= position;
                    }
                    else
                    {
                        int position = str.Last() - 'a' + 1;
                        currentResult += position;
                    }

                    sum += currentResult;
                }
            }

            Console.WriteLine($"{sum:F2}");

        }
    }
}
