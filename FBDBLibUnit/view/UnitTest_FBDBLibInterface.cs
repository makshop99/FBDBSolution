using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FBDBLib.data;

namespace FBDBLibUnit.view
{
    [TestClass]
    public class UnitTest_FBDBLibInterface
    {


        #region testdata local paths
        [TestMethod]
        public void Test_initFilesOk()
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

        [TestMethod]
        public void Test_initGamedayFileEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"c:\dummy\offense.txt";
            oData.DefenseFile = @"c:\dummy\offense.txt";
            oData.GamedayFile = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -3);
        }

        [TestMethod]
        public void Test_initOffenseFilesEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"";
            oData.DefenseFile = @"c:\dummy\offense.txt";
            oData.GamedayFile = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -1);
        }

        [TestMethod]
        public void Test_initDefenseFileEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"c:\dummy\offense.txt";
            oData.DefenseFile = @"";
            oData.GamedayFile = @"c:\dummy\offense.txt";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -2);
        }
        #endregion

        #region testdata url paths
        [TestMethod]
        public void Test_initURLsOk()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.DefenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.GamedayFile = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, 0);
        }

        [TestMethod]
        public void Test_initDefensURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.DefenseFile = @"";
            oData.GamedayFile = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -2);
        }

        [TestMethod]
        public void Test_initOffensURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"";
            oData.DefenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.GamedayFile = @"https://www.footballdb.com/games/index.html";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -1);
        }

        [TestMethod]
        public void Test_initGamedayURLEmpty()
        {
            FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
            FileProp oData = new FileProp();
            oData.OffenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            oData.DefenseFile = @"https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            oData.GamedayFile = @"";

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            Assert.AreEqual(iReturn, -3);
        }
        #endregion
    }


}
