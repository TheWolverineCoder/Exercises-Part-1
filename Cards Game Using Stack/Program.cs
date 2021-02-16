using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game_Using_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstPlayerCards = new Queue<int>();
            Queue<int> secondPlayerCards = new Queue<int>();
            Console.WriteLine("The first player should enter his cards power with space between them: ");
            int[] firstCards = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine("The second player should enter his cards power with space between them: ");
            int[] secondCards = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            foreach(int card in firstCards)
            {
                firstPlayerCards.Enqueue(card);
            }

            foreach (int card in secondCards)
            {
                secondPlayerCards.Enqueue(card);
            }

            while(firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                int firstElement = firstPlayerCards.ElementAt(0);
                int secondElement = secondPlayerCards.ElementAt(0);
                if (firstPlayerCards.ElementAt(0) > secondPlayerCards.ElementAt(0))
                {
                    firstPlayerCards.Dequeue();
                    secondPlayerCards.Dequeue();
                    firstPlayerCards.Enqueue(firstElement);
                    firstPlayerCards.Enqueue(secondElement);
                }
                else if(secondPlayerCards.ElementAt(0) > firstPlayerCards.ElementAt(0))
                {
                    firstPlayerCards.Dequeue();
                    secondPlayerCards.Dequeue();
                    secondPlayerCards.Enqueue(secondElement);
                    secondPlayerCards.Enqueue(firstElement);
                }
                else
                {
                    firstPlayerCards.Dequeue();
                    secondPlayerCards.Dequeue();
                }
            }

            if(firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine("The first player won and has a sum of: " + firstPlayerCards.Sum());
            }
            else if(secondPlayerCards.Count > firstPlayerCards.Count)
            {
                Console.WriteLine("The second player won and has a sum of: " + secondPlayerCards.Sum());
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
