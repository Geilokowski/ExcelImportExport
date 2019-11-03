using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ProExcelImportExport.ExcelHelper;

namespace ProExcelImportExport
{
    public class TProgVerzeichnisse
    {
        public String StartVerzeichnis;
        public String ListenVerzeichnis;
        public String ZensosDatei;
        public Boolean ZensosDateiExistenz;
        public String BestandsDatei;
        public Boolean BestandsDateiExistenz;
        public TProgVerzeichnisse()
        {
            StartVerzeichnis = System.IO.Directory.GetCurrentDirectory();
            StartVerzeichnis = System.IO.Directory.GetParent(StartVerzeichnis).ToString(); // Entwicklung
            StartVerzeichnis = System.IO.Directory.GetParent(StartVerzeichnis).ToString(); // Entwicklung
            ListenVerzeichnis = StartVerzeichnis+@"\Listen";
            ZensosDatei = ListenVerzeichnis + @"\Zensos.xlsx";
            ZensosDateiExistenz = File.Exists(ZensosDatei);
            BestandsDatei = ListenVerzeichnis + @"\Bestand.xlsx";
            BestandsDateiExistenz = File.Exists(BestandsDatei);            
        }
    }

    public class TLeereEintragsListe
    {
        public List<List<String>> LeereListe = new List<List<string>> { };
    }


    class Program
    {
        static TProgVerzeichnisse ProgrammVerzeichnisse = new TProgVerzeichnisse();

        [STAThread]    // Compilerdirektive für die Nutzung von Systemdialogen
        static void Main(string[] args)
        {
            Console.Title = "Excel Import/Export";
            bool debug = false;

            TObjExcelImport ExcelBestandsListe;
            TObjBestandsListe ObjektBestandsListe;
            TObjExcelImport ExcelZensosListe;
            TObjZensosListe ObjektZensosListe;

            Console.WriteLine("Willkommen. Beginne einlesen der Liste...");
            if (ProgrammVerzeichnisse.BestandsDateiExistenz) { // Wenn Bestandsdatei existiert
                // Importiere diese in ObjektBestandsListe
                ExcelBestandsListe = new TObjExcelImport(ProgrammVerzeichnisse.BestandsDatei);
                ObjektBestandsListe = new TObjBestandsListe(ExcelBestandsListe.EintragsListe);
            } else {
                // Wenn nicht importiere leere Liste
                TLeereEintragsListe LeereEintragsListe = new TLeereEintragsListe();
                ObjektBestandsListe = new TObjBestandsListe(LeereEintragsListe.LeereListe);
            }

            if (ProgrammVerzeichnisse.ZensosDateiExistenz) { // Wenn Zensosdatei existiert
                // Importiere diese in ObjektBestandsListe
                ExcelZensosListe = new TObjExcelImport(ProgrammVerzeichnisse.ZensosDatei);
                ObjektZensosListe = new TObjZensosListe(ExcelZensosListe.EintragsListe);
            } else {
                // Wenn nicht importiere leere Liste
                TLeereEintragsListe LeereEintragsListe = new TLeereEintragsListe();
                ObjektZensosListe = new TObjZensosListe(LeereEintragsListe.LeereListe);
            }
            Console.WriteLine("Listen erfolgreich eingelesen.");

            if (debug)
            {
                foreach (String Wert in ObjektBestandsListe.SchuelerListe[0])
                {
                    Console.WriteLine(Wert);
                }

                Console.WriteLine("");

                foreach (String Wert in ObjektZensosListe.SchuelerListe[0])
                {
                    Console.WriteLine(Wert);
                }

            }

            Console.WriteLine("");

            Console.WriteLine("Folgende Schüler existieren nicht in der Bestandsliste:");
            ObjektZensosListe.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind = ObjektZensosListe.BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(ObjektBestandsListe.SchuelerListe);
            foreach (List<String> Eintrag in ObjektZensosListe.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind)
            {
                Console.WriteLine(Eintrag[0] + " " + Eintrag[1] + " " + Eintrag[2] + " " + Eintrag[3] + " " + Eintrag[4] + " " + Eintrag[5]);
            }

            Console.WriteLine("");

            Console.WriteLine("Folgende Schüler haben die Klasse gewechselt");
            ObjektZensosListe.ListeDerSchuelerMitKlassenwechselInZensosListe = ObjektZensosListe.BestimmeSchuelerMitVeraenderungenInAndererSchuelerListe(ObjektBestandsListe.SchuelerListe);
            foreach (List<String> Eintrag in ObjektZensosListe.ListeDerSchuelerMitKlassenwechselInZensosListe)
            {
                Console.WriteLine(Eintrag[0] + " " + Eintrag[1] + " " + Eintrag[2] + " " + Eintrag[3] + " " + Eintrag[4] + " " + Eintrag[5]);
            }

            Console.WriteLine("");
            Console.WriteLine("Bitte drücken sie eine Taste um mit dem Export zu beginnen.");
            Console.ReadLine();

            // Hier kommt jetzt der neue Code
            Console.WriteLine("Beginne Export...");

            // Die veränderte Bestands Excel Datei, welche dann exportiert wird. Wird hier nur deklariert (erstellt).
            List<List<String>> changedBestandsListe = new List<List<string>>();

            // Initilisierung der Liste. Fügt die Schüler hinzu die davor nicht in der Liste waren.
            changedBestandsListe = SyncHelper.ChangedBestandsListe(ObjektBestandsListe.SchuelerListe, ObjektZensosListe.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind);

            // Ändert die Schüler mit Klassenwechsel
            changedBestandsListe = SyncHelper.ChangedBestandsListe(ObjektBestandsListe.SchuelerListe, ObjektZensosListe.ListeDerSchuelerMitKlassenwechselInZensosListe);

            // Für eine höhere Effizienz wird hier sortiert und nicht in der Methode ChangedBestandsListe
            changedBestandsListe = TObjKlassen.SortiereListeNachKlassen(changedBestandsListe); // Die Methode ist von Herr Wendland. Hab ich nicht selbst gemacht.

            // Jetzt folgt der Export. Auch die Methode war schon fertig.
            TObjExcelExport BExport = new TObjExcelExport(ProgrammVerzeichnisse.ListenVerzeichnis + @"\ExportTest.xlsx", changedBestandsListe);

            Console.WriteLine("Export erfolgreich!");
            Console.ReadLine();
        }
    }
}
