using System;
using System.Linq;
using System.Collections.Generic;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Dictionary<string,int>>> dragons = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            Dictionary<string, Dictionary<string,int>> average = new Dictionary<string, Dictionary<string, int>>();
            int loop = int.Parse(Console.ReadLine());
            for(int i = 0; i < loop; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string color = arr[0];
                string type = arr[1];
                int damage = int.Parse(arr[2]);
                int health = int.Parse(arr[3]);
                int armor = int.Parse(arr[4]);
                if(dragons.ContainsKey(color) == false)
                {
                    dragons.Add(color, new Dictionary<string, Dictionary<string, int>>());
                }

                if(dragons[color].ContainsKey(type) == false)
                {
                    dragons[color].Add(type, new Dictionary<string, int>());
                    dragons[color][type].Add("damage",damage);
                    dragons[color][type].Add("health",health);
                    dragons[color][type].Add("armor",armor);
                }

                if (dragons[color].ContainsKey(type))
                {
                    dragons[color].Remove(type);
                    dragons[color].Add(type, new Dictionary<string, int>());
                    dragons[color][type].Add("damage", damage);
                    dragons[color][type].Add("health", health);
                    dragons[color][type].Add("armor", armor);
                }
                

                if(average.ContainsKey(color) == false)
                {
                    average.Add(color, new Dictionary<string, int>());
                    average[color].Add(type, 1);
                    average[color].Add("damage",damage);
                    average[color].Add("health", health);
                    average[color].Add("armor", armor);
                    average[color].Add("counter", 1);
                }
                else if(average[color].ContainsKey(type))
                {
                    int diff1 = average[color]["damage"] - damage;
                    int diff2 = average[color]["health"] - health;
                    int diff3 = average[color]["armor"] - armor;
                    average[color]["damage"] += diff1;
                    average[color]["health"] += diff2;
                    average[color]["armor"] += diff3;
                }
                else
                {
                    average[color]["damage"] += damage;
                    average[color]["health"] += health;
                    average[color]["armor"] += armor;
                    average[color]["counter"]++;
                } 
            }

            foreach (var col in average.Keys)
            {
                int count = average[col]["counter"];
                double averageDmg = (double)average[col]["damage"] / count;
                double averageHealth = (double)average[col]["health"] / count;
                double averageArmor = (double)average[col]["armor"] / count;
                Console.WriteLine($"{col}::({averageDmg:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach(var drag in dragons[col].Keys)
                {
                    Console.WriteLine($"-{drag} -> damage:{dragons[col][drag]["damage"]}, health:{dragons[col][drag]["health"]}, armor:{dragons[col][drag]["armor"]}");
                }
            }
            
        }
    }
}
