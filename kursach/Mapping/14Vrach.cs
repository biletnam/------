using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Windows.Forms;
namespace kursach
{
    [Table]
    public class Vrach
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string FIO;
        [Column]
        public int IDSpiskaDolj;
        [Column]
        public int Zarplata;
        [Column]
        public string Data;
        [Column]
        public int VR;
        [Column]
        public int Norma;
        [Column]
        public int Premia;

    }
    public class DB14 : DataContext
    {
        public DB14(string cs) : base(cs) { }
        public System.Data.Linq.Table<Vrach> Vrach
        {
            get { return this.GetTable<Vrach>(); }
        }

    }
    public class Met14
    {
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB12 db12 = new DB12(kursach.Program.Pole.pole);
        public void ADD(string FIO,int IDSpiskaDolj,int Zarplata,string Data,int VR,int Norma,int Premia)
        {
            Vrach pac = new Vrach();
            pac.FIO = FIO;
            pac.IDSpiskaDolj = IDSpiskaDolj;
            pac.Zarplata = Zarplata;
            pac.Data = Data;
            pac.VR = VR;
            pac.Norma = Norma;
            pac.Premia = Premia;
            db14.Vrach.InsertOnSubmit(pac);
            db14.SubmitChanges();
        }
        public void Edit(int ID, string FIO, int IDSpiskaDolj, int Zarplata, int VR, int Norma, int Premia)
        {
            Vrach pac = db14.Vrach.Where(c => c.ID == ID).FirstOrDefault();
            pac.FIO = FIO;
            pac.IDSpiskaDolj = IDSpiskaDolj;
            pac.VR = VR;
            pac.Norma = Norma;
            pac.Premia = Premia;
            pac.Zarplata = Zarplata;
            db14.SubmitChanges();
        }
        public void Delete(string FIO)
        {
            Vrach pac = db14.Vrach.Where(c => c.FIO == FIO).FirstOrDefault();
            db14.Vrach.DeleteOnSubmit(pac);
            db14.SubmitChanges();
        }       
        public int RaschetZarplat2(int ID, int VR, int Premia,int Norma)
        {
            int zarplata = 0;
            string n = "";
            Form1 f = new Form1();
            RabotaSFailami.RabotaSFailami rsf = new RabotaSFailami.RabotaSFailami();
            n = rsf.outFile(Application.StartupPath.ToString() + "\\FormOplata.txt");            
            var ec = from n2 in db12.SpisokDoljnostei
                      where n2.ID == ID
                      select n2;
            foreach (var i in ec)
            {                
                    if (n == "Прямая сдельная оплата труда") { zarplata = i.Oklad * VR; }
                    if (n == "Сдельно-премиальная оплата труда") { zarplata = i.Oklad * VR + Premia; }
                    if (n == "Сдельно-прогрессивная оплата труда") { zarplata = i.Oklad * VR + (VR - Norma) * 2; }
                    if (n == "Простая повременная оплата труда") { zarplata = i.Oklad * VR; }
                    if (n == "Повременно-премиальная оплата труда") { zarplata = i.Oklad * VR + Premia; }
                    if (n == "Окладная оплата труда") { zarplata = i.Oklad; }                
            }
            return zarplata;
        }
        public void RaschetZarplat()
        {
            string n = "";
            Form1 f = new Form1();
            RabotaSFailami.RabotaSFailami rsf = new RabotaSFailami.RabotaSFailami();
            n = rsf.outFile(Application.StartupPath.ToString() + "\\FormOplata.txt");
            var ec = from n2 in db12.SpisokDoljnostei
                     select n2;
            var ec2 = from n2 in db14.Vrach
                     select n2;
            foreach (var i in ec)
            {
                foreach (var j in ec2)
                {
                    if(j.IDSpiskaDolj==i.ID){
                    if (n == "Прямая сдельная оплата труда") { j.Zarplata = i.Oklad * j.VR; }
                    if (n == "Сдельно-премиальная оплата труда") { j.Zarplata= i.Oklad * j.VR + j.Premia; }
                    if (n == "Сдельно-прогрессивная оплата труда") { j.Zarplata = i.Oklad * j.VR + (j.VR - j.Norma) * 2; }
                    if (n == "Простая повременная оплата труда") { j.Zarplata = i.Oklad * j.VR; }
                    if (n == "Повременно-премиальная оплата труда") { j.Zarplata = i.Oklad * j.VR + j.Premia; }
                    if (n == "Окладная оплата труда") { j.Zarplata = i.Oklad; }
                    }
                }
            }
            db14.SubmitChanges();
        }
    }
}
