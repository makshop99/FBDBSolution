using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.data
{
    /// <summary>
    ///  this class includes all props for a game
    /// </summary>
    public class GameProp
    {
        #region fields
        private String sAway;
        private String sHome;
        private String sDate;
        private String sAwayScore;
        private String sHomeScore;
        private String sOvertime;
        private String sScoreDiff;
        #endregion

        #region encapsulates
        public string Away { get => sAway; set => sAway = value; }
        public string Home { get => sHome; set => sHome = value; }
        public string Date { get => sDate; set => sDate = value; }
        public string AwayScore { get => sAwayScore; set => sAwayScore = value; }
        public string HomeScore { get => sHomeScore; set => sHomeScore = value; }
        public string Overtime { get => sOvertime; set => sOvertime = value; }
        public string ScoreDiff { get => sScoreDiff; set => sScoreDiff = value; }
        #endregion
    }
}
