using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the words here: ");
            string[] words = Console.ReadLine().Split().Where(w => w.Length % 2 == 0).ToArray();
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
