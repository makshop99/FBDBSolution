using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{
    /* Aufgabe
        Diese Methode liest den Inhalt der drei Files Offense, Defense und Schedule aus. Sie
        stellt dann die rohen HTML-Daten zur Verfuegung. Sie ist fuer den Zugriff auf das lokale
        Filesystem und fuer den TCP/IP Zugriff auf footballdb.com zustaendig.     
    */
    class RawDataReader
    {
        private FileProp gFileContents = new FileProp();
        bool gInternetFiles = false;
        bool gInnerState = false;
        
        // pruefen der Pfade, analysieren der Pfadtypen und auslesen der Dateiinhalte
        public int init(FileProp sFilePaths)
        {
            // Aufgaben
            
            // die Fileinhalte in eine eigene Struktur schreiben



            int iReturn = checkData(sFilePaths);
            if (iReturn == 0)
            {
                // pruefen, ob File oder URL
                //gInternetFiles = checkPaths(sFilePaths);

                // entsprechend die Daten auslesen    

                // wenn alles in Ordnung ist, inneren Status auf OK setzen
                gInnerState = true;
            }
            return iReturn;
        }

        /// <summary>
        /// this method returns a list<> with all games of a specific gameday.
        /// the name of the gameday is the parameter of this method.
        /// </summary>
        /// <param name="sGameday">format "week1"</param>
        /// <returns></returns>
        public List<GameProp> getSchedule(string sGameday)
        {
            return null;
        }


        /// <summary>
        /// diese methode liefert den inhalt der offense-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getOffenseDataRaw()
        {
            return "";
        }


        /// <summary>
        /// diese methode liefert den inhalt der defense-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getDefenseDataRaw()
        {
            return "";
        }        


        /// <summary>
        /// diese methode liefert den inhalt der schedule-datei in rohform zurueck
        /// </summary>
        /// <returns></returns>
        public string getScheduleDataRaw()
        {
            return "";
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
