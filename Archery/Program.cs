using System;
using System.Linq;

namespace Archery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the targets separated by | : ");
            int[] targets = Console.ReadLine().Split("|").Select(int.Parse).ToArray();
            string command;
            int points = 0;
            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] commandArr = command.Split(" ");
                if (commandArr[0] == "Shoot")
                {
                    string[] shooting = commandArr[1].Split("@");
                    int index = int.Parse(shooting[1]);
                    int length = int.Parse(shooting[2]);
                    if (shooting[0] == "Left")
                    {
                        if (index >= 0 || index < targets.Length)
                        {
                            for (int i = 0; i < length; i++)
                            {
                                index--;
                                if (index == -1)
                                {
                                    index = targets.Length - 1;
                                }
                            }

                        }
                        if (targets[index] >= 5)
                        {
                            targets[index] -= 5;
                            points += 5;
                        }
                        else
                        {
                            points += targets[index];
                            targets[index] = 0;
                        }

                    }
                    else if (shooting[0] == "Right")
                    {
                        if (index >= 0 || index < targets.Length)
                        {
                            for (int i = 0; i < length; i++)
                            {
                                index++;
                                if (index == targets.Length)
                                {
                                    index = 0;
                                }
                            }

                        }
                        if (targets[index] >= 5)
                        {
                            targets[index] -= 5;
                            points += 5;
                        }
                        else
                        {
                            points += targets[index];
                            targets[index] = 0;
                        }
                    }
                }
                else if (commandArr[0] == "Reverse")
                {
                    Array.Reverse(targets);
                }
            }

            foreach (int target in targets)
            {
                Console.Write($"{{{target}}} - ");
            }
            Console.WriteLine("Points: " + points);
            Console.ReadLine();
        }
    }
}
