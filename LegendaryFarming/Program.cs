using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering the quantity followed by the material separated with space: ");
            SortedDictionary<string, int> keyMaterials= new SortedDictionary<string, int>()
            {
                {"shards",0 },
                {"fragments",0 },
                {"motes",0 }
            };

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            bool itemObtained = false;
            while(itemObtained != true)
            {
                string[] inputLine = Console.ReadLine().Split(" ");
                for(int i = 0; i < inputLine.Length; i++)
                {
                    if(i % 2 == 1)
                    {
                        if(inputLine[i] == "shards")
                        {
                            keyMaterials["shards"] += int.Parse(inputLine[i - 1]);
                        }
                        else if(inputLine[i] == "fragments")
                        {
                            keyMaterials["fragments"] += int.Parse(inputLine[i - 1]);
                        }
                        else if (inputLine[i] == "motes")
                        {
                            keyMaterials["motes"] += int.Parse(inputLine[i - 1]);
                        }
                        else
                        {
                            if (junk.ContainsKey(inputLine[i])){
                                junk[inputLine[i]] += int.Parse(inputLine[i - 1]);
                            }
                            else
                            {
                                junk.Add(inputLine[i], int.Parse(inputLine[i - 1]));
                            }
                        }
                    }
                    

                    if(keyMaterials["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        keyMaterials["shards"] -= 250;
                        itemObtained = true;
                    }
                    else if (keyMaterials["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        keyMaterials["fragments"] -= 250;
                        itemObtained = true;
                    }
                    else if (keyMaterials["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        keyMaterials["motes"] -= 250;
                        itemObtained = true;
                    }
                }
            }

            var orderedByAmount = keyMaterials.OrderByDescending(n => n.Value);
            foreach(var item in orderedByAmount.OrderBy(o => o.Key))
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            foreach(var junky in junk.OrderBy(k => k.Key))
            {
                Console.WriteLine(junky.Key + ": " + junky.Value);
            }
        }
    }
}
