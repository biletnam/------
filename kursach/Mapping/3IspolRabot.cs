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
    public class IspolRabot
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDRashodnika;
        [Column]
        public int Kolichestvo;
        [Column]
        public int IDRabot;
    }
    public class DB3 : DataContext
    {
        public DB3(string cs) : base(cs) { }
        public System.Data.Linq.Table<IspolRabot> IspolRabot
        {
            get { return this.GetTable<IspolRabot>(); }
        }

    }
    public class Met3
    {
        DB3 db3 = new DB3(kursach.Program.Pole.pole);
        public void ADD(int IDRashodnika,int Kolichestvo,int IDRabot)
        {
            IspolRabot pac = new IspolRabot();
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.IDRabot = IDRabot;
            db3.IspolRabot.InsertOnSubmit(pac);
            db3.SubmitChanges();
        }
        public void Edit(int ID, int IDRashodnika, int Kolichestvo, int IDRabot)
        {
            IspolRabot pac = db3.IspolRabot.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDRashodnika = IDRashodnika;
            pac.Kolichestvo = Kolichestvo;
            pac.IDRabot = IDRabot;
            db3.SubmitChanges();
        }
        public void Delete(int ID)
        {
            IspolRabot pac = db3.IspolRabot.Where(c => c.ID == ID).FirstOrDefault();
            db3.IspolRabot.DeleteOnSubmit(pac);
            db3.SubmitChanges();
        }
    }
}
