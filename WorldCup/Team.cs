using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Team
    {
        public string teamName;
        public string coachName;
        public List<string> assistants;
        public string doctorName;
        public List<Player> players;
        public int totalPoint;
        public int totalGoal;
        public int totalLossGoal;
        public int goalDeficit;
        public int numOfCard;
        public Team()
        {
            this.teamName = "";
            this.coachName = "";
            this.assistants = new List<string>();
            this.doctorName = "";
            this.players = new List<Player>();
            this.totalPoint = 0;
            this.totalGoal = 0;
            this.totalLossGoal = 0;
            this.goalDeficit = 0;
            this.numOfCard = 0;
        }

        public void setteamName(string teamName)
        {
            if(teamName=="")
            {
                teamName = "XYZ";
            }
            this.teamName = teamName;
        }
        public void setcoachName(string coachName)
        {
            if (coachName == "")
            {
                coachName = "XYZ";
            }
            this.coachName = coachName;
        }
        public void setdoctorName(string doctorName)
        {
            if (doctorName == "")
            {
                doctorName = "DEF";
            }
            this.doctorName = doctorName;
        }
        public void settotalGoal(int totalGoal)
        {
            this.totalGoal = totalGoal;
        }
        public void setTeamCard(int totalCard)
        {
            if(totalCard<0)
            {
                totalCard = 0;
            }
            this.numOfCard = totalCard;
        }
        public void settotalLossGoal(int totalLossGoal)
        {
            this.totalLossGoal = totalLossGoal;
        }
        public void addDefaultPlayer()
        {
            if (this.players.Count() == 0)
            {
                for (int i = 1; i < 12; i++)
                {
                    Player player = new Player();
                    player.name = "default";
                    player.number = i;
                    this.players.Add(player);
                }
            }
        }
        public string getteamName()
        {
                return this.teamName;
        }
        public string getcoachName()
        {
           return this.coachName;
        }
        public int getnumofAssitants()
        {
            if(this.assistants.Count()<=0)
            {
                this.assistants.Add("default");
            }
            return this.assistants.Count();
        }
        public string getdoctorName()
        {
            return this.doctorName;
        }
        public int getnumofPlayers()
        {
            return this.players.Count();
        }
        public int gettotalPoint()
        {
            return this.totalPoint;
        }
        public int gettotalGoal()
        {
            return this.totalGoal;
        }
        public int gettotalLossGoal()
        {
            return this.totalLossGoal;
        }
        public int getgoalDeficit()
        {
            this.goalDeficit = totalGoal - totalLossGoal;
            return this.goalDeficit;
        }
        public int getNumofCard()
        {
            foreach (Player p in players)
            {
                this.numOfCard += p.redcard * 2 + p.yellowcard;
            }
            return this.numOfCard;
        }
        public void addteamGoal(int goal)
        {
            this.totalGoal += goal;
        }
        public void addteamLossGoal(int lossGoal)
        {
            this.totalLossGoal += lossGoal;
        }
    }
}
