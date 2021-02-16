using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the line of indexes: ");
            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int indexesLength = indexes.Length;
            //List<int> firstRacer = new List<int>();
            //List<int> secondRacer = new List<int>();
            double firstRacerTime = 0;
            double secondRacerTime = 0;
            for (int i = 0; i < indexesLength / 2; i++)
            {
                if(indexes[i] == 0)
                {
                    firstRacerTime *= 0.8;
                }
                else
                {
                    firstRacerTime += indexes[i];
                }
            }

            for (int s = indexesLength-1; s >= indexesLength / 2 + 1; s--)
            {
                if (indexes[s] == 0)
                {
                    secondRacerTime *= 0.8;
                }
                else
                {
                    secondRacerTime += indexes[s];
                }
            }

            if(firstRacerTime < secondRacerTime)
            {
                Console.WriteLine("The winner is left with total time of: {0:F2}", firstRacerTime);
            }
            else
            {
                Console.WriteLine("The winner is right with total time of: {0:F2}", secondRacerTime);
            }
        }
    }
}
