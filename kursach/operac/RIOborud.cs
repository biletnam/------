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
    public partial class RIOborud : Form
    {
        public RIOborud()
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
                    d.Edit(Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    this.Close();
                }
                else { MessageBox.Show("ID не существует"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB2 db = new DB2(kursach.Program.Pole.pole);
            var ec = from n in db.IspolOborud
                     where n.ID == Convert.ToInt32(textBox4.Text)
                     select n;
            foreach (var i in ec)
            {
                textBox1.Text = i.IDRabot.ToString();
                textBox2.Text = i.IDMedicamenta.ToString();
            }
        }
    }
}
