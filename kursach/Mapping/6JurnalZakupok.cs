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
    public class JurnalZakupok
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDPostovshika;
        [Column]
        public int IDRashodnika;
        [Column]
        public int Kolichestvo;
        [Column]
        public string Data;
    }
    public class DB6 : DataContext
    {
        public DB6(string cs) : base(cs) { }
        public System.Data.Linq.Table<JurnalZakupok> JurnalZakupok
        {
            get { return this.GetTable<JurnalZakupok>(); }
        }

    }
    public class Met6
    {
        DB6 db6 = new DB6(kursach.Program.Pole.pole);
        public void ADD(int IDPostovshika, int IDRashodnika, int Kolichestvo, string Data)
        {
            JurnalZakupok pac = new JurnalZakupok();
            pac.IDPostovshika = IDPostovshika;
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.Data = Data;
            db6.JurnalZakupok.InsertOnSubmit(pac);
            db6.SubmitChanges();
        }
        public void Edit(int ID, int IDPostovshika, int IDRashodnika, int Kolichestvo, string Data)
        {
            JurnalZakupok pac = db6.JurnalZakupok.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDPostovshika = IDPostovshika;
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.Data = Data;
            db6.SubmitChanges();
        }
        public void Delete(int ID)
        {
            JurnalZakupok pac = db6.JurnalZakupok.Where(c => c.ID == ID).FirstOrDefault();
            db6.JurnalZakupok.DeleteOnSubmit(pac);
            db6.SubmitChanges();
        }
    }
}
