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
    public partial class DPacient : Form
    {      
        public DPacient()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {       
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met1 d = new Met1();
                d.ADD(textBox1.Text, textBox2.Text, 0, DateTime.Today.ToString(), comboBox1.Items[comboBox1.SelectedIndex].ToString(), comboBox2.Items[comboBox2.SelectedIndex].ToString());
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        
    }
}
