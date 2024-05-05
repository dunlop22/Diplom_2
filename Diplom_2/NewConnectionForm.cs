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
            this.port_textBox.Text = "22";
            func.check_port(this.port_textBox.Text);
        }
        Func_Class func = new Func_Class();

        
        private void test_button_Click(object sender, EventArgs e)
        {
            
            if (func.check_port_open("109.195.38.77", 8728))
            {
                this.linkLabel1.Text = "Порт открыт!";
            }
            else
            {
                this.linkLabel1.Text = "Порт закрыт!";
            }
            return;

            //попытка подключения
            if (func.test_connect("109.195.38.77", 22, "Admin_Adm_Adm", "GfhjkzYtn1"))
            {
                this.linkLabel1.Text = "Подключение успешно!";
            }
            else
            {
                this.linkLabel1.Text = "Подключение НЕуспешно!";
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




        //проверка ip адреса
        private void ip_textBox_Leave(object sender, EventArgs e)
        {

            if (this.ip_textBox.Text.Length > 0)
            {

                //проверка ip (IP адрес или ДОМЕННОЕ ИМЯ?????)
                if (func.ip_or_domen(this.ip_textBox.Text) != 0)
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.link_warning;

                    //создание thread (???)
                    if (func.ping_host(this.ip_textBox.Text))
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

        private void NewConnectionForm_Load(object sender, EventArgs e)
        {
            
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
            if (func.check_port(this.port_textBox.Text))
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

            if (this.ip_textBox.Text.Length > 0)
            {
                if (!(func.check_valid_host(this.ip_textBox.Text)))
                {
                    this.test_ip_pictureBox.Image = Properties.Resources.error_connect;
                    this.test_ip_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;       //ReSize изображения под размер элемента (PictureBox)
                    return;
                }
            }
        }

        private void port_textBox_Leave(object sender, EventArgs e)
        {
            if (func.check_port(this.port_textBox.Text))
            {

            }
        }
    }
}
