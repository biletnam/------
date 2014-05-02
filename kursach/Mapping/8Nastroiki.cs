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
    public class Nastroiki
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;        
        [Column]
        public string login;
        [Column]
        public string pass;
    }
    public class DB8 : DataContext
    {
        public DB8(string cs) : base(cs) { }
        public System.Data.Linq.Table<Nastroiki> Nastroiki
        {
            get { return this.GetTable<Nastroiki>(); }
        }

    }
    public class Met8
    {
        DB8 db8 = new DB8(kursach.Program.Pole.pole);
        public void ADD(string login, string pass)
        {
            Nastroiki pac = new Nastroiki();
            pac.login = login;
            pac.pass = pass;
            db8.Nastroiki.InsertOnSubmit(pac);
            db8.SubmitChanges();
        }
        public void Edit(int ID,string login,string pass)
        {
            try
            {
                Nastroiki pac = db8.Nastroiki.Where(c => c.ID == ID).FirstOrDefault();
                pac.login = login;
                pac.pass = pass;
                db8.SubmitChanges();
            }
            catch (NullReferenceException)
            {
                Nastroiki pac = new Nastroiki();
                pac.ID = ID;
                pac.login = login;
                pac.pass = pass;
                db8.Nastroiki.InsertOnSubmit(pac);
                db8.SubmitChanges();
            }
        }
        public void Delete(int ID)
        {
            Nastroiki pac = db8.Nastroiki.Where(c => c.ID == ID).FirstOrDefault();
            db8.Nastroiki.DeleteOnSubmit(pac);
            db8.SubmitChanges();
        }
    }
}
