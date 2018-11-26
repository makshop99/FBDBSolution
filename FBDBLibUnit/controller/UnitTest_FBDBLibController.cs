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
            FTDBLibController oPruefling = new FTDBLibController();
            GameProp oData = new GameProp();
            string sSoll = "stats of a single game";
            oData.Home = "Detroit Lions";
            oData.Away = "Atlanta Falcons";

            string sIst = oPruefling.analyzeGame(oData);
            Assert.AreEqual(sIst, sSoll);
        }
    }
}
