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

            //for (int i = 0; i < 100; i++)
            //{
            //    Group group = new Group();
            //    group.setTeamList();
            //    group.setGroupName("A");
            //    group.playFirstRound();
            //    group.playSecondRound();
            //    if (group.getTopTeam().Count == 2)
            //    {
            //        foreach (string s in group.result)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        foreach (Team t in group.teamList)
            //        {
            //            Console.WriteLine(t.teamName + " " + t.totalPoint);
            //        }
            //        foreach (Team t in group.teamList)
            //        {
            //            int yellowcard = 0;
            //            int redcard = 0;
            //            foreach (Player p in t.players)
            //            {
            //                if (p.yellowcard > 0 || p.redcard > 0)
            //                {
            //                    Console.WriteLine(p.name + " " + p.number + " Y = " + p.yellowcard + " R = " + p.redcard);
            //                }
            //                yellowcard += p.yellowcard;
            //                redcard += p.redcard;
            //            }
            //            Console.WriteLine(t.teamName + " " + "Red card = " + redcard + " " + "Yellow card = " + yellowcard);
            //        }
            //        Console.WriteLine("Top 1 team " + group.getTopTeam()[0].teamName + " Goal deficit " + group.getTopTeam()[0].goalDeficit);
            //        Console.WriteLine("Top 2 team " + group.getTopTeam()[1].teamName + " Goal deficit " + group.getTopTeam()[1].goalDeficit);
            //    }

            //}


            Group groupA = new Group();
            groupA.setTeamList();
            groupA.setGroupName("A");
            groupA.playFirstRound();
            groupA.playSecondRound();
            foreach (string s in groupA.result)
            {
                Console.WriteLine(s);
            }
            foreach (Team t in groupA.teamList)
            {
                Console.WriteLine(t.teamName + " " + t.totalPoint);
            }
            Console.WriteLine("Top 1 team " + groupA.getTopTeam()[0].teamName + " Goal deficit " + groupA.getTopTeam()[0].goalDeficit);
            Console.WriteLine("Top 2 team " + groupA.getTopTeam()[1].teamName + " Goal deficit " + groupA.getTopTeam()[1].goalDeficit);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Bang B");
            Group groupB = new Group();
            groupB.setTeamList();
            groupB.setGroupName("A");
            groupB.playFirstRound();
            groupB.playSecondRound();
            foreach (string s in groupB.result)
            {
                Console.WriteLine(s);
            }
            foreach (Team t in groupB.teamList)
            {
                Console.WriteLine(t.teamName + " " + t.totalPoint);
            }
            Console.WriteLine("Top 1 team " + groupB.getTopTeam()[0].teamName + " Goal deficit " + groupB.getTopTeam()[0].goalDeficit);
            Console.WriteLine("Top 2 team " + groupB.getTopTeam()[1].teamName + " Goal deficit " + groupB.getTopTeam()[1].goalDeficit);
            Console.ReadKey();
        }
    }
}
