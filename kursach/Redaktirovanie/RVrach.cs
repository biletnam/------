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
    public partial class RVrach : Form
    {
        public RVrach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met14 m = new Met14();
                var ec = from n in db12.SpisokDoljnostei
                         where n.Doljnost == comboBox2.Items[comboBox2.SelectedIndex].ToString()
                         select n;

                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                m.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), textBox2.Text, temp, m.RaschetZarplat2(temp, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox4.Text)), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        int temp=0;
        string temp2 = "";
        private void button3_Click(object sender, EventArgs e)
        {
            var ec = from n in db14.Vrach
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            
            foreach (var i in ec)
            {
                temp=i.IDSpiskaDolj;
            }
           var ec2 = from n in db12.SpisokDoljnostei
                     where n.ID == temp
                     select n;
            foreach (var i in ec2)
            {
                temp2=i.Doljnost;
            }
            foreach (var i in ec)
            {
                textBox2.Text = i.FIO;
                comboBox2.Text = temp2; 
                textBox6.Text=i.VR.ToString();
                textBox4.Text=i.Norma.ToString(); 
                textBox5.Text=i.Premia.ToString(); 
            }
        }
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB12 db12 = new DB12(kursach.Program.Pole.pole);
        private void RVrach_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db14.Vrach
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.ID);
            }
            var ec2 = from n2 in db12.SpisokDoljnostei
                     select n2;
            foreach (var i in ec2)
            {
                comboBox2.Items.Add(i.Doljnost);
            }
        }
    }
}
