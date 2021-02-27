using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, int> dataBase = new Dictionary<string, int>();
            while((input = Console.ReadLine()) != "stop")
            {
                string material = input;
                string quant = Console.ReadLine();
                if(quant == "stop")
                {
                    break;
                }
                int quantity = int.Parse(quant);
                if (dataBase.ContainsKey(material))
                {
                    dataBase[material] += quantity;
                }
                else
                {
                    dataBase.Add(material, quantity);
                }
            }

            foreach (var materi in dataBase)
            {
                Console.WriteLine(materi.Key + " -> " + materi.Value);
            }
        }
    }
}
