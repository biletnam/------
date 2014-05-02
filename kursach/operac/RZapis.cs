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
    public partial class RZapis : Form
    {
        public RZapis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met16 d = new Met16();
                if (d.prov_id(Convert.ToInt32(textBox1.Text)) == true && d.prov_id(Convert.ToInt32(textBox2.Text)) && d.prov_id(Convert.ToInt32(textBox3.Text)))
                {
                    d.Edit(Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), maskedTextBox2.Text, maskedTextBox1.Text);
                    this.Close();
                }
                else { MessageBox.Show("ID  не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB16 db = new DB16(kursach.Program.Pole.pole);
            var ec = from n in db.Zapis
                     where n.ID == Convert.ToInt32(textBox4.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.IDPacienta.ToString();
                textBox2.Text = i.IDVracha.ToString();
                textBox3.Text = i.IDUslugi.ToString();
                maskedTextBox1.Text = i.Vrem;
                maskedTextBox2.Text = i.Data;
            }
        }
    }
}
