using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your cards separated with \":\" :");
            string[] cards = Console.ReadLine().Split(":");
            List<string> deck = new List<string>();
            
            string command;
            while((command = Console.ReadLine()) != "Ready")
            {
                string[] commandSplit = command.Split(" ");
                string comName = commandSplit[0];
                string index1 = commandSplit[1];
                string index = "";
                switch (comName)
                {
                    case "Add":
                        if (cards.Contains(index1))
                        {
                            deck.Add(index1);
                        }
                        else
                        {
                            Console.WriteLine("Card not found!");
                        }
                        break;
                    case "Insert":
                        index = commandSplit[2];
                        if (cards.Contains(index1))
                        {
                            deck.Insert(int.Parse(index), index1);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;
                    case "Remove":
                        if (cards.Contains(index1))
                        {
                            deck.Remove(index1);
                        }
                        else
                        {
                            Console.WriteLine("Card not found!");
                        }
                        break;
                    case "Swap":
                        index = commandSplit[2];
                        string firstCard = index1;
                        string secondCard = index;
                        int firstIndex = deck.IndexOf(firstCard);
                        int secondIndex = deck.IndexOf(secondCard);
                        deck.Remove(firstCard);
                        deck.Remove(secondCard);
                        deck.Insert(firstIndex, secondCard);
                        deck.Insert(secondIndex, firstCard);
                        break;
                    case "Shuffle deck":
                        deck.Reverse();
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", deck));
        }
    }
}
