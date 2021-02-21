using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your list of vagons: ");
            List<int> vagons = Console.ReadLine().Split().Select(int.Parse).ToList();
        }
        
        static List<int> ReadList(int n)
        {
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            return list;
        }
       
        static List<int> ReadList()
        {
            List<int> list = new List<int>();
            var line = Console.ReadLine();
            list = line.Split().Select(int.Parse).ToList();
            return list;
        }
        
        static List<string> ReadStringList(int number)
        {
            List<string> list = new List<string>(number);
            list = Console.ReadLine().Split().ToList();
            return list;
        }

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        
    }
}
