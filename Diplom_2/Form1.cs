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

namespace Diplom_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Создание потока для отслеживания наличия интернета
            
            Thread thread = new Thread(check_internet);
            thread.Start();
            
        }
        bool work = true;

        void check_internet()
        {
            while (work)
            {
                InternetConnectionChecker check = new InternetConnectionChecker();
                if (check.IsConnected())    //подключение есть
                {
                    this.Internet_connect_status_image.Image = Properties.Resources.green_circle;
                }
                else          //подключения нет
                {
                    this.Internet_connect_status_image.Image = Properties.Resources.red_circle;
                }
                Internet_connect_status_image.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)

                Thread.Sleep(400);  //пауза потока
            }
            
        }

        //Открытие формы для создания нового подключения
        private void new_connection_Main_Menu_Click(object sender, EventArgs e)
        {
            NewConnectionForm newForm = new NewConnectionForm(this);
            newForm.Show();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1); //принудительное удаление всех потоков (thread)

        }
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
