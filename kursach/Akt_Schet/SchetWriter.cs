using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;
using System.IO;
using System.Drawing;

namespace kursach
{
    class SchetWriter
    {
        public void CozdSchetWriter(string push, int ID)
        {
            DB5 db = new DB5(kursach.Program.Pole.pole);
            DB16 db2 = new DB16(kursach.Program.Pole.pole);
            DB1 db1 = new DB1(kursach.Program.Pole.pole);
            DB14 db14 = new DB14(kursach.Program.Pole.pole);
            DB13 db13 = new DB13(kursach.Program.Pole.pole);
            Mapping.DB17 db17=new Mapping.DB17(kursach.Program.Pole.pole);
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
            unoidl.com.sun.star.uno.XComponentContext localContext = uno.util.Bootstrap.bootstrap();
            unoidl.com.sun.star.lang.XMultiServiceFactory multiServiceFactory = (unoidl.com.sun.star.lang.XMultiServiceFactory)localContext.getServiceManager();
            XComponentLoader componentLoader = (XComponentLoader)multiServiceFactory.createInstance("com.sun.star.frame.Desktop");
            XComponent xComponent = componentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().setString("Счет №" + ID  + Environment.NewLine);

            unoidl.com.sun.star.text.XTextRange x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "от " + temp2 + "г." + Environment.NewLine + Environment.NewLine + Environment.NewLine, true);
            unoidl.com.sun.star.text.XTextRange xi = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            foreach (var i in Firma)
            {
                ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(xi, "ИНН " + i.INN + " КПП " + i.KPP + Environment.NewLine + "Получатель " + i.Name + " № Счета " + i.Schet + Environment.NewLine + "Банк получателя " + i.Bank + " № Счета банка " + i.SchetBank + Environment.NewLine,true);
            }

            DB11 db11 = new DB11(kursach.Program.Pole.pole);
            var Raspisanie = from n in db11.Raspisanie
                             where n.ID == temp
                             select n;
            foreach (var i in Raspisanie) { temp = i.IDVrach; }
            var Vrach = from n in db14.Vrach
                        where n.ID == temp
                        select n;
            foreach (var i in Vrach) { temp2 = i.FIO; }
            unoidl.com.sun.star.text.XTextRange x2 = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x2, "Исполнитель: " + temp2 + Environment.NewLine, true);

            foreach (var i in ec2) { temp = i.IDPacienta; }
            var ec3 = from n in db1.Pacient
                      where n.ID == temp
                      select n;
            foreach (var i in ec3) { temp2 = i.FIO; }
            unoidl.com.sun.star.text.XTextRange x3 = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x3, "Заказчик: " + temp2 + Environment.NewLine + Environment.NewLine + Environment.NewLine, true);

            //Таблица
            XFrame frame = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getCurrentController().getFrame();
            XDispatchHelper xDispatchHelper = (XDispatchHelper)multiServiceFactory.createInstance("com.sun.star.frame.DispatchHelper");
            unoidl.com.sun.star.beans.PropertyValue[] tableArgs = new unoidl.com.sun.star.beans.PropertyValue[4];
            tableArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            tableArgs[1] = new unoidl.com.sun.star.beans.PropertyValue();
            tableArgs[2] = new unoidl.com.sun.star.beans.PropertyValue();
            tableArgs[3] = new unoidl.com.sun.star.beans.PropertyValue();
            tableArgs[0].Name = "TableName";
            tableArgs[0].Value = new uno.Any("Акт");
            tableArgs[1].Name = "Columns";
            tableArgs[1].Value = new uno.Any(4);
            tableArgs[2].Name = "Rows";
            tableArgs[2].Value = new uno.Any(2);
            tableArgs[3].Name = "Flags";
            tableArgs[3].Value = new uno.Any(9);
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any("Наименование Услуги");
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertTable", "", 0, tableArgs);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs2 =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any("Цена");
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs2);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs3 =
new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any("Скидка");
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs3);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs4 =
new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any("Итого");
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs4);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            foreach (var i in ec2) { temp = i.IDUslugi; }
            var ec5 = from n in db13.Uslugi
                      where n.ID == temp
                      select n;
            foreach (var i in ec5) { temp2 = i.Name; }
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs5 =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any(temp2);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs5);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            foreach (var i in ec) { temp2 = i.Cena.ToString(); }
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs6 =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any(temp2);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs6);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            foreach (var i in ec) { temp2 = i.Skidka.ToString(); }
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs7 =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any(temp2);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs7);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);
            foreach (var i in ec) { temp2 = i.Itog.ToString(); }
            unoidl.com.sun.star.beans.PropertyValue[] cellTextArgs8 =
            new unoidl.com.sun.star.beans.PropertyValue[1];
            cellTextArgs[0] = new unoidl.com.sun.star.beans.PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any(temp2);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs8);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell", "", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, cellTextArgs);

            unoidl.com.sun.star.text.XTextRange x4 = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x4, "Всего оказано услуг на сумму: " + temp2 + "рублей " + Environment.NewLine + Environment.NewLine  + Environment.NewLine + Environment.NewLine, true);
            string temp3 = "";
            foreach (var i in Vrach) { temp2 = i.FIO; }
            foreach (var i in ec3) { temp3 = i.FIO; }
            unoidl.com.sun.star.text.XTextRange x5 = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            foreach (var i in Firma)
            {
                ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x5, "Исполнитель:__________________ " + temp2 + Environment.NewLine + "Бухгалтер:__________________"+i.Buh, true);
            }
            ((XStorable)xComponent).storeToURL(@"file:///" + push.Replace(@"\", "/"), new unoidl.com.sun.star.beans.PropertyValue[0]);
            xComponent.dispose();
        }
    }
}
