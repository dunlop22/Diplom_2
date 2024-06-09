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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            this.ActiveControl = this.textBox_Login;     //фокус на текстовое поле
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            //Проверка входных значений
            //Сравнение паролей
            if (textBox_Pass1.Text == textBox_Pass2.Text)
            {
                if (this.textBox_Login.Text != null)
                {
                    if (this.comboBox_Group.SelectedIndex >= 0)
                    {
                        Info temp = new Info();
                        temp.FirstStart();
                        //отправка запроса на создание пользователя
                        List<string> inform = new List<string>();
                        inform.Add(this.textBox_Login.Text);
                        inform.Add(this.textBox_Pass1.Text);
                        inform.Add(this.comboBox_Group.Text);
                        temp.SendCreateNewUser(inform);
                        this.Close();
                    }
                }

            }
            else
            {
                textBox_Pass1.Text = "";
                textBox_Pass2.Text = "";
                MessageBox.Show("Введенные пароли не совпадают.\nВведите пароль заново.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void FillComboBox(List<string> info)
        {
            for (int i = 0; i < info.Count(); i++)
            {
                this.comboBox_Group.Items.Add(info[i]);
            }
        }


        private void AddUserForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
