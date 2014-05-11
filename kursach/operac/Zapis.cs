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
    public partial class Zapis : Form
    {
        public Zapis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met16 d = new Met16();
                var ec = from n2 in db1.Pacient
                         where n2.FIO == comboBox1.Items[comboBox1.SelectedIndex].ToString()
                         select n2;
                string[] str = comboBox2.Items[comboBox2.SelectedIndex].ToString().Split(new char[] { ' ' });
                string[] str2 = dateTimePicker1.Value.ToString().Split(new char[] { ' ' });
                var ec2 = from n2 in db11.Raspisanie
                          where n2.ID == Convert.ToInt32(str[0])
                          select n2;
                var ec3 = from n2 in db13.Uslugi
                          where n2.Name == comboBox3.Items[comboBox3.SelectedIndex].ToString()
                          select n2;
                
                string temp = "";
                int temp2 = 0;
                foreach (var i in ec2)
                {
                    temp2 = i.IDVrem;
                }
                var ec4 = from n2 in db15.Vrem
                          where n2.ID == temp2
                          select n2;
                foreach (var i in ec4)
                {
                    temp = i.Den;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == d.Dni(temp))
                {
                    foreach (var i in ec)
                    {
                        foreach (var j in ec3)
                        {
                            d.ADD(i.ID, Convert.ToInt32(str[0]), j.ID, str2[0]);
                        }
                    }
                    this.Close();
                }
                else { MessageBox.Show("Ошибка ввода даты"); }
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        private void Zapis_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            var Pacient = from n2 in db1.Pacient
                     select n2;
            var Raspisanie = from n2 in db11.Raspisanie
                     select n2;
            var Uslugi = from n2 in db13.Uslugi
                     select n2;

            foreach (var i in Pacient)
                {
                        comboBox1.Items.Add(i.FIO);                   
                }
            foreach (var i in Raspisanie)
                {
                    var Vrach = from n2 in db14.Vrach
                     where n2.ID==i.IDVrach
                     select n2;
                    var Vrem = from n2 in db15.Vrem
                     where n2.ID==i.IDVrem
                     select n2;
                    foreach (var j in Vrach)
                    {
                        foreach (var k in Vrem)
                        {
                        comboBox2.Items.Add(i.ID + " "+j.FIO+" "+k.Den+" "+k.VremN+"-"+k.VremK);
                        }
                    }
                }
                foreach (var i in Uslugi)
                {
                        comboBox3.Items.Add(i.Name);                   
                }
        }
    }
}
