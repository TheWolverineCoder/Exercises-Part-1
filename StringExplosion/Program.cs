using System;
using System.Collections.Generic;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string here: ");
            string[] input = Console.ReadLine().Split(">");
            List<string> endList = new List<string>();
            foreach(string str in input)
            {
                endList.Add(str);
            }
            int powerStack = 0;
            for(int i = 1; i < input.Length; i++)
            {

                int power = int.Parse((input[i][0]).ToString()) + powerStack;
                if (power > input[1].Length)
                {
                    powerStack = power - input[i].Length;
                    endList.RemoveAt(i);
                    endList.Insert(i, "");
                }
                else
                {
                    int len = input[i].Length-power;
                    string newString =input[i].Substring(power, len);
                    endList.RemoveAt(i);
                    endList.Insert(i, newString);
                }
            }

            for(int k = 0; k < endList.Count - 1; k++)
            {
                Console.Write(endList[k] + ">");
            }
            Console.Write(endList[endList.Count - 1]);
        }
    }
}
