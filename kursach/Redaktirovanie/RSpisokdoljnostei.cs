using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Redaktirovanie
{
    public partial class RSpisokdoljnostei : Form
    {
        public RSpisokdoljnostei()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met12 d = new Met12();
                d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), textBox2.Text, Convert.ToInt32(textBox3.Text),textBox4.Text);
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
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
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var ec = from n in db.SpisokDoljnostei
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec)
            {
                textBox2.Text = i.Doljnost;
                textBox3.Text = i.Oklad.ToString();
                textBox4.Text = i.Ed;
            }
        }
         DB12 db = new DB12(kursach.Program.Pole.pole);
        private void RSpisokdoljnostei_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db.SpisokDoljnostei
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.ID);
            }
        }
    }
}
