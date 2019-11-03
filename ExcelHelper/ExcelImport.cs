using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using MyExcel = Microsoft.Office.Interop.Excel;

namespace ProExcelImportExport
{
    public class TObjExcelImport
    {
        public List<List<String>> EintragsListe = new List<List<String>> { };
        public readonly String ExcelDatei; 
        
        public TObjExcelImport(String ExcelFile)
        {
            MyExcel.Workbook ArbeitsMappe;
            MyExcel.Worksheet ArbeitsBlatt;
            MyExcel.Range ZellBereich;
            List<String> Eintrag;

            ExcelDatei = ExcelFile;
            MyExcel.Application ExcelApp = new MyExcel.Application(); 

            try
            {           
                if (ExcelApp != null & File.Exists(ExcelDatei))
                {
                    ExcelApp.Visible = false;
                    ExcelApp.DisplayAlerts = false;
                    try
                    {
                        ArbeitsMappe = ExcelApp.Workbooks.Open(ExcelDatei);
                        for (int j = 1; j <= ArbeitsMappe.Worksheets.Count; j++)
                        {
                            ArbeitsBlatt = ArbeitsMappe.Sheets[j];
                            ZellBereich = ArbeitsBlatt.UsedRange;
                            int AnzZeilen = ZellBereich.Rows.Count;
                            int AnzSpalten = ZellBereich.Columns.Count;
                            for (int i = 1; i <= AnzZeilen; i++)
                            {
                                Eintrag = new List<String> { };
                                for (int k = 1; k <= AnzSpalten; k++)
                                {
                                    MyExcel.Range ZellObjekt = (ArbeitsBlatt.Cells[i, k] as MyExcel.Range);
                                    if (ZellObjekt.Value != null)
                                    {
                                        Eintrag.Add(ZellObjekt.Value2.ToString());
                                    }
                                    else
                                    {
                                        Eintrag.Add("n.n.");
                                    }
                                }
                                EintragsListe.Add(Eintrag);
                            }
                        }
                        ArbeitsMappe.Close(false, ExcelDatei);
                        Marshal.ReleaseComObject(ArbeitsMappe);
                    }
                    catch
                    { }
                    
                    if (EintragsListe.Count > 0)
                    {
                        int DatumPos = EintragsListe[0].IndexOf("Geburtsdatum");
                        if (DatumPos > -1)
                        {
                            foreach(List<String> SEintrag in EintragsListe)
                            {
                                try
                                {
                                    SEintrag[DatumPos] = DateTime.FromOADate(Convert.ToDouble(SEintrag[DatumPos])).ToShortDateString();
                                }
                                catch {
                                    // Error Handling muss ja nicht sein, wa? Da löst man lieber 10000 Exceptions aus als seinen Code zu optimieren.
                                }
                            }
                        }
                    }
                    ExcelApp.Quit();
                }
            }
            catch
            {
                ExcelApp.Quit();
            }
            Marshal.ReleaseComObject(ExcelApp);
        }
    }
}
