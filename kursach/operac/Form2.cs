using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kursach
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //Метод работы c БД
        private void GetData(string selectCommand)
        {
            try
            {
                //Подключаемся к БД
                String connectionString = kursach.Program.Pole.pole;
                //  Создать новый адаптер данных на основе указанного запроса.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
                // Создаем команду строителя для создания обновления SQL, вставить, и
                // Удалить команды, основанные на SelectCommand. Они используются для
                // Обновить базу данных.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                //  Заполнение новую таблицу данных и привязать его к BindingSource..
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            catch (ArgumentException) { MessageBox.Show("Неправильная строка подключения"); }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.DataMember = "Table";
            this.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from JurnalRabot,IspolOborud,Zapis,Pacient,Uslugi,Raspisanie,Vrach,Oborud where IspolOborud.IDMedicamenta=Oborud.ID AND JurnalRabot.ID=IspolOborud.IDRabot AND JurnalRabot.IDZapisi=Zapis.ID AND Zapis.IDPacienta=Pacient.ID AND Zapis.IDUslugi=Uslugi.ID AND Zapis.IDRaspisania=Raspisanie.ID AND Raspisanie.IDVrach=Vrach.ID ");
            //dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].HeaderText = "Дата приема";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].HeaderText = "ФИО пациента";
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].HeaderText = "Протезирование";
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].HeaderText = "ФИО врача";
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[33].Visible = false;
            dataGridView1.Columns[34].Visible = false;
            dataGridView1.Columns[35].Visible = false;
            dataGridView1.Columns[36].HeaderText = "Наименование оборудования";
            dataGridView1.Columns[37].Visible = false;
            dataGridView1.Columns[38].Visible = false;
            dataGridView1.Columns[39].Visible = false;
        }
    }
}
