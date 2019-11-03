using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProExcelImportExport
{
    public class TObjKlassen
    {
        public List<List<String>> SchuelerListe;
        public readonly String Schuljahr;
        public readonly Int32 ReferenzJahr;

        public readonly List<String> KlassenStufe5;
        public readonly List<String> KlassenStufe6;
        public readonly List<String> KlassenStufe7;
        public readonly List<String> KlassenStufe8;
        public readonly List<String> KlassenStufe9;
        public readonly List<String> KlassenStufe10;
        public readonly List<String> KlassenStufe11;
        public readonly List<String> KlassenStufe12;
        public readonly List<String> GrundStufe;
        public readonly List<String> Sekundarstufe1;
        public readonly List<String> Sekundarstufe2;
        public readonly List<String> AlleKlassen;
        public readonly List<String> AlleJGKZ;
        public List<String> AktuelleKlassenListe;
        public List<String> AktuelleJGKZListe;

        public TObjKlassen(List<List<String>> UrListe)
        {
            SchuelerListe = new List<List<String>> { };
            Schuljahr = BestimmeSchuljahr();
            ReferenzJahr = BestimmeReferenzJahr();
            AlleJGKZ = new List<string> { };
            AktuelleKlassenListe = new List<string> { };
            AktuelleJGKZListe = new List<string> { };

            KlassenStufe5 = new List<string> { "5s" };
            foreach (String Klasse in KlassenStufe5)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2000).ToString() + Klasse.Substring(1, Klasse.Length - 1));
            KlassenStufe6 = new List<string> { "6s" };
            foreach (String Klasse in KlassenStufe6)
                AlleJGKZ.Add("JG" + (ReferenzJahr - 2001).ToString() + Klasse.Substring(1, Klasse.Length - 1));
            KlassenStufe7 = new List<string> { "7a", "7b", "7s", "7s-1", "7s-2" };
            foreach (String Klasse in KlassenStufe7)
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2002).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2000).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }

            KlassenStufe8 = new List<string> { "8a", "8b", "8s", "8s-1", "8s-2" };
            foreach (String Klasse in KlassenStufe8)
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2003).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2001).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }

            KlassenStufe9 = new List<string> { "9a", "9b", "9s", "9s-1", "9s-2" };
            foreach (String Klasse in KlassenStufe9)
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2004).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2002).ToString() + Klasse.Substring(1, Klasse.Length - 1));
                }

            KlassenStufe10 = new List<string> { "10a", "10b", "10s", "10s-1", "10s-2" };
            foreach (String Klasse in KlassenStufe10)
                if (Klasse.Contains("s"))
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2005).ToString() + Klasse.Substring(2, Klasse.Length - 2));
                }
                else
                {
                    AlleJGKZ.Add("JG" + (ReferenzJahr - 2003).ToString() + Klasse.Substring(2, Klasse.Length - 2));
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

            AlleKlassen.Add("n.n.");
            AlleJGKZ.Add("n.n.");
            BereiteSchuelerListenEintraegeAuf(UrListe);
            AktualisiereSchuelerUndKlassenListen();

        }
        public String BildeSuchName(List<String> ListenEintrag)
        {
            String SName = "";
            if (ListenEintrag.Count() > 3)
            {
                SName = ListenEintrag[2].Trim().ToLower() + ", " + ListenEintrag[3].Trim().ToLower();
            }            
            return SName;
        }

        public String BildeSuchNameExt(List<String> ListenEintrag)
        {
            String SName = "";
            if (ListenEintrag.Count() > 3)
            {
                SName = ListenEintrag[3].Trim().ToLower() + " " + ListenEintrag[2].Trim().ToLower();
            }
            return SName;
        }


        public List<List<String>> SucheListenEintragAnhandSuchName(String Suchname, List<List<String>> EintragsListe)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            String SName = Suchname.Trim().ToLower();
            foreach(List<String> Eintrag in EintragsListe)
            {
                String VergleichsName = BildeSuchName(Eintrag);
                // unscharfer Vergleich
                if (SName.Contains(VergleichsName) || VergleichsName.Contains(SName))
                {
                    ArbeitsListe.Add(Eintrag);
                }
            }
            return ArbeitsListe;
        }

        public List<List<String>> SucheEintragInSchuelerListeAnhandSuchName(String Suchname)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            String SName = Suchname.Trim().ToLower();
            foreach (List<String> Eintrag in SchuelerListe)
            {
                String VergleichsName = BildeSuchName(Eintrag);
                String VergleichsNameExt = BildeSuchNameExt(Eintrag);
                // unscharfer Vergleich
                if (VergleichsName.Contains(SName) || VergleichsNameExt.Contains(SName))
                {
                    ArbeitsListe.Add(Eintrag);
                }
            }
            return ArbeitsListe;
        }

        public List<List<String>> WaehleKlassenInSchuelerListeAus(String Suchname)
        {
            List<List<String>> AuswahlListeSchueler = new List<List<string>> { };
            List<String> ArbeitsListe = new List<string> { };
            List<String> SuchListeKlassen = new List<string> { };

            foreach(String Klasse in AktuelleKlassenListe)
            {
                SuchListeKlassen.Add(Klasse.ToLower());
            }
            List<String> SuchListeJGKZ = new List<string> { };
            foreach (String JGKZ in AktuelleJGKZListe)
            {
                SuchListeJGKZ.Add(JGKZ.ToLower());
            }

            String SName = Suchname.Trim().ToLower();
                        
            if ((SName.StartsWith("jg") & SName.Length > 3) | SName.StartsWith("ib") | SName.StartsWith("lur") | SName.StartsWith("wun") | SName.StartsWith("muk"))
            {
                foreach(String JGKZ in SuchListeJGKZ)
                {
                    if (JGKZ.Contains(SName))
                    {
                        ArbeitsListe.Add(JGKZ);                        
                    }
                    foreach (String SuchEintrag in ArbeitsListe)
                    {
                        foreach (List<String> Eintrag in SchuelerListe)
                        {
                            if (Eintrag[0].ToLower().Contains(SuchEintrag) & !AuswahlListeSchueler.Contains(Eintrag))
                            {
                                AuswahlListeSchueler.Add(Eintrag);
                            }
                        }
                    }
                }
            }
            else
            {
                if ( SName.StartsWith("5") | SName.StartsWith("6") | SName.StartsWith("7") | SName.StartsWith("8")
                     | SName.StartsWith("9") | SName.StartsWith("1") | SName.StartsWith("10") | SName.StartsWith("11") | SName.StartsWith("12") )
                {
                    foreach (String Klasse in SuchListeKlassen)
                    {
                        if (Klasse.Contains(SName))
                        {
                            ArbeitsListe.Add(Klasse);
                        }
                    }
                    foreach (String SuchEintrag in ArbeitsListe)
                    {
                        foreach (List<String> Eintrag in SchuelerListe)
                        {
                            if (Eintrag[1].ToLower().Contains(SuchEintrag) & !AuswahlListeSchueler.Contains(Eintrag))
                            {
                                AuswahlListeSchueler.Add(Eintrag);
                            }
                        }
                    }
                }
                
            }                     
            
            return AuswahlListeSchueler;
        }


        public List<List<String>> SucheListenEintragAnhandSuchEintrag(List<String> SuchEintrag, List<List<String>> EintragsListe)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            String SName = BildeSuchName(SuchEintrag);
            foreach (List<String> Eintrag in EintragsListe)
            {
                String VergleichsName = BildeSuchName(Eintrag);
                // unscharfer Vergleich
                if (SName.Contains(VergleichsName) || VergleichsName.Contains(SName))
                {
                    ArbeitsListe.Add(Eintrag);
                }
            }
            return ArbeitsListe;
        }


        private Int32 BestimmeReferenzJahr()
        {
            DateTime Heute = DateTime.Now.Date;
            DateTime Stichtag = DateTime.Parse("01.08." + Heute.Year.ToString());
            if (Heute.CompareTo(Stichtag.Date) > 0)
                return Stichtag.Year;
            else
                return Stichtag.AddYears(-1).Year;
        }

        private String BestimmeSchuljahr()
        {
            Int32 RefJahr = BestimmeReferenzJahr();
            String SJahr = "Schuljahr: " + RefJahr.ToString() + "/" + (RefJahr + 1).ToString();

            return SJahr;
        }

        public String OrdneEinerKlasseDasJGKZZu(String Klasse)
        {
            Int32 KPos = AlleKlassen.IndexOf(Klasse);
            if (KPos > 0)
            {
                return AlleJGKZ[KPos];
            }
            else
            {
                return "n.n.";
            }
        }

        public String OrdneEinemJGKZDieKlasseZu(String JGKZ)
        {
            Int32 KPos = AlleJGKZ.IndexOf(JGKZ);
            if (KPos > 0)
            {
                return AlleKlassen[KPos];
            }
            else
            {
                return "n.n.";
            }
        }

        private void BereiteSchuelerListenEintraegeAuf(List<List<String>> UrListe)
        {
            Int32 EPos = -1; String JGKZ = "n.n."; String Klasse = "n.n.";
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
                            Eintrag.Insert(1, JGKZ);
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

        public List<List<String>> SortiereListeNachNamen(List<List<String>> SortList)
        {
            List<List<String>> ArbeitsListe = new List<List<string>> { };
            ArbeitsListe = SortList;
            String NameA; String NameB;
            List<String> ZwischenSpeicher = new List<string> { };
            for (int i = 0; i < SortList.Count - 1; i++)
                for (int k = i + 1; k < SortList.Count; k++)
                {
                    NameA =BildeSuchName(ArbeitsListe[i]);
                    NameB = BildeSuchName(ArbeitsListe[k]);
                    if (NameA.CompareTo(NameB) > 0)
                    {
                        ZwischenSpeicher = ArbeitsListe[k];
                        ArbeitsListe[k] = ArbeitsListe[i];
                        ArbeitsListe[i] = ZwischenSpeicher;
                    }
                }
            return ArbeitsListe;
        }

        public List<List<String>> SortiereListeNachKlassen(List<List<String>> SortList)
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

        public void DerSchuelerListeEintraegeHinzufügen(List<List<String>> ListeNeuerEintraege)
        {
            List<String> NamensListe = new List<String> { };
            foreach (List<String> Eintrag in SchuelerListe)
                NamensListe.Add(BildeSuchName(Eintrag));
            foreach (List<String> Eintrag in ListeNeuerEintraege)
            {
                // Mindesteinträge : JKZ - Klasse - Name - Vorname
                if (Eintrag.Count > 3 & Eintrag[0].Length > 0)
                {
                    if (OrdneEinemJGKZDieKlasseZu(Eintrag[0]).CompareTo(Eintrag[1]) == 0
                        & !NamensListe.Contains(BildeSuchName(Eintrag)))
                    {
                        SchuelerListe.Add(Eintrag);
                    }
                }

            }
            AktualisiereSchuelerUndKlassenListen();
        }


        public List<List<String>> BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(List<List<String>> AndereSchuelerListe)
        {
            // Grundaufbau der zu vergleichenden Listen : JGKZ - Klasse - Name - Vorname
            List<List<String>> ListeDerSchuelerDieNichtInAndererListeEnthaltenSind = new List<List<String>> { };
            List<List<String>> ArbeitsListe = new List<List<String>> { };

            foreach (List<String> Eintrag in SchuelerListe)
            {
                ArbeitsListe = SucheListenEintragAnhandSuchEintrag(Eintrag, AndereSchuelerListe);

                if (ArbeitsListe.Count()<1)
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
                IDListeSchuelerDieNichtInAndererListeEnthaltenSind.Add(BildeSuchName(Eintrag));
            }

            foreach (List<String> Eintrag in SchuelerListe)
            {
                String VergleichsName = BildeSuchName(Eintrag);
                if (!IDListeSchuelerDieNichtInAndererListeEnthaltenSind.Contains(VergleichsName))
                {
                    foreach (List<String> AndererEintrag in AndereSchuelerListe)
                    {
                        String AndererVergleichsName = BildeSuchName(AndererEintrag);

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

    public class TObjBestandsListe : TObjKlassen
    {
        public List<TSchueler> SchuelerObjektListe;
        // List<List<String>> UrListe: JGKZ - Name - Vorname - Geburtsdatum - Geschlecht
        // List<List<String>> SchuelerListe: JGKZ - Klasse - Name - Vorname - Geburtsdatum - Geschlecht
        public List<List<String>> ListeDerSchuelerDieNichtInZensosListeEnthaltenSind;
        public List<List<String>> ArbeitsListeAusgewaehlterSchueler;

        public TObjBestandsListe(List<List<String>> UrListe) : base(UrListe)
        {
            SchuelerObjektListe = new List<TSchueler> { };
            foreach (List<String> Eintrag in SchuelerListe)
            {
                TSchueler SchuelerObjekt = new TSchueler(Eintrag[0], Eintrag[1], Eintrag[2], Eintrag[3], Eintrag[4], Eintrag[5]);
                SchuelerObjektListe.Add(SchuelerObjekt);
            }
            ListeDerSchuelerDieNichtInZensosListeEnthaltenSind = new List<List<string>> { };
            ArbeitsListeAusgewaehlterSchueler = new List<List<string>> { };
        }

        public void GleicheBestandsListeMitZensosListeAb(TObjZensosListe ZensosObjekt)
        {
            List<String> IDSchuelerListe = new List<string> { };
            ListeDerSchuelerDieNichtInZensosListeEnthaltenSind.Clear();
            foreach (List<String> Eintrag in SchuelerListe)
            {
                String IDName = Eintrag[2] + ", " + Eintrag[3];
                IDSchuelerListe.Add(IDName);
            }
            if (!(ZensosObjekt.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind == null))
            {
                ZensosObjekt.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind.Clear();
            }
            ZensosObjekt.ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind = ZensosObjekt.BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(SchuelerListe);
            if (!(ZensosObjekt.ListeDerSchuelerMitKlassenwechselInZensosListe == null))
            {
                ZensosObjekt.ListeDerSchuelerMitKlassenwechselInZensosListe.Clear();
            }

            ZensosObjekt.ListeDerSchuelerMitKlassenwechselInZensosListe = ZensosObjekt.BestimmeSchuelerMitVeraenderungenInAndererSchuelerListe(SchuelerListe);

            ListeDerSchuelerDieNichtInZensosListeEnthaltenSind = BestimmeSchuelerDieNichtInAndererListeEnthaltenSind(ZensosObjekt.SchuelerListe);
            
            foreach (List<String> Eintrag in ListeDerSchuelerDieNichtInZensosListeEnthaltenSind)
            {
                Int32 SPos = SchuelerListe.IndexOf(Eintrag);
                if (SPos > -1)
                {
                    SchuelerListe[SPos][6] = "FALSCH";
                }
            }

            foreach(List<String> Eintrag in ZensosObjekt.ListeDerSchuelerMitKlassenwechselInZensosListe)
            {
                String VName= Eintrag[2] + ", " + Eintrag[3];
                Int32 i = -1;
                foreach(String SName in IDSchuelerListe)
                {
                    i++;
                    if(SName.Contains(VName) || VName.Contains(SName))
                    {
                        SchuelerListe[i][0] = Eintrag[0];
                        SchuelerListe[i][1] = Eintrag[1];
                    }
                }
            }
            AktualisiereSchuelerUndKlassenListen();
        }

        public List<List<String>> SucheSchueler(String SuchName)
        {
            List<List<String>> SuchErgebnisListe = new List<List<string>> { };
            String SName = SuchName.Trim().ToLower();
                        
            if ( SName.StartsWith("5") | SName.StartsWith("6") | SName.StartsWith("7") | SName.StartsWith("8") | SName.StartsWith("9") | SName.StartsWith("1")
                 | ( SName.StartsWith("jg") && SName.Length > 3 ) | (SName.StartsWith("*") & SName.Length > 1))
            {
                if (SName.StartsWith("*"))
                {
                    Console.WriteLine(SName);
                    SName = SName.Substring(1).Trim();
                    Console.WriteLine(SName);
                }
                SuchErgebnisListe = WaehleKlassenInSchuelerListeAus(SName);
            }
            else
            {
                SuchErgebnisListe = SucheEintragInSchuelerListeAnhandSuchName(SName);
            }            
            return SuchErgebnisListe;
        }
    }


    public class TObjZensosListe : TObjKlassen
    {
        // List<List<String>> UrListe: Klasse - Name - Vorname - Geburtsdatum - Geschlecht
        // List<List<String>> SchuelerListe: JGKZ - Klasse - Name - Vorname - Geburtsdatum - Geschlecht
        public List<List<String>> ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind;
        public List<List<String>> ListeDerSchuelerMitKlassenwechselInZensosListe;


        public TObjZensosListe(List<List<String>> UrListe) : base(UrListe)
        {
            ListeDerSchuelerDieNichtInBestandsListeEnthaltenSind= new List<List<string>> { };
            ListeDerSchuelerMitKlassenwechselInZensosListe = new List<List<string>> { };
        }

        public List<List<String>> ErstelleNeueBestandsSchuelerListe()
        {
            List<List<String>> NeueBestandsListe = new List<List<String>> { };
            TSchueler SchuelerEintrag;
            foreach (List<String> Eintrag in SchuelerListe)
            {
                List<String> NeuerBestandSchueler = new List<string> { };
                // List<List<String>> NeueBestandsListe: JGKZ - Klasse - Name - Vorname - Geburtsdatum - Geschlecht

                SchuelerEintrag = new TSchueler(Eintrag[0], Eintrag[1], Eintrag[2], Eintrag[3], Eintrag[4], Eintrag[5]);

                NeuerBestandSchueler.Add(SchuelerEintrag.JahrgangKZ);
                NeuerBestandSchueler.Add(SchuelerEintrag.Klasse);
                NeuerBestandSchueler.Add(SchuelerEintrag.Name);
                NeuerBestandSchueler.Add(SchuelerEintrag.Vorname);
                NeuerBestandSchueler.Add(SchuelerEintrag.GeburtsDatum.ToShortDateString());
                NeuerBestandSchueler.Add(SchuelerEintrag.Geschlecht);                
                NeuerBestandSchueler.Add(SchuelerEintrag.UserNameID);
                NeuerBestandSchueler.Add("true");  // InZensos
                NeuerBestandSchueler.Add("false");  // InITK
                NeuerBestandSchueler.Add("n.n.");  // UserNameITK
                NeuerBestandSchueler.Add("false");  // InO365
                NeuerBestandSchueler.Add("n.n.");  // UserNameO365
                NeueBestandsListe.Add(NeuerBestandSchueler);                             
            }
            return NeueBestandsListe;
        }

        public List<List<String>> ErstelleNeueBestandsUrListe()
        {
            List<List<String>> NeueBestandsListe = new List<List<String>> { };
            List<List<String>> BestandsListe = ErstelleNeueBestandsSchuelerListe();

            foreach (List<String> Eintrag in BestandsListe)
            {
                // List<List<String>> NeueBestandsListe: JGKZ - Name - Vorname - Geburtsdatum - Geschlecht ...

                List<String> NeuerBestandSchueler = new List<string> { };
                Eintrag.RemoveAt(1);
                NeueBestandsListe.Add(Eintrag);

            }
            return NeueBestandsListe;
        }

        public TObjBestandsListe CreateNewBestandsListeObject()
        {

            TObjBestandsListe BestandsListeObject = new TObjBestandsListe(ErstelleNeueBestandsUrListe());
            return BestandsListeObject;
        }



    }


}