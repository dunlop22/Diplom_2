using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NETWORKLIST;      //для проверки интернет-подключения
using System.Threading;     //использование и создание потоков
using Renci.SshNet;

namespace Diplom_2
{
    public partial class Form1 : Form
    {

        LoadLogoForm LoadLogo = new LoadLogoForm();

        public Form1()
        {
            InitializeComponent();

            //создание дополнительного потока для проверки подключения к интернету
            thread_check_internet = new Thread(check_internet);
            thread_check_internet.Start();

        }
        Thread thread_check_internet;       //поток для проверки наличия интернета
        Thread thread_read_api_answer;      //поток для чтения ответов api от оборудования
        Thread thread_read_api_request;


        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<TextBox> textBoxes = new List<TextBox>();

        //объект класса для проверки подключения интернета
        internal InternetConnectionChecker check = new InternetConnectionChecker();

        Info information = new Info();

        bool SafeMode = false;

        //флажок для проверки интернета
        bool work = true;

        public string passwordfile = "";   //пароль для доступа к файлу-сессии

        void check_internet()
        {
            while (work)
            {
                if (check.IsConnected())    //подключение есть
                {
                    this.Internet_connect_status_image.Image = Properties.Resources.green_circle;
                }
                else          //подключения нет
                {
                    this.Internet_connect_status_image.Image = Properties.Resources.red_circle;
                }
                Internet_connect_status_image.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)

                Thread.Sleep(4);  //пауза потока
            }
        }
        
        //Открытие формы для создания нового подключения

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1); //принудительное удаление всех потоков (thread)
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.backgroundWorker1
            //Загрузка loader'a
            LoadLogo.TopMost = true;
            LoadLogo.ShowDialog();
            

            //Формирование массивов
            textBoxes.Add(textBox_telnet_port);
            textBoxes.Add(textBox_ftp_port);
            textBoxes.Add(textBox_www_port);
            textBoxes.Add(textBox_ssh_port);
            textBoxes.Add(textBox_www_ssl_port);
            textBoxes.Add(textBox_api_port);
            textBoxes.Add(textBox_winbox_port);
            textBoxes.Add(textBox_api_ssl_port);

            checkBoxes.Add(checkBox_telnet);
            checkBoxes.Add(checkBox_ftp);
            checkBoxes.Add(checkBox_www);
            checkBoxes.Add(checkBox_ssh);
            checkBoxes.Add(checkBox_wwwssl);
            checkBoxes.Add(checkBox_api);
            checkBoxes.Add(checkBox_winbox);
            checkBoxes.Add(checkBox_apissl);


            
            
            NewConnectionForm NewConn = new NewConnectionForm();
            NewConn.ShowDialog();
            if (connt.host == null)
            {
                Application.Exit();
            }
            else
            {
                information.FirstStart();
                this.timer1.Enabled = true;     //Постоянное обновление ресурсов
            }
           
            //Запуск таймера с обновлением всех данных (ресурсов)
            information.FirstStart();

            //information.GetGlobalIP();      //получение внешнего ip адреса оборудования

            //Отдельный поток для прослушивания ответов оборудования
            thread_read_api_answer = new Thread(information.ReadAnswer);
            thread_read_api_answer.Start();
            thread_read_api_request = new Thread(information.SendRequest);
            thread_read_api_request.Start();


            this.timer1.Enabled = true; //постоянное обновление ресурсов

            return;

        }

        private  void UpdateGraph()
        {
            Thread.Sleep(5);
            List<string> resource = information.GetResource();
            if (resource[0] != null)        //проверка на наличие полученных данных
            {
                //Блок процессор
                this.chart1.Series.Clear();     //Очистка коллекции
                this.chart1.Series.Add("CPU");          //Добавление нового набора данных
                chart1.Series["CPU"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                double[] yValuesCPU = { Convert.ToDouble(resource[0]), 100 - Convert.ToDouble(resource[0]) };
                string[] xValuesCPU = { "", "" };
                this.chart1.Series["CPU"].Points.DataBindXY(xValuesCPU, yValuesCPU);
                this.label_CPU_load.Text = resource[0] + "%";
                this.label_cpu_name.Text = "CPU Arch: " + resource[9];
                this.label_cpu_mhz.Text = "Frequency: " + resource[10] + "MHz";
                
                this.label_cpu_num_core.Text = "CPU Core: " + resource[11];

                //Цвет текста для нагрузки процессора
                if (Convert.ToDouble(resource[0]) >= 70)
                {
                    this.label_CPU_load.ForeColor = Color.Red;
                }
                else if (Convert.ToDouble(resource[0]) >= 30)
                {
                    this.label_CPU_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32)))));
                }
                else
                {
                    this.label_CPU_load.ForeColor = Color.Green;
                }

                //цвет диаграммы для нагрузки процессора
                if (Convert.ToDouble(resource[0]) >= 70)
                {
                    chart1.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(71)))), ((int)(((byte)(32))))), 
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else if (Convert.ToDouble(resource[0]) >= 30)
                {
                    chart1.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32))))), 
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else
                {
                    chart1.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(227)))), ((int)(((byte)(32))))), 
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }


                //Блок оперативной памяти
                this.chart2.Series.Clear();     //Очистка коллекции
                this.chart2.Series.Add("RAM");          //Добавление нового набора данных
                chart2.Series["RAM"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                double[] yValuesRAM = { ((Convert.ToDouble(resource[2]) - (Convert.ToDouble(resource[1]))) / 1048576), (Convert.ToDouble(resource[1]) / 1048576) };
                string[] xValuesRAM = { "", "" };
                this.chart2.Series["RAM"].Points.DataBindXY(xValuesRAM, yValuesRAM);
                //resource[2] - 128 (full memory)
                //resource[1] - XXX (free memory)
                this.label_RAM.Text = "Use: " + Math.Round((Convert.ToDouble(resource[2]) - Convert.ToDouble(resource[1])) / 1048576, 2) + "MiB / " + Math.Round((Convert.ToDouble(resource[2]) / 1048576), 2) + " MiB";
                double Ram_Percent_Use = ((Convert.ToDouble(resource[2]) - Convert.ToDouble(resource[1])) / Convert.ToDouble(resource[2])) * 100;
                this.label_RAM_load.Text = (Math.Round(Ram_Percent_Use, 0)).ToString() + "%";

                //Цвет текста для нагрузки процессора
                if (Ram_Percent_Use >= 90)
                {
                    this.label_RAM_load.ForeColor = Color.Red;
                }
                else if (Ram_Percent_Use >= 65)
                {
                    this.label_RAM_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32)))));
                }
                else
                {
                    this.label_RAM_load.ForeColor = Color.Green;
                }

                //цвет диаграммы для нагрузки процессора
                if (Ram_Percent_Use >= 90)
                {
                    chart2.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(71)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else if (Ram_Percent_Use >= 65)
                {
                    chart2.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else
                {
                    chart2.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(227)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }


                //Блок накопителя
                this.chart3.Series.Clear();     //Очистка коллекции
                this.chart3.Series.Add("Memory");           //Добавление нового набора данных
                chart3.Series["Memory"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                double[] yValuesMem = { ((Convert.ToDouble(resource[4]) - Convert.ToDouble(resource[3])) / 1048576), (Convert.ToDouble(resource[3]) / 1048576) };
                string[] xValuesMem = { "", "" };
                this.chart3.Series["Memory"].Points.DataBindXY(xValuesMem, yValuesMem);
                this.label_Memory.Text = Math.Round((Convert.ToDouble(resource[4]) - Convert.ToDouble(resource[3])) / 1048576, 2) + "MiB / " + Math.Round((Convert.ToDouble(resource[4]) / 1048576), 2) + " MiB";

                double Hdd_Percent_Use = ((Convert.ToDouble(resource[4]) - Convert.ToDouble(resource[3])) / (Convert.ToDouble(resource[4]))) * 100;
                this.label_hhd_load.Text = Math.Round(Hdd_Percent_Use, 0).ToString() + "%";
                //Цвет текста для нагрузки процессора
                if (Hdd_Percent_Use >= 90)
                {
                    this.label_hhd_load.ForeColor = Color.Red;
                }
                else if (Hdd_Percent_Use >= 65)
                {
                    this.label_hhd_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32)))));
                }
                else
                {
                    this.label_hhd_load.ForeColor = Color.Green;
                }

                //цвет диаграммы для заполненности накопителя
                if (Hdd_Percent_Use >= 90)
                {
                    chart3.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(71)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else if (Hdd_Percent_Use >= 65)
                {
                    chart3.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(214)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                else
                {
                    chart3.PaletteCustomColors = new System.Drawing.Color[] { System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(227)))), ((int)(((byte)(32))))),
                        System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194))))) }; ;
                }
                this.label_sector_reboot.Text = "Sector Writes\nAfter Reboot: " + resource[12];
                this.label_total_sector.Text = "Total Sector \n            Write: " + resource[13];
                this.label_bad_blocks.Text = "Bad Blocks: " + resource[14] + "%";
                this.label_factory_soft.Text = "Factory Software: " + resource[15];


                //Попытка вставки изображения оборудования
                try
                {
                    if (resource[8] == "hAP lite")
                    {
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.hAP_lite);
                    }
                    else if (resource[8] == "hAP ac^2")
                    {
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.hAP_ac_2);
                    }
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }


                //разбор uptime
                string uptime = "";

                for (int i=0;i<resource[5].Length;i++)
                {
                    if (resource[5][i] == 'd')
                    {
                        uptime = uptime + "d ";
                    }
                    else if (resource[5][i] == 'h' || resource[5][i] == 'm')
                    {
                        uptime = uptime + ':';
                        if (i == resource[5].Length - 1)

                        {
                            uptime = uptime + "00";
                        }

                    }
                    else if (resource[5][i] == 's') 
                    {
                        if (i > 0)
                        {
                            if (!Char.IsDigit(resource[5][i - 1]))
                            {
                                uptime = uptime + "00";
                            }
                        }
                    }
                    else
                    {
                        if (i > 1 && i < resource[5].Length - 2)
                        {
                            if (!Char.IsDigit(resource[5][i - 1]) && !Char.IsDigit(resource[5][i + 1]))
                            {
                                uptime = uptime + "0" + resource[5][i];
                            }
                            else
                            {
                                uptime = uptime + resource[5][i];
                            }
                        }
                        else if (i == resource[5].Length - 1)
                        {
                            if (i > 0)
                            {
                                if (!Char.IsDigit(resource[5][i - 1]))
                                {
                                    uptime = uptime + "0" + resource[5][i];
                                }
                            }
                        }
                        else
                        {
                            uptime = uptime + resource[5][i];
                        }
                    }
                }
               
                this.label_RouterOS.Text = "RouterOS: " + resource[6];
                this.label_UpTime.Text = "Время работы: " + uptime;
                this.label_Arch.Text = "Архитектура: " + resource[7];
                this.label_Model.Text = "Модель: " + resource[8];
            }
        }

        

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files | *.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            //Путь до выбранного файла
            string filename = openFileDialog1.FileName;
            this.label1.Text = filename;

            //проверка на необходимость дешифровки
            //считывание первой строки и сравнение его с константой

            //ввод пароля для доступа к файлу

            //открытый вариант файла
            //первая строка - AES
            InputPasswordForFile newForm = new InputPasswordForFile(this);
            newForm.ShowDialog();
            this.label1.Text = passwordfile;


        }
        

        
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            this.label1.Text = filename;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //обновление графиков ресурсов
            this.UpdateGraph();
        }

        private void UpdateUserTable()
        {
            //Заполнение таблицы пользователей
            //information.SendUser();
            //information.ReadAnswer();
            this.dataGridView_User.Rows.Clear();    //очистка таблицы
            List<List<string>> table_user = information.GetTableUser();
            if (table_user.Count() > 0)
            {
                
                for (int i = 0; i < table_user.Count(); i++)
                {
                    this.dataGridView_User.Rows.Add();
                    this.dataGridView_User.Rows[i].Cells[0].Value = table_user[i][1];   //логин
                    this.dataGridView_User.Rows[i].Cells[1].Value = table_user[i][2];   //группа
                    if (table_user[i][3] != "false")
                    {
                        this.dataGridView_User.Rows[i].Cells[2].Value = table_user[i][3];   //время последнего входа
                    }
                }
                this.dataGridView_User.Rows[0].Selected = false;
            }

            //Заполнение таблицы групп
            List<List<string>> table_usergroup = information.GetTableUserGroup();
            this.dataGridView_UserGroup.Rows.Clear();    //очистка таблицы
            if (table_usergroup.Count() > 0)
            {

                for (int i = 0; i < table_usergroup.Count(); i++)
                {

                    this.dataGridView_UserGroup.Rows.Add();
                    this.dataGridView_UserGroup.Rows[i].Cells[0].Value = table_usergroup[i][0];     //имя группы

                    //заполнение checkbox'ов политик групп
                    for (int j = 1; j < table_usergroup[i].Count(); j++)
                    {
                        this.dataGridView_UserGroup.Rows[i].Cells[j + 1].Value = Convert.ToBoolean(table_usergroup[i][j]);
                    }

                }
                this.dataGridView_UserGroup.Rows[0].Selected = false;
            }
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["ARP_tab"])
            {
                this.dataGridView_address.Rows.Clear();     //очистка таблицы
                List<List<string>> table_address = information.GetTableAddress();
                if (table_address.Count() > 0)
                {
                    
                    
                    for (int i = 0; i < table_address.Count(); i++)
                    {
                        this.dataGridView_address.Rows.Add();
                        this.dataGridView_address.Rows[i].Cells[1].Value = table_address[i][3]; //dynamic
                        this.dataGridView_address.Rows[i].Cells[1].Value = table_address[i][0]; //address
                        this.dataGridView_address.Rows[i].Cells[2].Value = table_address[i][1]; //network
                        this.dataGridView_address.Rows[i].Cells[3].Value = table_address[i][2]; //interface
                        if (table_address[i][4] == "true")        //изменить подсветку строки, если адрес  не активен
                        {
                            this.dataGridView_address.Rows[dataGridView_address.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                        }
                        else
                        {
                            this.dataGridView_address.Rows[dataGridView_address.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        }
                        //status
                    }
                    this.dataGridView_address.Rows[0].Selected = false;
                    
                }

                this.dataGridView_ARP.Rows.Clear();     //очистка таблицы
                List<List<string>> table_arp = information.GetTableARP();
                if (table_arp.Count() > 0)
                {
                    //заполнение таблицы
                    for (int i = 0; i < table_arp.Count(); i++)
                    {
                        this.dataGridView_ARP.Rows.Add();
                        this.dataGridView_ARP.Rows[i].Cells[0].Value = table_arp[i][0];         //ip
                        this.dataGridView_ARP.Rows[i].Cells[1].Value = table_arp[i][1];         //mac
                        if (table_arp[i][1] == null)
                        {
                            this.dataGridView_ARP.Rows[dataGridView_ARP.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                        }
                        if (table_arp[i][2] == "true")
                        {
                            this.dataGridView_ARP.Rows[i].Cells[2].Value = true;
                        }

                        this.dataGridView_ARP.Rows[i].Cells[3].Value = table_arp[i][3];         //interface

                    }
                    this.dataGridView_ARP.Rows[0].Selected = false;
                }

            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["User_tab"])
            {
                UpdateUserTable();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["Interface_tab"])
            {
                List<List<string>> table_interface = information.GetTableInterface();
                this.dataGridView_PhysicalInterface.Rows.Clear();       //очистка таблицы
                this.dataGridView_VirtualInterface.Rows.Clear();        //очистка таблицы

                
                
                if (table_interface.Count() > 0)
                {
                    for (int i = 0; i < table_interface.Count(); i++)
                    {
                        if (table_interface[i][2] == "ether" || table_interface[i][2] == "wlan")
                        {
                            this.dataGridView_PhysicalInterface.Rows.Add();
                            this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].Cells[0].Value = table_interface[i][0];     //name
                            this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].Cells[1].Value = table_interface[i][1];     //mac
                            this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].Cells[2].Value = table_interface[i][2];     //type
                            this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].Cells[3].Value = table_interface[i][3];     //download
                            this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].Cells[4].Value = table_interface[i][4];     //upload
                            if (table_interface[i][6] == "true")        //изменить подсветку строки, если интерфейс не активен
                            {
                                this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                            }
                            else
                            {
                                if (table_interface[i][5] != "true")        //изменить цвет, если кабель не подключен к интерфейсу
                                {
                                    this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(186)))), ((int)(((byte)(3)))));
                                }
                                else
                                {
                                    this.dataGridView_PhysicalInterface.Rows[dataGridView_PhysicalInterface.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                }
                            }
                        }
                        else
                        {
                            this.dataGridView_VirtualInterface.Rows.Add();
                            this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].Cells[0].Value = table_interface[i][0];     //name
                            this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].Cells[1].Value = table_interface[i][1];     //mac
                            this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].Cells[2].Value = table_interface[i][2];     //type
                            this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].Cells[3].Value = table_interface[i][3];     //download
                            this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].Cells[4].Value = table_interface[i][4];     //upload
                            if (table_interface[i][6] == "true")        //изменить подсветку строки, если интерфейс не активен
                            {
                                this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));

                            }
                            else
                            {
                                this.dataGridView_VirtualInterface.Rows[dataGridView_VirtualInterface.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                            }
                        }

                    }
                    this.dataGridView_VirtualInterface.Rows[0].Selected = false;
                    this.dataGridView_PhysicalInterface.Rows[0].Selected = false;
                }
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["Service_tab"])
            {
                List<List<string>> table_service = information.GetTableService();

                if (table_service.Count() > 0)
                {
                    for (int i = 0; i < table_service.Count(); i++)
                    {
                        if (table_service[i][1] == "api")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_api.Checked = false;
                            }
                            else
                            {
                                this.checkBox_api.Checked = true;
                            }
                            this.textBox_api_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "api-ssl")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_apissl.Checked = false;
                            }
                            else
                            {
                                this.checkBox_apissl.Checked = true;
                            }
                            this.textBox_api_ssl_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "ftp")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_ftp.Checked = false;
                            }
                            else
                            {
                                this.checkBox_ftp.Checked = true;
                            }
                            this.textBox_ftp_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "ssh")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_ssh.Checked = false;
                            }
                            else
                            {
                                this.checkBox_ssh.Checked = true;
                            }
                            this.textBox_ssh_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "telnet")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_telnet.Checked = false;
                            }
                            else
                            {
                                this.checkBox_telnet.Checked = true;
                            }
                            this.textBox_telnet_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "winbox")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_winbox.Checked = false;
                            }
                            else
                            {
                                this.checkBox_winbox.Checked = true;
                            }
                            this.textBox_winbox_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "www")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_www.Checked = false;
                            }
                            else
                            {
                                this.checkBox_www.Checked = true;
                            }
                            this.textBox_www_port.Text = (table_service[i][2]);
                        }
                        else if (table_service[i][1] == "www-ssl")       //наименование
                        {
                            if (table_service[i][3] == "true")   //статус
                            {
                                this.checkBox_wwwssl.Checked = false;
                            }
                            else
                            {
                                this.checkBox_wwwssl.Checked = true;
                            }
                            this.textBox_www_ssl_port.Text = (table_service[i][2]);
                        }
                    }

                    
                }
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["Log_tab"])
            {
                this.UpdateLogTable();
                


            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["firewall_tab"])
            {
                try
                {
                    List<List<string>> table_firewall = information.GetTableFirewall();
                    if (table_firewall.Count > 0)
                    { 
                        this.dataGridView_firewall.Rows.Clear();        //очистка таблицы
                        for (int i = 0; i < table_firewall.Count(); i++)
                        {
                            this.dataGridView_firewall.Rows.Add();
                            this.dataGridView_firewall.Rows[i].Cells[0].Value = table_firewall[i][1];       //action
                            this.dataGridView_firewall.Rows[i].Cells[1].Value = table_firewall[i][2];       //chain
                            this.dataGridView_firewall.Rows[i].Cells[2].Value = table_firewall[i][3];       //interface
                            this.dataGridView_firewall.Rows[i].Cells[3].Value = table_firewall[i][4];       //protocol
                            this.dataGridView_firewall.Rows[i].Cells[4].Value = table_firewall[i][5];       //port
                            this.dataGridView_firewall.Rows[i].Cells[5].Value = table_firewall[i][6];       //address list
                            this.dataGridView_firewall.Rows[i].Cells[6].Value = table_firewall[i][7];       //comment
                            if (table_firewall[i][8] == "true")     //изменение подсветки (deactive)
                            {
                                this.dataGridView_firewall.Rows[dataGridView_firewall.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                            }
                        }
                        
                        this.dataGridView_firewall.Rows[0].Selected = false;
                    }
                }
                catch { }

            }


        }

        
        private void UpdateLogTable()
        {

            List<List<string>> table_Log = information.GetLog();
            if (table_Log.Count() > 0)
            {
                this.dataGridView_log.Rows.Clear();     //очистка таблицы

                for (int i = 0; i < table_Log.Count(); i++)
                {
                    this.dataGridView_log.Rows.Add();
                    this.dataGridView_log.Rows[i].Cells[0].Value = table_Log[i][0];     //время
                    this.dataGridView_log.Rows[i].Cells[1].Value = table_Log[i][1];     //topics
                    if (table_Log[i][1].Contains("warning"))
                    {
                        //синий оттенок
                        this.dataGridView_log.Rows[dataGridView_log.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(128)))), ((int)(((byte)(181)))));
                    }
                    else if (table_Log[i][1].Contains("error"))
                    {
                        //красный оттенок
                        this.dataGridView_log.Rows[dataGridView_log.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                    this.dataGridView_log.Rows[i].Cells[2].Value = table_Log[i][2];     //message
                }
                this.dataGridView_log.Sort(this.dataGridView_log.Columns["Time_Log"], ListSortDirection.Descending);
                this.dataGridView_log.Rows[0].Selected = false;
                //this.dataGridView_log.Sort(this.dataGridView_log.Columns["Column1"]);
            }
        }

        private void button_Shutdown_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выключить оборудование?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)     //подтверждение на выключение
            {
                information.Shutdown();
            }
            /*
            if (res == DialogResult.Cancel)
            {
            }
            */
        }

        private void button_Reboot_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите перезагрузить оборудование?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)     //подтверждение на перезагрузку
            {
                information.Reboot();
            }
            /*
            if (res == DialogResult.Cancel)
            {
            }
            */
        }

        private void button_AddNewUser_Click(object sender, EventArgs e)
        {
            AddUserForm AddUser = new AddUserForm();
            AddUser.FillComboBox(information.GetTableUserGroupName());
            AddUser.ShowDialog();
         
            Thread.Sleep(500);
            information.SendRequestForGetUser(); //отправка запроса на обновление пользователей
            Thread.Sleep(500);
            this.UpdateUserTable(); //обновление списка пользователей
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> new_usergroup = new List<string>();
            AddUserGroupForm AddUserGroup = new AddUserGroupForm();
            AddUserGroup.ShowDialog();

            Thread.Sleep(200);
            information.SendRequestForGetUserGroup();    //отправка запроса на обновление групп
            Thread.Sleep(500);
            this.UpdateUserTable(); //обновление списка групп
        }

        //проверка наличия интернета
        private void timer_CheckInternet_Tick(object sender, EventArgs e)
        {
            check_internet();
        }

        //Обратный отсчет работы safemode
        //time - количество секунд для обратного отсчета
        private async void Countdown(double time)
        {
            var start = DateTime.UtcNow;
            var end = start.AddSeconds(time);
            var diff = TimeSpan.FromSeconds(time);

            this.label_timer_safemode.Visible = true;

            while ((DateTime.UtcNow - start) < diff)
            {
                this.label_timer_safemode.Text = (diff - (DateTime.UtcNow - start)).ToString(@"mm\:ss");
                await Task.Delay(1000);
            }
            this.label_timer_safemode.Visible = false;
        }

        
        //Переключение режима SafeMode
        private void button_SafeMode_Click(object sender, EventArgs e)
        {
            if (SafeMode == false)      //флаш состояния safemode
            {
                //Включение режима SafeMode
                information.SendStartSafeMode();
                this.button_SafeMode.BackColor = System.Drawing.SystemColors.ButtonShadow;
                
                SafeMode = true;        //изменить значение флага
                Countdown(900);  //начало отсчета в обратном порядке (15 минут)
            }
            else
            {
                //Отключение режима SafeMode
                information.SendEndSafeMode();
                this.button_SafeMode.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.label_timer_safemode.Visible = false;
            }
        }


        /*
        * 0 - telnet
        * 1 - ftp
        * 2 - www
        * 4 - ssh
        * 6 - www-ssl 
        * 7 - api 
        * 8 - winbox
        * 9 - api-ssl
        */
        //Обновление конфигурации сервисов оборудования
        private void button_save_Click(object sender, EventArgs e)
        {
            
            List<List<string>> send = new List<List<string>>();
            for (int i = 0; i < textBoxes.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add("/ip/service/set");
                if (i == 3)
                {
                    temp.Add("=.id=*" + (i + 1).ToString());
                }
                else if (i >= 4)
                {
                    temp.Add("=.id=*" + (i + 2).ToString());
                }
                else
                {
                    temp.Add("=.id=*" + (i).ToString());
                }
                temp.Add("=disabled=" + (!(checkBoxes[i].Checked)).ToString().ToLower());
                temp.Add("=port=" + textBoxes[i].Text);
                send.Add(temp);
            }
            information.SendUpdateService(send);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        //Окно вывода информации "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Открытие окна "о программе"
            AboutSoftwareForm ASF = new AboutSoftwareForm();
            ASF.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }

        //Сохранение записей лога в файл
        private void button_save_log_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;

            List<List<string>> log_message = information.GetLog();
            for (int i = 0; i < log_message.Count(); i++)
            {
                string temp = log_message[i][0] + " " + log_message[i][1] + " " + log_message[i][2] + "\n";
                if (i==0)
                {
                    System.IO.File.WriteAllText(filename, "Log файл" + DateTime.Now + "\n\n");
                }
                System.IO.File.AppendAllText(filename, temp);
            
            }
            DialogResult res = MessageBox.Show("Данные успешно записаны в файл", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //обновление таблицы лога по нажатию кнопки
        private void button_update_log_Click(object sender, EventArgs e)
        {
            information.SendRequestForGetLog();
            this.UpdateLogTable();
        }

        //Дополнительное уведомление о возможной потери связи с оборудованием после отключения сервиса (API)
        private void checkBox_api_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_api.Checked == false)
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите отключить сервис \"API\"?\\В случае отключения данного сервиса возможна потеря связи между приложением и оборудованием", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    this.checkBox_api.Checked = true;
                }
            }
        }

        //Дополнительное уведомление о возможной потери связи с оборудованием после отключения сервиса (API-SSL)
        private void checkBox_apissl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_api.Checked == false)
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите отключить сервис \"API-SSL\"?\\В случае отключения данного сервиса возможна потеря связи между приложением и оборудованием", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    this.checkBox_api.Checked = true;
                }
            }
        }


        //Загрузка конфигурации оборудования на компьютер
        private void button_save_config_Click(object sender, EventArgs e)
        {
            //Создать конфигурацию на роутере (через скрипт)
            information.SendSaveConfig();
            //Подключиться к роутеру по FTP и скачать на компьютер конфигурацию
        }

       
        //Дать доступ определенному IP (с указанием времени)
        private void button_allow_firewall_Click(object sender, EventArgs e)
        {
            string name_address = "api_" + DateTime.Now.ToShortTimeString();
            AllowFirewallForm AllowForm = new AllowFirewallForm("Разрешить доступ");
            AllowForm.ShowDialog();
            if (WorkFirewall.rez == true)
            {
                information.SendCreateAddressList(WorkFirewall.lifetime, WorkFirewall.host, name_address);
                information.SendCreateRuleFirewall(name_address, WorkFirewall.chain, "accept");
            }
        }

        //Удалить из блокировок
        private void button_del_firewall_Click(object sender, EventArgs e)
        {
            DelFromFirewallForm DelForm = new DelFromFirewallForm();
            DelForm.ShowDialog();
            if (WorkFirewall.rez == true)
            {
                //Отправка запроса на удаление
                information.SendDelFromFirewall();
            }
        }

        //Заблокировать IP
        private void button_block_firewall_Click(object sender, EventArgs e)
        {

            string name_address = "api_" + DateTime.Now.ToShortTimeString();
            AllowFirewallForm BlockForm = new AllowFirewallForm("Запретить доступ");
            BlockForm.ShowDialog();
            if (WorkFirewall.rez == true)
            {
                information.SendCreateAddressList(WorkFirewall.lifetime, WorkFirewall.host, name_address);
                information.SendCreateRuleFirewall(name_address, WorkFirewall.chain, "drop");
            }
        }
    }

    //Данные подключения
    static class connt
    {
        public static string name { get; set; }
        public static string host { get; set; }
        public static string port { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
    }


    static class WorkFirewall
    {
        public static string host { get ; set; }
        public static string chain { get; set; }
        public static int lifetime{ get; set; }
        public static bool rez { get; set; }
    }

    //проверка интернет-подключения
    public class InternetConnectionChecker
    {
        private readonly INetworkListManager _networkListManager;

        public InternetConnectionChecker()
        {
            _networkListManager = new NetworkListManager();
        }

        public bool IsConnected()
        {
            return _networkListManager.IsConnectedToInternet;
        }
    }
}
