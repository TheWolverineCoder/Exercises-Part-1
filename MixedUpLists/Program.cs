using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Write a program that mixes up two lists by some rules. You will receive two lines of input, each one being a list of
           numbers. The rules for mixing are:
-               Start from the beginning of the first list and from the ending of the second.
-               Add element from the first and element from the second.
-               At the end there will always be a list, in which there are 2 elements remaining.
-               These elements will be the range of the elements you need to print.
-               Loop through the result list and take only the elements that fulfill the condition.
-               Print the elements ordered in ascending order and separated by a space.*/
            List<int> firstList = new List<int>();
            List<int> secondList = new List<int>();
            Console.WriteLine("Enter the first line of numbers: ");
            int[] firstNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine("Enter the second line of numbers: ");
            int[] secondNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            for(int i = 0; i < firstNumbers.Length; i++)
            {
                firstList.Add(firstNumbers[i]);
            }
            

            for(int j = 0;j < secondNumbers.Length; j++)
            {
                secondList.Add(secondNumbers[j]);
            } 
            int iterations = 0;
            int firstLimiter = 0;
            int secondLimiter = 0;
            if(firstList.Count > secondList.Count)
            {
                iterations = secondList.Count;
                firstLimiter = firstList[firstList.Count - 1];
                secondLimiter = firstList[firstList.Count - 2];
                firstList.RemoveAt(firstList.Count - 1);
                firstList.RemoveAt(firstList.Count - 1);
            }
            else
            { 
                iterations = firstList.Count;
                firstLimiter = secondList[secondList.Count - 1];
                secondLimiter = secondList[secondList.Count - 2];
                secondList.RemoveAt(secondList.Count - 1);
                secondList.RemoveAt(secondList.Count - 1);
            }
            List<int> allNumbersList = new List<int>();
            for(int index = 0; index < iterations; index++)
            {
                allNumbersList.Add(firstList[index]);
                allNumbersList.Add(secondList[secondList.Count-index-1]);
            }

            
            
            int min = secondLimiter;
            int max = firstLimiter;
            if (firstLimiter > secondLimiter)
            {
                max = firstLimiter;
                min = secondLimiter;
            }
            else
            {
                min = firstLimiter;
                max = secondLimiter;
            }

            List<int> finalList = new List<int>();
            for(int h = 0; h < allNumbersList.Count; h++)
            {
                if(allNumbersList[h] > min && allNumbersList[h] < max)
                {
                    finalList.Add(allNumbersList[h]);
                    
                }
            }

            allNumbersList.Sort();
            finalList.Sort();
            Console.WriteLine("The final numbers are: ");
            foreach (int number in finalList)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine(firstLimiter);
            Console.WriteLine(secondLimiter);
            


        }
    }
}
