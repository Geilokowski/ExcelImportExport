using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProExcelImportExport.PersonHelper
{
    public class TSchueler : TPerson
    {
        public String JahrgangKZ;
        public String Klasse;
        public Int32 AbschlussJahrgang;

        public TSchueler(
            String _JahrgangKZ, String _Klasse, String _Name, String _Vorname
            , String _GeburtsDatum, String _Geschlecht
            )
            : base(_Name, _Vorname, _GeburtsDatum, _Geschlecht)
        {
            JahrgangKZ = _JahrgangKZ;
            Klasse = _Klasse;
            AbschlussJahrgang = 2020;

        }
    }
}
