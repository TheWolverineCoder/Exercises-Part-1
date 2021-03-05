using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();
            while((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputArr;
                bool first = false;
                if (input.Contains("|"))
                {
                    inputArr = input.Split(" | ");
                    first = true;
                }
                else
                {
                    inputArr = input.Split(" -> ");
                }
                
                if(first == true)
                {
                    string side = inputArr[0];
                    string user = inputArr[1];
                    if (sides.ContainsKey(side))
                    {
                        if (!(sides[side].Contains(user)))
                        {
                            sides[side].Add(user);
                        }
                    }
                    else
                    {
                        sides.Add(side, new List<string>());
                        sides[side].Add(user);
                    }
                }
                else
                {
                    string user = inputArr[0];
                    string side = inputArr[1];
                    bool check = false;
                    foreach(var s in sides)
                    {
                        if (s.Value.Contains(user))
                        {
                            s.Value.Remove(user);
                            sides[side].Add(user);
                            Console.WriteLine($"{user} joins the {side} side!");
                            check = true;
                        }
                    }

                    if (check == false)
                    {
                        sides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
            }

            var ordered = sides.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach(var side in ordered)
            {
                if(side.Value.Count > 0)
                {
                    Console.WriteLine("Side: " + side.Key + ", Members: " + side.Value.Count);
                    side.Value.Sort();
                    foreach (string name in side.Value)
                    {
                        Console.WriteLine("! " + name);
                    }
                }
                
            }
        }
    }
}
