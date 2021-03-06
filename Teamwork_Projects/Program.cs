using System;
using System.Collections.Generic;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<string> creators = new List<string>();
            List<string> teamNames = new List<string>();
            Console.WriteLine("Enter the number of teams you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for(int i = 0; i < count; i++)
            {
                string[] teamReg = Console.ReadLine().Split("-");
                string creator = teamReg[0];
                string team = teamReg[1];
                if (creators.Contains(creator))
                {
                    Console.WriteLine(creator + " can't create another team!");
                }
                else if (teamNames.Contains(team))
                {
                    Console.WriteLine("Team " + team + " was already created!");
                }
                else
                {
                    creators.Add(creator);
                    teamNames.Add(team);
                    Team teamObject = new Team(creator, team);
                    teams.Add(teamObject);
                    Console.WriteLine("Team " + team + " was created by " + creator);
                }
                
            }

            string input;

            List<string> membersInATeam = new List<string>();
            while((input = Console.ReadLine()) != "end of assignment")
            {
                string[] inputInfo = input.Split("->");
                string memberName = inputInfo[0];
                string teamJoin = inputInfo[1];
                
                if (teamNames.Contains(teamJoin) == false)
                {
                    Console.WriteLine("Team " + teamJoin + " does not exist!");
                }
                else if (membersInATeam.Contains(memberName))
                {
                    Console.WriteLine(memberName + " is already in a team!");
                }
                
                else
                {
                    membersInATeam.Add(memberName);
                    foreach(Team t in teams)
                    {
                        if(t.TeamName == teamJoin)
                        {
                            t.Members.Add(memberName);
                        }
                    }
                    
                }
            }

            List<Team> teamsToDisband = new List<Team>();
            foreach(Team t in teams)
            {
                if(t.Members.Count > 0)
                {
                    Console.WriteLine(t.TeamName + ":");
                    Console.WriteLine("-" + t.Creator);
                    foreach (string name in t.Members)
                    {
                        Console.WriteLine("--" + name);
                    }
                }
                else
                {
                    teamsToDisband.Add(t);
                }
                
            }

            Console.WriteLine("Teams to disband: ");
            foreach(Team te in teamsToDisband)
            {
                Console.WriteLine(te.TeamName);
            }
        }
    }

    class Team
    {
        public Team(string creator,string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();
        }

        public string Creator { get; set; }

        public  string TeamName { get; set; }

        public List<string> Members { get; set; }
    }
}
