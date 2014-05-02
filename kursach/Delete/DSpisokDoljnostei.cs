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
                m.Delete(Convert.ToInt32(textBox1.Text));
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
    }
}
