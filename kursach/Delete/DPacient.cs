using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        private void Form4_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db1.Pacient
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.FIO);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met1 m = new Met1();
                m.Delete(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }

       
    }
}
