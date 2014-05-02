using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace kursach
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        DataGridView dataGridView2 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private SqlDataAdapter dataAdapter2 = new SqlDataAdapter();
        private BindingSource bindingSource2 = new BindingSource();
        //Метод для открытия и считывания файла
        public string outFile(string path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            string line = "";
            line = reader.ReadLine();
            reader.Close();
            return line;
        }
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
        private void GetData2(string selectCommand)
        {
            try
            {
                //Подключаемся к БД
                String connectionString = kursach.Program.Pole.pole;
                //  Создать новый адаптер данных на основе указанного запроса.
                dataAdapter2 = new SqlDataAdapter(selectCommand, connectionString);
                // Создаем команду строителя для создания обновления SQL, вставить, и
                // Удалить команды, основанные на SelectCommand. Они используются для
                // Обновить базу данных.
                SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                //  Заполнение новую таблицу данных и привязать его к BindingSource..
                DataTable table2 = new DataTable();
                table2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter2.Fill(table2);
                bindingSource2.DataSource = table2;
                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView2.AutoResizeColumns(
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
        Panel panel1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                kursach.Program.Pole.pole = outFile(Application.StartupPath.ToString() + "\\DataSource.txt");
            }
            catch { MessageBox.Show("Файл не найден"); }            
            panel1 = new Panel();
        }        
        //Событие для списка
        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Text == "Добавить")
                {
                    switch (n)
                    {
                        case 1:
                            DPacient f = new DPacient();
                            f.ShowDialog(); // показываем    
                            break;
                        case 2:
                            Dobavlenie.DVrach f2 = new Dobavlenie.DVrach();
                            f2.ShowDialog(); // показываем    
                            break;
                        case 3:
                            Dobavlenie.DOborud f3 = new Dobavlenie.DOborud();
                            f3.ShowDialog(); // показываем    
                            break;
                        case 4:
                            Dobavlenie.DMedicament f4 = new Dobavlenie.DMedicament();
                            f4.ShowDialog(); // показываем    
                            break;
                        case 5:
                            Dobavlenie.DUslugi f5 = new Dobavlenie.DUslugi();
                            f5.ShowDialog(); // показываем    
                            break;
                        case 6:
                            Dobavlenie.DPostavshik f6 = new Dobavlenie.DPostavshik();
                            f6.ShowDialog(); // показываем    
                            break;
                        case 7:
                            Dobavlenie.DSpisokDoljnostei f7 = new Dobavlenie.DSpisokDoljnostei();
                            f7.ShowDialog(); // показываем       
                            break;

                    }
                    GetData(dataAdapter.SelectCommand.CommandText);
                }
                else
                {
                    if (e.Node.Text == "Редактировать")
                    {
                        switch (n)
                        {
                            case 1:
                                Form3 f = new Form3();
                                f.ShowDialog(); // показываем                            
                                break;
                            case 2:
                                Redaktirovanie.RVrach f2 = new Redaktirovanie.RVrach();
                                f2.ShowDialog(); // показываем                            
                                break;
                            case 3:
                                Redaktirovanie.ROborud f3 = new Redaktirovanie.ROborud();
                                f3.ShowDialog(); // показываем                            
                                break;
                            case 4:
                                Redaktirovanie.RMedicament f4 = new Redaktirovanie.RMedicament();
                                f4.ShowDialog(); // показываем                            
                                break;
                            case 5:
                                Redaktirovanie.RUslugi f5 = new Redaktirovanie.RUslugi();
                                f5.ShowDialog(); // показываем                            
                                break;
                            case 6:
                                Redaktirovanie.RPostavshik f6 = new Redaktirovanie.RPostavshik();
                                f6.ShowDialog(); // показываем                            
                                break;
                            case 7:
                                Redaktirovanie.RSpisokdoljnostei f7 = new Redaktirovanie.RSpisokdoljnostei();
                                f7.ShowDialog(); // показываем       
                                break;
                        }
                        GetData(dataAdapter.SelectCommand.CommandText);
                    }
                    else
                    {
                        if (e.Node.Text == "Удалить")
                        {
                            switch (n)
                            {
                                case 1:
                                    Form4 f = new Form4();
                                    f.ShowDialog(); // показываем                                
                                    break;
                                case 2:
                                    Delete.DVrach f2 = new Delete.DVrach();
                                    f2.ShowDialog(); // показываем       
                                    break;
                                case 3:
                                    Delete.DOborud f3 = new Delete.DOborud();
                                    f3.ShowDialog(); // показываем       
                                    break;
                                case 4:
                                    Delete.DMedicament f4 = new Delete.DMedicament();
                                    f4.ShowDialog(); // показываем       
                                    break;
                                case 5:
                                    Delete.DUslugi f5 = new Delete.DUslugi();
                                    f5.ShowDialog(); // показываем       
                                    break;
                                case 6:
                                    Delete.DPostavshik f6 = new Delete.DPostavshik();
                                    f6.ShowDialog(); // показываем       
                                    break;
                                case 7:
                                    Delete.DSpisokDoljnostei f7 = new Delete.DSpisokDoljnostei();
                                    f7.ShowDialog(); // показываем       
                                    break;
                            }
                            GetData(dataAdapter.SelectCommand.CommandText);

                        }
                        else
                        {
                            if (e.Node.Text == "Расписание")
                            {
                                kursach.Raspis.Raspisanie f1 = new kursach.Raspis.Raspisanie();
                                f1.ShowDialog(); // показываем
                            }
                            else
                            {
                                if (e.Node.Text == "Добавить время работы")
                                {
                                    kursach.Raspis.DVrem f2 = new kursach.Raspis.DVrem();
                                    f2.ShowDialog(); // показываем
                                    GetData(dataAdapter.SelectCommand.CommandText);
                                    GetData2(dataAdapter2.SelectCommand.CommandText);
                                }
                                else
                                {
                                    if (e.Node.Text == "Добавить расписание")
                                    {
                                        kursach.Raspis.DRaspisanie f3 = new kursach.Raspis.DRaspisanie();
                                        f3.ShowDialog(); // показываем
                                        GetData(dataAdapter.SelectCommand.CommandText);
                                        GetData2(dataAdapter2.SelectCommand.CommandText);
                                    }
                                    else
                                    {
                                        if (e.Node.Text == "Удалить время работы")
                                        {
                                            kursach.Raspis.DelVrem f4 = new kursach.Raspis.DelVrem();
                                            f4.ShowDialog(); // показываем
                                            GetData(dataAdapter.SelectCommand.CommandText);
                                            GetData2(dataAdapter2.SelectCommand.CommandText);
                                        }
                                        else
                                        {
                                            if (e.Node.Text == "Удалить расписание")
                                            {
                                                kursach.Raspis.DelRaspisanie f5 = new kursach.Raspis.DelRaspisanie();
                                                f5.ShowDialog(); // показываем
                                                GetData(dataAdapter.SelectCommand.CommandText);
                                                GetData2(dataAdapter2.SelectCommand.CommandText);
                                            }
                                            else
                                            {
                                                if (e.Node.Text == "Редактировать время работы")
                                                {
                                                    kursach.Raspis.EVrem f6 = new kursach.Raspis.EVrem();
                                                    f6.ShowDialog(); // показываем
                                                    GetData(dataAdapter.SelectCommand.CommandText);
                                                    GetData2(dataAdapter2.SelectCommand.CommandText);
                                                }
                                                else
                                                {
                                                    if (e.Node.Text == "Редактировать расписание")
                                                    {
                                                        kursach.Raspis.ERaspisanie f7 = new kursach.Raspis.ERaspisanie();
                                                        f7.ShowDialog(); // показываем
                                                        GetData(dataAdapter.SelectCommand.CommandText);
                                                        GetData2(dataAdapter2.SelectCommand.CommandText);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }                            
                            }
                            
                        }
                    }
                }
            }
            catch { MessageBox.Show("Error"); }            
        }
        DPacient f = new DPacient();
        public int n;
        //Вкладка пациента
        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                n = 1;
                panel1.Controls.Clear();
                //Добавление контейнера        
                panel1.AutoScroll = true;
                panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                panel1.Dock = DockStyle.Fill;
                this.Controls.Add(panel1);
                //Добавление списка Добавить Удалить Редактировать
                TreeView treeView1 = new TreeView();
                treeView1.BackColor = Color.LightBlue;
                treeView1.Width = 150;
                treeView1.ItemHeight = 100;
                treeView1.Dock = DockStyle.Left;
                treeView1.AfterSelect +=
                new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
                TreeNode tn = new TreeNode("Пациент");
                tn.Expand();
                tn.Nodes.Add(new TreeNode("Добавить"));
                tn.Nodes.Add(new TreeNode("Удалить"));
                tn.Nodes.Add(new TreeNode("Редактировать"));
                treeView1.Nodes.Add(tn);
                panel1.Controls.Add(treeView1);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.AutoSize = true;
                dataGridView1.Location = new Point(150, 28);
                dataGridView1.DataMember = "Table";
                panel1.Controls.Add(dataGridView1);
                //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
                dataGridView1.DataSource = bindingSource1;
                GetData("select * from Pacient");
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Полис";
                dataGridView1.Columns[3].HeaderText = "Посещения";
                dataGridView1.Columns[4].HeaderText = "1 обращение";
                dataGridView1.Columns[5].HeaderText = "Пол";
                dataGridView1.Columns[6].HeaderText = "Статус";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка врач
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try{
            n = 2;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Врач");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Vrach");
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "ID Должность";            
            dataGridView1.Columns[3].HeaderText = "Дата приема";
            dataGridView1.Columns[4].HeaderText = "Вып. работы/Время работ";
            dataGridView1.Columns[5].HeaderText = "Норма";
            dataGridView1.Columns[6].HeaderText = "Премия";
            dataGridView1.Columns[7].HeaderText = "Зарплата";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Оборудование
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try{
            n = 3;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Оборудование");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Oborud");
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "ID поставщика";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Медикаменты
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try{
            n = 4;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Медикаменты");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Medicament");
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].HeaderText = "ID поставщика";
            dataGridView1.Columns[4].HeaderText = "Минимум";
            dataGridView1.Columns[5].HeaderText = "Цена за ед";
            dataGridView1.Columns[6].HeaderText = "Заказывать";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Услуги
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try{
            n = 5;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Услуги");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Uslugi");
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Цена";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Поставщики
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try{
            n = 6; 
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Поставщики");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Postavshik");
            dataGridView1.Columns[1].HeaderText = "Наименование";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Должности
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try{
            n = 7;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 150;
            treeView1.ItemHeight = 100;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Должности");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить"));
            tn.Nodes.Add(new TreeNode("Удалить"));
            tn.Nodes.Add(new TreeNode("Редактировать"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(150, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from SpisokDoljnostei");
            dataGridView1.Columns[1].HeaderText = "Должность";
            dataGridView1.Columns[2].HeaderText = "Оклад";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Распписание работы врачей
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            try{
            n = 8;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            //Добавление списка Добавить Удалить Редактировать
            TreeView treeView1 = new TreeView();
            treeView1.BackColor = Color.LightBlue;
            treeView1.Width = 230;
            treeView1.ItemHeight = 57;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
            TreeNode tn = new TreeNode("Расписание работы");
            tn.Expand();
            tn.Nodes.Add(new TreeNode("Добавить время работы"));
            tn.Nodes.Add(new TreeNode("Добавить расписание"));
            tn.Nodes.Add(new TreeNode("Удалить время работы"));
            tn.Nodes.Add(new TreeNode("Удалить расписание"));
            tn.Nodes.Add(new TreeNode("Редактировать время работы"));
            tn.Nodes.Add(new TreeNode("Редактировать расписание"));
            tn.Nodes.Add(new TreeNode("Расписание"));
            treeView1.Nodes.Add(tn);
            panel1.Controls.Add(treeView1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(230, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Raspisanie");
            DataGridView dataGridView2 = new DataGridView();
            dataGridView2.AutoSize = true;
            dataGridView2.Location = new Point(605, 28);
            dataGridView2.DataMember = "Table";
            panel1.Controls.Add(dataGridView2);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView2.DataSource = bindingSource2;
            GetData2("select * from Vrem");
            dataGridView1.Columns[1].HeaderText = "ID времени";
            dataGridView1.Columns[2].HeaderText = "ID врача";

            dataGridView2.Columns[1].HeaderText = "День";
            dataGridView2.Columns[2].HeaderText = "Начало";
            dataGridView2.Columns[3].HeaderText = "Конец";
            }
            catch { MessageBox.Show("Error"); }
        }


        //Вкладка запись на прием
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            Button button=new Button();
            button.Text = "Записать на прием";
            button.Location = new Point(0, 28);
            button.Width = 200;
            button.Click += new System.EventHandler(button_Click);
            panel1.Controls.Add(button);
            Button button2 = new Button();
            button2.Text = "Редактировать запись";
            button2.Location = new Point(200, 28);
            button2.Width = 200;
            button2.Click += new System.EventHandler(button2_Click);
            panel1.Controls.Add(button2);
            Button button3 = new Button();
            button3.Text = "Удалить запись";
            button3.Location = new Point(400, 28);
            button3.Width = 200;
            button3.Click += new System.EventHandler(button3_Click);
            panel1.Controls.Add(button3);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.Location = new Point(0, 59);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Zapis");
             
        }
        //Запись, добавление удаление на прием
        private void button_Click(object sender, EventArgs e)
        {
            operac.Zapis f = new operac.Zapis();
            f.ShowDialog(); // показываем  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            operac.RZapis f = new operac.RZapis();
            f.ShowDialog(); // показываем  
        }
        private void button3_Click(object sender, EventArgs e)
        {
            operac.DZapis f = new operac.DZapis();
            f.ShowDialog(); // показываем  
        }

        //Задать строку подключения
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Settings.StrokaPodk f = new Settings.StrokaPodk();
            f.ShowDialog(); // показываем    
        }
        //Задать логин пароль
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Settings.Login f = new Settings.Login();
            f.ShowDialog(); // показываем    
        }
        //Алгоритм ЗП
        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            Settings.AlgoritmZarplat f = new Settings.AlgoritmZarplat();
            f.ShowDialog(); // показываем  
        }
        //Скидка
        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Settings.Skidka f = new Settings.Skidka();
            f.ShowDialog(); // показываем
        }
    }
}
