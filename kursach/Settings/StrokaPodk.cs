using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace kursach.Settings
{
    public partial class StrokaPodk : Form
    {
        public StrokaPodk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(Application.StartupPath.ToString() + "\\DataSource.txt");
                writer.WriteLine(textBox1.Text);
                writer.Close();
                kursach.Program.Pole.pole = textBox1.Text;
                this.Close();
            }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = kursach.Program.Pole.pole;
        }
    }
}
