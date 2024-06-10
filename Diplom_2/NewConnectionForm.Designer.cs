
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewConnectionForm));
            this.ip_label = new System.Windows.Forms.Label();
            this.host_textBox = new System.Windows.Forms.TextBox();
            this.port_textBox = new System.Windows.Forms.TextBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.test_button = new System.Windows.Forms.Button();
            this.connect_button = new System.Windows.Forms.Button();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Neighbors = new System.Windows.Forms.DataGridView();
            this.Neighbours_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neighbours_MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neighbours_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neighbours_RB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neighbours_ROS_V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_neighbors = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_ip_for_mac = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_api_ssl = new System.Windows.Forms.RadioButton();
            this.radioButton_api = new System.Windows.Forms.RadioButton();
            this.login_pictureBox = new System.Windows.Forms.PictureBox();
            this.port_pictureBox = new System.Windows.Forms.PictureBox();
            this.test_ip_pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_update_neighbors = new System.Windows.Forms.Button();
            this.pictureBox_status_internet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Neighbors)).BeginInit();
            this.groupBox_neighbors.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.port_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_ip_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_internet)).BeginInit();
            this.SuspendLayout();
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Location = new System.Drawing.Point(40, 51);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(80, 17);
            this.ip_label.TabIndex = 0;
            this.ip_label.Text = "Connect to:";
            // 
            // host_textBox
            // 
            this.host_textBox.Location = new System.Drawing.Point(137, 48);
            this.host_textBox.Name = "host_textBox";
            this.host_textBox.Size = new System.Drawing.Size(158, 23);
            this.host_textBox.TabIndex = 1;
            this.host_textBox.TextChanged += new System.EventHandler(this.ip_textBox_TextChanged);
            this.host_textBox.Leave += new System.EventHandler(this.host_textBox_Leave);
            // 
            // port_textBox
            // 
            this.port_textBox.Location = new System.Drawing.Point(413, 48);
            this.port_textBox.Name = "port_textBox";
            this.port_textBox.Size = new System.Drawing.Size(78, 23);
            this.port_textBox.TabIndex = 2;
            this.port_textBox.TextChanged += new System.EventHandler(this.port_textBox_TextChanged);
            this.port_textBox.Leave += new System.EventHandler(this.port_textBox_Leave);
            // 
            // login_textBox
            // 
            this.login_textBox.Location = new System.Drawing.Point(137, 94);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(158, 23);
            this.login_textBox.TabIndex = 3;
            this.login_textBox.Leave += new System.EventHandler(this.login_textBox_Leave);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(137, 135);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(158, 23);
            this.password_textBox.TabIndex = 4;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Location = new System.Drawing.Point(365, 51);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(38, 17);
            this.port_label.TabIndex = 5;
            this.port_label.Text = "Port:";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(43, 97);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(47, 17);
            this.login_label.TabIndex = 6;
            this.login_label.Text = "Login:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(43, 138);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(73, 17);
            this.password_label.TabIndex = 7;
            this.password_label.Text = "Password:";
            // 
            // test_button
            // 
            this.test_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.test_button.Location = new System.Drawing.Point(240, 250);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(120, 41);
            this.test_button.TabIndex = 8;
            this.test_button.Text = "Тест";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // connect_button
            // 
            this.connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.connect_button.Location = new System.Drawing.Point(438, 250);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(120, 41);
            this.connect_button.TabIndex = 9;
            this.connect_button.Text = "Подключение";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // name_textBox
            // 
            this.name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.name_textBox.Location = new System.Drawing.Point(319, 28);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(200, 23);
            this.name_textBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(222, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name:";
            // 
            // dataGridView_Neighbors
            // 
            this.dataGridView_Neighbors.AllowUserToAddRows = false;
            this.dataGridView_Neighbors.AllowUserToDeleteRows = false;
            this.dataGridView_Neighbors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Neighbors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Neighbours_IP,
            this.Neighbours_MAC,
            this.Neighbours_Name,
            this.Neighbours_RB,
            this.Neighbours_ROS_V});
            this.dataGridView_Neighbors.Location = new System.Drawing.Point(8, 65);
            this.dataGridView_Neighbors.Name = "dataGridView_Neighbors";
            this.dataGridView_Neighbors.ReadOnly = true;
            this.dataGridView_Neighbors.RowHeadersVisible = false;
            this.dataGridView_Neighbors.Size = new System.Drawing.Size(784, 214);
            this.dataGridView_Neighbors.TabIndex = 16;
            this.dataGridView_Neighbors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Neighbors_CellDoubleClick);
            // 
            // Neighbours_IP
            // 
            this.Neighbours_IP.HeaderText = "IP";
            this.Neighbours_IP.Name = "Neighbours_IP";
            this.Neighbours_IP.ReadOnly = true;
            this.Neighbours_IP.Width = 110;
            // 
            // Neighbours_MAC
            // 
            this.Neighbours_MAC.HeaderText = "MAC";
            this.Neighbours_MAC.Name = "Neighbours_MAC";
            this.Neighbours_MAC.ReadOnly = true;
            this.Neighbours_MAC.Width = 150;
            // 
            // Neighbours_Name
            // 
            this.Neighbours_Name.HeaderText = "Name";
            this.Neighbours_Name.Name = "Neighbours_Name";
            this.Neighbours_Name.ReadOnly = true;
            this.Neighbours_Name.Width = 170;
            // 
            // Neighbours_RB
            // 
            this.Neighbours_RB.HeaderText = "RouterBoard";
            this.Neighbours_RB.Name = "Neighbours_RB";
            this.Neighbours_RB.ReadOnly = true;
            this.Neighbours_RB.Width = 200;
            // 
            // Neighbours_ROS_V
            // 
            this.Neighbours_ROS_V.HeaderText = "RouterOS";
            this.Neighbours_ROS_V.Name = "Neighbours_ROS_V";
            this.Neighbours_ROS_V.ReadOnly = true;
            this.Neighbours_ROS_V.Width = 150;
            // 
            // groupBox_neighbors
            // 
            this.groupBox_neighbors.Controls.Add(this.dataGridView_Neighbors);
            this.groupBox_neighbors.Controls.Add(this.button_update_neighbors);
            this.groupBox_neighbors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox_neighbors.Location = new System.Drawing.Point(15, 297);
            this.groupBox_neighbors.Name = "groupBox_neighbors";
            this.groupBox_neighbors.Size = new System.Drawing.Size(813, 287);
            this.groupBox_neighbors.TabIndex = 17;
            this.groupBox_neighbors.TabStop = false;
            this.groupBox_neighbors.Text = "Neighbors";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 26);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 21);
            this.toolStripStatusLabel1.Text = "Интернет:";
            // 
            // label_ip_for_mac
            // 
            this.label_ip_for_mac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_ip_for_mac.Location = new System.Drawing.Point(134, 77);
            this.label_ip_for_mac.Name = "label_ip_for_mac";
            this.label_ip_for_mac.Size = new System.Drawing.Size(172, 21);
            this.label_ip_for_mac.TabIndex = 19;
            this.label_ip_for_mac.Text = "IP:";
            this.label_ip_for_mac.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_api_ssl);
            this.groupBox1.Controls.Add(this.radioButton_api);
            this.groupBox1.Controls.Add(this.password_textBox);
            this.groupBox1.Controls.Add(this.label_ip_for_mac);
            this.groupBox1.Controls.Add(this.ip_label);
            this.groupBox1.Controls.Add(this.host_textBox);
            this.groupBox1.Controls.Add(this.port_textBox);
            this.groupBox1.Controls.Add(this.login_textBox);
            this.groupBox1.Controls.Add(this.port_label);
            this.groupBox1.Controls.Add(this.login_pictureBox);
            this.groupBox1.Controls.Add(this.login_label);
            this.groupBox1.Controls.Add(this.port_pictureBox);
            this.groupBox1.Controls.Add(this.password_label);
            this.groupBox1.Controls.Add(this.test_ip_pictureBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(114, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 174);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры подключения";
            // 
            // radioButton_api_ssl
            // 
            this.radioButton_api_ssl.AutoSize = true;
            this.radioButton_api_ssl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton_api_ssl.Location = new System.Drawing.Point(469, 18);
            this.radioButton_api_ssl.Name = "radioButton_api_ssl";
            this.radioButton_api_ssl.Size = new System.Drawing.Size(78, 21);
            this.radioButton_api_ssl.TabIndex = 21;
            this.radioButton_api_ssl.TabStop = true;
            this.radioButton_api_ssl.Text = "API-SSL";
            this.radioButton_api_ssl.UseVisualStyleBackColor = true;
            this.radioButton_api_ssl.Visible = false;
            this.radioButton_api_ssl.CheckedChanged += new System.EventHandler(this.radioButton_api_ssl_CheckedChanged);
            // 
            // radioButton_api
            // 
            this.radioButton_api.AutoSize = true;
            this.radioButton_api.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton_api.Location = new System.Drawing.Point(397, 18);
            this.radioButton_api.Name = "radioButton_api";
            this.radioButton_api.Size = new System.Drawing.Size(47, 21);
            this.radioButton_api.TabIndex = 20;
            this.radioButton_api.TabStop = true;
            this.radioButton_api.Text = "API";
            this.radioButton_api.UseVisualStyleBackColor = true;
            this.radioButton_api.Visible = false;
            this.radioButton_api.CheckedChanged += new System.EventHandler(this.radioButton_api_CheckedChanged);
            // 
            // login_pictureBox
            // 
            this.login_pictureBox.Location = new System.Drawing.Point(301, 94);
            this.login_pictureBox.Name = "login_pictureBox";
            this.login_pictureBox.Size = new System.Drawing.Size(36, 26);
            this.login_pictureBox.TabIndex = 12;
            this.login_pictureBox.TabStop = false;
            // 
            // port_pictureBox
            // 
            this.port_pictureBox.Location = new System.Drawing.Point(497, 48);
            this.port_pictureBox.Name = "port_pictureBox";
            this.port_pictureBox.Size = new System.Drawing.Size(33, 26);
            this.port_pictureBox.TabIndex = 11;
            this.port_pictureBox.TabStop = false;
            // 
            // test_ip_pictureBox
            // 
            this.test_ip_pictureBox.Location = new System.Drawing.Point(301, 48);
            this.test_ip_pictureBox.Name = "test_ip_pictureBox";
            this.test_ip_pictureBox.Size = new System.Drawing.Size(36, 26);
            this.test_ip_pictureBox.TabIndex = 10;
            this.test_ip_pictureBox.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button_update_neighbors
            // 
            this.button_update_neighbors.Location = new System.Drawing.Point(708, 22);
            this.button_update_neighbors.Name = "button_update_neighbors";
            this.button_update_neighbors.Size = new System.Drawing.Size(84, 37);
            this.button_update_neighbors.TabIndex = 21;
            this.button_update_neighbors.Text = "Update";
            this.button_update_neighbors.UseVisualStyleBackColor = true;
            this.button_update_neighbors.Click += new System.EventHandler(this.button_update_neighbors_Click);
            // 
            // pictureBox_status_internet
            // 
            this.pictureBox_status_internet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_status_internet.Location = new System.Drawing.Point(83, 595);
            this.pictureBox_status_internet.Name = "pictureBox_status_internet";
            this.pictureBox_status_internet.Size = new System.Drawing.Size(16, 16);
            this.pictureBox_status_internet.TabIndex = 22;
            this.pictureBox_status_internet.TabStop = false;
            // 
            // NewConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 614);
            this.Controls.Add(this.pictureBox_status_internet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_neighbors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.test_button);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новое подключение";
            this.Load += new System.EventHandler(this.NewConnectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Neighbors)).EndInit();
            this.groupBox_neighbors.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.port_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_ip_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_internet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.TextBox host_textBox;
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
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Neighbors;
        private System.Windows.Forms.GroupBox groupBox_neighbors;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label_ip_for_mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neighbours_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neighbours_MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neighbours_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neighbours_RB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neighbours_ROS_V;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButton_api_ssl;
        private System.Windows.Forms.RadioButton radioButton_api;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_update_neighbors;
        private System.Windows.Forms.PictureBox pictureBox_status_internet;
    }
}