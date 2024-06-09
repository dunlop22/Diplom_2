using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;        //ping хоста
using MndpTray.Protocol;        //поиск "соседей" mikrotik
using System.Threading;     //использование и создание потоков
using System.Net;           //работа с портами (проверка открытости)
using System.Net.Security;        //поддержка ssl
using System.Net.Sockets;   //работа с портами (проверка открытости)

namespace Diplom_2
{
    public partial class NewConnectionForm : Form
    {
        //Connection conn;
        public NewConnectionForm()
        {
            InitializeComponent();
            this.port_textBox.Text = "8728";  //предустановка
            this.radioButton_api.Checked = true;
            thread = new Thread(CheckNeighbors);
            thread.Start();
            this.Visible = false;
            this.ActiveControl = this.host_textBox;     //фокус на текстовое поле

            //создание дополнительного потока для проверки подключения к интернету
            thread_check_internet = new Thread(check_internet);
            thread_check_internet.Start();
        }

        Thread thread;
        Func_Class func = new Func_Class();

        ToolTip t = new ToolTip();
        Thread thread_check_internet;       //поток для проверки наличия интернета
        //объект класса для проверки подключения интернета
        internal InternetConnectionChecker check = new InternetConnectionChecker();

        internal struct device
        {
            internal string ip;
            internal string mac;
            internal string identity;
            internal string boardname;
            internal string version_OS;
            internal string uptime;
        }

        static List<device> Devices = new List<device>();
        
        //проверка наличия интернета
        void check_internet()
        {
            if (check.IsConnected())    //подключение есть
            {
                this.pictureBox_status_internet.Image = Properties.Resources.green_circle;
            }
            else          //подключения нет
            {
                this.pictureBox_status_internet.Image = Properties.Resources.red_circle;
            }
            pictureBox_status_internet.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)

            Thread.Sleep(4);  //пауза потока
        }

        private void test_button_Click(object sender, EventArgs e)
        {
            //проверка форматирования всех введенных данных
            if (CheckConnCred())
            {
                //Создание пробного подключения
                TryConnect();
            }
            else
            {
                DialogResult res = MessageBox.Show("Проверьте корректность заполнения данных.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        ////проверка ip для подключения
        //bool check_ip()
        //{
        //    //проверка на наличие введенных данных
        //    if (this.ip_textBox.Text.Length > 0)
        //    {
        //        //разбивка введенного ip адреса на октеты
        //        string ip = this.ip_textBox.Text;
        //        string[] octets = ip.Split(new char[] { '.' });


        //        if (octets.Length != 4)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < 4; i++)
        //            {
        //                if ((Int32.Parse(octets[i]) < 0) && (Int32.Parse(octets[i]) > 255))
        //                {
        //                    return false;
        //                }
        //            }
        //        }

        //        return true; 
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ////Проверка порта подключения
        //bool check_port()
        //{
        //    if (this.port_textBox.Text.Length > 0)
        //    {
        //        //проверка на посторонние символы
        //        for (int i=0; i< this.port_textBox.Text.Length; i++)
        //        {
        //            if (char.IsDigit(this.port_textBox.Text[i]))
        //            {
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }

        //        if ((Int32.Parse(this.port_textBox.Text) > 0) && (Int32.Parse(this.port_textBox.Text) < 65536))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}

        //Проверка форматирования данных в поле "Порт"


        //проверка ip адреса
        private void host_textBox_Leave(object sender, EventArgs e)
        {
            if (this.host_textBox.Text.Length > 0)
            {

                //проверка ip (IP адрес или ДОМЕННОЕ ИМЯ?????)
                if (func.ip_or_domen(this.host_textBox.Text) != 0)
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.link_warning;

                    //создание thread (???)
                    if (func.ping_host(this.host_textBox.Text))
                    {
                        this.test_ip_pictureBox.Image = Properties.Resources.link_ok;
                    }
                    else
                    {
                        this.test_ip_pictureBox.Image = Properties.Resources.link_error;
                    }
                }
                else
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.error_connect;
                }
                this.test_ip_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
            }
        }

        private void CheckNeighbors()
        {
            //MndpTray.Protocol.MndpListener
            MndpListener.Instance.Start();
            MndpListener.Instance.OnDeviceDiscovered += Instance_OnDeviceDiscovered;
            MndpSender.Instance.Start(MndpHostInfo.Instance);

            /*
             * Console.WriteLine("--- Start ---");
            Console.WriteLine("Press any key to stop");
            */

            //while (!Console.KeyAvailable)
            Thread.Sleep(5000);

            //Console.WriteLine("--- Stop ---");

            MndpListener.Instance.Stop();
            MndpSender.Instance.Stop();
            
            //заполнение таблицы
            TebleNeighbors();
        }


        private void TebleNeighbors()
        {
            this.dataGridView_Neighbors.Rows.Clear();       //очистка таблицы
            for (int i = 0; i < Devices.Count(); i++)
            {
                this.dataGridView_Neighbors.Rows.Add();
                this.dataGridView_Neighbors.Rows[i].Cells[0].Value = (Devices[i].ip).ToString();
                //Разбитие на 2 символа
                for (int j = 0; j < 6; j++)
                {
                    this.dataGridView_Neighbors.Rows[i].Cells[1].Value = this.dataGridView_Neighbors.Rows[i].Cells[1].Value + (Devices[i].mac[j * 2]).ToString();
                    this.dataGridView_Neighbors.Rows[i].Cells[1].Value = this.dataGridView_Neighbors.Rows[i].Cells[1].Value + (Devices[i].mac[j * 2 + 1]).ToString();
                    if (j != 5)
                    {
                        this.dataGridView_Neighbors.Rows[i].Cells[1].Value = this.dataGridView_Neighbors.Rows[i].Cells[1].Value + ":";
                    }

                }

                this.dataGridView_Neighbors.Rows[i].Cells[2].Value = (Devices[i].identity).ToString();
                this.dataGridView_Neighbors.Rows[i].Cells[3].Value = (Devices[i].boardname).ToString();
                this.dataGridView_Neighbors.Rows[i].Cells[4].Value = (Devices[i].version_OS).ToString();
            }
        }

        private static void Instance_OnDeviceDiscovered(object sender, MndpListener.DeviceDiscoveredEventArgs e)
        {
            string text = e.Message.ToString();
            string[] words = text.Split(new char[] { ',' });
            Console.WriteLine(words[9]);        //Platform:MikroTik

            if (words.Length > 10)
            {
                if (words[9].Contains("Platform:MikroTik"))
                {
                    Console.WriteLine(words[1]);

                    //проверка на существование в листе по IP адресу
                    for (int i = 0; i < Devices.Count(); i++)
                    {
                        if (words[1].Contains(Devices[i].ip))
                        {
                            Console.WriteLine("уже есть в списке");
                            return;
                        }
                    }

                    device temp = new device();
                    temp.ip = (words[1].Split(new char[] { ':' }))[1];
                    temp.mac = (words[6].Split(new char[] { ':' }))[1];
                    temp.identity = (words[7].Split(new char[] { ':' }))[1];
                    temp.version_OS = (words[8].Split(new char[] { ':' }))[1];
                    temp.uptime = (words[10].Split(new char[] { ':' }))[1];
                    temp.boardname = (words[12].Split(new char[] { ':' }))[1];
                    Devices.Add(temp);
                }
            }
        }

        private void NewConnectionForm_Load(object sender, EventArgs e)
        {

            
            t.SetToolTip(this.host_textBox, "Поле для ввода IP адреса оборудования");
            t.SetToolTip(this.ip_label, "IP адрес для подключения к оборудованию");
            

            //запуск поиска соседей
            //CheckNeighbors();

        }





        private void login_textBox_Leave(object sender, EventArgs e)
        {
            /*
            if (this.login_textBox.Text.Length == 0)
            {
                this.login_pictureBox.Image = Properties.Resources.error_connect;
            }

            this.login_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
            */
        }


        private void port_text()
        {
            if (func.CheckPortFormat(this.port_textBox.Text))
            {
                this.port_pictureBox.Image = Properties.Resources.good_connect;
            }
            else
            {
                this.port_pictureBox.Image = Properties.Resources.error_connect;
            }
            this.port_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
        }


        private void port_textBox_TextChanged(object sender, EventArgs e)
        {
            port_text();
        }

        //быстрая проверка введенных данных
        private void ip_textBox_TextChanged(object sender, EventArgs e)
        {
            this.test_ip_pictureBox.Image = null;
            this.test_ip_pictureBox.Invalidate();

            if (this.host_textBox.Text.Length > 0)
            {
                if (!(func.check_valid_host(this.host_textBox.Text)))
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.error_connect;
                    this.test_ip_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
                    return;
                }
            }
        }


        //проверка открытости порта
        private void check_port_open()
        {
            try
            {
                using (var tcpClient = new TcpClient())
                {
                    tcpClient.Connect(this.host_textBox.Text, Convert.ToInt32(this.port_textBox.Text));
                    this.port_pictureBox.Image = Properties.Resources.link_ok;
                }
            }
            catch (SocketException)
            {
                this.port_pictureBox.Image = Properties.Resources.link_error;
            }
            
            if (this.port_pictureBox.Image == Properties.Resources.link_error)
            {
                t.SetToolTip(this.port_pictureBox, "Проблема с доступом по порту");
            }
            else if (this.port_pictureBox.Image == Properties.Resources.link_ok)
            {
                t.SetToolTip(this.port_pictureBox, "Успешная проверка доступа по порту");
            }
        }
        
        //Моментальная проверка корректности введенного значения порта (после покидания поля "Порт")
        private void port_textBox_Leave(object sender, EventArgs e)
        {
            if (func.CheckPortFormat(this.port_textBox.Text))
            {
                if (this.host_textBox.Text != null)
                {
                    Thread myThread = new Thread(check_port_open);
                    myThread.Start();
                }
            }
        }

        //Грубая проверка заполненности поля "Хост / IP"
        private bool CheckHost()
        {
            if (this.host_textBox.Text != null)
            {
                return true;
            }
            return false;
        }

        //Грубая проверка заполненности поля "Порт"
        private bool CheckPort()
        {
            if (this.port_textBox.Text != String.Empty)
            {
                if (func.CheckPortFormat(this.port_textBox.Text))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //Грубая проверка заполненности поля "Наименование"
        private bool CheckName()
        {
            if (this.name_textBox.Text != String.Empty)
            {
                return true;
            }
            return false;
        }

        //Грубая проверка заполненности поля "Логин"
        private bool CheckLogin()
        {
            if (this.login_textBox.Text != String.Empty)
            {
                return true;
            }
            return false;
        }

        //Грубая проверка заполненности поля "Пароль"
        private bool CheckPassword()
        {
            if (this.password_textBox.Text != String.Empty)
            {
                return true;
            }
            return false;
        }

        //Проверка корректности заполненности всех полей
        private bool CheckConnCred()
        {
            if (CheckHost())
            {
                if (CheckPort())
                {
                    if (CheckLogin())
                    {
                        if (CheckPassword())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Создание пробного подключения к оборудованию
        private bool TryConnect()
        {
            try
            {
                MK test_mikrotik = new MK(this.host_textBox.Text, Convert.ToInt32(this.port_textBox.Text));
                if (test_mikrotik.Login(this.login_textBox.Text, this.password_textBox.Text))
                {
                    DialogResult res = MessageBox.Show("Пробное подключение завершилось успешно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Пробное подключение завершилось неудачно.\nПроверьте введенные данные", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                DialogResult res = MessageBox.Show("Пробное подключение завершилось неудачно.\nПроверьте введенные данные", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        
        
        //Подключение к хосту
        private void connect_button_Click(object sender, EventArgs e)
        {
            if (CheckConnCred())
            {
                if (TryConnect())
                {

                    connt.name = this.name_textBox.Text;
                    connt.host = this.host_textBox.Text;
                    connt.port = this.port_textBox.Text;
                    connt.login = this.login_textBox.Text;
                    connt.password = this.password_textBox.Text;

                    //закрытие формы
                    thread.Abort();
                    this.Close();
                    return;
                }
            }
            DialogResult res = MessageBox.Show("Проверьте корректность заполнения данных.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        private void dataGridView_Neighbors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.host_textBox.Text = (this.dataGridView_Neighbors.Rows[e.RowIndex].Cells[0].Value).ToString();
            /*
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                this.host_textBox.Text = (this.dataGridView_Neighbors.Rows[e.RowIndex].Cells[0].Value).ToString();
                
                this.label_ip_for_mac.Visible = false;
                if (e.ColumnIndex == 1)
                {
                    this.label_ip_for_mac.Visible = true;
                    this.label_ip_for_mac.Text = "IP: " + this.dataGridView_Neighbors.Rows[e.RowIndex].Cells[0].Value;
                }
                
            }
            */
        }

        private void radioButton_api_ssl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_api_ssl.Checked == true)
            {
                this.radioButton_api.Checked = false;
                this.port_textBox.Text = "8729";
            }

        }

        private void radioButton_api_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton_api.Checked == true)
            {
                this.radioButton_api_ssl.Checked = false;
                this.port_textBox.Text = "8728";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i < 100)
            {
                System.Threading.Thread.Sleep(25);
                i++;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Visible = true;
        }

        private void button_update_neighbors_Click(object sender, EventArgs e)
        {
            thread = new Thread(CheckNeighbors);
            thread.Start();
        }
    }

}
