using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.data
{
    public class FileProp
    {
        private string sOffenseFile;
        private string sDefenseFile;
        private string sGamedayFile;

        public string Offense { get => sOffenseFile; set => sOffenseFile = value; }
        public string Defense { get => sDefenseFile; set => sDefenseFile = value; }
        public string Gameday { get => sGamedayFile; set => sGamedayFile = value; }
    }
}
