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

        public List<GameProp> getSchedule(string sGameday)
        {
            return null;
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
