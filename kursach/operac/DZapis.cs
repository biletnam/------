using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.operac
{
    public partial class DZapis : Form
    {
        public DZapis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met16 m = new Met16();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                m.Delete(Convert.ToInt32(str[0]));
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
        private void DZapis_Load(object sender, EventArgs e)
        {
            var Zapis = from n2 in db16.Zapis
                      select n2;
            foreach (var i in Zapis)
            {
                var Pacient = from n2 in db1.Pacient
                         where n2.ID==i.IDPacienta
                         select n2;
                var Uslugi = from n2 in db13.Uslugi
                          where n2.ID==i.IDUslugi
                          select n2;
                var Raspisanie= from n2 in db11.Raspisanie
                          where n2.ID==i.IDRaspisania
                          select n2;
                foreach (var j in Pacient)
                {
                    foreach (var k in Uslugi)
                    {
                        foreach (var l in Raspisanie)
                        {
                            var Vrem = from n2 in db15.Vrem
                            where n2.ID == l.IDVrem
                            select n2;
                            var Vrach = from n2 in db14.Vrach
                            where n2.ID == l.IDVrach
                            select n2;
                            foreach (var h in Vrem)
                            {
                                foreach (var g in Vrach)
                                {
                                    comboBox1.Items.Add(i.ID + " Пациент " + j.FIO + " Услуга "+k.Name+" Врач "+g.FIO+" Дата "+i.Data+" "+h.VremN+"-"+h.VremK);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
