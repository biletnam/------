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
    public partial class Skidka : Form
    {
        public Skidka()
        {
            InitializeComponent();
        }

        private void Skidka_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            maskedTextBox1.Text="000000000000";
            maskedTextBox2.Text="000000000000";
            maskedTextBox3.Text="0";
            maskedTextBox5.Text="0";
            maskedTextBox6.Text="0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = true;
groupBox2.Visible = false;groupBox4.Visible = false;groupBox6.Visible = false;groupBox7.Visible = false;
            if (checkBox1.Checked == true) {groupBox2.Visible = true; }
            if (checkBox2.Checked == true) {groupBox4.Visible = true; }
            if (checkBox3.Checked == true) {groupBox6.Visible = true; }
            if (checkBox4.Checked == true) {groupBox7.Visible = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string stroka = "";
            if (checkBox1.Checked == true) { stroka += "1 " + maskedTextBox1.Text+" | " + maskedTextBox2.Text + Environment.NewLine; }
            if (checkBox1.Checked == false) { stroka += "0 " + Environment.NewLine; }
            if (checkBox2.Checked == true) { stroka += "1 " + maskedTextBox3.Text + Environment.NewLine; }
            if (checkBox2.Checked == false) { stroka += "0 " + Environment.NewLine; }
            if (checkBox3.Checked == true) { stroka += "1 " + maskedTextBox5.Text + Environment.NewLine; }
            if (checkBox3.Checked == false) { stroka += "0 " + Environment.NewLine; }
            if (checkBox4.Checked == true) { stroka += "1 "+maskedTextBox6.Text ; } 
            if (checkBox4.Checked == false) { stroka += "0 " ; }
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.StartupPath.ToString() + "\\Skidka.txt");
                writer.WriteLine(stroka);
                writer.Close();
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }
    }
}
