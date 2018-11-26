using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{
    class DataReader
    {
        private FileProp gFiles = new FileProp();
        bool gInternetFiles = false;
        bool gInnerState = false;
        
        public int init(FileProp oData)
        {
            int iReturn = checkData(oData);
            if (iReturn == 0)
            {
                gFiles = oData;
                //gInternetFiles = bUrl;
                gInnerState = true;
            }
            return iReturn;
        }


        /// <summary>
        /// this method checks if all three paths are filled and valid.
        /// it also checks if the paths are URLS
        /// </summary>
        /// <param name="oData"></param>
        /// <returns></returns>
        private int checkData(FileProp oData)
        {
            if (oData.OffenseFile.Length <= 0) return -1;
            if (oData.DefenseFile.Length <= 0) return -1;
            if (oData.GamedayFile.Length <= 0) return -1;
            return 0;
        }

    }
}
