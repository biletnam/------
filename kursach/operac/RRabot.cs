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
    public partial class RRabot : Form
    {
        public RRabot()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB5 db = new DB5(kursach.Program.Pole.pole);
            var ec = from n in db.JurnalRabot
                     where n.ID == Convert.ToInt32(textBox2.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.IDZapisi.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Met5 d = new Met5();
                if (d.prov_id(Convert.ToInt32(textBox1.Text)) == true)
                {
                    d.Edit(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text), 0, 0, 0);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    label1.Visible = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button5.Visible = false;
                    button4.Visible = false;
                    button6.Visible = false;
                }
                else { MessageBox.Show("ID не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void RRabot_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operac.RIOborud f = new operac.RIOborud();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             operac.RIMedic f = new operac.RIMedic();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
