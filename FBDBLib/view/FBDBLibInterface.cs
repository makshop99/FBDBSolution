using System;
using System.Collections.Generic;
using System.Text;

namespace FBDBLib.view
{
    class FBDBLibInterface
    {
        public int init(string sData)
        {
            if (sData.Equals("ok")) return 0;
            else return -1;


        }
    }
}
