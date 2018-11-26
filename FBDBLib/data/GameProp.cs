using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.data
{
    public class GameProp
    {
        private String sAway;
        private String sHome;
        private String sDate;
        private String sAwayScore;
        private String sHomeScore;
        private String sOvertime;
        
        public string Away
                    {

            get

            {

                return sAway;

            }



            set

            {

                sAway = value;

            }

        }



        public string Home

        {

            get

            {

                return sHome;

            }



            set

            {

                sHome = value;

            }

        }



        public string Date

        {

            get

            {

                return sDate;

            }



            set

            {

                sDate = value;

            }

        }



        public string AwayScore

        {

            get

            {

                return sAwayScore;

            }



            set

            {

                sAwayScore = value;

            }

        }



        public string HomeScore

        {

            get

            {

                return sHomeScore;

            }



            set

            {

                sHomeScore = value;

            }

        }



        public string Overtime

        {

            get

            {

                return sOvertime;

            }



            set

            {

                sOvertime = value;

            }

        }

    }
}
