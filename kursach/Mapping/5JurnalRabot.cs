using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
namespace kursach
{
    [Table]
    public class JurnalRabot
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDZapisi;
        [Column]
        public int Cena;
        [Column]
        public int Skidka;
        [Column]
        public int Itog;
    }
    public class DB5 : DataContext
    {
        public DB5(string cs) : base(cs) { }
        public System.Data.Linq.Table<JurnalRabot> JurnalRabot
        {
            get { return this.GetTable<JurnalRabot>(); }
        }

    }
    public class Met5
    {
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        DB16 db16=new DB16(kursach.Program.Pole.pole);
        DB2 db2 = new DB2(kursach.Program.Pole.pole);
        DB3 db3=new DB3(kursach.Program.Pole.pole);
        DB1 db1=new DB1(kursach.Program.Pole.pole);
        public void ADD(int IDZapisi, int Cena, int Skidka, int Itog)
        {
            JurnalRabot pac = new JurnalRabot();
            pac.IDZapisi = IDZapisi;
            pac.Cena = Cena;
            pac.Skidka = Skidka;
            pac.Itog = Itog;
            db5.JurnalRabot.InsertOnSubmit(pac);
            db5.SubmitChanges();
        }
        public void Edit(int ID, int IDZapisi, int Cena, int Skidka, int Itog)
        {
            JurnalRabot pac = db5.JurnalRabot.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDZapisi = IDZapisi;
            pac.Cena = Cena;
            pac.Skidka = Skidka;
            pac.Itog = Itog;
            db5.SubmitChanges();
        }
        public void Delete(int ID)
        {
            JurnalRabot pac = db5.JurnalRabot.Where(c => c.ID == ID).FirstOrDefault();            
            db5.JurnalRabot.DeleteOnSubmit(pac);
            db5.SubmitChanges();
            var ec = from n in db2.IspolOborud
                    where n.IDRabot == ID
                    select n;
            foreach (var i in ec)
            {
                IspolOborud pac2 = db2.IspolOborud.Where(c => c.IDRabot == ID).FirstOrDefault();
                db2.IspolOborud.DeleteOnSubmit(pac2);
                db2.SubmitChanges();
            }
            var ec2 = from n in db2.IspolOborud
                    where n.IDRabot == ID
                    select n;
            foreach (var i in ec2)
            {
                IspolPabot pac3 = db3.IspolRabot.Where(c => c.IDRabot == ID).FirstOrDefault();
                db3.IspolRabot.DeleteOnSubmit(pac3);
                db3.SubmitChanges();
            }
        }
        public int RaschetSkidki(int IDPacient)
        {
            RabotaSFailami.RabotaSFailami rsf = new RabotaSFailami.RabotaSFailami();
            string stroka = rsf.outFile2(Application.StartupPath.ToString() + "\\Skidka.txt");
            int ind = 1;
            int summa=0;
            string[] Row = stroka.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int CountRow = Row.Length;
            string[][] mas = new string[CountRow][];
            for (int i = 0; i < CountRow; i++)
            {
                string[] Col = Row[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                mas[i] = new string[Col.Length];
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = Col[j];
                }
            }
            for (int i = 0; i < CountRow - 1; i++)
            {
                if (mas[i].Length == mas[i + 1].Length)
                {
                    ind++;
                }
            }
            var Pacient = from n2 in db1.Pacient
                          where n2.ID==IDPacient
                             select n2;
            foreach (var i in Pacient)
            {
                if (mas[0][0] == "1") 
                { 
                    string[] str = mas[0][1].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries); 
                    string[] str2 = mas[0][3].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j=0;j<str.Length; j++)
                    { 
                    if(i.Posesh>=Convert.ToInt32(str[j]))
                    {
                        summa = Convert.ToInt32(str2[j]);
                    }
                    }
                }
                if (mas[1][0] == "1" && i.Status=="Пенсионер") { summa += Convert.ToInt32(mas[1][1]); }
                if (mas[2][0] == "1" && i.Status=="Студент") { summa += Convert.ToInt32(mas[2][1]); }
                if (mas[3][0] == "1" && i.Status=="Учащийся") { summa += Convert.ToInt32(mas[3][1]); }
            }
            if (summa >= 100) { summa = 99; }
            return summa;
        }
        
    }
}
