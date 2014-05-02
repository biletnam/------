﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met11 d = new Met11();
                if (d.prov_id(Convert.ToInt32(textBox1.Text)) == true && d.prov_id2(Convert.ToInt32(textBox2.Text)) == true )
                {
                    d.ADD(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    this.Close();
                }
                else { MessageBox.Show("ID поставщика не существует"); }
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
    }
}