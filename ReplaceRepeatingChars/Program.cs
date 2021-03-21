using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string here: ");
            char[] charArr = Console.ReadLine().ToCharArray();
            List<char> charResult = new List<char>();
            charResult.Add(charArr[0]);
            foreach(char ch in charArr)
            {
                if(ch != charResult.Last())
                {
                    charResult.Add(ch);
                }
            }

            Console.WriteLine(String.Join(String.Empty,charResult));
        }
    }
}
