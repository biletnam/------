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
    public partial class DSpisokDoljnostei : Form
    {
        public DSpisokDoljnostei()
        {
            InitializeComponent();
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
                Met12 m = new Met12();
                m.Delete(comboBox1.Items[comboBox1.SelectedIndex].ToString());
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
        DB12 db12 = new DB12(kursach.Program.Pole.pole);
        private void DSpisokDoljnostei_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db12.SpisokDoljnostei
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.Doljnost);
            }
        }
    }
}
