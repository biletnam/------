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
    public class JurnalRabot
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int IDZapisi;
        [Column]
        public int IDIspolzuemogo;
        [Column]
        public int IDOborudovan;
        [Column]
        public int Cena;
        [Column]
        public int Skidka;
    }
    public class DB5 : DataContext
    {
        public DB5(string cs) : base(cs) { }
        public System.Data.Linq.Table<JurnalRabot> JurnalRabot
        {
            get { return this.GetTable<JurnalRabot>(); }
        }

    }
    public class Met5
    {
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        public void ADD(int IDZapisi,int IDIspolzuemogo,int IDOborudovan,int Cena,int Skidka)
        {
            JurnalRabot pac = new JurnalRabot();
            pac.IDZapisi = IDZapisi;
            pac.IDIspolzuemogo = IDIspolzuemogo;
            pac.IDOborudovan = IDOborudovan;
            pac.Cena = Cena;
            pac.Skidka = Skidka;
            db5.JurnalRabot.InsertOnSubmit(pac);
            db5.SubmitChanges();
        }
        public void Edit(int ID, int IDZapisi, int IDIspolzuemogo, int IDOborudovan, int Cena, int Skidka)
        {
            JurnalRabot pac = db5.JurnalRabot.Where(c => c.ID == ID).FirstOrDefault();
            pac.IDZapisi = IDZapisi;
            pac.IDIspolzuemogo = IDIspolzuemogo;
            pac.IDOborudovan = IDOborudovan;
            pac.Cena = Cena;
            pac.Skidka = Skidka;
            db5.SubmitChanges();
        }
        public void Delete(int ID)
        {
            JurnalRabot pac = db5.JurnalRabot.Where(c => c.ID == ID).FirstOrDefault();
            db5.JurnalRabot.DeleteOnSubmit(pac);
            db5.SubmitChanges();
        }
    }
}
