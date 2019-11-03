using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProExcelImportExport.ExcelHelper
{
    public class TObjKlassen
    {
        public List<List<String>> SchuelerListe = new List<List<String>> { };
        private static String Schuljahr = BestimmeSchuljahr();
        private static Int32 ReferenzJahr = BestimmeReferenzJahr();

        private List<String> KlassenStufe5;
        private List<String> KlassenStufe6;
        private List<String> KlassenStufe7;
        private List<String> KlassenStufe8;
        private List<String> KlassenStufe9;
        private List<String> KlassenStufe10;
        private List<String> KlassenStufe11;
        private List<String> KlassenStufe12;
        private List<String> GrundStufe;
        private List<String> Sekundarstufe1;
        private List<String> Sekundarstufe2;
        private List<String> AlleKlassen;

        private List<String> AlleJGKZ = new List<string> { };

        public List<String> AktuelleKlassenListe = new List<string> { };
        public static List<String> AktuelleJGKZListe = new List<string> { };

        public TObjKlassen(List<List<String>> UrListe)
        {
            CreateAllJGKZ();
            BereiteSchuelerListenEintraegeAuf(UrListe);
            AktualisiereSchuelerUndKlassenListen();
        }

        private void CreateAllJGKZ()
        {
            KlassenStufe5 = new List<string> { "5s" };
            foreach (String Klasse in KlassenStufe5)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2000).ToString() + Klasse.Substring(1, Klasse.Length - 1));
            KlassenStufe6 = new List<string> { "6s" };
            foreach (String Klasse in KlassenStufe6)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2001).ToString() + Klasse.Substring(1, Klasse.Length - 1));
            KlassenStufe7 = new List<string> { "7a", "7b", "7s", "7s-1", "7s-2" };

            foreach (String Klasse in KlassenStufe7)
            {
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2002).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2000).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
            }

            KlassenStufe8 = new List<string> { "8a", "8b", "8s", "8s-1", "8s-2" };
            foreach (String Klasse in KlassenStufe8)
            {
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2003).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2001).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
            }

            KlassenStufe9 = new List<string> { "9a", "9b", "9s", "9s-1", "9s-2" };
            foreach (String Klasse in KlassenStufe9)
            {
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2004).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2002).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
            }

            KlassenStufe10 = new List<string> { "10a", "10b", "10s", "10s-1", "10s-2" };
            foreach (String Klasse in KlassenStufe10)
            {
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2005).ToString() + Klasse.Substring(2, Klasse.Length - 2));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2003).ToString() + Klasse.Substring(2, Klasse.Length - 2));
                }
            }

            KlassenStufe11 = new List<string> { "11-IB","11-IB1","11-IB2", "11-LuR", "11-LuR1", "11-LuR2"
                                                    , "11-WuN", "11-WuN1", "11-WuN2","11-MuK", "11-MuK1", "11-MuK2" };
            foreach (String Klasse in KlassenStufe11)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2000).ToString() + Klasse.Substring(3, Klasse.Length - 3));

            KlassenStufe12 = new List<string>  { "12-IB","12-IB1","12-IB2", "12-LuR", "12-LuR1", "12-LuR2"
                                                    , "12-WuN", "12-WuN1", "12-WuN2","12-MuK", "12-MuK1", "12-MuK2" };
            foreach (String Klasse in KlassenStufe11)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2001).ToString() + Klasse.Substring(3, Klasse.Length - 3));

            GrundStufe = new List<String> { "5s", "6s" };
            Sekundarstufe1 = new List<String> { };

            foreach (String Element in KlassenStufe7)
                Sekundarstufe1.Add(Element);
            foreach (String Element in KlassenStufe8)
                Sekundarstufe1.Add(Element);
            foreach (String Element in KlassenStufe9)
                Sekundarstufe1.Add(Element);
            foreach (String Element in KlassenStufe10)
                Sekundarstufe1.Add(Element);

            Sekundarstufe2 = new List<String> { };

            foreach (String Element in KlassenStufe11)
                Sekundarstufe2.Add(Element);
            foreach (String Element in KlassenStufe12)
                Sekundarstufe2.Add(Element);

            AlleKlassen = new List<String> { };

            foreach (String Element in GrundStufe)
                AlleKlassen.Add(Element);
            foreach (String Element in Sekundarstufe1)
                AlleKlassen.Add(Element);
            foreach (String Element in Sekundarstufe2)
                AlleKlassen.Add(Element);
        }

        private static Int32 BestimmeReferenzJahr()
        {
            DateTime Heute = DateTime.Now.Date;
            DateTime Stichtag = DateTime.Parse("01.08." + Heute.Year.ToString());
            if (Heute.CompareTo(Stichtag.Date) > 0)
                return Stichtag.Year;
            else
                return Stichtag.AddYears(-1).Year;
        }

        private static String BestimmeSchuljahr()
        {
            Int32 RefJahr = BestimmeReferenzJahr();
            String SJahr = "Schuljahr: " + RefJahr.ToString() + "/" + (RefJahr + 1).ToString();

            return SJahr;
        }

        private void BereiteSchuelerListenEintraegeAuf(List<List<String>> UrListe)
        {
            int EPos = -1; 
            String JGKZ = "n.n."; 
            String Klasse = "n.n.BB";

            foreach (List<String> Eintrag in UrListe)
            {
                if (Eintrag.Count > 2 & Eintrag[0].Length > 0)
                {
                    for (int i = 0; i < Eintrag.Count; i++)
                    {
                        if (Eintrag[i].Trim().Length < 1)
                        {
                            Eintrag[i] = "n.n.";
                        }
                    }

                    EPos = AlleKlassen.IndexOf(Eintrag[0]);
                    if (EPos > -1)
                    {
                        JGKZ = AlleJGKZ[EPos];
                        Eintrag.Insert(0, JGKZ);
                    }
                    else
                    {
                        EPos = AlleJGKZ.IndexOf(Eintrag[0]);
                        if (EPos > -1)
                        {
                            Klasse = AlleKlassen[EPos];
                            Eintrag.Insert(1, Klasse);
                        }
                        else
                        {
                            JGKZ = "n.n";
                            Eintrag.Insert(0, JGKZ);
                        }
                    }

                    SchuelerListe.Add(Eintrag);
                }

            }
        }

        private void AktualisiereAktuelleKlassenUndJGKZListe()
        {
            List<String> ArbeitsListe = new List<String> { };
            AktuelleKlassenListe.Clear();
            AktuelleJGKZListe.Clear();
            foreach (List<String> Eintrag in SchuelerListe)
            {
                ArbeitsListe.Add(Eintrag[1]);
            }
            int i = -1;
            foreach (String Eintrag in AlleKlassen)
            {
                i++;
                if (ArbeitsListe.LastIndexOf(Eintrag) > -1)
                {
                    AktuelleKlassenListe.Add(Eintrag);
                    AktuelleJGKZListe.Add(AlleJGKZ[i]);
                }
            }
        }

        public static List<List<String>> SortiereListeNachNamen(List<List<String>> SortList)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            ArbeitsListe = SortList;
            String NameA; String NameB;
            List<String> ZwischenSpeicher = new List<string> { };
            for (int i = 0; i < SortList.Count - 1; i++)
                for (int k = i + 1; k < SortList.Count; k++)
                {
                    NameA = ArbeitsListe[i][2].Trim().ToLower() + ", " + ArbeitsListe[i][3].Trim().ToLower();
                    NameB = ArbeitsListe[k][2].Trim().ToLower() + ", " + ArbeitsListe[k][3].Trim().ToLower();
                    if (NameA.CompareTo(NameB) > 0)
                    {
                        ZwischenSpeicher = ArbeitsListe[k];
                        ArbeitsListe[k] = ArbeitsListe[i];
                        ArbeitsListe[i] = ZwischenSpeicher;
                    }
                }
            return ArbeitsListe;
        }

        public static List<List<String>> SortiereListeNachKlassen(List<List<String>> SortList)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            List<List<String>> KlassenListe = new List<List<string>> { };
            foreach (String JGKZ in AktuelleJGKZListe)
            {
                ArbeitsListe.Clear();
                foreach (List<String> Eintrag in SortList)
                {
                    if (Eintrag[0].CompareTo(JGKZ) == 0)
                    {
                        ArbeitsListe.Add(Eintrag);
                    }
                }
                foreach (List<String> Eintrag in SortiereListeNachNamen(ArbeitsListe))
                {
                    KlassenListe.Add(Eintrag);
                }

            }
            return KlassenListe;
        }

        public void AktualisiereSchuelerUndKlassenListen()
        {
            AktualisiereAktuelleKlassenUndJGKZListe();
            SchuelerListe = SortiereListeNachKlassen(SchuelerListe);
        }

        public List<List<String>> BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(List<List<String>> AndereSchuelerListe)
        {
            // Grundaufbau der zu vergleichenden Listen : JGKZ - Klasse - Name - Vorname
            List<List<String>> ListeDerSchuelerDieNichtInAndererListeEnthaltenSind = new List<List<String>> { };
            List<String> IDAndereSchuelerListe = new List<String> { };

            foreach (List<String> Eintrag in AndereSchuelerListe)
            {
                IDAndereSchuelerListe.Add(Eintrag[2].ToLower() + ", " + Eintrag[3].ToLower());

            }

            foreach (List<String> Eintrag in SchuelerListe)
            {
                String VergleichsName = Eintrag[2].ToLower() + ", " + Eintrag[3].ToLower();
                Boolean gefunden = false;
                foreach (String AndererVergleichsName in IDAndereSchuelerListe)
                {
                    // bewusst unscharfer Test nötig  (z.B. 5 Vornamen !)
                    if (VergleichsName.Contains(AndererVergleichsName) || AndererVergleichsName.Contains(VergleichsName))
                    {
                        gefunden = true;
                    }
                }
                if (!gefunden)
                {
                    ListeDerSchuelerDieNichtInAndererListeEnthaltenSind.Add(Eintrag);
                }
            }
            return ListeDerSchuelerDieNichtInAndererListeEnthaltenSind;
        }

        public List<List<String>> BestimmeSchuelerMitVeraenderungenInAndererSchuelerListe(List<List<String>> AndereSchuelerListe)
        {
            // Grundaufbau der zu vergleichenden Listen : JGKZ - Klasse - Name - Vorname
            List<List<String>> ListeDerSchuelerDieNichtInAndererListeEnthaltenSind;
            List<List<String>> ListeDerSchuelerMitVeraenderungen = new List<List<String>> { };
            List<String> IDListeSchuelerDieNichtInAndererListeEnthaltenSind = new List<String> { };

            ListeDerSchuelerDieNichtInAndererListeEnthaltenSind = BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(AndereSchuelerListe);
            foreach (List<String> Eintrag in ListeDerSchuelerDieNichtInAndererListeEnthaltenSind)
            {
                IDListeSchuelerDieNichtInAndererListeEnthaltenSind.Add(Eintrag[2].ToLower() + ", " + Eintrag[3].ToLower());
            }

            foreach (List<String> Eintrag in SchuelerListe)
            {
                String VergleichsName = Eintrag[2].ToLower() + ", " + Eintrag[3].ToLower();
                if (!IDListeSchuelerDieNichtInAndererListeEnthaltenSind.Contains(VergleichsName))
                {
                    foreach (List<String> AndererEintrag in AndereSchuelerListe)
                    {
                        String AndererVergleichsName = AndererEintrag[2].ToLower() + ", " + AndererEintrag[3].ToLower();
                        // bewusst unscharfer Test nötig  (z.B. 5 Vornamen !)
                        if (VergleichsName.Contains(AndererVergleichsName) || AndererVergleichsName.Contains(VergleichsName))
                        {
                            if (!(Eintrag[0].Equals(AndererEintrag[0]) && Eintrag[1].Equals(AndererEintrag[1])))
                            {
                                ListeDerSchuelerMitVeraenderungen.Add(Eintrag);
                            }

                        }
                    }

                }
            }

            return ListeDerSchuelerMitVeraenderungen;
        }

    }
}
