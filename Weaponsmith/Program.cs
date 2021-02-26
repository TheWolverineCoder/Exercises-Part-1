using System;
using System.Collections.Generic;

namespace Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weaponParts = new List<string>();
            Console.WriteLine("Enter parts of a weapon's name separated by | : ");
            string[] parts = Console.ReadLine().Split("|");
            for(int i = 0; i < parts.Length; i++)
            {
                weaponParts.Add(parts[i]);
            }
            Console.WriteLine("Start entering commands:");
            Console.WriteLine("Move Left {index}");
            Console.WriteLine("Move Right {index}");
            Console.WriteLine("Check Even");
            Console.WriteLine("Check Odd");
            Console.WriteLine("When you are done with the commands enter \"Done\"");
            string input;
            while((input = Console.ReadLine()) != "Done")
            {
                string[] inputInfo = input.Split(" ");
                switch (inputInfo[0])
                {
                    case "Move":
                        if (inputInfo[1] == "Left")
                        {
                            MoveLeft(int.Parse(inputInfo[2]), weaponParts);
                        }
                        else if(inputInfo[1] == "Right")
                        {
                            MoveRight(int.Parse(inputInfo[2]), weaponParts);
                        }
                        break;
                    case "Check":
                        if (inputInfo[1] == "Even")
                        {
                            CheckEven(weaponParts);
                        }
                        else if (inputInfo[1] == "Odd")
                        {
                            CheckOdd(weaponParts);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }

            foreach(string element in weaponParts)
            {
                Console.Write(element + " ");
            }
        }

        static void MoveLeft(int index,List<string> parts)
        {
            if(index-1 >= 0)
            {
                string element = parts[index];
                parts.RemoveAt(index);
                parts.Insert(index - 1, element);
            }
            else
            {
                Console.WriteLine("Impossible operation!");
            }
        }

        static void MoveRight(int index, List<string> parts)
        {
            if (index + 1 <= parts.Count-1)
            {
                string element = parts[index];
                parts.RemoveAt(index);
                parts.Insert(index + 1, element);
            }
            else
            {
                Console.WriteLine("Impossible operation!");
            }
        }

        static void CheckEven(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(i%2 == 0)
                {
                    Console.WriteLine(list[i]);
                }
            }
        }

        static void CheckOdd(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(list[i]);
                }
            }
        }
    }
}
