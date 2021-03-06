using System;
using System.Linq;

namespace Tom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();
            int leftElements = 0;
            int rightElements = 0;
            for(int i = 0; i < entryPoint; i++)
            {
                if(itemsType == "cheap")
                {
                    if(priceRatings[i] < priceRatings[entryPoint])
                    {
                        leftElements += priceRatings[i];
                    }
                    else
                    {
                        leftElements += 0;
                    }
                }
                else
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftElements += priceRatings[i];
                    }
                    else
                    {
                        leftElements += 0;
                    }
                }
            }

            for(int i = priceRatings.Length - 1; i > entryPoint; i--)
            {
                if (itemsType == "cheap")
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        rightElements += priceRatings[i];
                    }
                    else
                    {
                        rightElements += 0;
                    }
                }
                else
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightElements += priceRatings[i];
                    }
                    else
                    {
                        rightElements += 0;
                    }
                }
            }

            if(leftElements >= rightElements)
            {
                Console.WriteLine("Left - " + leftElements);
            }
            else
            {
                Console.WriteLine("Right - " + rightElements);
            }
        }
    }
}
