using FBDBLib.data;
using FBDBLib.model;
using FDB_Analysis.code.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.controller
{
    public class FTDBLibController
    {
        #region tasks
        /*
         * methode init() 
         * ist fertig
         * 
         * methode analyzeGameday()
         * aufruf der analyse methode in der statiistik klasse muss noch
         * eingebaut werden. ausserdem der output als string.
         * 
         * analyzeGame()
         * die gesamte methode muss noch implementiert werden.
         */
        #endregion

        #region members
        private DataReader oFileAccess = new DataReader();
        private FileProp oRawData = new FileProp();
        private ContentReader oContent = new ContentReader();
        private DataAnalyser oAnalyser = new DataAnalyser();
        #endregion



        #region public interface

        /// <summary>
        /// this method initialises the class. it reads out the raw data and converts it to content data.
        /// </summary>
        /// <param name="oData"></param>
        /// <returns>
        ///  0 - initialsation ok
        /// -1 - parameters empty
        /// -2 -  error while reading raw data
        /// </returns>
        /// <status>ready</status>
        public int init(FileProp oData)
        {
            // read raw file contents
            if (oFileAccess.init(oData) != 0) return -2;
            oRawData = oFileAccess.getAllRawData();
            if (oRawData == null) return -2;

            // read content data
            return oContent.init(oRawData);
        }
        

        public string analyzeGameday(string sGameday)
        {
            // gameday auslesen
            List<GameProp> oGameday = new List<GameProp>();
            //oGameday = oFileAccess.getScheduleDataRaw();

            // spiele analysieren
            DataAnalyser oStats = new DataAnalyser();
            // iterativ alle Spiele analyieren, ein gemeinsamen String erzeugen

            return "stats of all games";
        }

        public string analyseGame(string sAwayTeam, string sHomeTeam)
        {
            // spiel anaysieren                       
            TeamData oAway = oContent.getTeamData(sAwayTeam);
            TeamData oHome = oContent.getTeamData(sHomeTeam);
            return new DataAnalyser().analyseGame(oAway, oHome);
        }
        #endregion

        #region data validation
        // checks the content of the paths again
        private int checkPaths(FileProp oData)
        {
            if (oData.Offense.Length == 0) return -1;
            if (oData.Defense.Length == 0) return -1;
            if (oData.Gameday.Length == 0) return -1;
            return 0;
        }
        #endregion
    }
}
