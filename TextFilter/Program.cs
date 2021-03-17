using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter banned word separated with \", \": ");
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (string word in banList)
            {
                int length = word.Length;
                string newOne = "";
                for(int i = 0; i < length; i++)
                {
                    newOne += "*";
                }
                text = text.Replace(word, newOne);
            }
            Console.WriteLine(text);
        }
    }
}
