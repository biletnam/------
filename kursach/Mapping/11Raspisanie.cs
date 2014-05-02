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
    public class Raspisanie
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDVrem;
        [Column]
        public int IDVrach;
    }
    public class DB11 : DataContext
    {
        public DB11(string cs) : base(cs) { }
        public System.Data.Linq.Table<Raspisanie> Raspisanie
        {
            get { return this.GetTable<Raspisanie>(); }
        }

    }
    public class Met11
    {
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);

        public void ADD(int IDVrem,int IDVrach)
        {
            Raspisanie pac = new Raspisanie();
            pac.IDVrem= IDVrem;
            pac.IDVrach = IDVrach;
            db11.Raspisanie.InsertOnSubmit(pac);
            db11.SubmitChanges();
        }
        public void Edit(int ID, int IDVrem, int IDVrach)
        {
            Raspisanie pac = db11.Raspisanie.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDVrem = IDVrem;
            pac.IDVrach = IDVrach;
            db11.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Raspisanie pac = db11.Raspisanie.Where(c => c.ID == ID).FirstOrDefault();
            db11.Raspisanie.DeleteOnSubmit(pac);
            db11.SubmitChanges();
        }
        public bool prov_id(int id)
        {
            bool pro = false;
            var ec = from n in db15.Vrem
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
