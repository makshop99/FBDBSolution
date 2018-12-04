using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDB_Analysis.code.data
{
    /// <summary>
    /// this class includes all stats data for a nfl team
    /// </summary>
    public class TeamData
    {
        #region fields
        private String sTeamName;

        private String iOffensePntG;
        private String iOffenseRshG;
        private String iOffensePssG;
        private String iOffensePnt;
        private String iOffenseRsh;
        private String iOffensePss;
        private String iOffenseYrd;
        private String iOffenseYrdG;
        private String iOffenseGms;

        private String iDefensePntG;
        private String iDefenseRshG;
        private String iDefensePssG;
        private String iDefensePnt;
        private String iDefenseRsh;
        private String iDefensePss;
        private String iDefenseYrd;
        private String iDefenseYrdG;
        private String iDefenseGms;
        #endregion

        #region encapsulates
        public string TeamName { get => sTeamName; set => sTeamName = value; }
        public string OffensePntG { get => iOffensePntG; set => iOffensePntG = value; }
        public string OffenseRshG { get => iOffenseRshG; set => iOffenseRshG = value; }
        public string OffensePssG { get => iOffensePssG; set => iOffensePssG = value; }
        public string OffensePnt { get => iOffensePnt; set => iOffensePnt = value; }
        public string OffenseRsh { get => iOffenseRsh; set => iOffenseRsh = value; }
        public string OffensePss { get => iOffensePss; set => iOffensePss = value; }
        public string OffenseYrd { get => iOffenseYrd; set => iOffenseYrd = value; }
        public string OffenseYrdG { get => iOffenseYrdG; set => iOffenseYrdG = value; }
        public string OffenseGms { get => iOffenseGms; set => iOffenseGms = value; }
        public string DefensePntG { get => iDefensePntG; set => iDefensePntG = value; }
        public string DefenseRshG { get => iDefenseRshG; set => iDefenseRshG = value; }
        public string DefensePssG { get => iDefensePssG; set => iDefensePssG = value; }
        public string DefensePnt { get => iDefensePnt; set => iDefensePnt = value; }
        public string DefenseRsh { get => iDefenseRsh; set => iDefenseRsh = value; }
        public string DefensePss { get => iDefensePss; set => iDefensePss = value; }
        public string DefenseYrd { get => iDefenseYrd; set => iDefenseYrd = value; }
        public string DefenseYrdG { get => iDefenseYrdG; set => iDefenseYrdG = value; }
        public string DefenseGms { get => iDefenseGms; set => iDefenseGms = value; }
        #endregion
    }
}