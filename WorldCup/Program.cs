using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    class Program
    {
        static void PlayGroup(Group group)
        {
            Console.WriteLine("Bang " + group.groupName);
            group.playFirstRound();
            group.playSecondRound();
            foreach (string s in group.result)
            {
                Console.WriteLine(s);
            }
            foreach (Team t in group.teamList)
            {
                Console.WriteLine(t.teamName + " Point " + t.totalPoint);
            }
            Console.WriteLine("Top 1 team " + group.getTopTeam()[0].teamName + " Goal deficit " + group.getTopTeam()[0].goalDeficit);
            Console.WriteLine("Top 2 team " + group.getTopTeam()[1].teamName + " Goal deficit " + group.getTopTeam()[1].goalDeficit);
        }
        static Team PlayMatch(Team team1, Team team2)
        {
            Match match = new Match();
            match.setTeam1(team1);
            match.setTeam2(team2);
            match.setTeam1Players();
            match.setTeam2Players();
            match.setMatchType("loai truc tiep");
            match.playMatch();

            Console.WriteLine(match.result);
            if (match.result.Contains(team1.teamName + " Win"))
            {
                return team1;
            }
            return team2;
        }
        static void Main(string[] args)
        {
            Group groupA = new Group();
            Group groupB = new Group();
            Group groupC = new Group();
            Group groupD = new Group();
            Group groupE = new Group();
            Group groupF = new Group();
            Group groupG = new Group();
            Group groupH = new Group();
            groupA.setGroupName("A");
            groupB.setGroupName("B");
            groupC.setGroupName("C");
            groupD.setGroupName("D");
            groupE.setGroupName("E");
            groupF.setGroupName("F");
            groupG.setGroupName("G");
            groupH.setGroupName("H");
            int highestGoal = 0;
            string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
// string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C# Project\WorldCup\WorldCup\bin\Debug\WorldCupDB.mdf;Integrated Security=True;Connect Timeout=30;";

            string directoryName = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            Console.WriteLine("aaaaaaaaaaaaa" + directoryName);

            

            sqlCon += directoryName;
            sqlCon += @"\WorldCupDB.mdf; Integrated Security = True; Connect Timeout = 30;";

            Console.WriteLine("sql conn" + sqlCon);

            SqlConnection con = new SqlConnection(sqlCon);
            var command = new SqlCommand("select * from Team", con);
            con.Open();
            List<Team> listOfAllTeam = new List<Team>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Team team = new Team();
                team.teamName = reader.GetString(1).Trim();
                listOfAllTeam.Add(team);
            }
            foreach (Team t in listOfAllTeam)
            {
                if (groupA.addTeam(t) == false)
                {
                    if (groupB.addTeam(t) == false)
                    {
                        if (groupC.addTeam(t) == false)
                        {

                            if (groupD.addTeam(t) == false)
                            {
                                if (groupE.addTeam(t) == false)
                                {
                                    if (groupF.addTeam(t) == false)
                                    {
                                        if (groupG.addTeam(t) == false)
                                        {
                                            groupH.addTeam(t);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Round 1/32
            Console.WriteLine("Round 1/32");
            PlayGroup(groupA);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupB);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupC);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupD);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupE);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupF);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupG);
            Console.WriteLine("---------------------------------------------");
            PlayGroup(groupH);
            //Vong 1/16
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Round 1/16");
            List<Team> quarterFinalTeams = new List<Team>();
            quarterFinalTeams.Add(PlayMatch(groupA.getTopTeam()[0], groupB.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupB.getTopTeam()[0], groupA.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupC.getTopTeam()[0], groupD.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupD.getTopTeam()[0], groupC.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupE.getTopTeam()[0], groupF.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupF.getTopTeam()[0], groupE.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupG.getTopTeam()[0], groupH.getTopTeam()[1]));
            quarterFinalTeams.Add(PlayMatch(groupH.getTopTeam()[0], groupG.getTopTeam()[1]));
            //Vong ban ket
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Quarter Final");
            List<Team> semiFinalTeams = new List<Team>();
            for (int i = 0; i < 8; i += 2)
            {
                semiFinalTeams.Add(PlayMatch(quarterFinalTeams[i], quarterFinalTeams[i + 1]));
            }
            //Vong tu ket
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Semi Final");
            List<Team> finalTeams = new List<Team>();
            finalTeams.Add(PlayMatch(semiFinalTeams[0], semiFinalTeams[1]));
            finalTeams.Add(PlayMatch(semiFinalTeams[2], semiFinalTeams[3]));
            //Vong chung ket
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Final");
            Team championTeam = new Team();
            championTeam = PlayMatch(finalTeams[0], finalTeams[1]);
            Console.WriteLine("---------------------------------------------");
            foreach (Team t in listOfAllTeam)
            {
                foreach (Player p in t.players)
                {

                    if (p.goal > highestGoal)
                    {
                        highestGoal = p.goal;
                    }
                }
            }
            foreach (Team t in listOfAllTeam)
            {
                foreach (Player p in t.players)
                {

                    if (p.goal == highestGoal)
                    {
                        Console.WriteLine(p.name + " " + p.number + " from " + t.teamName + " with " + p.goal + " goal " + " is scorer king");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
