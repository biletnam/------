﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Delete
{
    public partial class DPostavshik : Form
    {
        public DPostavshik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met10 m = new Met10();
                m.Delete(comboBox1.Items[comboBox1.SelectedIndex].ToString());
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
        DB10 db10 = new DB10(kursach.Program.Pole.pole); 
        private void DPostavshik_Load(object sender, EventArgs e)
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
