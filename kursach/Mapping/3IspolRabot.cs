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
    public class IspolPabot
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDRashodnika;
        [Column]
        public int Kolichestvo;
        [Column]
        public int IDRabot;
    }
    public class DB3 : DataContext
    {
        public DB3(string cs) : base(cs) { }       
        public System.Data.Linq.Table<IspolPabot> IspolRabot
        {
            get { return this.GetTable<IspolPabot>(); }
        }

    }
    public class Met3
    {
        DB3 db3 = new DB3(kursach.Program.Pole.pole);
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        DB9 db9 = new DB9(kursach.Program.Pole.pole);
        DB7 db7=new DB7(kursach.Program.Pole.pole);
        public void ADD(int IDRashodnika,int Kolichestvo,int IDRabot)
        {
            IspolPabot pac = new IspolPabot();
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.IDRabot = IDRabot;
            db3.IspolRabot.InsertOnSubmit(pac);
            db3.SubmitChanges();
        }
        public void Edit(int ID, int IDRashodnika, int Kolichestvo, int IDRabot)
        {
            IspolPabot pac = db3.IspolRabot.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.IDRabot = IDRabot;
            db3.SubmitChanges();
        }
        public void Delete(int ID)
        {
            IspolPabot pac = db3.IspolRabot.Where(c => c.ID == ID).FirstOrDefault();
            db3.IspolRabot.DeleteOnSubmit(pac);
            db3.SubmitChanges();
        }
        public bool prov_id2(int id)
        {
            bool pro = false;
            var ec = from n in db9.Oborud
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
        public bool prov_id(int id)
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
        public bool prov_kol(int id,int kol)
        {
            bool pro = false;
            var ec = from n in db7.Medicament
                     select n;
            foreach (var i in ec)
            {
                if (id == i.ID && i.Kol>=kol)
                {
                    pro = true;
                }
            }
            return pro;
        }

    }
}
