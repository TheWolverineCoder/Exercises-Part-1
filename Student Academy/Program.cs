using System;
using System.Collections.Generic;
using System.Linq;
namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of students you are about to enter: ");
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, double> records = new Dictionary<string, double>();
            for(int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (records.ContainsKey(name))
                {
                    continue;
                }
                else
                {
                    records.Add(name, grade);
                }
            }

            foreach(var item in records)
            {
                if(item.Value < 4.50)
                {
                    records.Remove(item.Key);
                }
            }

            var ordered = records.OrderByDescending(g => g.Value);
            foreach(var name in ordered)
            {
                Console.WriteLine($"{name.Key} => {name.Value:F2}");
            }
        }
    }
}
