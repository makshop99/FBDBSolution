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
            //sScheduleFile = "https://www.footballdb.com/games/index.html";
            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;


            FTDBLibController oPruefling = new FTDBLibController();
            oPruefling.init(oData);
            string sHomeTeam = "Detroit Lions";
            string sAwayTeam = "Miami Dolphins";
            string sSoll = "Miami Dolphins @ Detroit Lions - 97:103";

            string sIst = oPruefling.analyseGame(sAwayTeam, sHomeTeam);
            Assert.AreEqual(sIst, sSoll);
        }
    }
}
