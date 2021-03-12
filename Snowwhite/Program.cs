using System;
using System.Linq;
using System.Collections.Generic;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();
            while((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] arr = input.Split(" <:> ");
                string name = arr[0];
                string color = arr[1];
                int power = int.Parse(arr[2]);
                string key = name + " " + color;
                if (dwarfs.ContainsKey(key) == false)
                {
                    dwarfs.Add(key, power);
                }

                if(dwarfs.ContainsKey(key) && dwarfs[key] < power)
                {
                    dwarfs[key] = power;
                }
            }

            foreach (var dwarf in dwarfs.OrderByDescending(k => k.Value)
                .ThenByDescending(c => dwarfs.Where(kvp => kvp.Key.Split(" ")[0] == c.Key.Split(" ")[0]).Count()))
            {
                string value = dwarf.Key;
                string[] valueArr = value.Split();
                string color = "(" + valueArr[1] + ")";
                Console.WriteLine($"{color} {valueArr[0]} <-> {dwarf.Value}");
            }
        }
    }
}
