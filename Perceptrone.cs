using System;
using System.IO;
using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data;

namespace Kovaleva_lab_sem6
{
    public static class Perceptrone
    {

        public static int[,] Create(int numLines, int numElementsInLine)
        {
            Random rand = new Random();
            int placeInLine;
            int decision;
            int[,] Rij = new int[numLines, numElementsInLine];

            for (int i = 0; i < numLines; i++)
            {
                for (int j = 0; j < numElementsInLine; j++)
                {
                    Rij[i, j] = 0;
                }
                placeInLine = rand.Next(0, numElementsInLine);
                decision = rand.Next(0, 2);
                Rij[i, placeInLine] = (decision == 0) ? 1 : -1;

            }
            return Rij;
        }

        public static int[] Create(int numElementsInLine)
        {
            Random rand = new Random();
            int decision;
            int[] lyambda = new int[numElementsInLine];

            for (int j = 0; j < numElementsInLine; j++)
            {
                decision = rand.Next(0, 2);
                lyambda[j] = (decision == 0) ? 1 : -1;
            }
            return lyambda;
        }

        public static void EditXlsxFile(string fileName, int[] array, int numElementsInLine)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Open(fileName);
            xlWorkSheet = xlWorkBook.ActiveSheet as Worksheet;
            int lastRow = xlWorkBook.Sheets[1].Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;


            for (int j = 0; j < numElementsInLine; j++)
                xlWorkSheet.Cells[lastRow + 1, j + 1] = Convert.ToString(array[j]);

            xlWorkBook.Save();
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        public static void CreateXlsxFile(string fileName, int[,] array2D, int numLines, int numElementsInLine)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();


            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < numLines; i++)
                for (int j = 0; j < numElementsInLine; j++)
                    xlWorkSheet.Cells[i + 1, j + 1] = Convert.ToString(array2D[i, j]);

            xlWorkBook.SaveAs(fileName, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        public static void CreateXlsxFile(string fileName, int[] array, int numElementsInLine)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();


            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < numElementsInLine; i++)
                xlWorkSheet.Cells[i + 1] = Convert.ToString(array[i]);

            xlWorkBook.SaveAs(fileName, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        public static int[] ReadLyambdaFromFile(FileStream fs, int numLines, int numElementsInLine)
        {
            int[,] arrayRes = new int[numLines, numElementsInLine];
            int[] array = new int[numElementsInLine];
            int i = 0;
            int j = 0;
            using (var reader = ExcelReaderFactory.CreateReader(fs))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        arrayRes[i, j] = Convert.ToInt32(cell);
                        j++;
                    }
                    j = 0;
                    i++;
                }
                for (int k = 0; k < numElementsInLine; k++)
                {
                    array[k] = arrayRes[i - 1, k];
                }
            }
            return array;
        }

        public static int[,] ReadFromFile(FileStream fs, int numLines, int numElementsInLine)
        {
            int[,] arrayRes = new int[numLines, numElementsInLine];
            int i = 0;
            int j = 0;
            using (var reader = ExcelReaderFactory.CreateReader(fs))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        arrayRes[i, j] = Convert.ToInt32(cell);
                        j++;
                    }
                    j = 0;
                    i++;
                }
            }
            return arrayRes;
        }

        public static int[] CalculateY(int numLines, int numElementsInLine, int[,] Rij, int[] pictureArray)
        {
            int sumy;
            const int teta = 1;
            int[] y = new int[numElementsInLine];

            for (int j = 0; j < numElementsInLine; j++)
            {
                sumy = 0;
                for (int i = 0; i < numLines; i++)
                    sumy += Rij[i, j] * pictureArray[i];
                y[j] = (sumy - teta) >= 0 ? 1 : 0;
            }
            return y;
        }

        public static int[] Teach(int[] lyambda, int[] y, int deltaLyambda, int lowerBound, int upperBound)
        {
            for (int i = lowerBound; i < upperBound; i++)
            {
                if (y[i] == 1)
                    lyambda[i] += deltaLyambda;
            }
            return lyambda;
        }

        public static int GetSignal(int lowerBound, int upperBound, int[] lyambda, int[] y)
        {
            int sum = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                sum += lyambda[i] * y[i];
            }
            int R = (sum) >= 0 ? 1 : 0;
            return R;
        }

        public static int GetSum(int lowerBound, int upperBound, int[] lyambda, int[] y)
        {
            int sum = 0;
            for (int i = lowerBound; i < upperBound; i++)
                sum += lyambda[i] * y[i];
            return sum;
        }
    }
}
