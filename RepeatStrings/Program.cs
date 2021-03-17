using System;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArr = { "Dog", "Cat", "Mouse" };
            string line = "";
            foreach(string word in stringArr)
            {
                for(int i = 0; i < word.Length; i++)
                {
                    line += word;
                }
            }
            Console.WriteLine(line);
        }
    }
}
