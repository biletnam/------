using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.operac
{
    public partial class IOborud : Form
    {
        public IOborud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met2 d = new Met2();
                if (d.prov_id(Convert.ToInt32(textBox1.Text)) == true && d.prov_id2(Convert.ToInt32(textBox2.Text)) == true)
                {
                    d.ADD(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    this.Close();
                }
                else { MessageBox.Show("ID не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
    }
}
