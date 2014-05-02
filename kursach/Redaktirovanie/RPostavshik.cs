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
    public partial class RPostavshik : Form
    {
        public RPostavshik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met10 m = new Met10();
                m.Edit(Convert.ToInt32(textBox3.Text), textBox1.Text, textBox2.Text);
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB10 db = new DB10(kursach.Program.Pole.pole);
            var ec = from n in db.Postavshik
                     where n.ID == Convert.ToInt32(textBox3.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Email;
            }
        }
    }
}
