using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Match
    {
        public Team team1;
        public Team team2;
        public int team1Score;
        public int team2Score;
        public List<Player> team1Players;
        public List<Player> team2Players;
        public List<Player> team1Subs;
        public List<Player> team2Subs;
        public bool subMatch;
        public bool penalty;
        public string result;
        public string matchType;
        Random rnd = new Random();

        public Match()
        {
            this.team1 = new Team();
            this.team2 = new Team();
            this.team1Score = 0;
            this.team2Score = 0;
            this.team1Players = new List<Player>();
            this.team2Players = new List<Player>();
            this.team1Subs = new List<Player>();
            this.team2Subs = new List<Player>();
            this.subMatch = false;
            this.penalty = false;
            this.matchType = "1/32";
        }

        public void setTeam1(Team team1)
        {
            this.team1 = team1;
        }

        public void setTeam2(Team team2)
        {
            this.team2 = team2;
        }

        public Team getTeam1()
        {
            return team1;
        }

        public Team getTeam2()
        {
            return team1;
        }

        public void setTeam1Score(int score)
        {
            if(score<0)
            {
                score = 0;
            }
            this.team1Score = score;
        }

        public void setTeam2Score(int score)
        {
            if (score < 0)
            {
                score = 0;
            }
            this.team2Score = score;
        }

        public int getTeam1Score()
        {
            return team1Score;
        }

        public int getTeam2Score()
        {
            return team2Score;
        }

        public void setTeam1Players()
        {
            this.team1.addDefaultPlayer();
            
            List<int> randomNumbers = Enumerable.Range(0, team1.players.Count()-1).OrderBy(x => rnd.Next()).ToList();
            while (team1Players.Count < 11)
            {
                int index = 0;
                this.team1Players.Add(this.team1.players[randomNumbers[index]]);
                index++;
            }
        }

        public void setTeam2Players()
        {
            this.team2.addDefaultPlayer();
            
            List<int> randomNumbers = Enumerable.Range(0, team2.players.Count() - 1).OrderBy(x => rnd.Next()).ToList();
            while (team2Players.Count < 11)
            {
                int index = 0;
                this.team2Players.Add(this.team2.players[randomNumbers[index]]);
                index++;
            }
        }

        public void setTeam1Subs()
        {
            List<Player> freePlayers = this.team1.players;
            for(int i=0;i<this.team1Players.Count();i++)
            {
                freePlayers.Remove(this.team1Players[i]);
            }
            if(freePlayers.Count>0)
            {
                
                List<int> randomNumbers = Enumerable.Range(0, freePlayers.Count() - 1).OrderBy(x => rnd.Next()).ToList();
                while (team1Subs.Count() < 5)
                {
                    int index = 0;
                    this.team1Subs.Add(freePlayers[randomNumbers[index]]);
                    index++;
                }
            }
        }

        public void setTeam2Subs()
        {
            List<Player> freePlayers = this.team2.players;
            for (int i = 0; i < this.team2Players.Count(); i++)
            {
                freePlayers.Remove(this.team2Players[i]);
            }

            if (freePlayers.Count > 0)
            {
                
                List<int> randomNumbers = Enumerable.Range(0, freePlayers.Count() - 1).OrderBy(x => rnd.Next()).ToList();
                while (team1Subs.Count() < 5)
                {
                    int index = 0;
                    this.team2Subs.Add(freePlayers[randomNumbers[index]]);
                    index++;
                }
            }
        }

        public int getNumofTeam1Players()
        {
            return this.team1Players.Count();
        }

        public int getNumofTeam2Players()
        {
            return this.team2Players.Count();
        }

        public int getNumofTeam1Subs()
        {
            return this.team1Subs.Count();
        }

        public int getNumofTeam2Subs()
        {
            return this.team2Subs.Count();
        }

        public void setMatchType(string matchType)
        {
            this.matchType = matchType;
        }

        public string getMatchType()
        {
            return this.matchType;
        }
        public void updateTeam1Score()
        {
            this.team1.addteamGoal(this.team1Score);
            this.team1.addteamLossGoal(this.team2Score);
        }
        public void updateTeam2Score()
        {
            this.team2.addteamGoal(this.team2Score);
            this.team2.addteamLossGoal(this.team1Score);
        }
        public string playMatch()
        {
            randomRedCard();
            randomYellowCard();
            this.team1Score = 0;
            this.team2Score = 0;
            this.team1Score += rnd.Next(0, 5);
            this.team2Score += rnd.Next(0, 5);
            if (checksubMatch() && matchType.CompareTo("1/32") != 0) 
            {
                return playSubHalf();
            }
            return matchResult();
        }

        public string matchResult()
        {
            updateTeam1Score();
            updateTeam2Score();
            if (this.team1Score == this.team2Score)
            {
                this.result = "Draw " + team2Score + " - "+ team1Score;
                if (matchType == "1/32")
                {
                    this.team1.totalPoint += 1;
                    this.team2.totalPoint += 1;
                }
            }
            else if (this.team1Score > this.team2Score)
            {
                this.result = team1.teamName + " Win " + team1Score + " - " + team2Score + " vs " + team2.teamName ;
                if (matchType == "1/32")
                {
                    this.team1.totalPoint += 3;
                }
            }
            else
            {
                this.result = team2.teamName + " Win " + team2Score + " - " + team1Score + " vs " + team1.teamName ;
                if (matchType == "1/32")
                {
                    this.team2.totalPoint += 3;
                }
            }
            return this.result;

        }

        public bool checksubMatch()
        {
            if (team1Score == team2Score)
            {
                this.subMatch = true;
            }
            return this.subMatch;
        }

        public string playSubHalf()
        {
            randomRedCard();
            randomYellowCard();
            this.team1Score += rnd.Next(0, 3);
            this.team2Score += rnd.Next(0, 3);
            if (this.team1Score == this.team2Score)
            {
                this.team1Score += rnd.Next(0, 3);
                this.team2Score += rnd.Next(0, 3);
                if (this.team1Score == this.team2Score)
                {
                    return playPenalty();
                }
                else
                {
                    return matchResult() + " ---Sub Half";
                }
            }
            return matchResult() + " ---Sub Half";
        }

        public string playPenalty()
        {
            int team1Penalty = rnd.Next(0, 5);
            int team2Penalty = rnd.Next(0, 5);
            while (team1Penalty == team2Penalty)
            {
                team1Penalty += rnd.Next(0, 1);
                team2Penalty += rnd.Next(0, 1);
                if (team1Penalty != team2Penalty)
                {
                    return penaltyResult(team1Penalty, team2Penalty);
                }
            }
            return penaltyResult(team1Penalty, team2Penalty);
        }

        public string penaltyResult(int team1Penalty, int team2Penalty)
        {
            if (team1Penalty > team2Penalty)
            {
                this.result = team1.teamName + " Win " + team1Score + " - " + team2Score + " vs " + team2.teamName + " ---Penalty " + team1Penalty + " - " + team2Penalty;
            }
            else if (team1Penalty < team2Penalty)
            {
                this.team2.totalPoint += 3;
                this.result = team2.teamName + " Win " + team2Score + " - " + team1Score + " vs " + team1.teamName + " ---Penalty " + team2Penalty + " - " + team1Penalty;
            }
            return this.result;
        }

        public bool team1PlayersScore()
        {
            bool result = false;
            for(int i=1;i<=this.team1Score;i++)
            {
                int index = rnd.Next(0, team1Players.Count() - 1);
                team1Players[index].goal++;
                result = true;
            }
            return result;
        }

        public bool team2PlayersScore()
        {
            bool result = false;
            for (int i = 1; i <= this.team2Score; i++)
            {
                int index = rnd.Next(0, team2Players.Count() - 1);
                team2Players[index].goal++;
                result = true;
            }
            return result;
        }
        public int team1PlayersRedCard()
        {
            int index = rnd.Next(1, team1Players.Count() - 1);
            team1Players[index].redcard++;
            return index;
        }
        public int team2PlayersRedCard()
        {
            int index = rnd.Next(1, team2Players.Count() - 1);
            team2Players[index].redcard++;
            return index;
        }
        public int team1PlayersYellowCard()
        {
            int index = rnd.Next(1, team1Players.Count() - 1);
            team1Players[index].yellowcard++;
            return index;
        }
        public int team2PlayersYellowCard()
        {
            int index = rnd.Next(1, team2Players.Count() - 1);
            team2Players[index].yellowcard++;
            return index;
        }
        public void randomYellowCard()
        {
            int random = rnd.Next(0, 100);
            if (random % 10 == 0) 
            {
                team1PlayersYellowCard();
            }
            else if (random % 10 == 1)
            {
                team2PlayersYellowCard();
            }
        }
        public void randomRedCard()
        {
            int random = rnd.Next(0, 100);
            if (random % 10 == 3)
            {
                team1PlayersYellowCard();
            }
            else if (random % 10 == 7)
            {
                team2PlayersYellowCard();
            }
        }

    }
}
