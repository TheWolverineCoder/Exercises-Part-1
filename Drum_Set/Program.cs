using System;
using System.Collections.Generic;
using System.Linq;

namespace Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Gabby's savings for drums: ");
            float savings = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter Gabby's drum set(integers separated by spaces): ");
            int[] drumSet = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> drumSetList = new List<int>();
            List<int> drumSetListReserve = new List<int>();
            foreach(int i in drumSet)
            {
                drumSetList.Add(i);
                drumSetListReserve.Add(i);
            }
            string command;
            Console.WriteLine("IF you want to stop the following operation enter \"Hit it again, Gabby!\"");
            Console.WriteLine("Start entering integers(the damage done to each drum daily): ");
            while((command = Console.ReadLine()) != "Hit it again, Gabby!")
            {
               int damage = int.Parse(command);
               for(int i=0;i<drumSetList.Count;i++)
                {
                    drumSetList[i] = drumSetList[i] - damage;
                    if(drumSetList[i] <= 0)
                    {
                        if((savings-3*drumSetList[i]) > 0)
                        {
                            drumSetList[i] = drumSetListReserve[i];
                            savings = savings - 3 * drumSetList[i];
                        }
                        else
                        {
                            drumSetList.RemoveAt(i);
                        }
                    }
                }
            }

            foreach(int k in drumSetList)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine("Gabby has {0:f2} leva left.", savings);
        }
    }
}
