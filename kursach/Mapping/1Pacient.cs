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
    public class Pacient
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string FIO;
        [Column]
        public string Polis;
        [Column]
        public int Posesh;
        [Column]
        public string Data;
        [Column]
        public string Pol;
        [Column]
        public string Status;
    }
    public class DB1 : DataContext
    {
        public DB1(string cs) : base(cs) { }
        public System.Data.Linq.Table<Pacient> Pacient
        {
            get { return this.GetTable<Pacient>(); }
        }

    }
    public class Met1
    {
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        public void ADD(string FIO,string Polis,int Posesh,string Data,string Pol,string Status)
        {
            Pacient pac = new Pacient();
            pac.FIO = FIO;
            pac.Polis = Polis;
            pac.Posesh = Posesh;
            pac.Data = Data;
            pac.Pol = Pol;
            pac.Status = Status;
            db1.Pacient.InsertOnSubmit(pac);
            db1.SubmitChanges();
        }
        public void Edit(int ID, string FIO,string Polis,string Pol,string Status)
        {
            Pacient pac = db1.Pacient.Where(c => c.ID == ID).FirstOrDefault();
            pac.FIO = FIO;
            pac.Polis = Polis;
            pac.Pol = Pol;
            pac.Status = Status;
            db1.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Pacient pac = db1.Pacient.Where(c => c.ID == ID).FirstOrDefault();
            db1.Pacient.DeleteOnSubmit(pac);
            db1.SubmitChanges();
        }
    }
}
