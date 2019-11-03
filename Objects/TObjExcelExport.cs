using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MyExcel = Microsoft.Office.Interop.Excel;

namespace ProExcelImportExport.ExcelHelper
{
    public class TObjExcelExport
    {
        public List<List<String>> EintragsListe;
        public readonly String ExcelDatei;

        public TObjExcelExport(String ExcelFile, List<List<String>> ListToSave)
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
                        foreach (List<String> Eintrag in ListToSave)
                        {
                            ZeilenNr++;
                            SpaltenNr = 0;
                            foreach (String Wert in Eintrag)
                            {
                                SpaltenNr++;
                                MyExcel.Range ZellObjekt = (ArbeitsBlatt.Cells[ZeilenNr, SpaltenNr] as MyExcel.Range);
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
