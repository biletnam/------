using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kursach.operac
{
    public partial class IMedic : Form
    {
        public IMedic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met7 m7 = new Met7();
                Met3 d = new Met3();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                d.ADD( Convert.ToInt32(str[0]), Convert.ToInt32(numericUpDown1.Value),Convert.ToInt32(temp));
                m7.Spisania(Convert.ToInt32(numericUpDown1.Value),Convert.ToInt32(str[0]));
                m7.Poisk_min();
                    this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            //catch { MessageBox.Show("Error"); }
        }
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DB7 db7 = new DB7(kursach.Program.Pole.pole);
        string temp = "";
        private void IMedic_Load(object sender, EventArgs e)
        {
            var Medicament = from n2 in db7.Medicament
                         select n2;
            foreach (var i in Medicament)
            {
                comboBox1.Items.Add(i.ID + " " + i.Name);
            }
            //Подключаемся к БД
            String connectionString = kursach.Program.Pole.pole;
            //  Создать новый адаптер данных на основе указанного запроса.
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //dataAdapter = new SqlDataAdapter("select * from JurnalRabot", connectionString);
            SqlCommand cmd = new SqlCommand("SELECT MAX(id) FROM JurnalRabot", conn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                temp = dr.GetValue(0).ToString();
            }
            
        } 
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
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
    }
}
