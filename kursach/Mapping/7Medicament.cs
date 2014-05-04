using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Windows.Forms;

namespace kursach
{
    [Table]
    public class Medicament
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public int Kol;
        [Column]
        public int IDPost;
        [Column]
        public int Min;
        [Column]
        public int CenazaEd;
        [Column]
        public int Zak;
    }
    public class DB7 : DataContext
    {
        public DB7(string cs) : base(cs) { }
        public System.Data.Linq.Table<Medicament> Medicament
        {
            get { return this.GetTable<Medicament>(); }
        }

    }
    public class Met7
    {
        DB7 db7 = new DB7(kursach.Program.Pole.pole);
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
DB8 db8 = new DB8(kursach.Program.Pole.pole);
        public void ADD(string Name, int Kol, int IDPost, int Min, int CenazaEd, int Zak)
        {
            Medicament pac = new Medicament();
            pac.Name = Name;
            pac.Kol =Kol  ;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            db7.Medicament.InsertOnSubmit(pac);
            db7.SubmitChanges();
        }
        public void Edit(int ID,string Name,int Kol,int IDPost,int Min,int CenazaEd,int Zak)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Kol = Kol;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            db7.SubmitChanges();
        }
        public void Delete(int ID)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            db7.Medicament.DeleteOnSubmit(pac);
            db7.SubmitChanges();
        }
        public bool prov_id(int id)
        {
            bool pro = false;
            var ec = from n in db10.Postavshik
                     select n;
            foreach (var i in ec)
            {
                if (id == i.ID)
                {
                    pro = true;
                }
            }
            return pro;
        }
        public void Poisk_min()
        {
            OtpravkaEmail email = new OtpravkaEmail();
            Met6 m = new Met6();
            var medic = from slovo in db7.Medicament
                        select slovo;
            var post = from nom in db10.Postavshik
                       select nom;
            var nastr = from slovo in db8.Nastroiki
                        where slovo.ID==1
                        select slovo;
            string temp="", temp2 = "";
            foreach (var j in nastr) { temp = j.login; temp2 = j.pass; }
            foreach (var j in medic)
            {
                if (j.Min >= j.Kol)
                {
                    foreach (var k in post)
                    {
                        if (j.IDPost == k.ID)
                        {
                            email.otpravka(k.Email, j.Name, j.Zak, temp,temp2);
                            m.ADD(j.IDPost, j.ID,j.Kol, DateTime.Today.ToString());
                            
                        }
                    }MessageBox.Show("Заказ на " + j.Name + " отправлен");
                }
            }
        }

    }
}
