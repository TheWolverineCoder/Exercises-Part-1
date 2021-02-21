using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_List_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your numbers here: ");
            List<int> numbers = ReadList();
            Console.WriteLine("There are several command you can use now:");
            Console.WriteLine("Add {} - adds the given number to the list.");
            Console.WriteLine("Remove {} - removes the given number from  the list.");
            Console.WriteLine("Shift left {count} - first number becomes last 'count' times.");
            Console.WriteLine("Shift right {count} - last number becomes first 'count' times.");
            Console.WriteLine("end - stops the program and prints the final list.");
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "Add":
                        Add(numbers, int.Parse(tokens[1]));
                        break;
                    case "Remove":
                        Remove(numbers, int.Parse(tokens[1]));
                        break;

                    case "Insert":
                        Insert(numbers, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Shift":
                        if (int.Parse(tokens[2]) > numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else if (tokens[1] == "left")
                        {
                            ShiftLeft(numbers, int.Parse(tokens[2]));

                        }
                        else if (tokens[1] == "right")
                        {
                            ShiftRight(numbers, int.Parse(tokens[2]));
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }

        static List<int> ReadList()
        {
            List<int> list = new List<int>();
            var line = Console.ReadLine();
            list = line.Split().Select(int.Parse).ToList();
            return list;
        }

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Add(List<int> numbers, int num)
        {
            numbers.Add(num);
        }

        static void Remove(List<int> numbers, int num)
        {
            numbers.Remove(num);
        }


        static void Insert(List<int> numbers, int num, int index)
        {
            numbers.Insert(index, num);
        }

        static void ShiftLeft(List<int> numbers, int index)
        {
            for(int k = 0; k < index; k++)
            {
                int temp = numbers[0];
                for (int i = 0; i < numbers.Count-1; i++) // 1 2 3 4 5
                {
                   
                    numbers[i] = numbers[i + 1];
                    
                }
                numbers[numbers.Count - 1] = temp;
            }
            
        }

        static void ShiftRight(List<int> numbers, int index)
        {
            for (int k = 0; k < index; k++)
            {
                int temp = numbers[numbers.Count - 1];
                for (int i = numbers.Count - 1; i > 0; i--)
                {
                    
                    numbers[i] = numbers[i-1];
                    
                }
                numbers[0] = temp;
            }
        }

    }
}
