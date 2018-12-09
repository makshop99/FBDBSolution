using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{
    /// <summary>
    /// this class reads all raw data needed. this includes offense stats, defense stats and gameday information.
    /// </summary>
    class DataReader
    {
        #region members
        private FileProp gFileContents = new FileProp();
        private FileProp oRawData = new FileProp();
        bool gInnerState = false;
        #endregion

        #region interface
        /// <summary>
        /// initiating the class. readsout all raw data ans stores it inside.
        /// </summary>
        /// <param name="sFilePaths"></param>
        /// <returns></returns>
        public int init(FileProp sFilePaths)
        {

            // check parameters
            int iReturn = checkData(sFilePaths);
            if (iReturn == 0)
            {
                // read data
                iReturn = readData(sFilePaths);

                // set inner state of classe
                if (iReturn == 0) gInnerState = true;
            }
            return iReturn;
        }

        public FileProp getAllRawData()
        {
            if (gInnerState) return oRawData;
            else return null;
        }

        /// <summary>
        /// diese methode liefert den inhalt der offense-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getOffenseDataRaw()
        {
            if (gInnerState) return oRawData.Offense;
            else return "error";

        }

        /// <summary>
        /// diese methode liefert den inhalt der defense-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getDefenseDataRaw()
        {
            if (gInnerState) return oRawData.Defense;
            else return "error";

        }

        /// <summary>
        /// diese methode liefert den inhalt der schedule-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getScheduleDataRaw()
        {
            if (gInnerState) return oRawData.Gameday;
            else return "error";
        }
        #endregion

        #region check methods
        /// <summary>
        /// this method checks if all three paths are filled and valid.
        /// it also checks if the paths are URLS
        /// </summary>
        /// <param name="oData"></param>
        /// <returns></returns>
        private int checkData(FileProp oData)
        {
            if (oData.Offense.Length <= 0) return -1;
            if (oData.Defense.Length <= 0) return -1;
            if (oData.Gameday.Length <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// this method checks wherethere a the given paths are filesystem or url
        /// </summary>
        /// <param name="oData"></param>
        /// <returns>
        ///     1   - URL
        ///     2   - windows path
        ///     3   - unix path
        ///     -1  - error
        /// </returns>
        private int checkPaths(string sPath)
        {
            if (sPath.Substring(0, 4).ToLower().Equals("http")) return 1;
            else if (sPath.Substring(1, 1).Equals(":")) return 2;
            else if (sPath.Substring(0, 2).Equals("//")) return 3;
            else return -1;
        }
        #endregion

        #region file reading
        /// <summary>
        /// this methods controls the readout of all raw data.
        /// </summary>
        /// <param name="oPaths"></param>
        /// <returns></returns>
        private int readData(FileProp oPaths)
        {
            int iReturn = 0;

            // Offense-File auslesen
            String sDummy = readFile(oPaths.Offense);
            if (sDummy.Equals("error")) return -1;
            oRawData.Offense = sDummy;

            // Defense-File auslesen
            sDummy = readFile(oPaths.Defense);
            if (sDummy.Equals("error")) return -1;
            oRawData.Defense = sDummy;

            // Schedule auslesen
            sDummy = readFile(oPaths.Gameday);
            if (sDummy.Equals("error")) return -1;
            oRawData.Gameday = sDummy;

            return iReturn;
        }

        /// <summary>
        /// this method checks the filetype and starts the readout of the file the proper way.
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        private string readFile(string sFilePath)
        {
            int iFileType = checkPaths(sFilePath);
            

            switch (iFileType)
            {
                case 1:
                    // read url
                    return readURL(sFilePath);                    
                case 2:
                    // read windows
                    return readLocalFile(sFilePath);
                default:
                    return "error";
            }
        }

        /// <summary>
        /// this method reads the data from the internet
        /// </summary>
        /// <param name="sUrl"></param>
        /// <returns></returns>
        private String readURL(String sUrl)
        {
            try
            {
                String sReturn = "";
                using (WebClient client = new WebClient())
                {
                    sReturn = client.DownloadString(sUrl);
                }
                return sReturn;
            }
            catch (Exception) { return "error"; }
        }

        /// <summary>
        /// this method reads the data from a local file
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        private string readLocalFile(String sFilePath)
        {
            try { return File.ReadAllText(sFilePath); }
            catch (Exception) { return "error"; }
        }
        #endregion
    }
}
