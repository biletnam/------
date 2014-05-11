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
    public partial class RZapis : Form
    {
        public RZapis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met16 d = new Met16();
                var Pacient = from n in db1.Pacient
                     where n.FIO == comboBox2.Items[comboBox2.SelectedIndex].ToString()
                     select n;
                var Uslugi = from n in db13.Uslugi
                          where n.Name == comboBox4.Items[comboBox4.SelectedIndex].ToString()
                          select n;
                
                string[] str = comboBox3.Items[comboBox3.SelectedIndex].ToString().Split(new char[] { ' ' });
                string[] str2 = dateTimePicker1.Value.ToString().Split(new char[] { ' ' });
                var Raspisanie = from n in db11.Raspisanie
                          where n.ID == Convert.ToInt32(str[0])
                          select n;
                string temp="";
                foreach (var i in Raspisanie)
                {
                          var Vrem = from n in db15.Vrem
                          where n.ID == i.IDVrem
                          select n;
                          foreach (var j in Vrem)
                          {
                              temp = j.Den;
                          }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == d.Dni(temp))
                {
                foreach (var i in Pacient)
                {
                    foreach (var j in Uslugi)
                    {
                        d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), i.ID, Convert.ToInt32(str[0]), j.ID, str2[0]);                    
                    }
                }
                    this.Close();
                }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Zapis = from n in db16.Zapis
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in Zapis)
            {
                var Pacient = from n in db1.Pacient
                     where n.ID == i.IDPacienta
                     select n;
                var Raspisanie = from n in db11.Raspisanie
                          where n.ID == i.IDRaspisania
                          select n;
                var Uslugi = from n in db13.Uslugi
                          where n.ID == i.IDUslugi
                          select n;
                foreach (var j in Pacient)
                {
                    comboBox2.Text = j.FIO;
                }
                foreach (var j in Raspisanie)
                {
                    var Vrem = from n in db15.Vrem
                          where n.ID == j.IDVrem
                          select n;
                    var Vrach = from n in db14.Vrach
                          where n.ID == j.IDVrach
                          select n;
                    foreach (var k in Vrem)
                    {
                        foreach (var h in Vrach)
                        {
                            comboBox3.Text=i.ID + " " + h.FIO + " " + k.Den + " " + k.VremN + "-" + k.VremK; ;
                        }
                    }
                }
                foreach (var j in Uslugi)
                {
                    comboBox4.Text = j.Name;
                }
                dateTimePicker1.Text = i.Data;
            }
        }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
        private void RZapis_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            var ec = from n2 in db1.Pacient
                     select n2;
            var ec2 = from n2 in db11.Raspisanie
                      select n2;
            var ec3 = from n2 in db13.Uslugi
                      select n2;
            var ec6 = from n2 in db16.Zapis
                      select n2;
            foreach (var i in ec6)
            {
                comboBox1.Items.Add(i.ID);
            }
            foreach (var i in ec)
            {
                comboBox2.Items.Add(i.FIO);
            }
            foreach (var i in ec2)
            {
                var ec4 = from n2 in db14.Vrach
                          where n2.ID == i.IDVrach
                          select n2;
                var ec5 = from n2 in db15.Vrem
                          where n2.ID == i.IDVrem
                          select n2;
                foreach (var j in ec4)
                {
                    foreach (var k in ec5)
                    {
                        comboBox3.Items.Add(i.ID + " " + j.FIO + " " + k.Den + " " + k.VremN + "-" + k.VremK);
                    }
                }
            }
            foreach (var i in ec3)
            {
                comboBox4.Items.Add(i.Name);
            }
        }
    }
}
