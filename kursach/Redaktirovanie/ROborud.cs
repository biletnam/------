using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Redaktirovanie
{
    public partial class ROborud : Form
    {
        public ROborud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met9 d = new Met9();
                if (d.prov_id(Convert.ToInt32(textBox3.Text)) == true)
                {
                    d.Edit(Convert.ToInt32(textBox4.Text), textBox1.Text, Convert.ToInt32(textBox2.Text),Convert.ToInt32(textBox3.Text));
                    this.Close();
                }
                else { MessageBox.Show("ID поставщика не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DB9 db = new DB9(kursach.Program.Pole.pole);
            var ec = from n in db.Oborud
                     where n.ID == Convert.ToInt32(textBox4.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Cena.ToString();
                textBox3.Text = i.IDPostav.ToString();
            }
        }
    }
}
