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
    public class JurnalPriema
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDPostavshika;
        [Column]
        public int IDRashodnika;
        [Column]
        public int Kolichestvo;
        [Column]
        public int Cena;
        [Column]
        public string Data;
    }
    public class DB4 : DataContext
    {
        public DB4(string cs) : base(cs) { }
        public System.Data.Linq.Table<JurnalPriema> JurnalPriema
        {
            get { return this.GetTable<JurnalPriema>(); }
        }

    }
    public class Met4
    {
        DB4 db4 = new DB4(kursach.Program.Pole.pole);
        public void ADD(int IDPostavshika,int IDRashodnika,int Kolichestvo,int Cena,string Data)
        {
            JurnalPriema pac = new JurnalPriema();
            pac.IDPostavshika = IDPostavshika;
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.Cena = Cena;
            pac.Data = Data;
            db4.JurnalPriema.InsertOnSubmit(pac);
            db4.SubmitChanges();
        }
        public void Edit(int ID, int IDPostavshika, int IDRashodnika, int Kolichestvo, int Cena, string Data)
        {
            JurnalPriema pac = db4.JurnalPriema.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDPostavshika = IDPostavshika;
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.Cena = Cena;
            pac.Data = Data;
            db4.SubmitChanges();
        }
        public void Delete(int ID)
        {
            JurnalPriema pac = db4.JurnalPriema.Where(c => c.ID == ID).FirstOrDefault();
            db4.JurnalPriema.DeleteOnSubmit(pac);
            db4.SubmitChanges();
        }
    }
}
