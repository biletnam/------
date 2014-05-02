using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Settings
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Met8 m = new Met8();
            m.Edit(1,textBox1.Text,textBox2.Text);
            this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB8 db = new DB8(kursach.Program.Pole.pole);
            var ec = from n in db.Nastroiki
                     where n.ID == 1
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.login;
                textBox2.Text = i.pass;
            }
        }
    }
}
