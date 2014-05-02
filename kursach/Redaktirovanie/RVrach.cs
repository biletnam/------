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
                m.Edit(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), m.RaschetZarplat(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text)), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
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

        private void button3_Click(object sender, EventArgs e)
        {
            DB14 db = new DB14(kursach.Program.Pole.pole);
            var ec = from n in db.Vrach
                     where n.ID == Convert.ToInt32(textBox1.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox2.Text = i.FIO;
                textBox3.Text = i.IDSpiskaDolj.ToString(); 
                textBox6.Text=i.VR.ToString();
                textBox4.Text=i.Norma.ToString(); 
                textBox5.Text=i.Premia.ToString(); 
            }
        }
    }
}
