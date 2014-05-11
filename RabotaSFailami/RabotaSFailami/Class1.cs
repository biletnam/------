using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RabotaSFailami
{
    public class RabotaSFailami
    {
        //Метод для открытия и считывания файла
        public string outFile(string path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            string line = "";
            line = reader.ReadLine();
            reader.Close();
            return line;
        }
        public string outFile2(string path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            string line = "";
            string temp = "";
            do
            {
                temp = reader.ReadLine();
                line += temp + Environment.NewLine;
            } while (temp != null);
            reader.Close();
            return line;
        }
        private DataGridView dataGridView1 = new DataGridView();
        public BindingSource bindingSource1 = new BindingSource();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //Метод работы c БД
        public void GetData(string selectCommand,String connectionString)
        {
            try
            {
                //Подключаемся к БД                
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
    }
}
