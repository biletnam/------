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
    public partial class VoprosOtpravka : Form
    {
        public VoprosOtpravka()
        {
            InitializeComponent();
        }
        string name = "";
        public VoprosOtpravka(string name) 
        { 
           InitializeComponent();
           this.name = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Met7.Vibor = true;
            Zakupat z = new Zakupat();
            z.ShowDialog();
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Met7.Vibor = false;
        }

        private void VoprosOtpravka_Load(object sender, EventArgs e)
        {
            label1.Text = "Медикамент " + name + " кончаетстя .Отправить заказ?";
        }
        
    }
}
