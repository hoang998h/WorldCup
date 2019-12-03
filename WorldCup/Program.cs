using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            do
            {
                Group group = new Group();
                group.setTeamList();
                group.setGroupName("A");
                group.playFirstRound();
                group.playSecondRound();
                count = group.getTop1Team().Count;
                if (count > 1)
                {
                    foreach (string s in group.result)
                    {
                        Console.WriteLine(s);
                    }
                    foreach (Team t in group.teamList)
                    {
                        Console.WriteLine(t.teamName + " " + t.totalPoint);
                    }
                    foreach (Team t in group.teamList)
                    {
                        int yellowcard = 0;
                        int redcard = 0;
                        foreach (Player p in t.players)
                        {
                            if (p.yellowcard > 0 || p.redcard > 0)
                            {
                                Console.WriteLine(p.name + " " + p.number + " Y = " + p.yellowcard + " R = " + p.redcard);
                            }
                            yellowcard += p.yellowcard;
                            redcard += p.redcard;
                        }
                        Console.WriteLine(t.teamName + " " + "Red card = " + redcard + " " + "Yellow card = " + yellowcard);
                    }

                    if (group.getTop1Team().Count > 1)
                    {
                        Console.WriteLine("Top 1 team " + group.getTop1Team()[0].teamName + " " + group.getTop1Team()[0].goalDeficit);
                        Console.WriteLine("Top 1 team " + group.getTop1Team()[1].teamName + " " + group.getTop1Team()[1].goalDeficit);
                    }
                    foreach (Team t in group.teamList)
                    {
                        Console.WriteLine(t.teamName);
                        foreach(Player p in  t.players)
                        {
                            Console.WriteLine(p.name + " "+ p.number + " " +p.goal);
                        }
                    }
                }
            } while (count == 1);



            //Team team1 = new Team();
            //team1.setteamName("Team1");
            //Team team2 = new Team();
            //team2.setteamName("Team2");
            //Match match = new Match();
            //match.setTeam1(team1);
            //match.setTeam2(team2);
            //match.setTeam1Players();
            //match.setTeam2Players();
            //match.setMatchType("1/16");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(match.playMatch());
            //}
            Console.ReadKey();
        }
    }
}
