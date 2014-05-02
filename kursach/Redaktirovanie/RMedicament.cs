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
    public partial class RMedicament : Form
    {
        public RMedicament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met7 m = new Met7();
                if (m.prov_id(Convert.ToInt32(textBox3.Text)) == true)
                { 
                m.Edit(Convert.ToInt32(textBox7.Text), textBox1.Text, Convert.ToInt32(textBox2.Text),Convert.ToInt32(textBox3.Text),Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox5.Text),Convert.ToInt32(textBox6.Text));
                this.Close();
                }
                else { MessageBox.Show("ID поставщика не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB7 db = new DB7(kursach.Program.Pole.pole);
            var ec = from n in db.Medicament
                     where n.ID == Convert.ToInt32(textBox7.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.Name;
                textBox2.Text = i.Kol.ToString();
                textBox1.Text = i.IDPost.ToString();
                textBox2.Text = i.Min.ToString();
                textBox1.Text = i.CenazaEd.ToString();
                textBox2.Text = i.Zak.ToString();
            }
        }
    }
}
