using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_2
{
    public partial class AddUserGroupForm : Form
    {
        public AddUserGroupForm()
        {
            InitializeComponent();
            //info = information;
        }

        CheckBox[] mass = new CheckBox[18];
               
        private void button_createGroup_Click(object sender, EventArgs e)
        {

            //проверка параметров
            if (this.textBox_Name.Text != "")
            {
                string inform_politics = "";
                string name = textBox_Name.Text;
                for (int i = 0; i < 18; i++)
                {
                    if (mass[i].Checked == true)
                    {
                        if (i != 0)
                        {
                            inform_politics = inform_politics + ",";
                        }
                        inform_politics = inform_politics + mass[i].Text;
                        //inform_politics.Add(mass[i].Text);
                    }
                }
                Info temp = new Info();
                temp.FirstStart();

                temp.SendCreateNewGroup(name, inform_politics);
                this.Close();

            }
        }

        private void AddUserGroupForm_Load(object sender, EventArgs e)
        {

            //Определение подсказок
            ToolTip t = new ToolTip();
            t.SetToolTip(checkBox_local, "Удаленное подключение к оборудованию по средствам консоли");
            t.SetToolTip(checkBox_ssh, "Удаленное подключение к оборудованию по средствам SSH");
            t.SetToolTip(checkBox_reboot, "Право на перезагрузку оборудования");
            t.SetToolTip(checkBox_write, "Право на запись конфигурации оборудования");
            t.SetToolTip(checkBox_test, "Тестирование сети");
            t.SetToolTip(checkBox_password, "Право изменение паролей");
            t.SetToolTip(checkBox_sniff, "Право анализатор траффика");
            t.SetToolTip(checkBox_api, "Подключение к оборудованию через API");
            t.SetToolTip(checkBox_dude, "Управление сетевым монитором (dude)");
            t.SetToolTip(checkBox_telnet, "Доступ через telnet");
            t.SetToolTip(checkBox_ftp, "Доступ к FTP оборудования");
            t.SetToolTip(checkBox_read, "Чтение конфигурации оборудования");
            t.SetToolTip(checkBox_policy, "Управление политиками");
            t.SetToolTip(checkBox_winbox, "Подключение через WinBox");
            t.SetToolTip(checkBox_web, "Подключение через WEB");
            t.SetToolTip(checkBox_sensitive, "Просмотр чувствительной информации (пароли и т.д.)");
            t.SetToolTip(checkBox_romon, "Подключение через RoMON");
            t.SetToolTip(checkBox_tikapp, "Подключение через приложение Tik-app");


            //создание массива объектов формы (policy)
            
            mass[0] = checkBox_local;
            mass[1] = checkBox_telnet;
            mass[2] = checkBox_ssh;
            mass[3] = checkBox_ftp;
            mass[4] = checkBox_reboot;
            mass[5] = checkBox_read;
            mass[6] = checkBox_write;
            mass[7] = checkBox_policy;
            mass[8] = checkBox_test;
            mass[9] = checkBox_winbox;
            mass[10] = checkBox_password;
            mass[11] = checkBox_web;
            mass[12] = checkBox_sniff;
            mass[13] = checkBox_sensitive;
            mass[14] = checkBox_api;
            mass[15] = checkBox_romon;
            mass[16] = checkBox_dude;
            mass[17] = checkBox_tikapp;
        }

        private void AddUserGroupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
