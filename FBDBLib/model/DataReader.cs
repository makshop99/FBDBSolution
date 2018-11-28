using FBDBLib.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDBLib.model
{
    // Diese Methode liest Dateien aus und stellt deren Inhalt als String zur 
    // verfuegung. Sie prueft die uebergebenen Pfade auf Korrektheit und darauf, 
    // ob es sich um lokale Pfade oder URL`s handelt. Den eigentlichen Zugriff auf
    // das Filesystem oder das Internet wird sie vermutlich ebenfalls uebernehmen. 
    // Das haengt von der Laenge des zu verwendenden Codes ab. Ggf. werden diese 
    // Funktionen spaeter noch ausgelagert. 
    class DataReader
    {
        private FileProp gFileContents = new FileProp();
        bool gInternetFiles = false;
        bool gInnerState = false;
        
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
        /// this method returns the content of an offense or defense
        /// stats file. depending on the paths handed over in init() the content
        /// is read from a local file or from footballdb.com.
        /// </summary>
        /// <returns></returns>
        public string getTeamData()
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
