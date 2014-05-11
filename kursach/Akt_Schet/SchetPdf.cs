using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using System.Drawing;

namespace kursach
{
    class SchetPdf
    {
        public void CozdSchetPdf(string push, int ID)
        {
            try
            {
                DB5 db = new DB5(kursach.Program.Pole.pole);
                DB16 db2 = new DB16(kursach.Program.Pole.pole);
                DB1 db1 = new DB1(kursach.Program.Pole.pole);
                DB14 db14 = new DB14(kursach.Program.Pole.pole);
                DB13 db13 = new DB13(kursach.Program.Pole.pole);
                Mapping.DB17 db17 = new Mapping.DB17(kursach.Program.Pole.pole);
                var ec = from n in db.JurnalRabot
                         where n.ID == Convert.ToInt32(ID)
                         select n;
                int temp = 0;
                foreach (var i in ec) { temp = i.IDZapisi; }
                var ec2 = from n in db2.Zapis
                          where n.ID == temp
                          select n;
                var Firma = from n in db17.Firma
                            where n.ID == 1
                            select n;
                string temp2 = "";
                foreach (var i in ec2) { temp2 = i.Data; }
                var doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(push, FileMode.Create));
                doc.Open();
                BaseFont basefont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Phrase j = new Phrase("Счет №" + ID, new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
                Paragraph a1 = new Paragraph(j);
                a1.Add(Environment.NewLine);  
                a1.Alignment = Element.ALIGN_CENTER;
                a1.SpacingAfter = 5;
                doc.Add(a1);
                Paragraph a2 = new Paragraph();
                a2.Add(new Phrase("от " + temp2 + "г.", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                a2.Alignment = Element.ALIGN_RIGHT;
                a2.SpacingAfter = 5;
                a2.Add(Environment.NewLine);
                a2.Add(Environment.NewLine);
                a2.Add(Environment.NewLine);
                a2.Add(Environment.NewLine);
                doc.Add(a2);
                PdfPTable table2 = new PdfPTable(3);
                table2.WidthPercentage = 100;
                foreach (var i in Firma)
                {
                    PdfPCell cell8 = new PdfPCell(new Phrase("ИНН "+i.INN, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    cell8.BackgroundColor = new BaseColor(Color.White);
                    cell8.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cell9 = new PdfPCell(new Phrase("КПП "+i.KPP, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell10 = new PdfPCell(new Phrase("", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table2.AddCell(cell8);
                    table2.AddCell(cell9);
                    table2.AddCell(cell10);
                    PdfPCell cell11 = new PdfPCell(new Phrase("Получатель "+i.Name, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell12 = new PdfPCell(new Phrase("Счет №", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell13 = new PdfPCell(new Phrase(i.Schet, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell14 = new PdfPCell(new Phrase("Банк получателя "+i.Bank, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell15 = new PdfPCell(new Phrase("Счет № ", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    PdfPCell cell16 = new PdfPCell(new Phrase(i.SchetBank, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table2.AddCell(cell11);
                    table2.AddCell(cell12);
                    table2.AddCell(cell13);
                    table2.AddCell(cell14);
                    table2.AddCell(cell15);
                    table2.AddCell(cell16);
                }
                
                doc.Add(table2);
                Paragraph a3 = new Paragraph();
                DB11 db11 = new DB11(kursach.Program.Pole.pole);
                var Raspisanie = from n in db11.Raspisanie
                                 where n.ID == temp
                                 select n;
                foreach (var i in Raspisanie) { temp = i.IDVrach; }
                var Vrach = from n in db14.Vrach
                            where n.ID == temp
                            select n;
                foreach (var i in Vrach) { temp2 = i.FIO; }
                a3.Add(new Phrase("Исполнитель: " + temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                a3.Alignment = Element.ALIGN_LEFT;
                a3.SpacingAfter = 5;
                a3.Add(Environment.NewLine);
                foreach (var i in ec2) { temp = i.IDPacienta; }
                var ec3 = from n in db1.Pacient
                          where n.ID == temp
                          select n;
                foreach (var i in ec3) { temp2 = i.FIO; }
                a3.Add(new Phrase("Заказчик: " + temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                a3.Add(Environment.NewLine);
                a3.Add(Environment.NewLine);
                a3.Add(Environment.NewLine);
                a3.Add(Environment.NewLine);
                doc.Add(a3);
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase("Наименование услуги", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.BackgroundColor = new BaseColor(Color.White);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell1 = new PdfPCell(new Phrase("Цена", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                PdfPCell cell2 = new PdfPCell(new Phrase("Скидка", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                PdfPCell cell3 = new PdfPCell(new Phrase("Итого", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.BOLD, new BaseColor(Color.Black))));
                table.AddCell(cell);
                table.AddCell(cell1);
                table.AddCell(cell2);
                table.AddCell(cell3);
                foreach (var i in ec2) { temp = i.IDUslugi; }
                var ec5 = from n in db13.Uslugi
                          where n.ID == temp
                          select n;
                foreach (var i in ec5) { temp2 = i.Name; }
                PdfPCell cell4 = new PdfPCell(new Phrase(temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                foreach (var i in ec) { temp2 = i.Cena.ToString(); }
                PdfPCell cell5 = new PdfPCell(new Phrase(temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                foreach (var i in ec) { temp2 = i.Skidka.ToString(); }
                PdfPCell cell6 = new PdfPCell(new Phrase(temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                foreach (var i in ec) { temp2 = i.Itog.ToString(); }
                PdfPCell cell7 = new PdfPCell(new Phrase(temp2, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.BOLD, new BaseColor(Color.Black))));
                table.AddCell(cell4);
                table.AddCell(cell5);
                table.AddCell(cell6);
                table.AddCell(cell7);
                doc.Add(table);
                Paragraph a4 = new Paragraph();
                a4.Add(Environment.NewLine);
                a4.Add(new Phrase("Всего оказано услуг на сумму: " + temp2 + "рублей ", new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.ITALIC, new BaseColor(Color.Black))));
                a4.Alignment = Element.ALIGN_LEFT;
                a4.SpacingAfter = 5;
                a4.Add(Environment.NewLine);
                a4.Add(Environment.NewLine);
                a4.Add(Environment.NewLine);
                a4.Add(Environment.NewLine);                
                string temp3 = "";
                foreach (var i in Vrach) { temp2 = i.FIO; }
                foreach (var i in ec3) { temp3 = i.FIO; }
                foreach (var i in Firma)
                {
                    a4.Add(new Phrase("Исполнитель:________________________ " + temp2 + Environment.NewLine + Environment.NewLine + "Бухгалтер: ________________________"+i.Buh, new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.ITALIC, new BaseColor(Color.Black))));
                }
                a4.Add(Environment.NewLine);
                doc.Add(a4);
                doc.Close();
            }
            catch { }
        }
    }
}
