using System;
using System.Collections.Generic;
using System.Linq;
namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, int> points = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>(); 
            while((input = Console.ReadLine()) != "exam finished")
            {
                string[] arr = input.Split("-");
                string participant = arr[0];
                if(arr[1] == "banned")
                {
                    if (points.ContainsKey(participant))
                    {
                        points.Remove(participant);
                    }
                }
                else
                {
                    if (points.ContainsKey(participant) && points[participant] < int.Parse(arr[2]))
                    {
                        submissions[arr[1]]++;
                        points[participant] = int.Parse(arr[2]);
                    }
                    else if (points.ContainsKey(participant))
                    {
                        submissions[arr[1]]++;
                        continue;
                    }
                    else
                    {
                        points.Add(participant, int.Parse(arr[2]));
                        if (submissions.ContainsKey(arr[1]))
                        {
                            submissions[arr[1]]++; 
                        }
                        else
                        {
                            submissions.Add(arr[1], 1);
                        }
                    }
                }
            }

            var orderedPoints = points.OrderBy(p => p.Value).ThenBy(n => n.Key).ToDictionary(n => n.Key,v => v.Value);
            var orderedSub = submissions.OrderByDescending(k => k.Value).ThenBy(n => n.Key).ToDictionary(n => n.Key, v => v.Value);
            Console.WriteLine("Results:");
            foreach(var participant in orderedPoints)
            {
                Console.WriteLine(participant.Key + "|" + participant.Value);
            }
            Console.WriteLine("Submissions: ");
            foreach(var sub in orderedSub)
            {
                Console.WriteLine(sub.Key + " - " + sub.Value);
            }
        }
    }
}
