using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = Console.ReadLine()[0];
            char secondChar = Console.ReadLine()[0];
            int sum = 0;
            string line = Console.ReadLine();
            foreach(char ch in line)
            {
                if(ch >= firstChar && ch <= secondChar)
                {
                    sum += (int)ch;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
