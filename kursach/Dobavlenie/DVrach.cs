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
    public partial class DVrach : Form
    {
        public DVrach()
        {
            InitializeComponent();
        }
DB12 db12 = new DB12(kursach.Program.Pole.pole);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met14 d = new Met14();
                var ec = from n2 in db12.SpisokDoljnostei
                         where n2.Doljnost==comboBox1.Items[comboBox1.SelectedIndex].ToString()
                         select n2;
                int temp = 0;
                foreach (var i in ec)
                {
                    temp = i.ID;  
                }       
                    d.ADD(textBox1.Text, temp, d.RaschetZarplat2(temp, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text),Convert.ToInt32(textBox4.Text) ), DateTime.Today.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void DVrach_Load(object sender, EventArgs e)
        {
            
            var ec = from n2 in db12.SpisokDoljnostei
                      select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.Doljnost);
            }
        }

   
    }
}
