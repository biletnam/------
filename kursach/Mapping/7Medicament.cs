using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Windows.Forms;
using EmailOtpravka;
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
        [Column]
        public string Ed;
        [Column]
        public string Ed2;
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
        Mapping.DB17 db17=new Mapping.DB17(kursach.Program.Pole.pole);
        public void ADD(string Name, int Kol, int IDPost, int Min, int CenazaEd, int Zak,string Ed,string Ed2)
        {
            Medicament pac = new Medicament();
            pac.Name = Name;
            pac.Kol =Kol  ;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            pac.Ed = Ed;
            pac.Ed2 = Ed2;
            db7.Medicament.InsertOnSubmit(pac);
            db7.SubmitChanges();
        }
        public void Edit(int ID, string Name, int Kol, int IDPost, int Min, int CenazaEd, int Zak, string Ed, string Ed2)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Kol = Kol;
            pac.IDPost = IDPost;
            pac.Min = Min;
            pac.CenazaEd = CenazaEd;
            pac.Zak = Zak;
            pac.Ed = Ed;
            pac.Ed2 = Ed2;
            db7.SubmitChanges();
        }
        public void Delete(string Name)
        {
            Medicament pac = db7.Medicament.Where(c => c.Name == Name).FirstOrDefault();
            db7.Medicament.DeleteOnSubmit(pac);
            db7.SubmitChanges();
        }        
        public void Poisk_min()
        {
            EmailOtpravka.Email e = new EmailOtpravka.Email();
            int med = 0;
            Met6 m = new Met6();
            var medic = from slovo in db7.Medicament
                        select slovo;
            
            var nastr = from slovo in db8.Nastroiki
                        where slovo.ID==1
                        select slovo;
            string temp="", temp2 = "";
            foreach (var j in nastr) { temp = j.login; temp2 = j.pass; }
            foreach (var j in medic)
            {
                var post = from nom in db10.Postavshik
                           where nom.ID==j.IDPost
                       select nom;
                if (j.Min >= j.Kol)
                {
                    VoprosOtpravka vo = new VoprosOtpravka(j.Name);
                    vo.ShowDialog();
                    if (Vibor == true)
                    {
                        if (Vibor2 == true) { med = kolich; } if (Vibor2 == false) { med = j.Zak; }
                        foreach (var k in post)
                        {
                                var Firma = from slovo in db17.Firma
                                            where slovo.ID == 1
                                            select slovo;
                                foreach (var f in Firma)
                                {
                                    e.otpravka(k.Email, j.Name, med, temp, temp2, f.Name);
                                    m.ADD(j.IDPost, j.ID, med, DateTime.Today.ToString());
                                }
                                
                           
                        } 
                    }
                }
            }
        }
        public void Spisania(int Kol,int ID)
        {
            Medicament pac = db7.Medicament.Where(c => c.ID == ID).FirstOrDefault();
            pac.Kol = pac.Kol - Kol;
            db7.SubmitChanges();
        }
        public static bool Vibor
        {
            get; set;
        } 
        public static bool Vibor2
        {
            get; set;
        }
        public static int kolich
        {
            get; set;
        }
    }
}
