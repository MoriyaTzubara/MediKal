using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Excel
    {
        public string Path = "";
        public _Application _Excel = new Application();
        Workbook WorkBook;
        Worksheet WorkSheet;
        public Excel(string path, int sheet)
        {
            Path = path;
            WorkBook = _Excel.Workbooks.Open(path);
            WorkSheet = WorkBook.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            if (WorkSheet.Cells[i, j].Value2 != null)
                return WorkSheet.Cells[i, j].Value2;
            else
                return "";
        }

        ~Excel()
        {
            Marshal.ReleaseComObject(WorkBook);
            Marshal.ReleaseComObject(WorkSheet);
            Marshal.ReleaseComObject(_Excel);
        }

    }
}
