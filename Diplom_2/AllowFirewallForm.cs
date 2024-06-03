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
    public partial class AllowFirewallForm : Form
    {
        public AllowFirewallForm(string action)
        {
            InitializeComponent();
            this.comboBox_chain.SelectedIndex = 0;
            this.ActiveControl = this.textBox_host;     //фокус на текстовое поле
            WorkFirewall.rez = false;
            this.label4.Text = action;
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            //Проверка корректности IP адреса
            if (this.textBox_host.Text.Length > 1)
            {
                Func_Class func = new Func_Class();
                if (func.check_valid_host(this.textBox_host.Text))
                {
                    maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    if (String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrWhiteSpace(maskedTextBox1.Text))
                    {
                        WorkFirewall.lifetime = -100;
                    }
                    else
                    {
                        WorkFirewall.lifetime = 0;
                        try
                        {
                            WorkFirewall.lifetime = (Convert.ToInt32(this.maskedTextBox1.Text[0]) - 48) * 3600 * 10;

                        }
                        catch { }

                        try
                        {
                            WorkFirewall.lifetime = WorkFirewall.lifetime + ((Convert.ToInt32(this.maskedTextBox1.Text[1]) - 48) * 3600);
                        }
                        catch { }
                        try
                        {
                            WorkFirewall.lifetime = WorkFirewall.lifetime + ((Convert.ToInt32(this.maskedTextBox1.Text[2]) - 48) * 10);
                        }
                        catch { }
                        try
                        {
                            WorkFirewall.lifetime = WorkFirewall.lifetime + ((Convert.ToInt32(this.maskedTextBox1.Text[3]) - 48));
                        }
                        catch { }
                        
                    }

                    WorkFirewall.rez = true;
                    WorkFirewall.chain = this.comboBox_chain.Text;
                    WorkFirewall.host = this.textBox_host.Text;
                    this.Close();
                    return;
                }

                //перевод по часам
            }
            DialogResult res = MessageBox.Show("Проверьте корректность ввода хоста", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        //Закрытие формы по нажатию клавиши ESC
        private void AllowFirewallForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
