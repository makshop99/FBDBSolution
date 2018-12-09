using FBDBLib.data;
using FDB_Analysis.code.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{

    /*
    Diese neue Klasse muss implementiert werden. Die Aufgabe ist, Rohdaten für Offense, Defense und Schedule zu üebernehmen und diese auszulesen. Die Daten sollen dann in Dictionaries von Props gelesen werden. 
    Folgende Funktionalität ist zu implementieren: 

    init()
        Auslesen der Offense Daten in ein Dict(TeamData) ()
        Auslesen der Defense Daten in ein Dict(TeamData); das gleiche Objekt wie die Offense Daten ()
        Auslesen des gesamten Spielplans in ein Dict(Week(Game)) () 
            Gameday (?)
            Datum des Spiels
            AwayTeam
            AwayPoints (wenn diese schon feststehen)
            HomeTeam
            HomePoints (wenn diese schon feststehen

    getData()
        getTeamStats(team)
        diese Methode liefert die TeamData für das übergebene Team
        getGameDay(week)
    diese Methode liefert ein Array(Game) für alle Spiele einer Woche
  */


    /// <summary>
    /// This class reads the team stats and schedule data from given strings. It converts raw data into structures and props. 
    /// </summary>
    class ContentReader
    {
        #region members
        private Dictionary<string, TeamData> oTeamStats = new Dictionary<string, TeamData>();
        private List<GameProp> oGames = new List<GameProp>();
        #endregion

        #region Interface
        public int init(FileProp oData)
        {

            // Auslesen der Offense Daten in ein Dict(TeamData)
            readOffenseData(oData.Offense);

            // Auslesen der Defense Daten in ein Dict(TeamData); das gleiche Objekt wie die Offense Daten()
            readDefenseData(oData.Defense);

            // Auslesen des gesamten Spielplans in ein Dict(Week(Game)) ()
// [TASK_402] - read the whole season in a data structur (TFS tasks existing
            //readWeek("Week 13", oData.Gameday);

            return 0;
        }


        /// <summary>
        /// this method returns a list of GameProp objects for a given gameday
        /// </summary>
        /// <param name="sGameDay"></param>
        /// <returns></returns>
        public List<GameProp> readGameday(string sGameDay, string sScheduleRaw)
        {
            return readWeek(sGameDay, sScheduleRaw);
        }

        /// <summary>
        /// this method returns the teamdata for a team thats name is given as string
        /// </summary>
        /// <param name="sTeamName"></param>
        /// <returns></returns>
        public TeamData getTeamData(string sTeamName)
        {
            return oTeamStats[sTeamName];
        }
        #endregion

        #region Offense/Defense
        /// <summary>
        /// this method reads out the offense stats of all teams from the raw string the class received as parameter in tne interface method init()
        /// </summary>
        private void readOffenseData(string sOffenseData)
        {           
            int iStartIndex = sOffenseData.IndexOf("<tbody>");
            int iEndIndex = sOffenseData.IndexOf("</tbody>");
            sOffenseData = sOffenseData.Substring(iStartIndex, iEndIndex - iStartIndex);

            iStartIndex = sOffenseData.IndexOf("<tr");
            while (iStartIndex >= 0)
            {
                iEndIndex = sOffenseData.IndexOf("</tr>", iStartIndex);
                string sTeamdata = sOffenseData.Substring(iStartIndex, iEndIndex - iStartIndex);
                iStartIndex = sOffenseData.IndexOf("<tr", iEndIndex + 1);

                TeamData oData = new TeamData();
                for (int iCount = 0; iCount < 10; iCount++)
                {

                    int iTDStart = sTeamdata.IndexOf("<td");
                    int iTDEnd = sTeamdata.IndexOf("</td>");
                    string sData = sTeamdata.Substring(iTDStart, iTDEnd - iTDStart);

                    switch (iCount)
                    {
                        // Teamname
                        case 0:
                            oData.TeamName = readTeamName(sData);
                            break;

                        // Offense Games
                        case 1:
                            oData.OffenseGms = convertString2Double(sData);
                            break;

                        // Offense Points total
                        case 2:
                            oData.OffensePnt = convertString2Double(sData);
                            break;

                        // Offense Points/Game
                        case 3:
                            oData.OffensePntG = convertString2Double(sData);
                            break;

                        // Offense Rushing total
                        case 4:
                            oData.OffenseRsh = convertString2Double(sData);
                            break;

                        // Offense Rushing/Game
                        case 5:
                            oData.OffenseRshG = convertString2Double(sData);
                            break;

                        // Offense Passing total
                        case 6:
                            oData.OffensePss = convertString2Double(sData);
                            break;

                        // Offense Passing/Game
                        case 7:
                            oData.OffensePssG = convertString2Double(sData);
                            break;

                        // Offense Total
                        // Offense Total/Game
                        case 8:
                        case 9:
                            break;

                        default:
                            break;
                    }
                    if (iCount < 9) sTeamdata = sTeamdata.Substring(iTDEnd + 5);
                }
                string sTeamName = oData.TeamName;
                oTeamStats.Add(oData.TeamName, oData);
            }
        }

        /// <summary>
        /// this method reads out the defense stats data for all teams.
        /// </summary>
        /// <param name="sDefenseData"></param>
        private void readDefenseData(string sDefenseData)
        {    
            int iStartIndex = sDefenseData.IndexOf("<tbody>");
            int iEndIndex = sDefenseData.IndexOf("</tbody>");
            sDefenseData = sDefenseData.Substring(iStartIndex, iEndIndex - iStartIndex);

            iStartIndex = sDefenseData.IndexOf("<tr");
            while (iStartIndex >= 0)
            {
                iEndIndex = sDefenseData.IndexOf("</tr>", iStartIndex);
                string sTeamdata = sDefenseData.Substring(iStartIndex, iEndIndex - iStartIndex);
                iStartIndex = sDefenseData.IndexOf("<tr", iEndIndex + 1);
                string sTeamName = readTeamName(sTeamdata);

                TeamData oData = oTeamStats[sTeamName];
                for (int iCount = 0; iCount < 10; iCount++)
                {

                    int iTDStart = sTeamdata.IndexOf("<td");
                    int iTDEnd = sTeamdata.IndexOf("</td>");
                    string sData = sTeamdata.Substring(iTDStart, iTDEnd - iTDStart);

                    switch (iCount)
                    {
                        // Teamname
                        case 0:
                            oData.TeamName = readTeamName(sData);
                            break;

                        // Offense Games
                        case 1:
                            oData.DefenseGms = convertString2Double(sData);
                            break;

                        // Offense Points total
                        case 2:
                            oData.DefensePnt = convertString2Double(sData);
                            break;

                        // Offense Points/Game
                        case 3:
                            oData.DefensePntG = convertString2Double(sData);
                            break;

                        // Offense Rushing total
                        case 4:
                            oData.DefenseRsh = convertString2Double(sData);
                            break;

                        // Offense Rushing/Game
                        case 5:
                            oData.DefenseRshG = convertString2Double(sData);
                            break;

                        // Offense Passing total
                        case 6:
                            oData.DefensePss = convertString2Double(sData);
                            break;

                        // Offense Passing/Game
                        case 7:
                            oData.DefensePssG = convertString2Double(sData);
                            break;

                        // Defense Total
                        // Defense Total/Game
                        case 8:
                        case 9:
                            break;

                        default:
                            break;
                    }
                    if (iCount < 9) sTeamdata = sTeamdata.Substring(iTDEnd + 5);
                }
                oTeamStats[oData.TeamName] = oData;
            }
        }

        /// <summary>
        /// this method reads out the team name from raw data
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        private string readTeamName(string sData)
        {
            string sReturn = "";

            int iStart = sData.IndexOf("<a href=\"/teams/nfl/");
            sReturn = sData.Substring(iStart);
            iStart = sReturn.IndexOf(">");
            sReturn = sReturn.Substring(iStart + 1);
            int iEnd = sReturn.IndexOf("</a>");
            sReturn = sReturn.Substring(0, iEnd);
            return sReturn;
        }

        /// <summary>
        /// this helper method replaces a . by a , for double values in the stats data
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        private string convertString2Double(string sData)
        {
            sData = sData.Replace(".", ",");
            return sData.Substring(4);
        }
        #endregion

        #region GameDay
        /// <summary>
        /// this method reads out all games for a given gameday from the raw data.
        /// if the gameday is in the past and results are included the scores will be read as well. 
        /// Otherwise the scores will be 0.
        /// </summary>
        /// <param name="sGameDay">gameday in the format "Week X"</param>
        /// <param name="sData">raw data to read from</param>
        /// <returns></returns>
        private List<GameProp> readWeek(string sGameDay, string sData)
        {            
            var lWeek = new List<GameProp>();

            // cut out the desired gameday from raw data
            string sWeek = getGameDay(sData, sGameDay);
            
            // read out the games with details from the gameday data
            lWeek = readGameDay(sWeek);

            // Return
            return lWeek;
        }

        /// <summary>
        /// this method cuts out the desired gameday from raw data
        /// </summary>
        /// <param name="sDase">raw data with games for one gameday</param>
        /// <param name="sGameday">>gameday in the format "Week X"</param>
        /// <returns></returns>
        private string getGameDay(string sData, string sGameday)
        {
            int iWeek = sData.IndexOf(sGameday);
            int iVon = sData.IndexOf("<tbody", iWeek);
            int iBis = sData.IndexOf("</tbody", iVon);

            return sData.Substring(iVon, iBis - iVon);
        }

        /// <summary>
        /// this method reads out the games with details from the gameday data
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        private List<GameProp> readGameDay(string sData)
        {
            var lReturn = new List<GameProp>();

            // find first game in raw data
            int iTRStart = sData.IndexOf("<tr");

            // now for each game in raw data
            while (iTRStart >= 0)
            {
                // cut out the code for one game
                int iTREnd = sData.IndexOf("</tr>", iTRStart);
                string sGame = sData.Substring(iTRStart, iTREnd - iTRStart);

                // 1st <td> tag  -> game date
                int iVon = sGame.IndexOf("<td>");
                int iBis = sGame.IndexOf("</span>", iVon);          // EXCEPTION - hier fliegt die Anwendung immer wieder heraus
                string sDate = sGame.Substring(iVon + 5, iBis - iVon);
                iVon = sDate.IndexOf(">");
                iBis = sDate.IndexOf("<");
                sDate = sDate.Substring(iVon, iBis - iVon);
                GameProp oGame = new GameProp();
                oGame.Date = sDate;

                // 2nd <td> tag -> name of away team
                sGame = sGame.Substring(iBis);
                iVon = sGame.IndexOf("<td><span class=");
                sGame = sGame.Substring(iVon + "<td><span class=".Length);
                iVon = sGame.IndexOf(">") + 1;
                iBis = sGame.IndexOf("<");
                string sAwayTeam = sGame.Substring(iVon, iBis - iVon);
                sGame = sGame.Substring(iBis);
                oGame.Away = sAwayTeam;

                // 3rd <td> tag -> score away team
                iVon = sGame.IndexOf("<td class=");
                sGame = sGame.Substring(iVon);
                iVon = sGame.IndexOf(">") + 1;
                iBis = sGame.IndexOf("</td>");
                string sAwayScore = sGame.Substring(iVon, iBis - iVon);
                sGame = sGame.Substring(iBis);
                oGame.AwayScore = sAwayScore;

                // 4th <td> tag -> name of home team
                iVon = sGame.IndexOf("<td><span class=");
                sGame = sGame.Substring(iVon + "<td><span class=".Length);
                iVon = sGame.IndexOf(">") + 1;
                iBis = sGame.IndexOf("<");
                string sHomeTeam = sGame.Substring(iVon, iBis - iVon);
                sGame = sGame.Substring(iBis);
                oGame.Home = sHomeTeam;

                // 5th <td> tag -> score home team
                iVon = sGame.IndexOf("<td class=");
                sGame = sGame.Substring(iVon);
                iVon = sGame.IndexOf(">") + 1;
                iBis = sGame.IndexOf("</td>");
                string sHomeScore = sGame.Substring(iVon, iBis - iVon);
                sGame = sGame.Substring(iBis);
                oGame.HomeScore = sHomeScore;

                // 6th <td> tag -> overtime flag
                oGame.Overtime = "no";
                if (sGame.IndexOf("OT") > 0) oGame.Overtime = "yes";
                iTRStart = sData.IndexOf("<tr", iTREnd);
                lReturn.Add(oGame);
            }
            return lReturn;
        }
#endregion


    }
}
