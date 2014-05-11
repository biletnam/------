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
    public class Postavshik
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public string Email;
        [Column]
        public string Adres; 
        [Column]
        public string Telefon;        
    }
    public class DB10 : DataContext
    {
        public DB10(string cs) : base(cs) { }
        public System.Data.Linq.Table<Postavshik> Postavshik
        {
            get { return this.GetTable<Postavshik>(); }
        }

    }
    public class Met10
    {
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        public void ADD(string Name, string Email, string Adres, string Telefon)
        {
            Postavshik pac = new Postavshik();
            pac.Name = Name;
            pac.Email = Email;
            pac.Adres = Adres;
            pac.Telefon = Telefon;
            db10.Postavshik.InsertOnSubmit(pac);
            db10.SubmitChanges();
        }
        public void Edit(int ID, string Name, string Email, string Adres, string Telefon)
        {
            Postavshik pac = db10.Postavshik.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Email = Email;
            pac.Adres = Adres;
            pac.Telefon = Telefon;
            db10.SubmitChanges();
        }
        public void Delete(string Name)
        {
            Postavshik pac = db10.Postavshik.Where(c => c.Name == Name).FirstOrDefault();
            db10.Postavshik.DeleteOnSubmit(pac);
            db10.SubmitChanges();
        }
    }
}
