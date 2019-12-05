using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Group
    {
        public string groupName;
        public List<Team> teamList;
        public List<string> result;
        public Group()
        {
            this.groupName = "";
            this.teamList = new List<Team>();
            this.result = new List<string>();
        }
        public void setGroupName(string groupName)
        {
            this.groupName = groupName;
        }
        public void setGroupPoint(List<int> listPoint)
        {
            for (int i = 0; i < 4; i++)
            {
                this.teamList[i].totalPoint = listPoint[i];
            }
        }
        public void setGroupGoalDeficit(List<int> listDeficit)
        {
            for (int i = 0; i < 4; i++)
            {
                this.teamList[i].goalDeficit = listDeficit[i];
            }
        }
        public void setTeamList()
        {
            if (this.teamList.Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Team team = new Team();
                    team.setteamName("team " + (i + 1));
                    this.teamList.Add(team);
                }
            }
        }
        public void setTeamCard(List<int> listCard)
        {
            for (int i = 0; i < 4; i++)
            {
                this.teamList[i].setTeamCard(listCard[i]);
            }
        }
        public string getGroupName()
        {
            if (this.groupName == "")
            {
                this.groupName = "A";
            }
            return this.groupName;
        }
        public List<Team> getTeamList()
        {
            return this.teamList;
        }
        public void playFirstRound()
        {
            this.result.Clear();
            this.result.Add("Luot di vong bang " + this.groupName);
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    Match match = new Match();
                    match.setTeam1(teamList[i]);
                    match.setTeam2(teamList[j]);
                    match.setTeam1Players();
                    match.setTeam2Players();
                    this.result.Add(match.playMatch());
                }
            }
        }
        public void playSecondRound()
        {
            this.result.Add("Luot ve vong bang " + this.groupName);
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    Match match = new Match();
                    match.setTeam1(teamList[i]);
                    match.setTeam2(teamList[j]);
                    match.setTeam1Players();
                    match.setTeam2Players();
                    this.result.Add(match.playMatch());
                }
            }
        }
        public int getTopNPoint(int n)
        {
            List<int> topNPoint = new List<int>();
            foreach (Team t in this.teamList)
            {
                topNPoint.Add(t.totalPoint);
            }
            topNPoint.Sort();
            return topNPoint[n];
        }
        public int getTopNGoalDeficit(List<Team> listOfTopTeam, int n)
        {
            List<int> teamGoalDeficit = new List<int>();
            foreach (Team t in listOfTopTeam)
            {
                teamGoalDeficit.Add(t.goalDeficit);
            }
            teamGoalDeficit.Sort();
            return teamGoalDeficit[n];
        }
        public int getTopNCard(List<Team> listOfTopTeam, int n)
        {
            List<int> teamCard = new List<int>();
            foreach (Team t in listOfTopTeam)
            {
                int numOfCard = t.getNumofCard();
                teamCard.Add(numOfCard);
            }
            teamCard.Sort();
            return teamCard[n];
        }
        public int getNumOfCard(Team team)
        {
            int numOfCard = 0;
            foreach (Player p in team.players)
            {
                numOfCard += p.yellowcard + p.redcard * 2;
            }
            return numOfCard;
        }
        public List<Team> getTopTeam()
        {
            Team topTeam = new Team();
            int numOfTopTeam = 0;
            List<Team> listOfTopTeam = this.teamList;
            listOfTopTeam= listOfTopTeam.OrderByDescending(t => t.totalPoint).ToList();
            foreach (Team t in listOfTopTeam)
            {
                if (t.totalPoint == getTopNPoint(3))
                {
                    numOfTopTeam++;
                }
            }
            if (numOfTopTeam > 1)
            {
                numOfTopTeam = 0;
                listOfTopTeam = listOfTopTeam.Where(t => t.totalPoint == getTopNPoint(3)).ToList();
                listOfTopTeam = listOfTopTeam.OrderByDescending(t => t.goalDeficit).ToList();
                foreach (Team t in listOfTopTeam)
                {
                    if (t.goalDeficit == getTopNGoalDeficit(listOfTopTeam, listOfTopTeam.Count - 1))
                    {
                        numOfTopTeam++;
                    }
                }
                if (numOfTopTeam > 1)
                {
                    numOfTopTeam = 0;
                    listOfTopTeam = listOfTopTeam.Where(t => t.goalDeficit == getTopNGoalDeficit(listOfTopTeam, listOfTopTeam.Count - 1)).ToList();
                    listOfTopTeam = listOfTopTeam.OrderBy(t => t.numOfCard).ToList();
                    foreach (Team t in listOfTopTeam)
                    {
                        if (t.numOfCard == getTopNCard(listOfTopTeam, 0))
                        {
                            numOfTopTeam++;
                        }
                    }
                    if(numOfTopTeam>1)
                    {
                        for(int i=0;i<listOfTopTeam.Count;i++)
                        {
                            for(int j=i+1;j<listOfTopTeam.Count;j++)
                            {
                                int confrontationScore = 0;
                                foreach(string s in this.result)
                                {
                                    if(s.Contains(listOfTopTeam[i].teamName + " Win " + " vs " + listOfTopTeam[j].teamName))
                                    {
                                        confrontationScore++;
                                    }
                                    else if(s.Contains(listOfTopTeam[j].teamName + " Win " + " vs " + listOfTopTeam[i].teamName))
                                    {
                                        confrontationScore--;
                                    }
                                }
                                if (confrontationScore < 0)
                                {
                                    Team team = new Team();
                                    team = listOfTopTeam[i];
                                    listOfTopTeam[i] = listOfTopTeam[i + 1];
                                    listOfTopTeam[i + 1] = team;
                                }
                            }
                        }
                    }
                }
            }

            return listOfTopTeam;
        }

    }
}
