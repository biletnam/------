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
    public partial class DelRaspisanie : Form
    {
        public DelRaspisanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met11 m = new Met11();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                m.Delete(Convert.ToInt32(str[0]));
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
        private void DelRaspisanie_Load(object sender, EventArgs e)
        {       
            var ec2 = from n2 in db11.Raspisanie
                     select n2;   
            foreach (var i in ec2)
            {
                var ec = from n2 in db14.Vrach
                     where n2.ID==i.IDVrach
                     select n2;
                var ec3 = from n2 in db15.Vrem
                     where n2.ID==i.IDVrem
                     select n2;
                foreach (var j in ec)
                {
                    foreach (var k in ec3)
                    {
                        comboBox1.Items.Add(i.ID + " " + j.FIO +" " +k.Den+ " " + k.VremN + "-" + k.VremK);
                    }
                }
            }
        }
    }
}
