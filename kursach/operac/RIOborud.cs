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
RRabot rr = new RRabot();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Met2 d = new Met2();
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), RRabot.IDRabot, Convert.ToInt32(str[0]));
                this.Close();
               
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ec = from n in db2.IspolOborud
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec)
            {
                var Oborud = from n2 in db9.Oborud
                             where n2.ID==i.IDMedicamenta
                             select n2;
                foreach (var j in Oborud)
                {
                    comboBox2.Text = j.Name;
                }
            }
        }
        DB9 db9 = new DB9(kursach.Program.Pole.pole);
        DB2 db2 = new DB2(kursach.Program.Pole.pole);
        private void RIOborud_Load(object sender, EventArgs e)
        {            
            var Oborud = from n2 in db9.Oborud
                         select n2;
            foreach (var i in Oborud)
            {
                comboBox2.Items.Add(i.ID + " " + i.Name);
            }
            var IspolOborud = from n2 in db2.IspolOborud
                              select n2;
            foreach (var i in IspolOborud)
            {
                if (i.IDRabot == RRabot.IDRabot)
                {
                    comboBox1.Items.Add(i.ID);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Met2 d = new Met2();
                d.Delete(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]));
                this.Close();

            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                RRabot rr = new RRabot();
                Met2 d = new Met2();
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                d.ADD(RRabot.IDRabot,Convert.ToInt32(str[0]));
                this.Close();

            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
    }
}
