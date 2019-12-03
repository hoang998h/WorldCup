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
        public string getGroupName()
        {
            if(this.groupName=="")
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
                for (int j = i+1; j < 4; j++)
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
        public int getTopPoint()
        {
            int topPoint = 0;
            foreach(Team t in this.teamList)
            {
                if (t.totalPoint>topPoint)
                {
                    topPoint = t.totalPoint;
                }
            }
            return topPoint;
        }
        public List<Team> getTop1Team()
        {
            Team topTeam = new Team();
            List<Team> listOfTopTeam = new List<Team>();
            foreach(Team t in this.teamList)//lay cac doi co diem cao nhat vao list
            {
                if(t.totalPoint==getTopPoint())
                {
                    listOfTopTeam.Add(t);
                }
            }
            if(listOfTopTeam.Count>1) // neu so doi co diem cao nhat nhieu hon 1 xet hieu so
            {
                for(int i=0;i<listOfTopTeam.Count;i++) // sap xep doi co hieu so lon hon o vi tri cao hon
                {
                    for (int j = i + 1; j < listOfTopTeam.Count; j++)
                    {
                        if (listOfTopTeam[i].goalDeficit < listOfTopTeam[j].goalDeficit)
                        {
                            Team team = new Team();
                            team = listOfTopTeam[i];
                            listOfTopTeam[i] = listOfTopTeam[i + 1];
                            listOfTopTeam[i + 1] = team;
                        }
                    }
                }
            }
            return listOfTopTeam;
        }
    }
}
