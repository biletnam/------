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
    public partial class DRaspisanie : Form
    {
        public DRaspisanie()
        {
            InitializeComponent();
        }
        int temp = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met11 d = new Met11();
                var ec = from n2 in db14.Vrach
                         where n2.FIO == comboBox1.Items[comboBox1.SelectedIndex].ToString()
                         select n2;
                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                string[] str =comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });

                d.ADD(Convert.ToInt32(str[0]), temp);
                    this.Close();               
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            //catch { MessageBox.Show("Error"); }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DRaspisanie_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db14.Vrach
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.FIO);
            }
            var ec2 = from n2 in db15.Vrem
                     select n2;
            foreach (var i in ec2)
            {
                comboBox2.Items.Add(i.ID+" "+i.Den+" "+i.VremN+"-"+i.VremK);
            }
        }
    }
}
