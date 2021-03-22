using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtractUserInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of lines: ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                List<string> words = Console.ReadLine().Split(" ").ToList();
                string name = "";
                int age = 0;
                foreach (string word in words)
                {
                    if (word[0] == '@' && (word.Last() == '|'))
                    {
                        name = word.Substring(1, word.Length - 2);
                    }

                    if (word[0] == '#' && (word.Last() == '*'))
                    {
                        age = int.Parse(word.Substring(1, word.Length - 2));
                    }

                }
                Console.WriteLine($"{name} is {age} years old.");
            }

        }
    }
}
