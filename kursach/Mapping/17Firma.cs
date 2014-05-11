using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace kursach.Mapping
{
    [Table]
    public class Firma
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public string Adres;
        [Column]
        public string Buh;
        [Column]
        public string INN;
        [Column]
        public string KPP;
        [Column]
        public string Schet;
        [Column]
        public string SchetBank;
        [Column]
        public string Bank;
        }
    public class DB17 : DataContext
    {
        public DB17(string cs) : base(cs) { }
        public System.Data.Linq.Table<Firma> Firma 
        {
            get { return this.GetTable<Firma>(); }
        }

    }
    public class Met17
    {
        DB17 db17 = new DB17(kursach.Program.Pole.pole);
        public void ADD(string Name, string Adres, string Buh, string INN,string KPP, string Schet,string SchetBank,string Bank)
        {
            Firma pac = new Firma();
            pac.Name = Name;
            pac.Adres = Adres;
            pac.Buh = Buh;
            pac.INN = INN;
            pac.KPP = KPP;
            pac.Schet = Schet;
            pac.SchetBank = SchetBank;
            pac.Bank = Bank;
            db17.Firma.InsertOnSubmit(pac);
            db17.SubmitChanges();
        }
        public void Edit(int ID, string Name, string Adres, string Buh, string INN, string KPP, string Schet, string SchetBank, string Bank)
        {
            try
            {
                Firma pac = db17.Firma.Where(c => c.ID == ID).FirstOrDefault();
                pac.Name = Name;
                pac.Adres = Adres;
                pac.Buh = Buh;
                pac.INN = INN;
                pac.KPP = KPP;
                pac.Schet = Schet;
                pac.SchetBank = SchetBank;
                pac.Bank = Bank;
                db17.SubmitChanges();
            }
            catch (NullReferenceException)
            {
                ADD(Name, Adres, Buh, INN, KPP, Schet, SchetBank, Bank);
            }
        }
    }
}
