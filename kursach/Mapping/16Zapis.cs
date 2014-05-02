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
    public class Zapis
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDPacienta;
        [Column]
        public int IDVracha;
        [Column]
        public int IDUslugi;
        [Column]
        public string Data;
        [Column]
        public string Vrem;
    }
    public class DB16 : DataContext
    {
        public DB16(string cs) : base(cs) { }
        public System.Data.Linq.Table<Zapis> Zapis
        {
            get { return this.GetTable<Zapis>(); }
        }

    }
    public class Met16
    {
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        public void ADD(int IDPacienta,int IDVracha,int IDUslugi,string Data,string Vrem)
        {
            Zapis pac = new Zapis();
            pac.IDPacienta = IDPacienta;
            pac.IDVracha = IDVracha;
            pac.IDUslugi = IDUslugi;
            pac.Vrem = Vrem ;
            pac.Data = Data;
            db16.Zapis.InsertOnSubmit(pac);
            db16.SubmitChanges();
        }
        public void Edit(int ID, int IDPacienta, int IDVracha, int IDUslugi, string Data, string Vrem)
        {
            Zapis pac = db16.Zapis.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDPacienta = IDPacienta;
            pac.IDVracha = IDVracha;
            pac.IDUslugi = IDUslugi;
            pac.Vrem = Vrem;
            pac.Data = Data;
            db16.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Zapis pac = db16.Zapis.Where(c => c.ID == ID).FirstOrDefault();
            db16.Zapis.DeleteOnSubmit(pac);
            db16.SubmitChanges();
        }
        public bool prov_id(int id)
        {
            bool pro = false;
            var ec = from n in db1.Pacient
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
            var ec = from n in db13.Uslugi
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
        public bool prov_id3(int id)
        {
            bool pro = false;
            var ec = from n in db14.Vrach
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
