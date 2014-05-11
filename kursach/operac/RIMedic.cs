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
    public partial class RIMedic : Form
    {
        public RIMedic()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met7 m7 = new Met7();
                Met3 d = new Met3();
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                var ec = from n in db.IspolRabot
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
                foreach (var i in ec)
                {
                    m7.Spisania(Convert.ToInt32(numericUpDown1.Value)-i.Kolichestvo, Convert.ToInt32(str[0]));
                }
                d.Edit(Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex]), Convert.ToInt32(str[0]), Convert.ToInt32(numericUpDown1.Value), operac.RRabot.IDRabot);
                
                m7.Poisk_min();
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
 DB3 db = new DB3(kursach.Program.Pole.pole);
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
           
            var ec = from n in db.IspolRabot
                     where n.ID == Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex])
                     select n;
            foreach (var i in ec)
            {
                     var Medicament= from n in db7.Medicament
                     where n.ID == i.IDRashodnika
                     select n;
                     foreach (var j in Medicament)
                     {
                         comboBox2.Text = j.Name;
                     }
                numericUpDown1.Text = i.Kolichestvo.ToString();
            }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        DB3 db3 = new DB3(kursach.Program.Pole.pole);
        DB7 db7 = new DB7(kursach.Program.Pole.pole);
        private void RIMedic_Load(object sender, EventArgs e)
        {
            var IspolRabot = from n2 in db3.IspolRabot
                             where n2.IDRabot == operac.RRabot.IDRabot
                         select n2;
            foreach (var i in IspolRabot)
            {
                comboBox1.Items.Add(i.ID );
            }
            var IspolOborud = from n2 in db7.Medicament
                              select n2;
            foreach (var i in IspolOborud)
            {
                comboBox2.Items.Add(i.ID+" "+i.Name);
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                var Medicament = from n2 in db7.Medicament
                                 where n2.ID == Convert.ToInt32(str[0])
                                 select n2;
                foreach (var i in Medicament)
                {
                    numericUpDown1.Maximum = i.Kol;
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {                
                Met3 d = new Met3();
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
                Met3 d = new Met3();
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                d.ADD(Convert.ToInt32(str[0]), Convert.ToInt32(numericUpDown1.Value), operac.RRabot.IDRabot);
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
    }
}
