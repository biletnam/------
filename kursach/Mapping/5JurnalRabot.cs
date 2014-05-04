using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
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
        public bool prov_id(int id)
        {
            bool pro = false;
            var ec = from n in db16.Zapis
                     select n;
            foreach (var i in ec)
            {
                if (id == i.ID)
                {
                    pro = true;
                }
            }
            return pro;
        }
        public bool prov_id2(int id)
        {
            bool pro = false;
            var ec = from n in db5.JurnalRabot
                     select n;
            foreach (var i in ec)
            {
                if (id == i.ID)
                {
                    pro = true;
                }
            }
            return pro;
        }
    }
}
