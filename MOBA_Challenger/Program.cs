using System;
using System.Linq;
using System.Collections.Generic;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering: ");
            string input;
            Dictionary<string, Dictionary<string, int>> playersPool = new Dictionary<string, Dictionary<string, int>>();
            while((input = Console.ReadLine()) != "Season end")
            {
                string[] inputArr = input.Split(" ");
                if(inputArr[1] == "vs")
                {
                    string playerOne = inputArr[0];
                    string playerTwo = inputArr[2];
                    if(playersPool.ContainsKey(playerOne) == true && playersPool.ContainsKey(playerTwo) == true)
                    {
                        foreach(var pos in playersPool[playerOne])
                        {
                            if (playersPool[playerTwo].ContainsKey(pos.Key))
                            {
                                if(playersPool[playerOne].Values.Sum() < playersPool[playerTwo].Values.Sum())
                                {
                                    playersPool.Remove(playerOne);
                                }
                                else if(playersPool[playerOne].Values.Sum() > playersPool[playerTwo].Values.Sum())
                                {
                                    playersPool.Remove(playerTwo);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string player = inputArr[0];
                    string position = inputArr[2];
                    int skill = int.Parse(inputArr[4]);
                    if(playersPool.ContainsKey(player) == false)
                    {
                        playersPool.Add(player, new Dictionary<string, int>());
                    }

                    if(playersPool[player].ContainsKey(position) == false)
                    {
                        playersPool[player].Add(position, 0);
                    }

                    if(playersPool[player][position] < skill)
                    {
                        playersPool[player][position] = skill;
                    }
                }
                
            }

            foreach (var player in playersPool.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()}skill.");
                foreach (var pos in player.Value.OrderByDescending(k => k.Value).ThenBy(v => v.Key)){
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }
        }
    }
}
