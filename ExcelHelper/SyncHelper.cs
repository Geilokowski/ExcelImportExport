using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProExcelImportExport.ExcelHelper
{
    class SyncHelper
    {
        // Funktion um die veränderten Schüler zur Bestandsliste hinzuzufügen und etwaige Duplikate zu enfernen
        // Nur zur Info, das Static ist dazu da das man kein Objekt erstellen muss um die Methode zu nutzen. Ansonsten müsste man mit new eins erstellen.
        public static List<List<String>> ChangedBestandsListe(List<List<String>> bestandsListe, List<List<String>> changedStudents) 
        {
            // Geht die veränderten Schüler durch
            foreach(List<String> changedStudent in changedStudents)
            {
                // Geht die Bestandsliste durch. Hier kann kein foreach benutzt werden da wir dann nicht die Liste verändern dürfen. Frag mich nicht wieso.
                for(int i = 0; i < bestandsListe.Count; i++)
                //foreach(List<String> student in bestandsListe)
                {
                    // Falls der geänderte Student mit einem der Studenten aus der Bestandsliste übereinstimmt (überprüft nach Vorname, Nachname und Geburtsdatum)
                    if(bestandsListe[i][2].Equals(changedStudent[2]) && bestandsListe[i][3].Equals(changedStudent[3]) && bestandsListe[i][4].Equals(changedStudent[4])){
                        // Das Problem ist nun, das changed Student nicht alle Informationen der BestandsListe enthält da dieser nur aus dem Eintrag in der Zensosliste besteht. Es fehlt also z.B. der Username.
                        // Diese Informationen fügen wir jetzt zu unserer changedStuden Variable hinzu.
                        // Dies klappt natürlich nur wenn der Schüler schon in der Bestandsliste steht. Sonst haben wir nur die Informationen aus der Zensos Datei und lassen die restlichen Spalten leer.
                        changedStudent.Add(bestandsListe[i][6]); // Nutzername
                        changedStudent.Add(bestandsListe[i][7]); // InZensos
                        changedStudent.Add(bestandsListe[i][8]); // InITK
                        changedStudent.Add(bestandsListe[i][9]); // UsernameITK
                        changedStudent.Add(bestandsListe[i][10]); // InO365
                        changedStudent.Add(bestandsListe[i][11]); // UsernameO365

                        bestandsListe.Remove(bestandsListe[i]); // Lösche diesen Schüler, sonst gibt es ihn nachher doppelt. Trifft nur zu wenn ein Klassenwechsel vollzogen wurde.
                    }
                }

                if (changedStudent.Count == 12)
                {
                    // Wenn alle 12 Spalten vollständig sind (also nur ein Klassenwechsel vollzogen wurde und wir den Schüler schon in der BEstandsliste hatten)
                    bestandsListe.Add(changedStudent); // Und füge den veränderten Schüler hinzu den wir gerade gelöscht haben
                }
                else
                {
                    // Wenn der Schüler komplett in der Bestandsliste gefehlt hat geben wir eine Warnung aus da Informationen fehlen werden. Gut zu beobachten bei z.B. Luiza Bortolotto.
                    Console.WriteLine("WARNUNG: Fehlende Informationen zu Schüler " + changedStudent[3] + " " + changedStudent[2]);
                    bestandsListe.Add(changedStudent); // Und füge den veränderten Schüler hinzu den wir gerade gelöscht haben
                }
            }


            return bestandsListe; // Gibt die Liste zurück.
            // An der Stelle ist eigentlich das Programm quasi schon fertig. Jetzt folgt nurnoch das Sortieren und der Export.
        }
    }
}
