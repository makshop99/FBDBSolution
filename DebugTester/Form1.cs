﻿using FBDBLib.data;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sOffenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\offense.htm";
            string sDefenseFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\defense.htm";
            string sScheduleFile = @"C:\Users\PeterPiper07\workspace\CSharp\FBDBSolution\schedule.htm";
            //sScheduleFile = "https://www.footballdb.com/games/index.html";

            
            FileProp oData = new FileProp();
            oData.Offense = sOffenseFile;
            oData.Defense = sDefenseFile;
            oData.Gameday = sScheduleFile;

            // test with local paths OK
            int iReturn = oPruefling.init(oData);
            tbOutput.Text = "init() returns value [" + iReturn.ToString() + "]";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sHomeTeam = "Detroit Lions";
            string sAwayTeam = "Miami Dolphins";
            tbOutput.Text = oPruefling.getGame(sAwayTeam, sHomeTeam);
        }
    }
}


