using FBDBLib.data;
using FBDBLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.controller
{
    public class FTDBLibController
    {
        private DataReader oFileAccess = new DataReader();
        #region public interface

        /// <summary>
        /// public init method
        /// </summary>
        /// <param name="oData"></param>
        /// <returns>
        ///  0 - initialsation ok
        /// -1 - parameters empty
        /// </returns>
        public void init(FileProp oData)
        {
            oFileAccess.init(oData);
        }
        

        public string analyzeGameday(string sGameday)
        {
            // gameday auslesen
            List<GameProp> oGameday = new List<GameProp>();
            oGameday = oFileAccess.getSchedule(sGameday);

            // spiele analysieren
            DataAnalyzer oStats = new DataAnalyzer();
            // iterativ alle Spiele analyieren, ein gemeinsamen String erzeugen

            return "stats of all games";
        }

        public string analyzeGame(GameProp oGame)
        {
            // spiel anaysieren                       
            return new DataAnalyzer().analyzeGame(oGame);
        }
        #endregion

        #region data validation
        // checks the content of the paths again
        private int checkPaths(FileProp oData)
        {
            if (oData.OffenseFile.Length == 0) return -1;
            if (oData.DefenseFile.Length == 0) return -1;
            if (oData.GamedayFile.Length == 0) return -1;
            return 0;
        }

        #endregion
    }
}
