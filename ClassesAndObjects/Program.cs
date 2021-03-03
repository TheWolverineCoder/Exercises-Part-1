using System;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] input = Console.ReadLine().Split(" ");
            for(int i = 0; i < input.Length; i++)
            {
                int index = random.Next(i, input.Length);
                string help = input[i];
                input[i] = input[index];
                input[index] = help;
            }

            foreach(string word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
