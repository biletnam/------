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
using RabotaSFailami;
  
namespace kursach
{
    public partial class Form1 : Form
    {
        RabotaSFailami.RabotaSFailami rsf = new RabotaSFailami.RabotaSFailami();

        Panel panel1;
        DPacient f = new DPacient();
        public int n;
        
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem22.Visible = false;
            try
            {
                kursach.Program.Pole.pole = rsf.outFile(Application.StartupPath.ToString() + "\\DataSource.txt");
            }
            catch { MessageBox.Show("Файл не найден"); }            
            panel1 = new Panel();
        }               
        private void add_Click(object sender, EventArgs e)
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
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void edit_Click(object sender, EventArgs e)
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
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void del_Click(object sender, EventArgs e)
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
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void addv_Click(object sender, EventArgs e)
        {
            kursach.Raspis.DVrem f2 = new kursach.Raspis.DVrem();
            f2.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void addr_Click(object sender, EventArgs e)
        {
            kursach.Raspis.DRaspisanie f3 = new kursach.Raspis.DRaspisanie();
            f3.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void editv_Click(object sender, EventArgs e) 
        {
            kursach.Raspis.EVrem f6 = new kursach.Raspis.EVrem();
            f6.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole); 
        }
        private void editr_Click(object sender, EventArgs e)
        {
            kursach.Raspis.ERaspisanie f7 = new kursach.Raspis.ERaspisanie();
            f7.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);  
        }
        private void delv_Click(object sender, EventArgs e) 
        {
            kursach.Raspis.DelVrem f4 = new kursach.Raspis.DelVrem();
            f4.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void delr_Click(object sender, EventArgs e) 
        {
            kursach.Raspis.DelRaspisanie f5 = new kursach.Raspis.DelRaspisanie();
            f5.ShowDialog(); // показываем
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void rasp_Click(object sender, EventArgs e) 
        {
            kursach.Raspis.Raspisanie f1 = new kursach.Raspis.Raspisanie();
                                f1.ShowDialog(); // показываем 
        }
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
                Button add = new Button();
                add.Text = "Добавить запись";
                add.Location = new Point(0, 28);
                add.Width = 200;
                add.Click += new System.EventHandler(add_Click);
                panel1.Controls.Add(add);
                Button edit = new Button();
                edit.Text = "Редактировать запись";
                edit.Location = new Point(200, 28);
                edit.Width = 200;
                edit.Click += new System.EventHandler(edit_Click);
                panel1.Controls.Add(edit);
                Button del = new Button();
                del.Text = "Удалить запись";
                del.Location = new Point(400, 28);
                del.Width = 200;
                del.Click += new System.EventHandler(del_Click);
                panel1.Controls.Add(del);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.AutoSize = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Location = new Point(0, 56);
                dataGridView1.DataMember = "Table";
                panel1.Controls.Add(dataGridView1);
                //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
                dataGridView1.DataSource = rsf.bindingSource1;
                rsf.GetData("select * from Pacient",kursach.Program.Pole.pole);
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Полис";
                dataGridView1.Columns[3].HeaderText = "Посещения";
                dataGridView1.Columns[4].HeaderText = "Первое обращение";
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
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Vrach,SpisokDoljnostei where Vrach.IDSpiskaDolj=SpisokDoljnostei.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Дата приема на работу";
            dataGridView1.Columns[4].HeaderText = "Вып. работы/Время работ";
            dataGridView1.Columns[5].HeaderText = "Норма(в часах)";
            dataGridView1.Columns[6].HeaderText = "Премия";
            dataGridView1.Columns[7].HeaderText = "Зарплата";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Должность";
            dataGridView1.Columns[10].HeaderText = "Оклад";
            dataGridView1.Columns[11].HeaderText = "Ден. ед.";
            string AlgoritmZarplat=rsf.outFile(Application.StartupPath.ToString() + "\\FormOplata.txt");
            if (AlgoritmZarplat == "Прямая сдельная оплата труда" || AlgoritmZarplat =="Простая повременная оплата труда" ) 
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            if (AlgoritmZarplat == "Сдельно-премиальная оплата труда" || AlgoritmZarplat == "Повременно-премиальная оплата труда") { dataGridView1.Columns[5].Visible = false; }
            if (AlgoritmZarplat == "Сдельно-прогрессивная оплата труда") { dataGridView1.Columns[6].Visible = false; }
            if (AlgoritmZarplat == "Окладная оплата труда") 
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Оборудование
        private void toolStripMenuItem4_Click(object sender, EventArgs e)

        {
            try
            {
            n = 3;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Oborud,Postavshik where Oborud.IDPostav=Postavshik.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Фирма";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Ден. ед.";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            }
            catch { MessageBox.Show("Error"); }
        }
        //Вкладка Медикаменты
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                DB8 db = new DB8(kursach.Program.Pole.pole);
                var ec = from n2 in db.Nastroiki
                         where n2.ID == 1
                         select n2;
                EmailPriem ep = new EmailPriem();
                //foreach(var i in ec){ep.priem(i.login,i.pass);}
            n = 4;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Medicament,Postavshik where Medicament.IDPost=Postavshik.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Минимум";
            dataGridView1.Columns[5].HeaderText = "Цена за ед";
            dataGridView1.Columns[6].HeaderText = "Заказывать";
            dataGridView1.Columns[7].HeaderText = "Ед. изм.";
            dataGridView1.Columns[8].HeaderText = "Ден. ед.";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[10].HeaderText = "Фирма";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
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
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Uslugi", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "Ден. ед.";
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
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Postavshik", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Телефон";
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
            Button add = new Button();
            add.Text = "Добавить запись";
            add.Location = new Point(0, 28);
            add.Width = 200;
            add.Click += new System.EventHandler(add_Click);
            panel1.Controls.Add(add);
            Button edit = new Button();
            edit.Text = "Редактировать запись";
            edit.Location = new Point(200, 28);
            edit.Width = 200;
            edit.Click += new System.EventHandler(edit_Click);
            panel1.Controls.Add(edit);
            Button del = new Button();
            del.Text = "Удалить запись";
            del.Location = new Point(400, 28);
            del.Width = 200;
            del.Click += new System.EventHandler(del_Click);
            panel1.Controls.Add(del);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 56);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from SpisokDoljnostei", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].HeaderText = "Должность";
            dataGridView1.Columns[2].HeaderText = "Оклад";
            dataGridView1.Columns[3].HeaderText = "Ден. ед.";
            }
            catch { MessageBox.Show("Error"); }
        }
        //Распписание работы врачей
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            try
            {
            n = 8;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            Button addv = new Button();
            addv.Text = "Добавить время работы";
            addv.Location = new Point(0, 28);
            addv.Width = 200;
            addv.Click += new System.EventHandler(addv_Click);
            panel1.Controls.Add(addv);
            Button addr = new Button();
            addr.Text = "Добавить расписание работы";
            addr.Location = new Point(200, 28);
            addr.Width = 200;
            addr.Click += new System.EventHandler(addr_Click);
            panel1.Controls.Add(addr);
            Button editv = new Button();
            editv.Text = "Редактировать время работ";
            editv.Location = new Point(400, 28);
            editv.Width = 200;
            editv.Click += new System.EventHandler(editv_Click);
            panel1.Controls.Add(editv);
            Button editr = new Button();
            editr.Text = "Редактировать расписание работ";
            editr.Location = new Point(600, 28);
            editr.Width = 200;
            editr.Click += new System.EventHandler(editr_Click);
            panel1.Controls.Add(editr);
            Button delv = new Button();
            delv.Text = "Удалить время работ";
            delv.Location = new Point(0, 56);
            delv.Width = 200;
            delv.Click += new System.EventHandler(delv_Click);
            panel1.Controls.Add(delv);
            Button delr = new Button();
            delr.Text = "Удалить расписание работ";
            delr.Location = new Point(200, 56);
            delr.Width = 200;
            delr.Click += new System.EventHandler(delr_Click);
            panel1.Controls.Add(delr);
            Button rasp = new Button();
            rasp.Text = "Расписание";
            rasp.Location = new Point(400, 56);
            rasp.Width = 200;
            rasp.Click += new System.EventHandler(rasp_Click);
            panel1.Controls.Add(rasp);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 84);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Vrach,Vrem,Raspisanie where Raspisanie.IDVrem=Vrem.ID AND Raspisanie.IDVrach=Vrach.ID", kursach.Program.Pole.pole);
            //DataGridView dataGridView2 = new DataGridView();
            //dataGridView2.AutoSize = true;
            //dataGridView2.Location = new Point(605, 28);
            //dataGridView2.DataMember = "Table";
            //panel1.Controls.Add(dataGridView2);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            //dataGridView2.DataSource = bindingSource2;
            //GetData2("select * from Vrem ");
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "День";
            dataGridView1.Columns[10].HeaderText = "Начало";
            dataGridView1.Columns[11].HeaderText = "Конец";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            }
            catch { MessageBox.Show("Error"); }
        }

        int temp;
        //Вкладка запись на прием
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            temp = 1;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 59);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Zapis,Pacient,Uslugi,Raspisanie,Vrach,Vrem where Zapis.IDPacienta=Pacient.ID AND Zapis.IDUslugi=Uslugi.ID AND Zapis.IDRaspisania=Raspisanie.ID AND Raspisanie.IDVrach=Vrach.ID AND Raspisanie.IDVrem=Vrem.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Дата приема";
            dataGridView1.Columns[6].HeaderText = "ФИО пациента";
            dataGridView1.Columns[13].HeaderText = "Услуга";
            dataGridView1.Columns[20].HeaderText = "ФИО врача";
            dataGridView1.Columns[28].HeaderText = "День";
            dataGridView1.Columns[29].HeaderText = "Начало";
            dataGridView1.Columns[30].HeaderText = "Конец";
        }
        //Данные о выполненной работе
        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            temp = 2;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            Button button = new Button();
            button.Text = "Записать работу";
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
            Button button4 = new Button();
            button4.Text = "Показать используемое оборудование";
            button4.Location = new Point(600, 28);
            button4.Width = 300;
            button4.Click += new System.EventHandler(button4_Click);
            panel1.Controls.Add(button4);
            Button button5 = new Button();
            button5.Text = "Показать используемые медикаменты";
            button5.Location = new Point(900, 28);
            button5.Width = 300;
            button5.Click += new System.EventHandler(button5_Click);
            panel1.Controls.Add(button5);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 59);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from Zapis,Pacient,Uslugi,Raspisanie,Vrach,Vrem,JurnalRabot where JurnalRabot.IDZapisi=Zapis.ID AND Zapis.IDPacienta=Pacient.ID AND Zapis.IDUslugi=Uslugi.ID AND Zapis.IDRaspisania=Raspisanie.ID AND Raspisanie.IDVrach=Vrach.ID AND Raspisanie.IDVrem=Vrem.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[31].HeaderText = "ID";
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Дата приема";
            dataGridView1.Columns[6].HeaderText = "ФИО пациента";
            dataGridView1.Columns[13].HeaderText = "Услуга";
            dataGridView1.Columns[14].HeaderText = "Цена услуги";
            dataGridView1.Columns[15].HeaderText = "Ден. ед.";
            dataGridView1.Columns[20].HeaderText = "ФИО врача";
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[33].HeaderText = "Цена";
            dataGridView1.Columns[34].HeaderText = "Скидка";
            dataGridView1.Columns[35].HeaderText = "Итого";
        }
        
        //Акт выполненных работ
        CheckBox cb = new CheckBox();
        CheckBox cb2 = new CheckBox();
        TextBox t = new TextBox();
        ComboBox cb1 = new ComboBox();
        public  SaveFileDialog sfd = new SaveFileDialog();
         private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
             DB5 db5 = new DB5(kursach.Program.Pole.pole);
        DB1 db1 = new DB1(kursach.Program.Pole.pole);
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        DB11 db11 = new DB11(kursach.Program.Pole.pole);
        DB14 db14 = new DB14(kursach.Program.Pole.pole);
        DB15 db15 = new DB15(kursach.Program.Pole.pole);
        DB16 db16 = new DB16(kursach.Program.Pole.pole);
            temp = 3;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            cb.Text = "Сформировать акт в PDf";
            cb.Location = new Point(40, 40);
            cb.Width = 300;
            panel1.Controls.Add(cb);             
            cb2.Text = "Сформировать акт в writter";
            cb2.Location = new Point(40, 80);
            cb2.Width = 300;
            panel1.Controls.Add(cb2);
            Label l = new Label();
            l.Text = "Введите номер работ";
            l.Location = new Point(40, 120);
            l.Width = 300;
            panel1.Controls.Add(l);
            
            cb1.Location = new Point(40, 160);
            cb1.Width = 800;
            var JurnalRabot = from n2 in db5.JurnalRabot
                              select n2;
            foreach (var i in JurnalRabot)
            {
                var Zapis = from n2 in db16.Zapis
                            where n2.ID == i.IDZapisi
                            select n2;
                foreach (var r in Zapis)
                {
                    var Pacient = from n2 in db1.Pacient
                                  where n2.ID == r.IDPacienta
                                  select n2;
                    var Uslugi = from n2 in db13.Uslugi
                                 where n2.ID == r.IDUslugi
                                 select n2;
                    var Raspisanie = from n2 in db11.Raspisanie
                                     where n2.ID == r.IDRaspisania
                                     select n2;
                    foreach (var j in Pacient)
                    {
                        foreach (var k in Uslugi)
                        {
                            foreach (var u in Raspisanie)
                            {
                                var Vrem = from n2 in db15.Vrem
                                           where n2.ID == u.IDVrem
                                           select n2;
                                var Vrach = from n2 in db14.Vrach
                                            where n2.ID == u.IDVrach
                                            select n2;
                                foreach (var h in Vrem)
                                {
                                    foreach (var g in Vrach)
                                    {
                                        cb1.Items.Add(i.ID + " " + " Цена " + i.Cena + " Итог " + i.Itog + " Пациент " + j.FIO + " Услуга " + k.Name + " Врач " + g.FIO + " Дата " + r.Data + " " + h.VremN + "-" + h.VremK);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            panel1.Controls.Add(cb1);
            Button button = new Button();
            button.Text = "Создать акт работ";
            button.Location = new Point(40, 200);
            button.Width = 300;
            button.Click += new System.EventHandler(button_Click);
            panel1.Controls.Add(button);
        }
        //Счет выполненных работ
        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            DB5 db5 = new DB5(kursach.Program.Pole.pole);
            DB1 db1 = new DB1(kursach.Program.Pole.pole);
            DB13 db13 = new DB13(kursach.Program.Pole.pole);
            DB11 db11 = new DB11(kursach.Program.Pole.pole);
            DB14 db14 = new DB14(kursach.Program.Pole.pole);
            DB15 db15 = new DB15(kursach.Program.Pole.pole);
            DB16 db16 = new DB16(kursach.Program.Pole.pole);
            temp = 4;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            cb.Text = "Сформировать счет в PDf";
            cb.Location = new Point(40, 40);
            cb.Width = 300;
            panel1.Controls.Add(cb);
            cb2.Text = "Сформировать счет в writter";
            cb2.Location = new Point(40, 80);
            cb2.Width = 300;
            panel1.Controls.Add(cb2);
            Label l = new Label();
            l.Text = "Введите номер работ";
            l.Location = new Point(40, 120);
            l.Width = 300;
            panel1.Controls.Add(l);
            cb1.Location = new Point(40, 160);
            cb1.Width = 800;
            var JurnalRabot = from n2 in db5.JurnalRabot
                              select n2;
            foreach (var i in JurnalRabot)
            {
                var Zapis = from n2 in db16.Zapis
                            where n2.ID == i.IDZapisi
                            select n2;
                foreach (var r in Zapis)
                {
                    var Pacient = from n2 in db1.Pacient
                                  where n2.ID == r.IDPacienta
                                  select n2;
                    var Uslugi = from n2 in db13.Uslugi
                                 where n2.ID == r.IDUslugi
                                 select n2;
                    var Raspisanie = from n2 in db11.Raspisanie
                                     where n2.ID == r.IDRaspisania
                                     select n2;
                    foreach (var j in Pacient)
                    {
                        foreach (var k in Uslugi)
                        {
                            foreach (var u in Raspisanie)
                            {
                                var Vrem = from n2 in db15.Vrem
                                           where n2.ID == u.IDVrem
                                           select n2;
                                var Vrach = from n2 in db14.Vrach
                                            where n2.ID == u.IDVrach
                                            select n2;
                                foreach (var h in Vrem)
                                {
                                    foreach (var g in Vrach)
                                    {
                                        cb1.Items.Add(i.ID + " " + " Цена " + i.Cena + " Итог " + i.Itog + " Пациент " + j.FIO + " Услуга " + k.Name + " Врач " + g.FIO + " Дата " + r.Data + " " + h.VremN + "-" + h.VremK);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            panel1.Controls.Add(cb1);
            Button button = new Button();
            button.Text = "Создать счет работ";
            button.Location = new Point(40, 200);
            button.Width = 300;
            button.Click += new System.EventHandler(button_Click);
            panel1.Controls.Add(button);
        }
        //Запись, добавление удаление на прием и выполнение
        private void button_Click(object sender, EventArgs e)
        {
            try{
                switch (temp)
                {
                    case 1:
                        operac.Zapis f = new operac.Zapis();
                        f.ShowDialog(); // показываем  
                        rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
                        break;
                    case 2:
                        operac.Rabot f2 = new operac.Rabot();                        
                        f2.ShowDialog(); // показываем  
                        rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
                        break;
                    case 3:
                        Met5 m = new Met5();                        
                            if (cb.Checked == true) 
                            {                        
                                sfd.Filter = "PDF Document|*.pdf";
                                sfd.ShowDialog();
                                AktPdf a = new AktPdf();
                                string[] str = cb1.Items[cb1.SelectedIndex].ToString().Split(new char[] { ' ' });                
                                a.CozdAktPdf(sfd.FileName, Convert.ToInt32(str[0]));  //                     
                            }
                        if (cb2.Checked == true) 
                        {
                            sfd.Filter = "Writer Document|*.odt";
                            sfd.ShowDialog();
                            string push = sfd.FileName;
                            AktWriter a = new AktWriter();
                            string[] str = cb1.Items[cb1.SelectedIndex].ToString().Split(new char[] { ' ' });
                            a.CozdAktWriter(push, Convert.ToInt32(str[0]));
                        }
                        break;
                    case 4:
                        Met5 m2 = new Met5();
                        
                        if (cb.Checked == true)
                        {                                                        
                                sfd.Filter = "PDF Document|*.pdf";
                                sfd.ShowDialog();
                                SchetPdf a = new SchetPdf();
                                string[] str = cb1.Items[cb1.SelectedIndex].ToString().Split(new char[] { ' ' });                
                                
                                a.CozdSchetPdf(sfd.FileName, Convert.ToInt32(str[0]));
                            }
                            if (cb2.Checked == true) 
                        {
                            sfd.Filter = "Writer Document|*.odt";
                            sfd.ShowDialog();
                            string push = sfd.FileName;
                            SchetWriter a = new SchetWriter();
                            string[] str = cb1.Items[cb1.SelectedIndex].ToString().Split(new char[] { ' ' });
                            a.CozdSchetWriter(push, Convert.ToInt32(str[0]));
                        }
                        break;
                    case 5:
                        if (cb.Checked == true)
                        {
                            OtchetForm of = new OtchetForm();
                            of.ShowDialog();
                        }
                        if (cb2.Checked == true)
                        {
                            OtchetExel a = new OtchetExel();
                            a.SozdOtchetExel(Convert.ToInt32(t.Text));
                        }
                        break;
                }
            }catch(ArgumentOutOfRangeException){MessageBox.Show("Не все поля заполнены");}
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch(temp)
            {
                case 1:
            operac.RZapis f = new operac.RZapis();
            f.ShowDialog(); // показываем  
                    break;
                case 2: 
                    operac.RRabot f2 = new operac.RRabot();
                    f2.ShowDialog(); // показываем  
                    break;
            }
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            switch(temp)
            {
                case 1:
            operac.DZapis f = new operac.DZapis();
            f.ShowDialog(); // показываем  
            break;
                case 2: 
                    operac.DRabot f2 = new operac.DRabot();
                    f2.ShowDialog(); // показываем
                    break;
            }
            rsf.GetData(rsf.dataAdapter.SelectCommand.CommandText, kursach.Program.Pole.pole);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.ShowDialog();
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
       
        //Отчеты
        //Журнал закупок
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);            
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from JurnalPriema,Postavshik,Medicament where JurnalPriema.IDPostavshika=Postavshik.ID AND JurnalPriema.IDRashodnika=Medicament.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Количество";
            dataGridView1.Columns[4].HeaderText = "Цена";
            dataGridView1.Columns[5].HeaderText = "Дата";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Название";
            dataGridView1.Columns[10].HeaderText = "фирма";
        }
        //Журнал заказов
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.DataMember = "Table";
            panel1.Controls.Add(dataGridView1);
            //Свяжите DataGridView к BindingSource И загрузить данные из базы данных.
            dataGridView1.DataSource = rsf.bindingSource1;
            rsf.GetData("select * from JurnalZakupok,Postavshik,Medicament where JurnalZakupok.IDPostovshika=Postavshik.ID AND JurnalZakupok.IDRashodnika=Medicament.ID", kursach.Program.Pole.pole);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Количество";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[6].HeaderText = "Фирма";
            dataGridView1.Columns[11].HeaderText = "Название";
            dataGridView1.Columns[17].HeaderText = "Ед. изм.";
        }
        //Отчет о работе фирмы
        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            temp = 5;
            panel1.Controls.Clear();
            //Добавление контейнера        
            panel1.AutoScroll = true;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            cb.Text = "Сформировать отчет в программе";
            cb.Location = new Point(40, 40);
            cb.Width = 300;
            panel1.Controls.Add(cb);
            cb2.Text = "Сформировать отчет в Exel";
            cb2.Location = new Point(40, 80);
            cb2.Width = 300;
            panel1.Controls.Add(cb2);

            Label l = new Label();
            l.Text = "Введите год";
            l.Location = new Point(40, 120);
            l.Width = 300;
            panel1.Controls.Add(l);

            t.Location = new Point(40, 160);
            t.Width = 300;
            panel1.Controls.Add(t);
            Button button = new Button();
            button.Text = "Создать отчет";
            button.Location = new Point(40, 200);
            button.Width = 300;
            button.Click += new System.EventHandler(button_Click);
            panel1.Controls.Add(button);
        }
        //О фирме
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Firma f=new Firma();
            f.ShowDialog();
        }

        

       

        
    }
}
