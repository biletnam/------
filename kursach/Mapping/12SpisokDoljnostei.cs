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
    public class SpisokDoljnostei
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Doljnost;
        [Column]
        public int Oklad;        
    }
    public class DB12 : DataContext
    {
        public DB12(string cs) : base(cs) { }
        public System.Data.Linq.Table<SpisokDoljnostei> SpisokDoljnostei
        {
            get { return this.GetTable<SpisokDoljnostei>(); }
        }

    }
    public class Met12
    {
        DB12 db12 = new DB12(kursach.Program.Pole.pole);
        public void ADD(string Doljnost, int Oklad)
        {
            SpisokDoljnostei pac = new SpisokDoljnostei();
            pac.Doljnost = Doljnost;
            pac.Oklad = Oklad ;            
            db12.SpisokDoljnostei.InsertOnSubmit(pac);
            db12.SubmitChanges();
        }
        public void Edit(int ID, string Doljnost, int Oklad)
        {
            SpisokDoljnostei pac = db12.SpisokDoljnostei.Where(c => c.ID == ID).FirstOrDefault();
            pac.Doljnost = Doljnost;
            pac.Oklad = Oklad;             
            db12.SubmitChanges();
        }
        public void Delete(int ID)
        {
            SpisokDoljnostei pac = db12.SpisokDoljnostei.Where(c => c.ID == ID).FirstOrDefault();
            db12.SpisokDoljnostei.DeleteOnSubmit(pac);
            db12.SubmitChanges();
        }
    }
}
