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
    public partial class InputPasswordForFile : Form
    {
        private Form1 frm1;

        public InputPasswordForFile(Form1 main_form)
        {
            InitializeComponent();
            frm1 = main_form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.frm1.passwordfile = this.textBox1.Text;

        }
    }
}
