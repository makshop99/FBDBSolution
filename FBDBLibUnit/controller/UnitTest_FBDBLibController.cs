using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FBDBLib.controller;
using FBDBLib.data;

namespace FBDBLibUnit.controller
{
    [TestClass]
    public class UnitTest_FBDBLibController
    {
        [TestMethod]
        public void FBDBLibController_analyzeGame_OK()
        {

            string sOffenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\offense.htm";
            string sDefenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\defense.htm";
            string sScheduleFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\schedule.htm";
           
            sOffenseFile = "https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            sDefenseFile = "https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            sScheduleFile = "https://www.footballdb.com/games/index.html"; // use only reely...
            

            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;


            FTDBLibController oPruefling = new FTDBLibController();
            oPruefling.init(oData);
            string sHomeTeam = "Detroit Lions";
            string sAwayTeam = "Miami Dolphins";
            string sSoll = "Miami Dolphins @ Detroit Lions - 97 : 103 (6)";

            // create ist string
            GameProp oReturn = oPruefling.analyseGame(sAwayTeam, sHomeTeam);
            string sIst = oReturn.Away + " @ " + oReturn.Home + " - ";
            sIst += oReturn.AwayScore + " : " + oReturn.HomeScore + " (" + oReturn.ScoreDiff + ")";

            Assert.AreEqual(sIst, sSoll);
        }
    }
}