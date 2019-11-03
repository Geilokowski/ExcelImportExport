using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProExcelImportExport
{
    public partial class FoSucheSchueler : Form
    {
        TObjBestandsListe ObjBestandsListe;
        List<List<String>> ListeSuchergebnisse;
        List<List<String>> ListeAuswahlSchueler;

        public FoSucheSchueler(TObjBestandsListe ObjektBestandsListe)
        {
            InitializeComponent();
            ObjBestandsListe = ObjektBestandsListe;
            ListeSuchergebnisse = new List<List<string>> { };
            ListeAuswahlSchueler = new List<List<string>> { };
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            ObjBestandsListe.ArbeitsListeAusgewaehlterSchueler.Clear();
            foreach(List<String> Eintrag in ListeAuswahlSchueler)
            {
                ObjBestandsListe.ArbeitsListeAusgewaehlterSchueler.Add(Eintrag);
            }
            Close();
           
        }

        private void tBEingabeSuchBegriff_TextChanged(object sender, EventArgs e)
        {
            List<List<String>> SuchErgebnisListe = ObjBestandsListe.SucheSchueler(tBEingabeSuchBegriff.Text);

            cLBSuchErgebnis.Items.Clear();
            ListeSuchergebnisse.Clear();
            foreach(List<String> Eintrag in SuchErgebnisListe)
            {
                cLBSuchErgebnis.Items.Add(Eintrag[1] + " " + Eintrag[2] + ", " + Eintrag[3]);                
                ListeSuchergebnisse.Add(Eintrag);
            }
            if (ListeSuchergebnisse.Count > 0)
            {
                bTAswahlAllerEintraege.Enabled = true;
                bTAswahlAllerEintraege.Visible = true;
                bTAswahlAllerEintraege.Text = "Alle " + ListeSuchergebnisse.Count.ToString() + " Einträge markieren";
            }
            else 
            {
                bTAswahlAllerEintraege.Text = "Keine Eintrag vorhanden";
                bTAswahlAllerEintraege.Enabled = false;
                bTAswahlAllerEintraege.Visible = false;
            }
            
        }

        private void cLBSuchErgebnis_SelectedValueChanged(object sender, EventArgs e)
        {
            ListeAuswahlSchueler.Clear();
            lBAuswahlListe.Items.Clear();
            Int32 AnzEintraege = cLBSuchErgebnis.Items.Count;
            for (Int32 i = 0; i < AnzEintraege; i++)
            {
                if (cLBSuchErgebnis.GetItemChecked(i))
                {
                    List<String> Eintrag = ListeSuchergebnisse[i];
                    ListeAuswahlSchueler.Add(Eintrag);
                    lBAuswahlListe.Items.Add(Eintrag[1] + " " + Eintrag[2] + ", " + Eintrag[3]);
                }
            }
        }

        private void bTAswahlAllerEintraege_Click(object sender, EventArgs e)
        {
            Int32 AnzEintraege = cLBSuchErgebnis.Items.Count;
            for (Int32 i = 0; i < AnzEintraege; i++)
            {
                cLBSuchErgebnis.SetItemChecked(i, true);
                List<String> Eintrag = ListeSuchergebnisse[i];
                ListeAuswahlSchueler.Add(Eintrag);
                lBAuswahlListe.Items.Add(Eintrag[1] + " " + Eintrag[2] + ", " + Eintrag[3]);                
            }
        }
    }
}
