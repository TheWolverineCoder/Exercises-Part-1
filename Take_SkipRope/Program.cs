using System;
using System.Collections.Generic;

namespace Take_SkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string here: ");
            string initialMessage = Console.ReadLine();
            List<int> integers = new List<int>();
            List<char> chars = new List<char>();
            
            for(int i = 0; i < initialMessage.Length; i++)
            {
                if(initialMessage[i] >= 48 && initialMessage[i] <= 57)
                {
                    integers.Add((initialMessage[i] - '0'));
                }
                else
                {
                    chars.Add(initialMessage[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for(int k = 0; k < integers.Count; k++)
            {
                if(k%2 == 0)
                {
                    takeList.Add(integers[k]);
                }
                else
                {
                    skipList.Add(integers[k]);
                }
            }
            string result = "";
            int iterations = takeList.Count;
            int currentStart = 0;
            for (int f = 0; f < iterations; f++)
            {


                int increase = takeList[f] + currentStart;
                if(increase > chars.Count)
                {
                    increase = chars.Count;
                }
                for (int h = currentStart; h < increase; h++)
                {
                    result += chars[h];
                }
                
                currentStart += takeList[f];
                currentStart += skipList[f];

            }

            Console.WriteLine(result);
            
        }
    }
}
