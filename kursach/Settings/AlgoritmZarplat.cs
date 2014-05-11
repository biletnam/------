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
    public partial class AlgoritmZarplat : Form
    {
        public AlgoritmZarplat()
        {
            InitializeComponent();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;            
        }

        private void AlgoritmZarplat_Load(object sender, EventArgs e)
        {
            RabotaSFailami.RabotaSFailami rsf = new RabotaSFailami.RabotaSFailami();
            label1.Text ="Нынешняя оплата труда "+ rsf.outFile(Application.StartupPath.ToString() + "\\FormOplata.txt");
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
             groupBox3.Visible = true;
             groupBox4.Visible = false;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
             groupBox3.Visible = false;
             groupBox4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n="";
            if(radioButton1.Checked==true)
            {
                if(radioButton4.Checked==true)
                {
                    if (radioButton6.Checked == true) { n = "Прямая сдельная оплата труда"; }
                    if (radioButton7.Checked == true) { n = "Сдельно-премиальная оплата труда"; }
                    if (radioButton8.Checked == true) { n = "Сдельно-прогрессивная оплата труда"; }
                    
                }
                if(radioButton5.Checked==true)
                {
                    if (radioButton10.Checked == true) { n = "Простая повременная оплата труда"; }
                    if (radioButton11.Checked == true) { n = "Повременно-премиальная оплата труда"; }
                    if (radioButton12.Checked == true) { n = "Окладная оплата труда"; }
                }
            }            
            try
            {
                Met14 m=new Met14();
                System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.StartupPath.ToString() + "\\FormOplata.txt");
                writer.WriteLine(n);
                writer.Close();
                m.RaschetZarplat();
                this.Close();
            }
            catch { MessageBox.Show("Error"); }

        }
    }
}
