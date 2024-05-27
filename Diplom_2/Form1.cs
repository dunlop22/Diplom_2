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

//using MndpTray.Protocol;    //поиск оборудования Mikrotik в окружении (Neighbours)

namespace Diplom_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //создание дополнительного потока для проверки подключения к интернету
            thread_check_internet = new Thread(check_internet);
            thread_check_internet.Start();

        }
        Thread thread_check_internet;       //поток для проверки наличия интернета
        Thread thread_read_api_answer;      //поток для чтения ответов api от оборудования

        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<TextBox> textBoxes = new List<TextBox>();

        //объект класса для проверки подключения интернета
        internal InternetConnectionChecker check = new InternetConnectionChecker();

        Info information = new Info();

        bool SafeMode = false;

        //флажок для проверки интернета
        bool work = true;
        //Connection conn = new Connection();

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
            //окно для ввода данных сессии

            //открыть окно для ввода логин-пароля


            /*
            //ПРОБА SSL
            MikrotikAPI mkssl = new MikrotikAPI("192.168.0.1", true, 8728);
            mkssl.Connect();
            string str;
            mkssl.Login("test", "test", out str);
            return;
            //this.label1.Text = str;
            /*
             * mkssl.Connect();

            foreach (string h in mkssl.Receive())
            {
                this.label1.Text = h;
                //mkssl.Receive()
            }
            */



            List<string> connt = new List<string>();
            /*
            NewConnectionForm NewConn = new NewConnectionForm(connt);
            NewConn.ShowDialog();
            if (connt.Count() <1)
            {
                Application.Exit();
            }
            else
            {
                if (connt.Count() == 5)
                {
                    information.SetConnCred(connt);

                    //TODO:
                    //Запуск таймера с обновлением всех данных (ресурсов)
                    information.FirstStart();
                    this.timer1.Enabled = true;     //Постоянное обновление ресурсов
                    
                    return;
                }
                else
                {
                    //TODO:
                    DialogResult res = MessageBox.Show("Произошла внутренняя ошибка!\nПроверьте правильность введенных данных в форме подключения", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            */
            //Принудительная установка значений для подключения
            //List<string> connt = new List<string>();
            connt.Add("Home");
            connt.Add("109.195.38.77");
            connt.Add("8728");
            connt.Add("test");
            connt.Add("test");
            
            information.SetConnCred(connt);
            
            
            //mkssl.LoginDeprecated()
            //TODO:
            //Запуск таймера с обновлением всех данных (ресурсов)
            information.FirstStart();

            //Отдельный поток для прослушивания ответов оборудования
            /*
            thread_read_api_answer = new Thread(information.ReadAnswer);
            thread_read_api_answer.Start();
            
            this.timer1.Enabled = true; //постоянное обновление ресурсов
            */

            return;



            //Обработка сессии (новая или из файла)
            file_work file = new file_work();
            if (file.check_file())
            {
                this.label1.Text = "good";
            }
            else
            {
                this.label1.Text = "bad";
            }


            //Шифровка файла
            string plainText = "sayonara";

            string passPhrase = "TestPassphrase";        //Может быть любой строкой
            string saltValue = "TestSaltValue";        // Может быть любой строкой
            string hashAlgorithm = "SHA256";             // может быть "MD5"
            int passwordIterations = 2;                //Может быть любым числом
            string initVector = "!1A3g2D4s9K556g7"; // Должно быть 16 байт
            int keySize = 256;                // Может быть 192 или 128

            string cipherText = Shifr.Encrypt
            (
                plainText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );

            this.label1.Text = cipherText;


            /*
             * conn.host = "109.195.38.77";
            conn.login = "test";
            conn.port = "8728";
            conn.password = "test";
            Info gh = new Info();
            */

        }

        private  void UpdateGraph()
        {
                //получение данных
                /*
                Func_Class gh = new Func_Class();
                gh.CPULoad(conn.host, 0, conn.login, conn.password, resource);
                */

                //information.FirstStart();
                Thread.Sleep(5);
                //information.SendResource();
                //information.ReadAnswer();
                List<string> resource = information.GetResource();
                if (resource[0] != null)
                {

                    this.chart1.Series.Clear();
                    this.chart2.Series.Clear();
                    this.chart3.Series.Clear();
                    //Добавление нового набора данных
                    this.chart1.Series.Add("CPU");
                    this.chart2.Series.Add("RAM");
                    this.chart3.Series.Add("Memory");
                    chart1.Series["CPU"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart2.Series["RAM"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType    .Pie;
                    chart3.Series["Memory"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                    //задаем первое значение с прозрачным цветом
                    chart1.Series["CPU"].Label = "#PERCENT{P}";
                    double[] yValuesCPU = { Convert.ToDouble(resource[0]), 100 - Convert.ToDouble(resource[0]) };
                    string[] xValuesCPU = { "Нагрузка", "Простой" };
                    //this.Invoke(new Action(() => this.chart1.Series["CPU"].Points.DataBindXY(xValues, yValues)));
                    this.chart1.Series["CPU"].Points.DataBindXY(xValuesCPU, yValuesCPU);


                    double[] yValuesRAM = { ((Convert.ToDouble(resource[2]) - (Convert.ToDouble(resource[1]))) / 1048576), (Convert.ToDouble(resource[1]) / 1048576) };
                    string[] xValuesRAM = { "Занято", "Свободно" };
                    this.chart2.Series["RAM"].Points.DataBindXY(xValuesRAM, yValuesRAM);
                    this.label_RAM.Text = Math.Round((Convert.ToDouble(resource[2]) - Convert.ToDouble(resource[1])) / 1048576, 2) + "MiB / " + Math.Round((Convert.ToDouble(resource[2]) / 1048576), 2) + " MiB";

                    double[] yValuesMem = { ((Convert.ToDouble(resource[4]) - Convert.ToDouble(resource[3])) / 1048576), (Convert.ToDouble(resource[3]) / 1048576) };
                    string[] xValuesMem = { "Занято", "Свободно" };
                    this.chart3.Series["Memory"].Points.DataBindXY(xValuesMem, yValuesMem);
                    this.label_Memory.Text = Math.Round((Convert.ToDouble(resource[4]) - Convert.ToDouble(resource[3])) / 1048576, 2) + "MiB / " + Math.Round((Convert.ToDouble(resource[4]) / 1048576), 2) + " MiB";

                    string uptime = "";
                    for (int i = 0; i < resource[5].Length; i++)
                    {
                        if (resource[5][i] == 'd')
                        {
                            uptime = uptime + "d ";
                        }
                        else if (resource[5][i] == 'h' || resource[5][i] == 'm')
                        {
                            uptime = uptime + ":";
                        }
                        else if (resource[5][i] == 's') { }
                        else
                        {
                            uptime = uptime + resource[5][i];
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

            //попытка дешифровки
            

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
                    this.dataGridView_User.Rows[i].Cells[0].Value = table_user[i][1];
                    this.dataGridView_User.Rows[i].Cells[1].Value = table_user[i][2];
                    this.dataGridView_User.Rows[i].Cells[2].Value = table_user[i][3];
                }
            }

            /*
             * information.SendUserGroup();
            information.ReadAnswer();
            */
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
            }
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["ARP_tab"])
            {
                /*
                information.SendARP();
                information.ReadAnswer();
                */
                this.dataGridView_ARP.Rows.Clear();     //очистка таблицы
                List<List<string>> table_arp = information.GetTableARP();
                //this.label1.Text = table_arp[0][0];
                //заполнение таблицы
                for (int i = 0; i < table_arp.Count(); i++)
                {
                    this.dataGridView_ARP.Rows.Add();
                    this.dataGridView_ARP.Rows[i].Cells[0].Value = table_arp[i][0];
                    this.dataGridView_ARP.Rows[i].Cells[1].Value = table_arp[i][1];
                    this.dataGridView_ARP.Rows[i].Cells[2].Value = table_arp[i][2];
                    this.dataGridView_ARP.Rows[i].Cells[3].Value = table_arp[i][3];

                }

            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["User_tab"])
            {
                UpdateUserTable();
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["Interface_tab"])
            {
                /*
                information.SendInterface();
                
                //information.ReadAnswer();
                */
                List<List<string>> table_interface = information.GetTableInterface();
                this.dataGridView_PhysicalInterface.Rows.Clear();    //очистка таблицы
                if (table_interface.Count() > 0)
                {
                    for (int i = 0; i < table_interface.Count(); i++)
                    {
                        this.dataGridView_PhysicalInterface.Rows.Add();
                        this.dataGridView_PhysicalInterface.Rows[i].Cells[0].Value = table_interface[i][0];     //name
                        this.dataGridView_PhysicalInterface.Rows[i].Cells[1].Value = table_interface[i][1];     //mac
                        this.dataGridView_PhysicalInterface.Rows[i].Cells[2].Value = table_interface[i][2];     //type
                        this.dataGridView_PhysicalInterface.Rows[i].Cells[3].Value = table_interface[i][3];     //download
                        this.dataGridView_PhysicalInterface.Rows[i].Cells[4].Value = table_interface[i][4];     //upload
                    }

                }
            }
            else if (tabControl2.SelectedTab == tabControl2.TabPages["Service_tab"])
            {
                /*
                 * information.SendService();
                information.ReadAnswer();
                */
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
        }

        private void button_Shutdown_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выключить оборудование?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show("You have clicked Ok Button");
                information.Shutdown();
            }
            if (res == DialogResult.Cancel)
            {
                //MessageBox.Show("You have clicked Cancel Button");
            }
         
        }

        private void button_Reboot_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите перезагрузить оборудование?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show("You have clicked Ok Button");
                information.Reboot();
            }
            if (res == DialogResult.Cancel)
            {
                //MessageBox.Show("You have clicked Cancel Button");
            }
        }

        private void button_AddNewUser_Click(object sender, EventArgs e)
        {
            //Открытие новой формы
            
            AddUserForm AddUser = new AddUserForm();
            AddUser.Show();
            AddUser.FillComboBox(information.GetTableUserGroupName());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> new_usergroup = new List<string>();
            AddUserGroupForm AddUserGroup = new AddUserGroupForm(new_usergroup);
            AddUserGroup.ShowDialog();

            //если хоть одно поле заполнено, то создать группу
            if (new_usergroup.Count() > 0)
            {
                information.SendCreateNewGroup(new_usergroup);
                UpdateUserTable();
            }


        }


        //проверка наличия интернета
        private void timer_CheckInternet_Tick(object sender, EventArgs e)
        {
            check_internet();
        }

        private async void Countdown()
        {
            var start = DateTime.UtcNow;
            var end = start.AddSeconds(900);
            var diff = TimeSpan.FromSeconds(900);

            while ((DateTime.UtcNow - start) < diff)
            {
                this.label_timer_safemode.Text = (diff - (DateTime.UtcNow - start)).ToString();
                await Task.Delay(1000);
            }

            //Close();
        }

        private void button_SafeMode_Click(object sender, EventArgs e)
        {
            if (SafeMode == false)
            {
                //Включение режима SafeMode
                information.SendStartSafeMode();
                this.button_SafeMode.BackColor = System.Drawing.SystemColors.ButtonShadow;
                
                SafeMode = true;        //изменить значение флага

                //Countdown();  //начало отсчета в обратном порядке (15 минут)
            }
            else
            {
                Info info = new Info();
                info.SetConnCred(information.GetCred());
                info.FirstStart();

                //Отключение режима SafeMode
                info.SendEndSafeMode();
                this.button_SafeMode.BackColor = System.Drawing.SystemColors.ButtonFace;
                SafeMode = false;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            /*
            Info info = new Info();
            info.SetConnCred(information.GetCred());
            info.FirstStart();

            List<List<string>> send = new List<List<string>>();
            for (int i = 0; i < textBoxes.Count(); i++)
            {
                List<string> temp = new List<string>();
                temp.Add("/ip/service/set");
                temp.Add("=id=*" + i.ToString());
                temp.Add("=disabled=" + (!(checkBoxes[i].Checked)).ToString().ToLower());
                temp.Add("=port=" + textBoxes[i].Text + ", true");
                send.Add(temp);
            }
            
            info.SendUpdateService(send);
            //information.ReadAnswer();
            */
        }
    }

    //проверка интернет-подключения
    public class InternetConnectionChecker
    {
        //bool connect = false;
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


    /*
    public class Connection
    {
        public string name = "";
        public string host = "";
        public string port = "";
        public string login = "";
        public string password = "";
    }
    */
}
