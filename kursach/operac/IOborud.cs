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
    public partial class IOborud : Form
    {
        public IOborud()
        {
            InitializeComponent();
        }
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Met2 d = new Met2();
                string[] str = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(new char[] { ' ' });
                //Подключаемся к БД
                String connectionString = kursach.Program.Pole.pole;
                //  Создать новый адаптер данных на основе указанного запроса.
                dataAdapter = new SqlDataAdapter("SELECT @@IDENTITY AS 'Identity'", connectionString);
                d.ADD(Convert.ToInt32(temp), Convert.ToInt32(str[0]));
                this.Close();
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Не все поля заполнены"); }
            catch { MessageBox.Show("Error"); }
        }
        DB9 db9 = new DB9(kursach.Program.Pole.pole);
        DB5 db5 = new DB5(kursach.Program.Pole.pole);
        string temp = "";
        private void IOborud_Load(object sender, EventArgs e)
        {
            var Oborud = from n2 in db9.Oborud
                        select n2;
            foreach (var i in Oborud)
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
    }
}
