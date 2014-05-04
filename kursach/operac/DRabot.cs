using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.operac
{
    public partial class DRabot : Form
    {
        public DRabot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met5 m = new Met5();
                m.Delete(Convert.ToInt32(textBox1.Text));
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
    }
}
