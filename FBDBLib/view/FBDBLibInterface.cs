using FBDBLib.controller;
using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// added a comment for testing azure devops ci build.
// and another comment added.
namespace FBDBLib.view
{
    public class FBDBLibInterface
    {
        private FTDBLibController oController;

        /// <summary>
        /// this method takes init data and initializes the class
        /// </summary>
        /// <param name="sData"></param>
        /// <returns>
        ///  0 -> no error 
        /// -1 -> no offense file delivered
        /// -2 -> no defense path delivered
        /// -3 -> no gameday path delivered 
        /// </returns>
        public int init(FileProp oData)
        {
            // check data
            if (oData.OffenseFile.Length < 1) return -1;
            if (oData.DefenseFile.Length < 1) return -2;
            if (oData.GamedayFile.Length < 1) return -5; // changed from -3 for azure devops unit tests

            // init controller
            oController = new FTDBLibController();
            oController.init(oData);
            return 0;
        }

        /// <summary>
        ///  this method gets data and calculates a whole gameday
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public string getGameDay(string sGameday)
        {
            if (sGameday.Length <= 0) return "error: no gameday passed";
            return oController.analyzeGameday(sGameday);
        }


        /// <summary>
        ///  this method calculates a single game
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public string getGame(GameProp oData)
        {
            if (oData == null) return "error: no gameday passed";
            if (oData.Home.Length <= 0) return "error: no hometeam passed";
            if (oData.Away.Length <= 0) return "error: no awayteam passed";
            return oController.analyzeGame(oData);
        }
    }
}


