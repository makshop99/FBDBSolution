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
            if (oData.Offense.Length < 1) return -1;
            if (oData.Defense.Length < 1) return -2;
            if (oData.Gameday.Length < 1) return -3;

            // init controller
            oController = new FTDBLibController();            
            return oController.init(oData);
        }

        /// <summary>
        ///  this method gets data and calculates a whole gameday
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public List<GameProp> getGameDay(string sGameday)
        {
            if (sGameday.Length <= 0) return null;
            return oController.analyzeGameday(sGameday);
        }


        /// <summary>
        ///  this method calculates a single game
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public GameProp getGame(string sAwayTeam, string sHomeTeam)
        {
            if (sHomeTeam.Length <= 0) return null;
            if (sAwayTeam.Length <= 0) return null;
            return oController.analyseGame(sAwayTeam,sHomeTeam);
        }
    }
}


