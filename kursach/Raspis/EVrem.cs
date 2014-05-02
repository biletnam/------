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
    public partial class EVrem : Form
    {
        public EVrem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met15 m = new Met15();
                m.Edit(Convert.ToInt32(textBox3.Text), comboBox1.Items[comboBox1.SelectedIndex].ToString(), textBox1.Text, textBox2.Text);
                this.Close();                
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB15 db = new DB15(kursach.Program.Pole.pole);
            var ec = from n in db.Vrem
                     where n.ID == Convert.ToInt32(textBox3.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.VremN.ToString();
                textBox2.Text = i.VremK.ToString();
                comboBox1.Text = i.Den;
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
    }
}
