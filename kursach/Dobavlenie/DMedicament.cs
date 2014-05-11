using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Dobavlenie
{
    public partial class DMedicament : Form
    {
        public DMedicament()
        {
            InitializeComponent();
        }
        int temp = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met7 d = new Met7();
                var ec = from n2 in db10.Postavshik
                         where n2.Name == comboBox1.Items[comboBox1.SelectedIndex].ToString()
                         select n2;
                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                d.ADD(textBox1.Text, Convert.ToInt32(textBox2.Text), temp, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text),textBox7.Text,textBox8.Text);
                    d.Poisk_min();
                    this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        DB7 db = new DB7(kursach.Program.Pole.pole);
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        private void DMedicament_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db10.Postavshik
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.Name);
            }
        }
    }
}
