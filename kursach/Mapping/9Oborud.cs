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
        [Column]
        public string Ed;       
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
        public void ADD(string Name, int Cena, int IDPostav,string Ed)
        {
            Oborud pac = new Oborud();
            pac.Name = Name;
            pac.Cena = Cena;
            pac.Ed = Ed;
            pac.IDPostav = IDPostav;   
            db9.Oborud.InsertOnSubmit(pac);
            db9.SubmitChanges();
        }
        public void Edit(int ID, string Name, int Cena, int IDPostav, string Ed)
        {
            Oborud pac = db9.Oborud.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Cena = Cena ;
            pac.Ed = Ed;
            pac.IDPostav = IDPostav;            
            db9.SubmitChanges();
        }
        public void Delete(string Name)
        {
            Oborud pac = db9.Oborud.Where(c => c.Name == Name).FirstOrDefault();
            db9.Oborud.DeleteOnSubmit(pac);
            db9.SubmitChanges();
        }
    }
}
