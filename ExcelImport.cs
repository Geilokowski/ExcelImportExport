using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
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

    public class TObjExcelExport
    {
        public List<List<String>> EintragsListe;
        public readonly String ExcelDatei;

        public TObjExcelExport(String ExcelFile,List<List<String>> ListToSave)
        {
            MyExcel.Workbook ArbeitsMappe;
            MyExcel.Worksheet ArbeitsBlatt;
            ExcelDatei = ExcelFile;
            MyExcel.Application ExcelApp = new MyExcel.Application();
            
            object misvalue = System.Reflection.Missing.Value;

            Int32 AnzEintraege = ListToSave.Count;
            Int32 ZeilenNr;
            Int32 SpaltenNr;

            try
            {
                if (ExcelApp != null)
                {
                    ExcelApp.Visible = false;
                    ExcelApp.DisplayAlerts = false;
                    try
                    {                        
                        ArbeitsMappe = ExcelApp.Workbooks.Add(misvalue);
                       
                        ArbeitsBlatt = ArbeitsMappe.ActiveSheet;

                        ZeilenNr = 0;
                        foreach(List<String> Eintrag in ListToSave)
                        {
                            ZeilenNr++;
                            SpaltenNr = 0;
                            foreach(String Wert in Eintrag)
                            {
                                SpaltenNr++;
                                MyExcel.Range ZellObjekt = (ArbeitsBlatt.Cells[ZeilenNr,SpaltenNr] as MyExcel.Range);
                                ZellObjekt.Value2 = Wert;
                            }
                        }

                        try
                        {
                            ArbeitsMappe.SaveAs(ExcelDatei);
                        }
                        catch
                        { }
                        ArbeitsMappe.Close(false, ExcelDatei);
                        Marshal.ReleaseComObject(ArbeitsMappe);
                    }
                    catch
                    { }

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
