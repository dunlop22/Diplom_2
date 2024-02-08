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
    public partial class NewConnectionForm : Form
    {
        public NewConnectionForm()
        {
            InitializeComponent();
        }

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
            return false;
        }

        //Проверка порта подключения
        bool check_port()
        {
            return false;
        }
    }
}
