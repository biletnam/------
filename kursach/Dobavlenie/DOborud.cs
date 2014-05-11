using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Dobavlenie
{
    public partial class DOborud : Form
    {
        public DOborud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met9 d = new Met9();
                var ec = from n2 in db10.Postavshik
                         where n2.Name == comboBox1.Items[comboBox1.SelectedIndex].ToString()
                         select n2;
                int temp = 0;
                foreach (var i in ec)
                {
                    temp = i.ID;
                }
                    d.ADD(textBox1.Text, Convert.ToInt32(textBox2.Text),temp,textBox3.Text);
                    this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
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
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        private void DOborud_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db10.Postavshik
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.Name);
            }
        }
    }
}
