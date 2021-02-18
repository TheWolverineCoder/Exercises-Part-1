using System;
using System.Collections.Generic;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < numberOfGuests; i++)
            {
                //Enter something like this: "Tom is going/not going to the party."
                string input = Console.ReadLine();
                string[] inputArr = input.Split();
                if (input.Contains("not going"))
                {
                    if (guests.Contains(inputArr[0]))
                    {
                        guests.Remove(inputArr[0]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input.Contains("going"))
                {
                    if (guests.Contains(inputArr[0]))
                    {
                        Console.WriteLine(inputArr[0]  + " is already in the list!");
                    }
                    else
                    {
                        guests.Add(inputArr[0]);
                    }
                    
                }

                
            }

            foreach (string name in guests)
            {
                Console.WriteLine(name);
            }

        }
    }
}
