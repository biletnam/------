using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Raspis
{
    public partial class DelVrem : Form
    {
        public DelVrem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met15 m = new Met15();
                Met11 m2 = new Met11();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                m.Delete(Convert.ToInt32(str[0]));
                var ec2 = from n2 in db11.Raspisanie
                          where n2.IDVrem==Convert.ToInt32(str[0])
                          select n2;
                foreach (var i in ec2)
                {
                    m2.Delete(i.ID);
                }
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
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        private void DelVrem_Load(object sender, EventArgs e)
        {
            var ec2 = from n2 in db15.Vrem
                     select n2;
            foreach (var i in ec2)
            {
                comboBox1.Items.Add(i.ID + " " + i.Den + " " + i.VremN + "-" + i.VremK);
            }    
               
        }
    }
}
