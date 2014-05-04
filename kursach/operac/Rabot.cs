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
    public partial class Rabot : Form
    {
        public Rabot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operac.IOborud f = new operac.IOborud();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             operac.IMedic f = new operac.IMedic();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Met5 d = new Met5();
                if (d.prov_id(Convert.ToInt32(textBox1.Text)) == true)
                {
                    d.ADD(Convert.ToInt32(textBox1.Text), 0, 0, 0);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    label1.Visible = false;
                    textBox1.Visible = false;
                    button5.Visible = false;
                    button4.Visible = false;
                }
                else { MessageBox.Show("ID не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void Rabot_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
    }
}
