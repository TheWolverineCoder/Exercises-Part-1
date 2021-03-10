using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            var collection = new Dictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] arr = input.Split(":");
                string contest = arr[0];
                string pass = arr[1];
                passwords.Add(contest, pass);
            }
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "end of submissions")
            {
                string[] secArr = secondInput.Split("=>");
                string contest = secArr[0];
                string pass = secArr[1];
                string name = secArr[2];
                int points = int.Parse(secArr[3]);
                if (passwords.ContainsKey(contest))
                {
                    if(passwords[contest] == pass)
                    {
                        if (collection.ContainsKey(name))
                        {
                            if (collection[name].ContainsKey(contest))
                            {
                                if(collection[name][contest] < points)
                                {
                                    collection[name][contest] = points;
                                }
                            }
                            else
                            {
                                collection[name].Add(contest, points);
                            }
                        }
                        else
                        {
                            collection.Add(name, new Dictionary<string, int>());
                            collection[name].Add(contest, points);
                        }                       
                    }
                }
            }

            
            int sum = 0;
            int maxSum = 0;
            string bestCandidate = "";
            var col = collection;
            foreach(var user in collection.Keys)
            {
                foreach(var contest in collection[user])
                {
                    sum += contest.Value;
                }
                if(sum > maxSum)
                {
                    maxSum = sum;
                    bestCandidate = user;
                    sum = 0;
                }
                
               
            }
            var orderedCollection = collection.OrderBy(n => n.Key).ThenByDescending(v => v.Value).ToDictionary(k => k.Key,v => v.Value);
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxSum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in orderedCollection.Keys)
            {
                Console.WriteLine(user);
                foreach(var contest in collection[user])
                {
                    Console.WriteLine("# " + contest.Key + " -> " + contest.Value);
                }
            }
        }
    }
}
