﻿using System;
using WorldCup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestTeam
{
    [TestClass]
    public class UnitTest
    {
        //Player Test


        Player player = new Player();
        [TestMethod]
        public void playerNameIsNotNull()
        {
            player.setPlayerName("");
            string name = player.getPlayerName();
            Assert.IsNotNull(name);
        }
        [TestMethod]
        public void playerNameIsNotEmpty()
        {
            player.setPlayerName("");
            string name = player.getPlayerName();
            Assert.AreNotSame("", name);
        }
        [TestMethod]
        public void playerNumberIsNotNegative()
        {
            player.setPlayerNumber(-5);
            int number = player.getPlayerNumber();
            Assert.IsTrue(number > 0,"So cua cau thu lon hon 0");
        }
        [TestMethod]
        public void playerGoalIsNotNegative()
        {
            player.setGoal(-3);
            int goal = player.getPlayerGoal();
            Assert.IsTrue(goal >= 0, "So cua cau thu lon hon 0");
        }
        [TestMethod]
        public void playerRedCardIsNotNegative()
        {
            player.setRedCard(-1);
            int redCard = player.getPlayerRedCard();
            Assert.IsTrue(redCard >= 0, "So cua cau thu lon hon 0");
        }
        [TestMethod]
        public void playerYellowCardIsNotNegative()
        {
            player.setYellowCard(-3);
            int yellowCard = player.getPlayerYellowCard();
            Assert.IsTrue(yellowCard >= 0, "So cua cau thu lon hon 0");
        }
        [TestMethod]
        public void player2YellowTo1RedCard()
        {
            player.setYellowCard(3);
            player.twoYellowToOneRedCard();
            int redcard = player.getPlayerRedCard();
            Assert.AreEqual(1, redcard);
        }
        


        //Team Test
        Team team = new Team();

        [TestMethod]
        public void teamNameIsNotNull()
        {
            string teamName = team.getteamName();
            Assert.IsNotNull(teamName);
        }
        [TestMethod]
        public void teamNameIsNotEmpty()
        {
            team.setteamName("");
            string teamName = team.getteamName();
            int length = teamName.Length;
            Assert.AreNotEqual(0, length);
        }
        [TestMethod]
        public void coachNameIsNotNull()
        {
            string coachName = team.getcoachName();
            Assert.IsNotNull(coachName);
        }
        [TestMethod]
        public void coachNameIsNotEmpty()
        {
            team.setcoachName("");
            string coachName = team.getcoachName();
            int length = coachName.Length;
            Assert.AreNotEqual(0, length);
        }
        [TestMethod]
        public void numofAssistantsSmallerThan4()
        {
            int numofAssistants = team.getnumofAssitants();
            Assert.IsTrue(numofAssistants <= 3, "So luong tro ly nho hon hoac bang 3");
        }
        public void numofAssistantsGreaterThan0()
        {
            int numofAssistants = team.getnumofAssitants();
            Assert.IsTrue(numofAssistants >0, "So luong tro ly nho hon hoac bang 3");
        }
        [TestMethod]
        public void doctorNameIsNotNull()
        {
            string doctorName = team.getdoctorName();
            Assert.IsNotNull(doctorName);
        }
        [TestMethod]
        public void doctorNameIsNotEmpty()
        {
            team.setdoctorName("");
            string doctorName = team.getdoctorName();
            int length = doctorName.Length;
            Assert.AreNotEqual(0, length);
        }
        [TestMethod]
        public void numofPlayersLessThan23()
        {
            int numofAssistants = team.getnumofPlayers();
            Assert.IsTrue(numofAssistants <= 22, "So luong cau thu nho hon hoac bang 22");
        }
        [TestMethod]
        public void numofPlayersMoreThan6()
        {
            team.addDefaultPlayer();
            int numofAssistants = team.getnumofPlayers();
            Assert.IsTrue(numofAssistants >6 , "So luong cau thu lon hon 0");
        }
        [TestMethod]
        public void totalPointNotNegative()
        {
            int point = team.gettotalPoint();
            Assert.IsTrue(point >= 0, "Diem cua doi bong duong");
        }
        [TestMethod]
        public void totalGoalNotNegative()
        {
            int goal = team.gettotalGoal();
            Assert.IsTrue(goal >= 0, "Tong so ban thang duong");
        }
        [TestMethod]
        public void totalLossGoalNegative()
        {
            int lossGoal = team.gettotalLossGoal();
            Assert.IsTrue(lossGoal >= 0, "Tong so ban thua duong");
        }
        [TestMethod]
        public void negativeGoalDeficit()
        {
            team.settotalGoal(3);
            team.settotalLossGoal(5);
            int goalDeficit=team.getgoalDeficit();
            Assert.AreEqual(-2, goalDeficit);
        }
        [TestMethod]
        public void positiveGoalDeficit()
        {
            team.settotalGoal(5);
            team.settotalLossGoal(3);
            int goalDeficit = team.getgoalDeficit();
            Assert.AreEqual(2, goalDeficit);
        }
        [TestMethod]
        public void zeroGoalDeficit()
        {
            team.settotalGoal(3);
            team.settotalLossGoal(3);
            int goalDeficit = team.getgoalDeficit();
            Assert.AreEqual(0, goalDeficit);
        }

        //Match test


        Match match = new Match();

        [TestMethod]
        public void team1IsNotNull()
        {
            Team team1= match.getTeam1();
            Assert.IsNotNull(team1);
        }
        [TestMethod]
        public void team2IsNotNull()
        {
            Team team2 = match.getTeam2();
            Assert.IsNotNull(team2);
        }
        [TestMethod]
        public void Team1ScoreNotNegative()
        {
            int score = match.getTeam1Score();
            Assert.IsTrue(score >= 0, "So ban thang random lon hon khong");
        }
        [TestMethod]
        public void Team2ScoreNotNegative()
        {
            
            int score = match.getTeam2Score();
            Assert.IsTrue(score >= 0, "So ban thang random lon hon khong");
        }
        [TestMethod]
        public void numofTeam1PlayersMoreThan6()
        {
            match.setTeam1Players();
            int numofPlayers = match.getNumofTeam1Players();
            Assert.IsTrue(numofPlayers > 6, "So cau thu chinh thuc nhieu hon 6");
        }
        [TestMethod]
        public void numofTeam1PlayersLessThan12()
        {
            int numofPlayers = match.getNumofTeam1Players();
            Assert.IsTrue(numofPlayers < 12, "So cau thu chinh thuc it hon 12");
        }
        [TestMethod]
        public void numofTeam2PlayersMoreThan6()
        {
            match.setTeam2Players();
            int numofPlayers = match.getNumofTeam2Players();
            Assert.IsTrue(numofPlayers > 6, "So cau thu chinh thuc nhieu hon 6");
        }
        [TestMethod]
        public void numofTeam2PlayersLessThan12()
        {
            int numofPlayers = match.getNumofTeam2Players();
            Assert.IsTrue(numofPlayers < 12, "So cau thu chinh thuc it hon 12");
        }
        [TestMethod]
        public void numofTeam1SubNotNegative()
        {
            match.setTeam1Subs();
            int numofSubs = match.getNumofTeam1Subs();
            Assert.IsTrue(numofSubs >= 0, "So cau thu du bi lon hon hoac bang khong");
        }
        [TestMethod]
        public void numofTeam1SubLessThan6()
        {
            match.setTeam1Subs();
            int numofSubs = match.getNumofTeam1Subs();
            Assert.IsTrue(numofSubs < 6, "So cau thu du bi nho hon 6");
        }
        [TestMethod]
        public void numofTeam2SubNotNegative()
        {
            match.setTeam2Subs();
            int numofSubs = match.getNumofTeam2Subs();
            Assert.IsTrue(numofSubs >= 0, "So cau thu du bi lon hon hoac bang khong");
        }
        [TestMethod]
        public void numofTeam2SubLessThan6()
        {
            match.setTeam2Subs();
            int numofSubs = match.getNumofTeam2Subs();
            Assert.IsTrue(numofSubs <6, "So cau thu du bi nho hon 6");
        }
        [TestMethod]
        public void matchResultNotNull()
        {
            string result = match.playMatch(); ;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void matchResultDraw()
        {
            match.setTeam1Score(2);
            match.setTeam2Score(2);
            string result = match.matchResult();
            Assert.IsTrue(result.CompareTo(match.team1.getteamName() + " Draw " + match.getTeam1Score() + " - " + match.getTeam2Score() + " vs " + match.team2.teamName) ==0);
        }
        [TestMethod]
        public void matchResultTeam1Win()
        {
            match.setTeam1Score(5);
            match.setTeam2Score(2);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            string result = match.matchResult();
            Assert.IsTrue(result.CompareTo(match.team1.getteamName() + " Win " + match.getTeam1Score() + " - " + match.getTeam2Score() + " vs " + match.team2.teamName) == 0);
        }
        [TestMethod]
        public void matchResultTeam2Win()
        {
            match.setTeam1Score(2);
            match.setTeam2Score(3);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            string result = match.matchResult();
            Assert.IsTrue(result.CompareTo(match.team2.getteamName() + " Win " + match.getTeam2Score() + " - " + match.getTeam1Score() + " vs " + match.team1.teamName)==0);
        }
        [TestMethod]
        public void checkSubmatch()
        {
            match.setTeam1Score(3);
            match.setTeam2Score(3);
            bool subMatch = match.checksubMatch();
            Assert.IsTrue(subMatch, "Co dien ra hiep phu");
        }
        [TestMethod]
        public void matchTypeIsNotNull()
        {
            string matchType = match.getMatchType();
            Assert.IsNotNull(matchType);
        }
        [TestMethod]
        public void matchTypeIsNotEmpty()
        {
            string matchType = match.getMatchType();
            Assert.IsTrue(matchType.Length > 0);
        }
        [TestMethod]
        public void team1WinpenaltyResult()
        {
            int team1Penalty = 3;
            int team2Penalty = 2;
            string result =match.penaltyResult(team1Penalty, team2Penalty);
            string expectedResult  = match.team1.teamName + " Win " + match.team1Score + " - " + match.team2Score + " vs " + match.team2.teamName + " ---Penalty " + team1Penalty + " - " + team2Penalty;
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void team2WinpenaltyResult()
        {
            int team1Penalty = 1;
            int team2Penalty = 3;
            string result = match.penaltyResult(team1Penalty, team2Penalty);
            string expectedResult = match.team1.teamName + " Win " + match.team1Score + " - " + match.team2Score + " vs " + match.team2.teamName + " ---Penalty " + team2Penalty + " - " + team1Penalty;
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void team1PlayerScore()
        {
            match.setTeam1Players();
            match.playMatch();
            bool result = match.team1PlayersScore();
            if (match.team1Score>0)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }
        [TestMethod]
        public void team2PlayerScore()
        {
            match.setTeam2Players();
            match.playMatch();
            bool result = match.team2PlayersScore();
            if (match.team2Score > 0)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }
        [TestMethod]
        public void team1Get3Point()
        {
            match.setTeam1Score(3);
            match.setTeam2Score(0);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team1Point = match.team1.totalPoint;
            match.matchResult();
            int team1PointAfterWin = match.team1.totalPoint;
            Assert.IsTrue(team1PointAfterWin - team1Point == 3);
        }
        [TestMethod]
        public void team2Get3Point()
        {
            match.setTeam1Score(3);
            match.setTeam2Score(5);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team2Point = match.team2.totalPoint;
            match.matchResult();
            int team2PointAfterWin = match.team2.totalPoint;
            Assert.IsTrue(team2PointAfterWin - team2Point == 3);
        }
        [TestMethod]
        public void team1Get1Point()
        {
            match.setTeam1Score(1);
            match.setTeam2Score(1);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team1Point = match.team1.totalPoint;
            match.matchResult();
            int team1PointAfterWin = match.team1.totalPoint;
            Assert.IsTrue(team1PointAfterWin - team1Point==1);
        }
        [TestMethod]
        public void team2Get1Point()
        {
            match.setTeam1Score(1);
            match.setTeam2Score(1);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team2Point = match.team2.totalPoint;
            match.matchResult();
            int team2PointAfterWin = match.team2.totalPoint;
            Assert.IsTrue(team2PointAfterWin - team2Point==1);
        }
        [TestMethod]
        public void team1Get0Point()
        {
            match.setTeam1Score(0);
            match.setTeam2Score(1);
            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team1Point = match.team1.totalPoint;
            match.matchResult();
            int team1PointAfterWin = match.team1.totalPoint;
            Assert.IsTrue(team1PointAfterWin == team1Point);
        }
        [TestMethod]
        public void team2Get0Point()
        {
            match.setTeam1Score(1);
            match.setTeam2Score(0);

            match.team1.setteamName("team1");
            match.team2.setteamName("team2");
            int team2Point = match.team2.totalPoint;
            match.matchResult();
            int team2PointAfterWin = match.team2.totalPoint;
            Assert.IsTrue(team2PointAfterWin == team2Point);
        }
        [TestMethod]
        public void team1PlayerRedCard()
        {
            match.setTeam1Players();
            int index = match.team1PlayersRedCard();
            Assert.AreEqual(1, match.team1Players[index].redcard);
        }
        [TestMethod]
        public void team2PlayerRedCard()
        {
            match.setTeam2Players();
            int index = match.team2PlayersRedCard();
            Assert.AreEqual(1, match.team2Players[index].redcard);
        }
        [TestMethod]
        public void team1PlayerYellowCard()
        {
            match.setTeam1Players();
            int index = match.team1PlayersYellowCard();
            Assert.AreEqual(1, match.team1Players[index].yellowcard);
        }
        [TestMethod]
        public void team2PlayerYellowCard()
        {
            match.setTeam2Players();
            int index = match.team2PlayersYellowCard();
            Assert.AreEqual(1, match.team2Players[index].yellowcard);
        }
        [TestMethod]
        public void team1GoalIncreaseN()
        {

            match.setTeam1(team);
            int team1goalBeforeMatch = team.gettotalGoal();
            match.setTeam1Score(3);
            match.updateTeam1Score();
            int team1goalAfterMatch = team.gettotalGoal();
            Assert.AreEqual(3, -team1goalBeforeMatch + team1goalAfterMatch);
        }
        [TestMethod]
        public void team1GoalIncrease0()
        {

            match.setTeam1(team);
            int team1goalBeforeMatch = team.gettotalGoal();
            match.setTeam1Score(0);
            match.updateTeam1Score();
            int team1goalAfterMatch = team.gettotalGoal();
            Assert.AreEqual(0, -team1goalBeforeMatch + team1goalAfterMatch);
        }
        [TestMethod]
        public void team2GoalIncreaseN()
        {

            match.setTeam2(team);
            int team2goalBeforeMatch = team.gettotalGoal();
            match.setTeam2Score(5);
            match.updateTeam2Score();
            int team2goalAfterMatch = team.gettotalGoal();
            Assert.AreEqual(5, -team2goalBeforeMatch + team2goalAfterMatch);
        }
        [TestMethod]
        public void team2GoalIncrease0()
        {

            match.setTeam2(team);
            int team2goalBeforeMatch = team.gettotalGoal();
            match.setTeam2Score(0);
            match.updateTeam2Score();
            int team2goalAfterMatch = team.gettotalGoal();
            Assert.AreEqual(0, -team2goalBeforeMatch + team2goalAfterMatch);
        }

        // Group Test


        Group group = new Group();
        [TestMethod]
        public void groupNameIsNotNull()
        {
            group.setGroupName("");
            string groupName = group.getGroupName();
            Assert.IsNotNull(groupName);
        }
        [TestMethod]
        public void groupNameIsNotEmpty()
        {
            group.setGroupName("");
            string groupName = group.getGroupName();
            Assert.IsNotNull(groupName);
        }
        [TestMethod]
        public void numOfTeamListNotNegative()
        {
            group.setTeamList();
            int numOfTeamList = group.teamList.Count;
            Assert.IsTrue(numOfTeamList >= 0);
        }
        [TestMethod]
        public void numOfTeamListIs4()
        {
            group.setTeamList();
            int numOfTeamList = group.teamList.Count;
            Assert.IsTrue(numOfTeamList == 4);
        }
        [TestMethod]
        public void getTopPoint()
        {
            group.setTeamList();
            List<int> listPoint = new List<int> {3,7,8,10 };
            group.setGroupPoint(listPoint);
            int topPoint = group.getTopPoint();
            Assert.AreEqual(10, topPoint);
        }
        [TestMethod]
        public void getTop1TeamWhenPointAreNotTheSame()
        {
            group.setTeamList();
            List<int> listPoint = new List<int> { 3, 7, 8, 10 };
            group.setGroupPoint(listPoint);
            List<Team> listTeam = group.getTop1Team();
            Assert.AreEqual("team 4", listTeam[0].teamName);
        }
        [TestMethod]
        public void getTop1TeamWhenPointAreTheSame()
        {
            group.setTeamList();
            List<int> listPoint = new List<int> { 3, 10, 10, 10 };
            List<int> listDeficit = new List<int> { 2, -1, 4, -7 };
            group.setGroupPoint(listPoint);
            group.setGroupGoalDeficit(listDeficit);
            List<Team> listTeam = group.getTop1Team();
            Assert.AreEqual("team 3", listTeam[0].teamName);
        }
    }
}
