using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            //The digits of your numbers are summed and stored in a list of indexes
            //Then after you enter your text
            //The characters at the given indexes we got are printed as a message
            Console.WriteLine("Enter your list of numbers: ");
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine("Enter your text: ");
            string text = Console.ReadLine();
            
            List<char> characters = new List<char>();
            foreach(char character in text)
            {
                characters.Add(character);
            }
            List<int> indexes = new List<int>();
            foreach(int number in numbers)
            {
                int currentNumber = number;
                int sum = 0;
                while (currentNumber > 0)
                {
                    sum += (currentNumber % 10);
                    currentNumber /= 10;
                }
                indexes.Add(sum);
            }

            string hiddenMessage = "";
            foreach(int index in indexes)
            {
                int selectedChar = index;
                if(characters.Count <= index)
                {
                    selectedChar = index % characters.Count;
                }
                hiddenMessage = hiddenMessage + characters[selectedChar];
                characters.RemoveAt(selectedChar);
            }

            Console.WriteLine(hiddenMessage);
        }
    }
}
