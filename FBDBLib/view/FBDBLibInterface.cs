using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.view
{
    public class FBDBLibInterface
    {
        /// <summary>
        /// this method takes init data and initializes the class
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public int init(string sData)
        {
            return 0;
        }

        /// <summary>
        ///  this method gets data and calculates a whole gameday
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public string getGameDay(string sData)
        {
            return "";
        }


        /// <summary>
        ///  this method calculates a single game
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public string getGame(string sData)
        {
            return ""; ;
        }
    }
}


