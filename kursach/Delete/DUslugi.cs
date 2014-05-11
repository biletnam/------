using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Delete
{
    public partial class DUslugi : Form
    {
        public DUslugi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met13 m = new Met13();
                m.Delete(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                this.Close();
            }
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
        DB13 db13=new DB13(kursach.Program.Pole.pole);
        private void DUslugi_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db13.Uslugi
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.Name);
            }
        }
    }
}
