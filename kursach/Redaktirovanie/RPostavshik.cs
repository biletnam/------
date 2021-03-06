﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Redaktirovanie
{
    public partial class RPostavshik : Form
    {
        public RPostavshik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met10 m = new Met10();
                m.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text);
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        DB10 db10 = new DB10(kursach.Program.Pole.pole);
        private void RPostavshik_Load(object sender, EventArgs e)
        {
            var ec = from n2 in db10.Postavshik
                     select n2;
            foreach (var i in ec)
            {
                comboBox1.Items.Add(i.ID);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var ec = from n in db10.Postavshik
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Email;
                textBox4.Text = i.Adres;
                textBox5.Text = i.Telefon;
            }
        }
    }
}
