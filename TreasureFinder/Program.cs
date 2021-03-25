using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter your decryption key: ");
            int[] key = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string mes;
            while ((mes = Console.ReadLine()) != "find")
            {
                StringBuilder message = new StringBuilder();

                for (int i = 0; i < mes.Length; i++)
                {
                    message.Append(Convert.ToChar(mes[i] - key[i % key.Length]));
                }

                string messageAsStr = message.ToString();

                int startIndexOfTreasure = messageAsStr.IndexOf("&") + 1;
                int treasureLength = messageAsStr.LastIndexOf("&") - startIndexOfTreasure;

                string treasure = messageAsStr.Substring(startIndexOfTreasure, treasureLength);

                int startIndexOfCoordinates = messageAsStr.IndexOf("<") + 1;
                int coordinatesLength = messageAsStr.IndexOf(">") - startIndexOfCoordinates;

                string coordinates = messageAsStr.Substring(startIndexOfCoordinates, coordinatesLength);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                

            }

        }
    }
}
