using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number here: ");
            string bigNum = Console.ReadLine();
            Console.WriteLine("Enter the multiplier here: ");
            int multiplier = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();
            int remainder = 0;
            for(int i = bigNum.Length - 1; i > 0; i--)
            {
                int currentNum = int.Parse(bigNum[i].ToString());
                string addDigit;
                int result = currentNum * multiplier + remainder;
                string resultToString = result.ToString();
                if(resultToString.Length > 1)
                {
                    remainder = int.Parse(resultToString[0].ToString());
                    addDigit = resultToString[1].ToString();
                }
                else
                {
                    remainder = 0;
                    addDigit = resultToString[0].ToString();
                }
                list.Insert(0, addDigit);
            }
            int lastAdd = int.Parse(bigNum[0].ToString())*multiplier+remainder;
            list.Insert(0, lastAdd.ToString());
            foreach (string digit in list)
            {
                sb.Append(digit);
            }
            string res = new string(sb.ToString().ToArray());
            Console.WriteLine(res);

        }
    }
}
