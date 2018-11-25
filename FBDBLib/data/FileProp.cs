using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.data
{
    class FileProp
    {
        private string sOffenseFile;
        private string sDefenseFile;
        private string sGamedayFile;

        public string OffenseFile { get => sOffenseFile; set => sOffenseFile = value; }
        public string DefenseFile { get => sDefenseFile; set => sDefenseFile = value; }
        public string GamedayFile { get => sGamedayFile; set => sGamedayFile = value; }
    }
}
