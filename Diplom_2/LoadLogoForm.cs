using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Diplom_2
{
    public partial class LoadLogoForm : Form
    {
        public LoadLogoForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void LoadLogoForm_Load(object sender, EventArgs e)
        {

            //поместить форму в центр экрана
            /*
             * var screen = Screen.FromControl(this);
            this.Top = screen.Bounds.Height / 2 - this.Height / 2;
            this.Left = screen.Bounds.Width / 2 - this.Width / 2;
            */


            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;     //убрать оформление рамки
            /*
             * Thread.Sleep(4000);
            this.Close();
            */
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i <= 110)
            {
                if (i < 100)
                {
                    this.pictureBox1.Width = 900 / 100 * i;
                    //this.progressBar1.Value = i;
                }
                System.Threading.Thread.Sleep(25);
                i++;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
