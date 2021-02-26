using System;
using System.Collections.Generic;

namespace WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of pairs you want to enter: ");
            int times = int.Parse(Console.ReadLine());
            var words = new Dictionary<string, List<string>>();
            for(int i = 0; i < times; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (words.ContainsKey(word) == false)
                {
                    words.Add(word, new List<string>());
                }
                words[word].Add(synonym);
                

            }

            foreach(var word in words)
            {
                Console.Write(word.Key + " -> ");
                int counts = 0;
                foreach(string synonym in word.Value)
                {
                    
                    if(counts == word.Value.Count-1)
                    {
                        Console.Write(synonym);
                    }
                    else
                    {
                        Console.Write(synonym + ",");
                        counts++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
