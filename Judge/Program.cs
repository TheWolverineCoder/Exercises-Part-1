using System;
using System.Collections.Generic;
using System.Linq;
namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Dictionary<string,int>> contestsInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> individual = new Dictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputArr = input.Split(" -> ");
                string studentName = inputArr[0];
                string contestName = inputArr[1];
                int pointsPer = int.Parse(inputArr[2]);

                if (!contestsInfo.ContainsKey(contestName))
                {
                    contestsInfo.Add(contestName, new Dictionary<string, int>());
                }

                if (!contestsInfo[contestName].ContainsKey(studentName))
                {
                    contestsInfo[contestName].Add(studentName, 0);
                }

                if (contestsInfo[contestName][studentName] < pointsPer)
                {
                    contestsInfo[contestName][studentName] = pointsPer;
                }

                if (!individual.ContainsKey(studentName))
                {
                    individual.Add(studentName, new Dictionary<string, int>());
                }

                if (!individual[studentName].ContainsKey(contestName))
                {
                    individual[studentName].Add(contestName, 0);
                }

                if (individual[studentName][contestName] < pointsPer)
                {
                    individual[studentName][contestName] = pointsPer;
                }
            }

            foreach(var contest in contestsInfo)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int counter = 1;

                foreach(var participant in contest.Value.OrderByDescending(k => k.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"{counter}. {participant.Key} <::> {participant.Value}");
                    counter++;
                }
            }

            Console.WriteLine("Individual standings: ");
            int count = 1;
            foreach (var student in individual.OrderByDescending(kvp => kvp.Value.Values.Sum()).ThenBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{count}. {student.Key} -> {student.Value.Values.Sum()}");
                count++;
            }
        }
    }
}
