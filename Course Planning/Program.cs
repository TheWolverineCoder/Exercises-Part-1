using System;
using System.Collections.Generic;

namespace Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your lessons and exercises here: ");
            string line = Console.ReadLine();
            string[] lineArr = line.Split(", ");
            List<string> lineList = new List<string>(lineArr);
            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commands = command.Split(":");
                string firstCommand = commands[0];
                string secondCommand = commands[1];
                if (firstCommand == "Add")
                {
                    if (lineList.Contains(secondCommand) == false)
                    {
                        lineList.Add(secondCommand);
                    }
                }
                else if (firstCommand == "Insert")
                {
                    if (lineList.Contains(secondCommand) == false)
                    {
                        int index = int.Parse(commands[2]);
                        lineList.Insert(index, secondCommand);
                    }
                }
                else if (firstCommand == "Remove")
                {
                    if (lineList.Contains(secondCommand) == true)
                    {
                        lineList.Remove(secondCommand);
                    }
                }
                else if(firstCommand == "Swap")
                {
                    string thirdCommand = commands[2];
                    if (lineList.Contains(secondCommand) == true && lineList.Contains(thirdCommand) == true)
                    {
                        string firstElement = secondCommand;
                        int firstIndex = lineList.IndexOf(secondCommand);
                        string secondElement = thirdCommand;
                        int secondIndex = lineList.IndexOf(thirdCommand);
                        lineList[firstIndex] = secondElement;
                        lineList[secondIndex] = firstElement;

                    }
                }
                else if(firstCommand == "Exercise")
                {
                    
                    if (lineList.Contains(secondCommand) == false)
                    {
                        lineList.Add(secondCommand);
                        string commExerc = secondCommand + "-Exercise";
                        lineList.Add(commExerc);
                    }
                    else
                    {
                        int index = lineList.IndexOf(secondCommand);
                        string commExerc = secondCommand+ "-Exercise";
                        lineList.Insert(index + 1, commExerc);
                    }
                }
                

            }

            for(int index = 0; index < lineList.Count; index++)
            {
                Console.Write((index + 1) + lineList[index]);
                Console.WriteLine();
            }
        }
    }
}
