using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FBDBLib.data;

namespace FBDBLibUnit.view
{
    [TestClass]
    public class UnitFBDBLibInterface_FBDBLibInterface
    {


        #region init tests - local paths
        [TestMethod]
        public void FBDBLibInterface_init_FilesOk()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"c:\dummy\offense.txt";
            oData.Defense = @"c:\dummy\offense.txt";
            oData.Gameday = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, 0);
        }

        [TestMethod]
        public void FBDBLibInterface_init_ScheduleFileEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"c:\dummy\offense.txt";
            oData.Defense = @"c:\dummy\offense.txt";
            oData.Gameday = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -3);
        }

        [TestMethod]
        public void FBDBLibInterface_init_OffenseFilesEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"";
            oData.Defense = @"c:\dummy\offense.txt";
            oData.Gameday = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -1);
        }

        [TestMethod]
        public void FBDBLibInterface_init_DefenseFileEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"c:\dummy\offense.txt";
            oData.Defense = @"";
            oData.Gameday = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -2);
        }
        #endregion

        #region init tests - URL
        [TestMethod]
        public void FBDBLibInterface_init_URLsOk()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, 0);
        }

        [TestMethod]
        public void FBDBLibInterface_init_DefensURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -2);
        }

        [TestMethod]
        public void FBDBLibInterface_init_OffensURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -1);
        }

        [TestMethod]
        public void FBDBLibInterface_init_ScheduleURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.Offense = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.Defense = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.Gameday = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -3);
        }
        #endregion


        #region gameday tests
        /*
        [TestMethod]
        public void FBDBLibInterface_GamedayOK()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"c:\dummy\offense.txt";
            oData.DefenseFile = @"c:\dummy\offense.txt";
            oData.GamedayFile = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, 0);
        }
        */
        #endregion

        #region game tests
        [TestMethod]
        public void FBDBLibInterface_game_OK()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp pPaths = new FileProp();
            pPaths.Offense = @"c:\dummy\offense.txt";
            pPaths.Defense = @"c:\dummy\defense.txt";
            pPaths.Gameday = @"c:\dummy\schedule.txt";
            int iReturn = oPruefling.init(pPaths);

            GameProp oData = new GameProp();
            oData.Home = "Detroit Lions";
            oData.Away = "Atlanta Falcons";
            string sSoll = "stats of a single game";
            string sIst = oPruefling.getGame(oData);
            Assert.AreEqual(sIst, sSoll);
        }

        [TestMethod]
        public void FBDBLibInterface_game_HometeamEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp pPaths = new FileProp();
            pPaths.Offense = @"c:\dummy\offense.txt";
            pPaths.Defense = @"c:\dummy\defense.txt";
            pPaths.Gameday = @"c:\dummy\schedule.txt";
            int iReturn = oPruefling.init(pPaths);

            GameProp oData = new GameProp();
            oData.Home = "";
            oData.Away = "Atlanta Falcons";
            string sSoll = "error: no hometeam passed";
            string sIst = oPruefling.getGame(oData);
            Assert.AreEqual(sIst, sSoll);
        }

        [TestMethod]
        public void FBDBLibInterface_game_AwayteamEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp pPaths = new FileProp();
            pPaths.Offense = @"c:\dummy\offense.txt";
            pPaths.Defense = @"c:\dummy\defense.txt";
            pPaths.Gameday = @"c:\dummy\schedule.txt";
            int iReturn = oPruefling.init(pPaths);

            GameProp oData = new GameProp();
            oData.Home = "Detroit Lions";
            oData.Away = "";
            string sSoll = "error: no awayteam passed";
            string sIst = oPruefling.getGame(oData);
            Assert.AreEqual(sIst, sSoll);
        }

        [TestMethod]
        public void FBDBLibInterface_game_NoData()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp pPaths = new FileProp();
            pPaths.Offense = @"c:\dummy\offense.txt";
            pPaths.Defense = @"c:\dummy\defense.txt";
            pPaths.Gameday = @"c:\dummy\schedule.txt";
            int iReturn = oPruefling.init(pPaths);

            string sSoll = "error: no gameday passed";
            string sIst = oPruefling.getGame(null);
            Assert.AreEqual(sIst, sSoll);
        }
        #endregion
    }


}
