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
    public partial class Zakupat : Form
    {
        public Zakupat()
        {
            InitializeComponent();
        }

        private void Zakupat_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            label2.Visible=false;
            textBox1.Visible=false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            label2.Visible=true;
            textBox1.Visible=true;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Met7.Vibor2 = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Met7.kolich = Convert.ToInt32(textBox1.Text);
            Met7.Vibor2 = true;            
            this.Close();
        }
    }
}
