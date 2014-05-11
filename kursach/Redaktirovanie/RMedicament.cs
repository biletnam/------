using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Redaktirovanie
{
    public partial class RMedicament : Form
    {
        public RMedicament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met7 m = new Met7();
                var ec = from n2 in db10.Postavshik
                         where n2.Name == comboBox2.Items[comboBox2.SelectedIndex].ToString()
                         select n2;
                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                m.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), textBox1.Text, Convert.ToInt32(textBox2.Text), temp, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text),textBox7.Text,textBox8.Text);
                m.Poisk_min();
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        int temp = 0;
        string temp2 = "";
        private void button3_Click(object sender, EventArgs e)
        {
            var ec = from n in db.Medicament
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec) { temp = i.IDPost; }
            var ec2 = from n2 in db10.Postavshik
                      where n2.ID == temp
                      select n2;
            foreach (var i in ec2) { temp2 = i.Name; }
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Kol.ToString();
                comboBox2.Text = temp2;
                textBox4.Text = i.Min.ToString();
                textBox5.Text = i.CenazaEd.ToString();
                textBox6.Text = i.Zak.ToString();
                textBox7.Text = i.Ed.ToString();
                textBox8.Text = i.Ed2.ToString();
            }
        }
        DB7 db = new DB7(kursach.Program.Pole.pole);
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        private void RMedicament_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db10.Postavshik
                     select n2;
            foreach (var i in ec)
            {
                comboBox2.Items.Add(i.Name);
            }
            var ec2 = from n2 in db.Medicament
                      select n2;
            foreach (var i in ec2)
            {
                comboBox1.Items.Add(i.ID);
            }
        }

       
    }
}
