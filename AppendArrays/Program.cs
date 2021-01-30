using System;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program appends your arrays which are split by | from the last to the first and removes all the whitespaces.");
            Console.WriteLine("Enter your array here: ");
            string unformattedLine = Console.ReadLine();
            string[] arrays = unformattedLine.Split("|");
            string[] formattedArr = new string[arrays.Length];
            string arrayFormatted = "";
            for(int i = arrays.Length-1; i >= 0; i--)
            {
                formattedArr[i] = arrays[arrays.Length-i-1] + " ";
            }
            formattedArr = formattedArr.Select(l => String.Join(" ", l.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))).ToArray();

            foreach(string str in formattedArr)
            {
                Console.Write(str + " ");
            }
        }
    }
}
