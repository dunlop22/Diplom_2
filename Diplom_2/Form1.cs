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

        private void Form1_Resize(object sender, EventArgs e)
        {
            //изменение расположения индикатора подключения интернета
            var temp = this.Size.Height - 59;
            this.Internet_connect_status_image.Location = new Point(this.Internet_connect_status_image.Location.X, temp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
