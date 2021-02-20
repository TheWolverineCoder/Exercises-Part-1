using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your sequence of distances: ");
            int[] distances = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> listDistances = new List<int>();
            foreach(int distance in distances)
            {
                listDistances.Add(distance);
            }
            int sum = 0;
            while(listDistances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int number = listDistances.ElementAt(0);
                    sum += number;
                    int changeNum = listDistances.ElementAt(listDistances.Count - 1);
                    listDistances.RemoveAt(0);
                    listDistances.Insert(0, changeNum);
                    for (int i = 0; i < listDistances.Count; i++)
                    {
                        listDistances[i] = listDistances.ElementAt(i) - number;
                    }
                }
                else if (index >= listDistances.Count)
                {
                    int number = listDistances.ElementAt(listDistances.Count - 1);
                    int changeNum = listDistances.ElementAt(0);
                    sum += number;
                    listDistances.RemoveAt(listDistances.Count - 1);
                    listDistances.Insert(listDistances.Count - 1, changeNum);
                    for (int i = 0; i < listDistances.Count; i++)
                    {
                        listDistances[i] = listDistances.ElementAt(i) - number;
                    }
                }
                else
                {
                    int element = listDistances.ElementAt(index);
                    sum += element;
                    for (int i = 0; i < listDistances.Count; i++)
                    {
                        if (listDistances.ElementAt(i) > element)
                        {
                            listDistances[i] = listDistances.ElementAt(i) - element;
                        }
                        else
                        {
                            listDistances[i] = listDistances.ElementAt(i) + element;
                        }
                    }
                    listDistances.RemoveAt(index);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
