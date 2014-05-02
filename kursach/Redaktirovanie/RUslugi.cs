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
    public partial class RUslugi : Form
    {
        public RUslugi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met13 m = new Met13();
                m.Edit(Convert.ToInt32(textBox3.Text), textBox1.Text, Convert.ToInt32(textBox2.Text));
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB13 db = new DB13(kursach.Program.Pole.pole);
            var ec = from n in db.Uslugi
                     where n.ID == Convert.ToInt32(textBox3.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Cena.ToString();
            }
        }
    }
}
