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
    public partial class DelFromFirewallForm : Form
    {
        public DelFromFirewallForm()
        {
            InitializeComponent();
            this.ActiveControl = this.textBox1;
            WorkFirewall.rez = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text != null)
            {
                Func_Class func = new Func_Class();
                if (func.check_valid_host(this.textBox1.Text))
                {
                    WorkFirewall.rez = true;
                    WorkFirewall.host = this.textBox1.Text;
                    this.Close();
                }
                else
                {
                    DialogResult res = MessageBox.Show("Проверьте корректность ввода хоста", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        //Закрытие формы по нажатию клавиши ESC
        private void DelFromFirewallForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
