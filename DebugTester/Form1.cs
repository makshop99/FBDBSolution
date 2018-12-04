using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugTester
{
    public partial class Form1 : Form
    {
        FBDBLib.view.FBDBLibInterface oPruefling = new FBDBLib.view.FBDBLibInterface();
        public Form1()
        {
            InitializeComponent();
            btGame.Enabled = false;
            btGameday.Enabled = false;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sOffenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\offense.htm";
            string sDefenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\defense.htm";
            string sScheduleFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\schedule.htm";


            sOffenseFile = "https://www.footballdb.com/stats/teamstat.html?group=O&cat=T";
            sDefenseFile = "https://www.footballdb.com/stats/teamstat.html?group=D&cat=T";
            sScheduleFile = "https://www.footballdb.com/games/index.html"; // use only reely...


            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            tbOutput.Text = "init() returns value [" + iReturn.ToString() + "]";

            if (iReturn == 0)
            {
                btGame.Enabled = true;
                btGameday.Enabled = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sHomeTeam = "Detroit Lions";
            string sAwayTeam = "Miami Dolphins";

            // run analysis
            GameProp oData = oPruefling.getGame(sAwayTeam, sHomeTeam);

            // create output string
            string sReturn = oData.Away + " @ " + oData.Home + " - ";
            sReturn += oData.AwayScore + " : " + oData.HomeScore + " (" + oData.ScoreDiff + ")";

            tbOutput.Text = sReturn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sGameDay = cbGameday.SelectedItem.ToString();
            List<GameProp> oData = oPruefling.getGameDay(sGameDay);
            string sReturn = "";

            // create output string
            foreach (var oGame in oData)
            {
                sReturn += oGame.Away + " @ " + oGame.Home + " - ";
                sReturn += oGame.AwayScore + " : " + oGame.HomeScore + " (" + oGame.ScoreDiff + ")" + Environment.NewLine;
                //sReturn += " -> " + oGame.Date + Environment.NewLine; // game date
            }

            tbOutput.Text = sReturn;
        }
    }
}



