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
    public class Oborud
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public int Cena;
        [Column]
        public int IDPostav;       
    }
    public class DB9 : DataContext
    {
        public DB9(string cs) : base(cs) { }
        public System.Data.Linq.Table<Oborud> Oborud
        {
            get { return this.GetTable<Oborud>(); }
        }

    }
    public class Met9
    {
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        DB9 db9 = new DB9(kursach.Program.Pole.pole);
        public void ADD(string Name, int Cena, int IDPostav)
        {
            Oborud pac = new Oborud();
            pac.Name = Name;
            pac.Cena = Cena;
            pac.IDPostav = IDPostav;   
            db9.Oborud.InsertOnSubmit(pac);
            db9.SubmitChanges();
        }
        public void Edit(int ID,string Name,int Cena,int IDPostav)
        {
            Oborud pac = db9.Oborud.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Cena = Cena ;
            pac.IDPostav = IDPostav;            
            db9.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Oborud pac = db9.Oborud.Where(c => c.ID == ID).FirstOrDefault();
            db9.Oborud.DeleteOnSubmit(pac);
            db9.SubmitChanges();
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
