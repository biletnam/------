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
                if (m.prov_id(Convert.ToInt32(textBox1.Text)) == true && m.prov_id2(Convert.ToInt32(textBox2.Text)) == true)
                { 
                m.Edit(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                this.Close();
                }
                else { MessageBox.Show("ID не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB11 db = new DB11(kursach.Program.Pole.pole);
            var ec = from n in db.Raspisanie
                     where n.ID == Convert.ToInt32(textBox3.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.IDVrem.ToString();
                textBox2.Text = i.IDVrach.ToString();                
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
    }
}
