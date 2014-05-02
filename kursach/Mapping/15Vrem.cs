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
    public class Vrem
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Den;
        [Column]
        public string VremN;
        [Column]
        public string VremK;        
    }
    public class DB15 : DataContext
    {
        public DB15(string cs) : base(cs) { }
        public System.Data.Linq.Table<Vrem> Vrem
        {
            get { return this.GetTable<Vrem>(); }
        }

    }
    public class Met15
    {
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        public void ADD(string Den,string VremN,string VremK)
        {
            Vrem pac = new Vrem();
            pac.Den = Den;
            pac.VremN = VremN;
            pac.VremK = VremK;
            db15.Vrem.InsertOnSubmit(pac);
            db15.SubmitChanges();
        }
        public void Edit(int ID, string Den, string VremN, string VremK)
        {
            Vrem pac = db15.Vrem.Where(c => c.ID == ID).FirstOrDefault();
            pac.Den = Den;
            pac.VremN = VremN;
            pac.VremK = VremK;
            db15.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Vrem pac = db15.Vrem.Where(c => c.ID == ID).FirstOrDefault();
            db15.Vrem.DeleteOnSubmit(pac);
            db15.SubmitChanges();
        }       
    }
}
