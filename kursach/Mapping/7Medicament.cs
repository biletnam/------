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
    public class Medicament
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public int Kol;
        [Column]
        public int IDPost;
        [Column]
        public int Min;
        [Column]
        public int CenazaEd;
        [Column]
        public int Zak;
    }
    public class DB7 : DataContext
    {
        public DB7(string cs) : base(cs) { }
        public System.Data.Linq.Table<Medicament> Medicament
        {
            get { return this.GetTable<Medicament>(); }
        }

    }
    public class Met7
    {
        DB7 db7 = new DB7(kursach.Program.Pole.pole);
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        public void ADD(string Name, int Kol, int IDPost, int Min, int CenazaEd, int Zak)
        {
            Medicament pac = new Medicament();
            pac.Name = Name;
            pac.Kol =Kol  ;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            db7.Medicament.InsertOnSubmit(pac);
            db7.SubmitChanges();
        }
        public void Edit(int ID,string Name,int Kol,int IDPost,int Min,int CenazaEd,int Zak)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Kol = Kol;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            db7.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            db7.Medicament.DeleteOnSubmit(pac);
            db7.SubmitChanges();
        }
        public bool prov_id(int id)
        {
            bool pro = false;
            var ec = from n in db10.Postavshik
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
