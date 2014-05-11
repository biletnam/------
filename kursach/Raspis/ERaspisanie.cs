using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Raspis
{
    public partial class ERaspisanie : Form
    {
        public ERaspisanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met11 m = new Met11();
                var Vrach = from n2 in db14.Vrach
                            where n2.FIO==comboBox3.Items[comboBox3.SelectedIndex].ToString()
                            select n2;
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                foreach (var i in Vrach)
                {
                    m.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), Convert.ToInt32(str[0]), i.ID);
                }
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB11 db = new DB11(kursach.Program.Pole.pole);
            var Raspisanie = from n in db.Raspisanie
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in Raspisanie)
            {
                var Vrach = from n2 in db14.Vrach
                            where n2.ID==i.IDVrach
                            select n2;
                var Vrem = from n2 in db15.Vrem
                           where n2.ID == i.IDVrem
                           select n2;
                foreach (var j in Vrach)
                {
                    foreach (var k in Vrem)
                    {
                        comboBox2.Text = i.ID + " " + k.Den + " " + k.VremN + "-" + k.VremK;
                    }
                    comboBox3.Text = j.FIO;
                }
            }
        }        
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        private void ERaspisanie_Load(object sender, EventArgs e)
        {
            var Raspisanie = from n2 in db11.Raspisanie
                      select n2;
            foreach (var i in Raspisanie)
            {
                comboBox1.Items.Add(i.ID);
            } 
            var Vrach = from n2 in db14.Vrach
                         select n2;
            foreach (var i in Vrach)
            {
                comboBox3.Items.Add(i.FIO);
            }
            foreach (var i in Raspisanie)
            {
                var Vrem = from n2 in db15.Vrem
                          where n2.ID == i.IDVrem
                          select n2;
                foreach (var j in Vrem)
                {                    
                        comboBox2.Items.Add(i.ID +  " " + j.Den + " " + j.VremN + "-" + j.VremK);                    
                }
            }
        }
    }
}
