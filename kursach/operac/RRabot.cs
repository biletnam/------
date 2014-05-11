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
    public partial class RRabot : Form
    {
        public RRabot()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB5 db = new DB5(kursach.Program.Pole.pole);
            var ec = from n in db.JurnalRabot
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var t in ec)
            {
                var Zapis = from n2 in db16.Zapis
                            where n2.ID == t.IDZapisi
                            select n2;
                foreach (var i in Zapis)
                {
                    var Pacient = from n2 in db1.Pacient
                                  where n2.ID == i.IDPacienta
                                  select n2;
                    var Uslugi = from n2 in db13.Uslugi
                                 where n2.ID == i.IDUslugi
                                 select n2;
                    var Raspisanie = from n2 in db11.Raspisanie
                                     where n2.ID == i.IDRaspisania
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
                                        comboBox2.Text=i.ID + " Пациент " + j.FIO + " Услуга " + k.Name + " Врач " + g.FIO + " Дата " + i.Data + " " + h.VremN + "-" + h.VremK;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Met5 d = new Met5();
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                var Zapis = from n2 in db16.Zapis
                                where n2.ID==Convert.ToInt32(str[0])
                        select n2;
                foreach (var i in Zapis)
                {
                    var Uslugi = from n2 in db13.Uslugi
                                 where n2.ID == i.IDUslugi
                                 select n2;
                    foreach (var j in Uslugi)
                    {
                        d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), Convert.ToInt32(str[0]), j.Cena, d.RaschetSkidki(i.IDPacienta), j.Cena - ((j.Cena * d.RaschetSkidki(i.IDPacienta)) / 100));
                    }
                }
                    IDRabot = Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    label1.Visible = false;
                    label2.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    button5.Visible = false;
                    button4.Visible = false;
                    button6.Visible = false;
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        public static int IDRabot { get; set; }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
        private void RRabot_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            var JurnalRabot = from n2 in db5.JurnalRabot
                        select n2;
            foreach (var i in JurnalRabot)
            {
                comboBox1.Items.Add(i.ID);
            }
            var Zapis = from n2 in db16.Zapis
                        select n2;
            foreach (var i in Zapis)
            {
                var Pacient = from n2 in db1.Pacient
                              where n2.ID == i.IDPacienta
                              select n2;
                var Uslugi = from n2 in db13.Uslugi
                             where n2.ID == i.IDUslugi
                             select n2;
                var Raspisanie = from n2 in db11.Raspisanie
                                 where n2.ID == i.IDRaspisania
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
                                    comboBox2.Items.Add(i.ID + " Пациент " + j.FIO + " Услуга " + k.Name + " Врач " + g.FIO + " Дата " + i.Data + " " + h.VremN + "-" + h.VremK);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operac.RIOborud f = new operac.RIOborud();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             operac.RIMedic f = new operac.RIMedic();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
