using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup
{
    public class Player
    {
        public int number;
        public string name;
        public int goal;
        public int redcard;
        public int yellowcard;
        public Player()
        {
            this.number = 0;
            this.name = "";
            this.goal = 0;
            this.redcard = 0;
            this.yellowcard = 0;
        }
        public Player(int number, string name,int goal,int redcard,int yellowcard)
        {
            this.number = number;
            this.name = name;
            this.goal = goal;
            this.redcard = redcard;
            this.yellowcard = yellowcard;
        }
        public void setPlayerName(string name)
        {
            this.name = name;
        }

        public void setPlayerNumber(int number)
        {
            this.number = number;
        }

        public void setGoal(int goal)
        {
            this.goal = goal;
        }

        public void setRedCard(int redcard)
        {
            this.redcard = redcard;
        }

        public void setYellowCard(int yellowcard)
        {
            this.yellowcard = yellowcard;
        }

        public string getPlayerName()
        {
            if(this.name == "")
            {
                this.name = "default";
            }
            return this.name;
        }

        public int getPlayerNumber()
        {
            if(this.number <= 0)
            {
                this.number = 99;
            }
            return this.number;
        }

        public int getPlayerGoal()
        {
            if(this.goal < 0)
            {
                this.goal = 0;
            }
            return this.goal;
        }

        public int getPlayerRedCard()
        {
            if(this.redcard <0)
            {
                this.redcard = 0;
            }
            return this.redcard;
        }

        public int getPlayerYellowCard()
        {
            if(this.yellowcard<0)
            {
                this.yellowcard = 0;
            }
            return this.yellowcard;
        }

        public void twoYellowToOneRedCard()
        {
            while (this.yellowcard >= 2)
            {
                this.redcard += 1;
                this.yellowcard -= 2;
            }
        }
    }
}
