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
    public class IspolOborud
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;        
        [Column]
        public int IDRabot;
        [Column]
        public int IDMedicamenta;
    }
    public class DB2 : DataContext
    {
        public DB2(string cs) : base(cs) { }
        public System.Data.Linq.Table<IspolOborud> IspolOborud
        {
            get { return this.GetTable<IspolOborud>(); }
        }

    }
    public class Met2
    {
        DB2 db2 = new DB2(kursach.Program.Pole.pole);
        public void ADD(int IDRabot,int IDMedicamenta)
        {
            IspolOborud pac = new IspolOborud();
            pac.IDMedicamenta = IDMedicamenta;
            pac.IDRabot = IDRabot;
            db2.IspolOborud.InsertOnSubmit(pac);
            db2.SubmitChanges();
        }
        public void Edit(int ID, int IDRabot, int IDMedicamenta)
        {
            IspolOborud pac = db2.IspolOborud.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDMedicamenta = IDMedicamenta;
            pac.IDRabot = IDRabot;            
            db2.SubmitChanges();
        }
        public void Delete(int ID)
        {
            IspolOborud pac = db2.IspolOborud.Where(c => c.ID == ID).FirstOrDefault();
            db2.IspolOborud.DeleteOnSubmit(pac);
            db2.SubmitChanges();
        }
    }
}
