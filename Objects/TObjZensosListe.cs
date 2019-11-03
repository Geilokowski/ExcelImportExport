using ProExcelImportExport.PersonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProExcelImportExport.ExcelHelper
{
    public class TObjZensosListe : TObjKlassen
    {
        // List<List<String>> UrListe: Klasse - Name - Vorname - Geburtsdatum - Geschlecht
        // List<List<String>> SchuelerListe: JGKZ - Klasse - Name - Vorname - Geburtsdatum - Geschlecht
        public List<List<String>> ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind;
        public List<List<String>> ListeDerSchuelerMitKlassenwechselInZensosListe;


        public TObjZensosListe(List<List<String>> UrListe) : base(UrListe)
        {
            ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind = new List<List<string>> { };
            ListeDerSchuelerMitKlassenwechselInZensosListe = new List<List<string>> { };
        }
    }
}
