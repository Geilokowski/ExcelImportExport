using ProExcelImportExport.PersonHelper;
using System;
using System.Collections.Generic;

namespace ProExcelImportExport.ExcelHelper
{
    public class TObjBestandsListe : TObjKlassen
    {
        public List<TSchueler> SchuelerObjektListe;
        // List<List<String>> UrListe: JGKZ - Name - Vorname - Geburtsdatum - Geschlecht
        // List<List<String>> SchuelerListe: JGKZ - Klasse - Name - Vorname - Geburtsdatum - Geschlecht

        public TObjBestandsListe(List<List<String>> UrListe) : base(UrListe)
        {
            SchuelerObjektListe = new List<TSchueler> { };
            foreach (List<String> Eintrag in SchuelerListe)
            {
                TSchueler SchuelerObjekt = new TSchueler(Eintrag[0], Eintrag[1], Eintrag[2], Eintrag[3], Eintrag[4], Eintrag[5]);
                SchuelerObjektListe.Add(SchuelerObjekt);
            }
        }
    }
}
