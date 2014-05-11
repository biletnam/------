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
    public partial class DRabot : Form
    {
        public DRabot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met5 m = new Met5();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                m.Delete(Convert.ToInt32(str[0]));
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
        private void DRabot_Load(object sender, EventArgs e)
        {
            var JurnalRabot = from n2 in db5.JurnalRabot
                        select n2;
            foreach (var i in JurnalRabot)
            {
                var Zapis = from n2 in db16.Zapis
                            where n2.ID==i.IDZapisi
                            select n2;
                foreach (var r in Zapis)
                {
                    var Pacient = from n2 in db1.Pacient
                                  where n2.ID == r.IDPacienta
                                  select n2;
                    var Uslugi = from n2 in db13.Uslugi
                                 where n2.ID == r.IDUslugi
                                 select n2;
                    var Raspisanie = from n2 in db11.Raspisanie
                                     where n2.ID == r.IDRaspisania
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
                                        comboBox1.Items.Add(i.ID+" "+" Цена "+i.Cena+" Итог "+i.Itog+ " Пациент " + j.FIO + " Услуга " + k.Name + " Врач " + g.FIO + " Дата " + r.Data + " " + h.VremN + "-" + h.VremK);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
