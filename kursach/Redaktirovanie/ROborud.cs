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
    public partial class ROborud : Form
    {
        public ROborud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met9 d = new Met9();
                var ec = from n2 in db10.Postavshik
                         where n2.Name == comboBox2.Items[comboBox2.SelectedIndex].ToString()
                         select n2;
                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), textBox1.Text, Convert.ToInt32(textBox2.Text), temp,textBox3.Text);
                    this.Close();
               
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        int temp = 0;
        string temp2 = "";
        private void button3_Click_1(object sender, EventArgs e)
        {            
            var ec = from n in db.Oborud
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec)   {   temp = i.IDPostav; }
            var ec2 = from n2 in db10.Postavshik
                     where n2.ID == temp
                     select n2;
            foreach (var i in ec2)   {   temp2 = i.Name; }
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Cena.ToString();
                comboBox2.Text = temp2;
                textBox3.Text = i.Ed;
            }
        }
        DB9 db = new DB9(kursach.Program.Pole.pole);
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        private void ROborud_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db10.Postavshik
                     select n2;
            foreach (var i in ec)
            {
                comboBox2.Items.Add(i.Name);
            }
            var ec2 = from n2 in db.Oborud
                     select n2;
            foreach (var i in ec2)
            {
                comboBox1.Items.Add(i.ID);
            }
        }
    }
}
