using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace kursach
{
    class OtchetExel
    {
        public void SozdOtchetExel(int year)
        {
            Excel.Application excelapp = new Excel.Application();
            //добавляем книгу
            excelapp.Workbooks.Add(Type.Missing);

            ////делаем временно неактивным документ
            excelapp.Interactive = true;
            excelapp.ScreenUpdating = true;
            excelapp.UserControl = true;
            excelapp.Visible = true;
            //xlApp.Interactive = true;
            //xlApp.EnableEvents = true;
            Excel.Workbooks excelappworkbooks = excelapp.Workbooks;
            Excel.Workbook excelappworkbook = excelappworkbooks[1];
            Excel.Sheets excelsheets = excelappworkbook.Worksheets;
            //выбираем лист на котором будем работать (Лист 1)
            Excel.Worksheet xlSheet = (Excel.Worksheet)excelapp.Sheets[1];
            //Название листа
            xlSheet.Name = "Отчет";
            int rowInd = 0;
            string data = "";
            string[] dt=new string[]{"Месяц","1","2","3","4","5","6","7","8","9","10","11","12"};
            Excel.Range xlSheetRange=xlSheet.get_Range("A1:Z1", Type.Missing);;
                //называем колонки
            for (int i = 0; i < dt.Length; i++)
            {
                data = dt[i];
                xlSheet.Cells[1, i + 1] = data;
                //выделяем первую строку
                xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                //делаем полужирный текст и перенос слов
                xlSheetRange.WrapText = true;
                xlSheetRange.Font.Bold = true;
            }
            //заполняем строки
            for (rowInd = 0; rowInd < dt.Length; rowInd++)
            {               
                    data = dt[rowInd];
                    xlSheet.Cells[rowInd + 1] = data;
            }

            //Отсоединяемся от Excel
            releaseObject(xlSheetRange);
            releaseObject(xlSheet);
            releaseObject(excelapp);
            ////Закрытие
            //excelapp.Quit();
        }
        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
