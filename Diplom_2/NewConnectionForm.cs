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


namespace Diplom_2
{
    public partial class NewConnectionForm : Form
    {
        public NewConnectionForm(Form1 f1)
        {
            InitializeComponent();
            
        }
        Func_Class func = new Func_Class();

        private void test_button_Click(object sender, EventArgs e)
        {
            //проверка IP
            check_ip();

            //проверка порта

            //попытка подключения
        }

        //проверка ip для подключения
        bool check_ip()
        {
            //проверка на наличие введенных данных
            if (this.ip_textBox.Text.Length > 0)
            {
                //разбивка введенного ip адреса на октеты
                string ip = this.ip_textBox.Text;
                string[] octets = ip.Split(new char[] { '.' });


                if (octets.Length != 4)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if ((Int32.Parse(octets[i]) < 0) && (Int32.Parse(octets[i]) > 255))
                        {
                            return false;
                        }
                    }
                }


                //Объекта класса с инструментами работы
                
                /*
                if (func.ping_ip(this.ip_textBox.Text))
                {

                }
                else
                {

                }
                */

                return true; 
                
                //this.linkLabel_test.Text = octets.Length.ToString();
            }
            else
            {
                return false;
            }
        }

        
        //Проверка порта подключения
        bool check_port()
        {
            if (this.port_textBox.Text.Length > 0)
            {
                if ((Int32.Parse(this.port_textBox.Text) > 0) && (Int32.Parse(this.port_textBox.Text) < 65536))
                {
                    return true;
                }
                return false;
            }
            return false;
            
        }

        private void ip_textBox_Leave(object sender, EventArgs e)
        {
            this.test_ip_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
            //this.test_ip_pictureBox.Image = Properties.Resources.good_connect;
            
            //проверка ip (IP адрес или ДОМЕННОЕ ИМЯ?????)
            if (check_ip())
            {
                this.test_ip_pictureBox.Image = Properties.Resources.good_connect;

                if (func.ping_ip(this.ip_textBox.Text))
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.good_connect;
                    
                }
                else
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.good_connect;
                }
            }
            else
            {
                this.test_ip_pictureBox.Image = Properties.Resources.error_connect;
                

            }
            this.test_ip_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)

        }

        private void NewConnectionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void login_textBox_Leave(object sender, EventArgs e)
        {
            if (this.login_textBox.Text.Length == 0)
            {
                this.login_pictureBox.Image = Properties.Resources.error_connect;
            }
            this.login_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
        }

        private void port_textBox_Leave(object sender, EventArgs e)
        {
            if (check_port())
            {
                this.port_pictureBox.Image = Properties.Resources.good_connect;
            }
            else
            {
                this.port_pictureBox.Image = Properties.Resources.error_connect;
            }
            this.port_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
        }
    }
}
