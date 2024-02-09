
namespace Diplom_2
{
    partial class NewConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewConnectionForm));
            this.ip_label = new System.Windows.Forms.Label();
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.port_textBox = new System.Windows.Forms.TextBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.test_button = new System.Windows.Forms.Button();
            this.connect_button = new System.Windows.Forms.Button();
            this.test_ip_pictureBox = new System.Windows.Forms.PictureBox();
            this.port_pictureBox = new System.Windows.Forms.PictureBox();
            this.login_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.test_ip_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.port_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Location = new System.Drawing.Point(339, 133);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(28, 20);
            this.ip_label.TabIndex = 0;
            this.ip_label.Text = "IP:";
            // 
            // ip_textBox
            // 
            this.ip_textBox.Location = new System.Drawing.Point(387, 130);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(158, 26);
            this.ip_textBox.TabIndex = 1;
            this.ip_textBox.Leave += new System.EventHandler(this.ip_textBox_Leave);
            // 
            // port_textBox
            // 
            this.port_textBox.Location = new System.Drawing.Point(684, 130);
            this.port_textBox.Name = "port_textBox";
            this.port_textBox.Size = new System.Drawing.Size(100, 26);
            this.port_textBox.TabIndex = 2;
            this.port_textBox.Leave += new System.EventHandler(this.port_textBox_Leave);
            // 
            // login_textBox
            // 
            this.login_textBox.Location = new System.Drawing.Point(484, 213);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(181, 26);
            this.login_textBox.TabIndex = 3;
            this.login_textBox.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(484, 319);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(181, 26);
            this.password_textBox.TabIndex = 4;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Location = new System.Drawing.Point(622, 133);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(56, 20);
            this.port_label.TabIndex = 5;
            this.port_label.Text = "PORT:";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(339, 216);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(63, 20);
            this.login_label.TabIndex = 6;
            this.login_label.Text = "LOGIN:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(339, 322);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(107, 20);
            this.password_label.TabIndex = 7;
            this.password_label.Text = "PASSWORD:";
            // 
            // test_button
            // 
            this.test_button.Location = new System.Drawing.Point(364, 451);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(108, 41);
            this.test_button.TabIndex = 8;
            this.test_button.Text = "TEST";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(590, 451);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(108, 41);
            this.connect_button.TabIndex = 9;
            this.connect_button.Text = "CONNECT";
            this.connect_button.UseVisualStyleBackColor = true;
            // 
            // test_ip_pictureBox
            // 
            this.test_ip_pictureBox.Location = new System.Drawing.Point(551, 130);
            this.test_ip_pictureBox.Name = "test_ip_pictureBox";
            this.test_ip_pictureBox.Size = new System.Drawing.Size(36, 26);
            this.test_ip_pictureBox.TabIndex = 10;
            this.test_ip_pictureBox.TabStop = false;
            // 
            // port_pictureBox
            // 
            this.port_pictureBox.Location = new System.Drawing.Point(790, 130);
            this.port_pictureBox.Name = "port_pictureBox";
            this.port_pictureBox.Size = new System.Drawing.Size(33, 26);
            this.port_pictureBox.TabIndex = 11;
            this.port_pictureBox.TabStop = false;
            // 
            // login_pictureBox
            // 
            this.login_pictureBox.Location = new System.Drawing.Point(671, 213);
            this.login_pictureBox.Name = "login_pictureBox";
            this.login_pictureBox.Size = new System.Drawing.Size(29, 26);
            this.login_pictureBox.TabIndex = 12;
            this.login_pictureBox.TabStop = false;
            // 
            // NewConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.login_pictureBox);
            this.Controls.Add(this.port_pictureBox);
            this.Controls.Add(this.test_ip_pictureBox);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.test_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.port_label);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.login_textBox);
            this.Controls.Add(this.port_textBox);
            this.Controls.Add(this.ip_textBox);
            this.Controls.Add(this.ip_label);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NewConnectionForm";
            this.Text = "NewConnectionForm";
            this.Load += new System.EventHandler(this.NewConnectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.test_ip_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.port_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.TextBox ip_textBox;
        private System.Windows.Forms.TextBox port_textBox;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button test_button;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.PictureBox test_ip_pictureBox;
        private System.Windows.Forms.PictureBox port_pictureBox;
        private System.Windows.Forms.PictureBox login_pictureBox;
    }
}