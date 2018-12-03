using FBDBLib.data;
using FDB_Analysis.code.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{
    public class DataAnalyser
    {

        #region members
        private Double iOffenseMax = 100;
        private Double iDefenseMax = 100;
        #endregion

        #region interface

        /// <summary>
        /// this method analyses the game of two teams by their stats
        /// </summary>
        /// <param name="tdAway"></param>
        /// <param name="tdHome"></param>
        /// <returns></returns>
        public String analyseGame(TeamData tdAway, TeamData tdHome)
        {
            // Offense berechnen
            Double dHome = calculateOffense(tdAway, tdHome);
            Double dAway = iOffenseMax - dHome;

            // Defense berechnen
            Double idummy = calculateDefense(tdAway, tdHome);
            dHome += idummy;
            dAway += iDefenseMax - idummy;

            // Heimvorteil
            //dHome += 10;
            int iHome = Convert.ToInt32(dHome);
            int iAway = Convert.ToInt32(dAway);

            // Streak (Spaeter...)


            String sReturn = tdAway.TeamName + " @ " + tdHome.TeamName + " - " + iAway.ToString() + ":" + iHome.ToString();
            return sReturn;
            //  return "stats of a single game";

        }
        #endregion

        #region stats methods
        private Double calculateOffense(TeamData tdAway, TeamData tdHome)
        {
            // 100, 40 for Points/Game; 35 for PassingYards/Game; 25 for RushYards/Game

            Double iPointsHome = Convert.ToDouble(tdHome.OffensePntG);
            Double iPassingHome = Convert.ToDouble(tdHome.OffensePssG);
            Double iRushingHome = Convert.ToDouble(tdHome.OffenseRshG);

            Double iPointsAway = Convert.ToDouble(tdAway.OffensePntG);
            Double iPassingAway = Convert.ToDouble(tdAway.OffensePssG);
            Double iRushingAway = Convert.ToDouble(tdAway.OffenseRshG);

            Double iPoints = (iPointsHome / (iPointsHome + iPointsAway)) * 40;
            Double iPassing = (iPassingHome / (iPassingHome + iPassingAway)) * 35;
            Double iRushing = (iRushingHome / (iRushingHome + iRushingAway)) * 25;

            // returns the points of the hometeam --> awayteam then is iOffenseMax - hometeam
            return (iPoints + iPassing + iRushing);
        }

        //TODO - hier muss die Logik noch herumgedreht werden, da aktuell auch hier die grossen Werte besser sind!!!
        // update - ich habe schon etwas geaendert, muss aber mal ueberprueft werden.
        private Double calculateDefense(TeamData tdAway, TeamData tdHome)
        {
            // 100, 40 for Points/Game; 35 for PassingYards/Game; 25 for RushYards/Game
            Double iPointsHome = Convert.ToDouble(tdHome.DefensePntG);
            Double iPassingHome = Convert.ToDouble(tdHome.DefensePssG);
            Double iRushingHome = Convert.ToDouble(tdHome.DefenseRshG);

            Double iPointsAway = Convert.ToDouble(tdAway.DefensePntG);
            Double iPassingAway = Convert.ToDouble(tdAway.DefensePssG);
            Double iRushingAway = Convert.ToDouble(tdAway.DefenseRshG);

            Double iPoints = (iPointsAway / (iPointsHome + iPointsAway)) * 40;
            Double iPassing = (iPassingAway / (iPassingHome + iPassingAway)) * 35;
            Double iRushing = (iRushingAway / (iRushingHome + iRushingAway)) * 25;

            // returns the points of the hometeam --> awayteam then is DeffenseMax - hometeam
            return (iPoints + iPassing + iRushing);
        }
        #endregion
    }
}

