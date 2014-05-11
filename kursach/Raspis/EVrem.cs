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
    public partial class EVrem : Form
    {
        public EVrem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] str2 = dateTimePicker2.Value.ToString().Split(new char[] { ' ' });
                string[] str = dateTimePicker1.Value.ToString().Split(new char[] { ' ' });
                Met15 m = new Met15();
                m.Edit(Convert.ToInt32(comboBox2.Items[comboBox2.SelectedIndex]), comboBox1.Items[comboBox1.SelectedIndex].ToString(), str[1], str2[1]);
                this.Close();                
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB15 db = new DB15(kursach.Program.Pole.pole);
            var ec = from n in db.Vrem
                     where n.ID == Convert.ToInt32(comboBox2.Items[comboBox2.SelectedIndex])
                     select n;
            foreach (var i in ec)
            {
                dateTimePicker1.Text = i.VremN.ToString();
                dateTimePicker2.Text = i.VremK.ToString();
                comboBox1.Text = i.Den;
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
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        private void EVrem_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            var Vrem = from n2 in db15.Vrem
                      select n2;
            foreach (var i in Vrem)
            {
                comboBox2.Items.Add(i.ID);
            }  
        }
    }
}
