using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;

namespace ProExcelImportExport
{
    public partial class FoExcelImportExport : Form
    {
        public TProgVerzeichnisse FoProgrammVerzeichnisse;

        public FoExcelImportExport(TProgVerzeichnisse ProgVerzeichnisse)
        {
            InitializeComponent();
            FoProgrammVerzeichnisse = ProgVerzeichnisse;
            cBBestandsDateiExistenz.Checked = FoProgrammVerzeichnisse.BestandsDateiExistenz;
            cBZensosDateiExistenz.Checked = FoProgrammVerzeichnisse.ZensosDateiExistenz;
            lbBestandsDatei.Text= FoProgrammVerzeichnisse.BestandsDatei;
            lbZensosDatei.Text = FoProgrammVerzeichnisse.ZensosDatei;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            TObjExcelImport ZensosListeExcelObjekt = new TObjExcelImport(FoProgrammVerzeichnisse.ZensosDatei);
            TObjZensosListe ZensosListenObjekt = new TObjZensosListe(ZensosListeExcelObjekt.EintragsListe);
            List<List<String>> TestListe = ZensosListenObjekt.ErstelleNeueBestandsSchuelerListe();
            TObjBestandsListe BObj = ZensosListenObjekt.CreateNewBestandsListeObject();
            TObjExcelExport BExport = new TObjExcelExport(FoProgrammVerzeichnisse.ListenVerzeichnis + @"\ExportTest.xlsx", BObj.SchuelerListe);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Zensos";
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel documents (.xlsx)|Zensos*.xlsx";
           
            DialogResult result = dlg.ShowDialog();
                       
            if (result == DialogResult.OK)
            {
                FoProgrammVerzeichnisse.ZensosDatei = @dlg.FileName;
                lbZensosDatei.Text = dlg.FileName;
               
            }
        }

        private void btImportBestand_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Bestand";
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel documents (.xlsx)|Bestand*.xlsx";

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                FoProgrammVerzeichnisse.BestandsDatei = @dlg.FileName;
                lbBestandsDatei.Text = FoProgrammVerzeichnisse.BestandsDatei;
                cBBestandsDateiExistenz.Checked = File.Exists(FoProgrammVerzeichnisse.BestandsDatei);

            }

        }
    }

   
}
