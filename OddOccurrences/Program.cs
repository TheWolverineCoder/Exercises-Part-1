using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your line of words(separated by space): ");
            string[] words = Console.ReadLine().Split(" ");
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach(string word in words)
            {
                string wordInLowerCase = word.ToLower();
                if (occurrences.ContainsKey(wordInLowerCase))
                {
                    occurrences[wordInLowerCase]++;
                }
                else
                {
                    occurrences.Add(wordInLowerCase, 1);
                }
            }

            foreach(var occurrence in occurrences)
            {
                if(occurrence.Value % 2 != 0)
                {
                    Console.WriteLine(occurrence.Key + " ");
                }
            }
        }
    }
}
