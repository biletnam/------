using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        private void Form3_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db1.Pacient
                     select n2;
            foreach (var i in ec)
            {
                comboBox3.Items.Add(i.ID);
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
            var ec = from n in db1.Pacient
                     where n.ID == Convert.ToInt32(comboBox3.Items[comboBox3.SelectedIndex])
                     select n;
            foreach(var i in ec)
            {
                    textBox1.Text = i.FIO;
                    textBox2.Text = i.Polis;
                    comboBox1.Text = i.Pol;
                    comboBox2.Text = i.Status;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            try
            {
            Met1 m = new Met1();
            m.Edit(Convert.ToInt32(comboBox3.Items[comboBox3.SelectedIndex]), textBox1.Text, textBox2.Text, comboBox1.Items[comboBox1.SelectedIndex].ToString(), comboBox2.Items[comboBox2.SelectedIndex].ToString());
            this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
    }
}
