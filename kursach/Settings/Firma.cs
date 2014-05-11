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
    public partial class Firma : Form
    {
        public Firma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Mapping.Met17 m = new Mapping.Met17();
            m.Edit(1, textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox8.Text, textBox9.Text, textBox7.Text);
            this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        Mapping.DB17 db17 = new Mapping.DB17(kursach.Program.Pole.pole);
        private void Firma_Load(object sender, EventArgs e)
        {
            try
            {
                var Firma = from n in db17.Firma
                            where n.ID == 1
                            select n;
                foreach (var i in Firma)
                {
                    textBox1.Text = i.Name;
                    textBox2.Text = i.Adres;
                    textBox4.Text = i.Buh;
                    textBox5.Text = i.INN;
                    textBox6.Text = i.KPP;
                    textBox7.Text = i.Bank;
                    textBox8.Text = i.Schet;
                    textBox9.Text = i.SchetBank;
                }
            }
            catch { }
        }

        
    }
}
