using System;
using System.Collections.Generic;

namespace Anonymous_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your input here: ");
            string line = Console.ReadLine();
            string[] lineArr = line.Split(", ");
            List<string> lineList = new List<string>(lineArr);
            Console.WriteLine("There are 3 commands you can use: ");
            Console.WriteLine("1. merge {startIndex} {endIndex} - used to merge all elements from the start index to last index.");
            Console.WriteLine("2. divide {index} {partitions} - used to divide a selected element to given number of pieces.");
            Console.WriteLine("3. 3:1 - used to print the results,after that the program ends.");
            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandTokens = command.Split();
                string firstToken = commandTokens[0];
                int secondToken = int.Parse(commandTokens[1]);
                int thirdToken = int.Parse(commandTokens[2]);
                //merge operation
                if (firstToken == "merge")
                {
                    if (secondToken < 0)
                    {
                        secondToken = 0;
                    }
                    if (thirdToken > lineArr.Length)
                    {
                        thirdToken = lineArr.Length;
                    }
                    string concatenatedString = "";
                    for (int i = secondToken; i <= thirdToken; i++)
                    {
                        concatenatedString += lineList[i];

                    }
                    for (int l = secondToken; l <= thirdToken; l++)
                    {
                        lineList.RemoveAt(secondToken);

                    }

                    lineList.Insert(0, concatenatedString);


                }
                else if (firstToken == "divide")
                {
                    int index = secondToken;
                    int parts = thirdToken;
                    string selectedItem = lineList[index];
                    int stringSize = selectedItem.Length;
                    int partSize = stringSize / parts;
                    lineList.RemoveAt(index);
                    int wordIndex = 0;
                    if (stringSize % parts == 0)
                    {


                        for (int part = 0; part < parts; part++)
                        {
                            int ind = 0;
                            for (int m = ind; m < partSize; m++)
                            {
                                string word = "";
                                for (int s = wordIndex; s < wordIndex + partSize; s++)
                                {
                                    word += selectedItem[wordIndex];

                                }
                                wordIndex++;
                                lineList.Insert(index + m, word);
                            }
                        }


                    }
                    else
                    {
                        for (int part = 0; part < parts - 1; part++)
                        {
                            int ind = 0;
                            for (int m = ind; m < partSize; m++)
                            {
                                string word = "";
                                for (int s = wordIndex; s < wordIndex + partSize; s++)
                                {
                                    word += selectedItem[wordIndex];

                                }
                                wordIndex++;
                                lineList.Insert(index + m, word);
                            }
                        }
                        string lastWord = "";
                        for (int s = wordIndex; s < wordIndex + partSize + 1; s++)
                        {
                            lastWord += selectedItem[wordIndex];

                        }
                        wordIndex++;
                        lineList.Insert(index + parts - 1, lastWord);
                    }
                }
            }

            foreach (string item in lineList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
