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

        void check_internet()
        {
            while (true)
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
