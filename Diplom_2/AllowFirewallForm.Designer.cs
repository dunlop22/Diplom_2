
namespace Diplom_2
{
    partial class AllowFirewallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_chain = new System.Windows.Forms.ComboBox();
            this.label_host = new System.Windows.Forms.Label();
            this.label_chain = new System.Windows.Forms.Label();
            this.button_Accept = new System.Windows.Forms.Button();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_chain
            // 
            this.comboBox_chain.FormattingEnabled = true;
            this.comboBox_chain.Items.AddRange(new object[] {
            "forward",
            "input",
            "output"});
            this.comboBox_chain.Location = new System.Drawing.Point(161, 128);
            this.comboBox_chain.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_chain.Name = "comboBox_chain";
            this.comboBox_chain.Size = new System.Drawing.Size(160, 24);
            this.comboBox_chain.TabIndex = 0;
            // 
            // label_host
            // 
            this.label_host.AutoSize = true;
            this.label_host.Location = new System.Drawing.Point(101, 78);
            this.label_host.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_host.Name = "label_host";
            this.label_host.Size = new System.Drawing.Size(41, 17);
            this.label_host.TabIndex = 1;
            this.label_host.Text = "Host:";
            // 
            // label_chain
            // 
            this.label_chain.AutoSize = true;
            this.label_chain.Location = new System.Drawing.Point(101, 128);
            this.label_chain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_chain.Name = "label_chain";
            this.label_chain.Size = new System.Drawing.Size(52, 17);
            this.label_chain.TabIndex = 2;
            this.label_chain.Text = "Chain: ";
            // 
            // button_Accept
            // 
            this.button_Accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Accept.Location = new System.Drawing.Point(161, 239);
            this.button_Accept.Margin = new System.Windows.Forms.Padding(4);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(100, 28);
            this.button_Accept.TabIndex = 3;
            this.button_Accept.Text = "Применить";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // textBox_host
            // 
            this.textBox_host.Location = new System.Drawing.Point(161, 78);
            this.textBox_host.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(160, 23);
            this.textBox_host.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите IP адрес и цепочку прохождения траффика";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(195, 187);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBox1.TabIndex = 6;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Life Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(168, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Empty = infinity";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(52, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllowFirewallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 297);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_host);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.label_chain);
            this.Controls.Add(this.label_host);
            this.Controls.Add(this.comboBox_chain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllowFirewallForm";
            this.Text = "AllowFirewallForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowFirewallForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_chain;
        private System.Windows.Forms.Label label_host;
        private System.Windows.Forms.Label label_chain;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.TextBox textBox_host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}