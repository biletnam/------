using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursach.Raspis
{
    public partial class Raspisanie : Form
    {
        public Raspisanie()
        {
            InitializeComponent();
        }

        private void Raspisanie_Load(object sender, EventArgs e)
        {
            DB14 db = new DB14(kursach.Program.Pole.pole);
            DB11 db2 = new DB11(kursach.Program.Pole.pole);
            DB15 db3 = new DB15(kursach.Program.Pole.pole);
            var ec = from n in db.Vrach
                     select n;
            var ec2 = from n2 in db2.Raspisanie
                     select n2;
            var ec3 = from n3 in db3.Vrem
                     select n3;
            label1.Text += "\n";
            label2.Text += "\n";
            label3.Text += "\n";
            label4.Text += "\n";
            label5.Text += "\n";
            label6.Text += "\n";
            label7.Text += "\n";
            label8.Text += "\n";
            foreach (var i in ec)
            {
                label1.Text+=i.FIO +"\n";
                foreach (var i2 in ec2)
                { 
                if(i.ID==i2.IDVrach)
                {
                    foreach (var i3 in ec3) 
                    { 
                        if(i2.IDVrem==i3.ID)
                        {
                            if (i3.Den == "Понедельник") { label2.Text += i3.VremN + "-" + i3.VremK; }
                            if (i3.Den == "Вторник") { label3.Text += i3.VremN + "-" + i3.VremK;}
                            if (i3.Den == "Среда") { label4.Text += i3.VremN + "-" + i3.VremK;}
                            if (i3.Den == "Четверг") { label5.Text += i3.VremN + "-" + i3.VremK;}
                            if (i3.Den == "Пятница") { label6.Text += i3.VremN + "-" + i3.VremK;}
                            if (i3.Den == "Суббота") { label7.Text += i3.VremN + "-" + i3.VremK;}
                            if (i3.Den == "Воскресенье") {label8.Text += i3.VremN + "-" + i3.VremK; }
                        }
                    }
                }
                }
                label2.Text += "\n";
                label3.Text += "\n";
                label4.Text += "\n";
                label5.Text += "\n";
                label6.Text += "\n";
                label7.Text += "\n";
                label8.Text += "\n";
            }
            
        }
    }

}
