using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string here: ");
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder("");
            foreach(char ch in input)
            {
                int code = (int)ch + 3;
                char newOne = (char)code;
                sb.Append(newOne);
            }

            Console.WriteLine(sb);
        }
    }
}
