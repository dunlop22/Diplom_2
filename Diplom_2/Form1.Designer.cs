
namespace Diplom_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.new_connection_Main_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Internet_connect_status_image = new System.Windows.Forms.PictureBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Main_tab = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label_Arch = new System.Windows.Forms.Label();
            this.label_UpTime = new System.Windows.Forms.Label();
            this.label_RouterOS = new System.Windows.Forms.Label();
            this.label_Model = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_Memory = new System.Windows.Forms.Label();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_RAM = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Interface_tab = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridView_PhysicalInterface = new System.Windows.Forms.DataGridView();
            this.InterfaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterfaceMac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterfaceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterfaceDownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterfaceUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dataGridView_VirtualInterface = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARP_tab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView_ARP = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DHCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterfaceARP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView_WiFi = new System.Windows.Forms.DataGridView();
            this.dataGridView_CapsMan = new System.Windows.Forms.DataGridView();
            this.User_tab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView_User = new System.Windows.Forms.DataGridView();
            this.NameLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_AddNewUser = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView_UserGroup = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Policy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.policy_local = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_telnet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_ssh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_ftp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_reboot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_read = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_write = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_policy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_test = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_winbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_password = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_web = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_sniff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_sensitive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_api = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_romon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_dude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.policy_tikapp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.firewall_tab = new System.Windows.Forms.TabPage();
            this.dataGridView_firewall = new System.Windows.Forms.DataGridView();
            this.AddressList_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressList_Timeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Tools_tab = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button_Shutdown = new System.Windows.Forms.Button();
            this.button_Reboot = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Service_tab = new System.Windows.Forms.TabPage();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox_www_ssl_port = new System.Windows.Forms.TextBox();
            this.textBox_www_port = new System.Windows.Forms.TextBox();
            this.textBox_winbox_port = new System.Windows.Forms.TextBox();
            this.textBox_telnet_port = new System.Windows.Forms.TextBox();
            this.textBox_ssh_port = new System.Windows.Forms.TextBox();
            this.textBox_ftp_port = new System.Windows.Forms.TextBox();
            this.textBox_api_ssl_port = new System.Windows.Forms.TextBox();
            this.textBox_api_port = new System.Windows.Forms.TextBox();
            this.checkBox_wwwssl = new System.Windows.Forms.CheckBox();
            this.checkBox_www = new System.Windows.Forms.CheckBox();
            this.checkBox_winbox = new System.Windows.Forms.CheckBox();
            this.checkBox_telnet = new System.Windows.Forms.CheckBox();
            this.checkBox_ssh = new System.Windows.Forms.CheckBox();
            this.checkBox_ftp = new System.Windows.Forms.CheckBox();
            this.checkBox_apissl = new System.Windows.Forms.CheckBox();
            this.checkBox_api = new System.Windows.Forms.CheckBox();
            this.timer_CheckInternet = new System.Windows.Forms.Timer(this.components);
            this.button_SafeMode = new System.Windows.Forms.Button();
            this.label_timer_safemode = new System.Windows.Forms.Label();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Internet_connect_status_image)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.Main_tab.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Interface_tab.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PhysicalInterface)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VirtualInterface)).BeginInit();
            this.ARP_tab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ARP)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WiFi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CapsMan)).BeginInit();
            this.User_tab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserGroup)).BeginInit();
            this.firewall_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_firewall)).BeginInit();
            this.Tools_tab.SuspendLayout();
            this.Service_tab.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.new_connection_Main_Menu,
            this.справкаToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(880, 27);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // new_connection_Main_Menu
            // 
            this.new_connection_Main_Menu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.new_connection_Main_Menu.Name = "new_connection_Main_Menu";
            this.new_connection_Main_Menu.Size = new System.Drawing.Size(152, 23);
            this.new_connection_Main_Menu.Text = "Новое подключение";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 613);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(880, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 21);
            this.toolStripStatusLabel1.Text = "Интернет: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Internet_connect_status_image
            // 
            this.Internet_connect_status_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Internet_connect_status_image.Location = new System.Drawing.Point(84, 619);
            this.Internet_connect_status_image.Name = "Internet_connect_status_image";
            this.Internet_connect_status_image.Size = new System.Drawing.Size(16, 16);
            this.Internet_connect_status_image.TabIndex = 2;
            this.Internet_connect_status_image.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl2.Controls.Add(this.Main_tab);
            this.tabControl2.Controls.Add(this.Interface_tab);
            this.tabControl2.Controls.Add(this.ARP_tab);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.User_tab);
            this.tabControl2.Controls.Add(this.firewall_tab);
            this.tabControl2.Controls.Add(this.Tools_tab);
            this.tabControl2.Controls.Add(this.Service_tab);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabControl2.HotTrack = true;
            this.tabControl2.Location = new System.Drawing.Point(26, 86);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(823, 507);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl2_Selected);
            // 
            // Main_tab
            // 
            this.Main_tab.Controls.Add(this.groupBox11);
            this.Main_tab.Controls.Add(this.groupBox3);
            this.Main_tab.Controls.Add(this.groupBox2);
            this.Main_tab.Controls.Add(this.groupBox1);
            this.Main_tab.Location = new System.Drawing.Point(25, 4);
            this.Main_tab.Name = "Main_tab";
            this.Main_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Main_tab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Main_tab.Size = new System.Drawing.Size(794, 499);
            this.Main_tab.TabIndex = 0;
            this.Main_tab.Text = "Главная";
            this.Main_tab.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label_Arch);
            this.groupBox11.Controls.Add(this.label_UpTime);
            this.groupBox11.Controls.Add(this.label_RouterOS);
            this.groupBox11.Controls.Add(this.label_Model);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox11.Location = new System.Drawing.Point(409, 261);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(364, 223);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Ресурсы";
            // 
            // label_Arch
            // 
            this.label_Arch.AutoSize = true;
            this.label_Arch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Arch.Location = new System.Drawing.Point(36, 128);
            this.label_Arch.Name = "label_Arch";
            this.label_Arch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Arch.Size = new System.Drawing.Size(109, 20);
            this.label_Arch.TabIndex = 8;
            this.label_Arch.Text = "Архитектура:";
            // 
            // label_UpTime
            // 
            this.label_UpTime.AutoSize = true;
            this.label_UpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_UpTime.Location = new System.Drawing.Point(24, 180);
            this.label_UpTime.Name = "label_UpTime";
            this.label_UpTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_UpTime.Size = new System.Drawing.Size(122, 20);
            this.label_UpTime.TabIndex = 10;
            this.label_UpTime.Text = "Время работы:";
            // 
            // label_RouterOS
            // 
            this.label_RouterOS.AutoSize = true;
            this.label_RouterOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_RouterOS.Location = new System.Drawing.Point(60, 84);
            this.label_RouterOS.Name = "label_RouterOS";
            this.label_RouterOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_RouterOS.Size = new System.Drawing.Size(89, 20);
            this.label_RouterOS.TabIndex = 7;
            this.label_RouterOS.Text = "RouterOS: ";
            // 
            // label_Model
            // 
            this.label_Model.AutoSize = true;
            this.label_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Model.Location = new System.Drawing.Point(71, 40);
            this.label_Model.Name = "label_Model";
            this.label_Model.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Model.Size = new System.Drawing.Size(78, 20);
            this.label_Model.TabIndex = 9;
            this.label_Model.Text = "Модель: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_Memory);
            this.groupBox3.Controls.Add(this.chart3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(18, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(364, 223);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Накопитель";
            // 
            // label_Memory
            // 
            this.label_Memory.AutoSize = true;
            this.label_Memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Memory.Location = new System.Drawing.Point(206, 99);
            this.label_Memory.Name = "label_Memory";
            this.label_Memory.Size = new System.Drawing.Size(51, 20);
            this.label_Memory.TabIndex = 3;
            this.label_Memory.Text = "label2";
            // 
            // chart3
            // 
            chartArea1.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea1);
            this.chart3.Location = new System.Drawing.Point(15, 25);
            this.chart3.Name = "chart3";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Name = "CPU";
            this.chart3.Series.Add(series1);
            this.chart3.Size = new System.Drawing.Size(200, 175);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart2);
            this.groupBox2.Controls.Add(this.label_RAM);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(409, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(364, 223);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Оперативная память";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(18, 25);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Name = "CPU";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(200, 175);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // label_RAM
            // 
            this.label_RAM.AutoSize = true;
            this.label_RAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_RAM.Location = new System.Drawing.Point(214, 99);
            this.label_RAM.Name = "label_RAM";
            this.label_RAM.Size = new System.Drawing.Size(87, 20);
            this.label_RAM.TabIndex = 2;
            this.label_RAM.Text = "label_RAM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(18, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(364, 223);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Процессор";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(15, 25);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Name = "CPU";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(200, 175);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Interface_tab
            // 
            this.Interface_tab.Controls.Add(this.groupBox8);
            this.Interface_tab.Controls.Add(this.groupBox7);
            this.Interface_tab.Location = new System.Drawing.Point(25, 4);
            this.Interface_tab.Name = "Interface_tab";
            this.Interface_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Interface_tab.Size = new System.Drawing.Size(794, 499);
            this.Interface_tab.TabIndex = 5;
            this.Interface_tab.Text = "Interface";
            this.Interface_tab.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridView_PhysicalInterface);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox8.Location = new System.Drawing.Point(13, 10);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox8.Size = new System.Drawing.Size(527, 541);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Физические интерфейсы";
            // 
            // dataGridView_PhysicalInterface
            // 
            this.dataGridView_PhysicalInterface.AllowUserToAddRows = false;
            this.dataGridView_PhysicalInterface.AllowUserToDeleteRows = false;
            this.dataGridView_PhysicalInterface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PhysicalInterface.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InterfaceName,
            this.InterfaceMac,
            this.InterfaceType,
            this.InterfaceDownload,
            this.InterfaceUpload});
            this.dataGridView_PhysicalInterface.Location = new System.Drawing.Point(11, 19);
            this.dataGridView_PhysicalInterface.Name = "dataGridView_PhysicalInterface";
            this.dataGridView_PhysicalInterface.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_PhysicalInterface.RowHeadersVisible = false;
            this.dataGridView_PhysicalInterface.Size = new System.Drawing.Size(503, 509);
            this.dataGridView_PhysicalInterface.TabIndex = 0;
            // 
            // InterfaceName
            // 
            this.InterfaceName.HeaderText = "Наименование";
            this.InterfaceName.Name = "InterfaceName";
            // 
            // InterfaceMac
            // 
            this.InterfaceMac.HeaderText = "MAC-адрес";
            this.InterfaceMac.Name = "InterfaceMac";
            // 
            // InterfaceType
            // 
            this.InterfaceType.HeaderText = "Тип интерфейса";
            this.InterfaceType.Name = "InterfaceType";
            // 
            // InterfaceDownload
            // 
            this.InterfaceDownload.HeaderText = "Download";
            this.InterfaceDownload.Name = "InterfaceDownload";
            // 
            // InterfaceUpload
            // 
            this.InterfaceUpload.HeaderText = "Upload";
            this.InterfaceUpload.Name = "InterfaceUpload";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dataGridView_VirtualInterface);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox7.Location = new System.Drawing.Point(562, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox7.Size = new System.Drawing.Size(527, 541);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Виртуальные интерфейсы";
            // 
            // dataGridView_VirtualInterface
            // 
            this.dataGridView_VirtualInterface.AllowUserToAddRows = false;
            this.dataGridView_VirtualInterface.AllowUserToDeleteRows = false;
            this.dataGridView_VirtualInterface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VirtualInterface.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView_VirtualInterface.Location = new System.Drawing.Point(11, 21);
            this.dataGridView_VirtualInterface.Name = "dataGridView_VirtualInterface";
            this.dataGridView_VirtualInterface.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_VirtualInterface.RowHeadersVisible = false;
            this.dataGridView_VirtualInterface.Size = new System.Drawing.Size(504, 507);
            this.dataGridView_VirtualInterface.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "MAC-адрес";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип интерфейса";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Download";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Upload";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ARP_tab
            // 
            this.ARP_tab.Controls.Add(this.groupBox6);
            this.ARP_tab.Location = new System.Drawing.Point(25, 4);
            this.ARP_tab.Name = "ARP_tab";
            this.ARP_tab.Padding = new System.Windows.Forms.Padding(3);
            this.ARP_tab.Size = new System.Drawing.Size(794, 499);
            this.ARP_tab.TabIndex = 1;
            this.ARP_tab.Text = "ARP";
            this.ARP_tab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView_ARP);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox6.Location = new System.Drawing.Point(17, 21);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox6.Size = new System.Drawing.Size(1111, 486);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Список подключенных устройств";
            // 
            // dataGridView_ARP
            // 
            this.dataGridView_ARP.AllowUserToAddRows = false;
            this.dataGridView_ARP.AllowUserToDeleteRows = false;
            this.dataGridView_ARP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ARP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.MAC,
            this.DHCP,
            this.InterfaceARP});
            this.dataGridView_ARP.Location = new System.Drawing.Point(18, 34);
            this.dataGridView_ARP.Name = "dataGridView_ARP";
            this.dataGridView_ARP.ReadOnly = true;
            this.dataGridView_ARP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_ARP.RowHeadersVisible = false;
            this.dataGridView_ARP.Size = new System.Drawing.Size(523, 409);
            this.dataGridView_ARP.TabIndex = 0;
            // 
            // ip
            // 
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Width = 150;
            // 
            // MAC
            // 
            this.MAC.HeaderText = "MAC-адрес";
            this.MAC.Name = "MAC";
            this.MAC.ReadOnly = true;
            this.MAC.Width = 170;
            // 
            // DHCP
            // 
            this.DHCP.HeaderText = "DHCP";
            this.DHCP.Name = "DHCP";
            this.DHCP.ReadOnly = true;
            // 
            // InterfaceARP
            // 
            this.InterfaceARP.HeaderText = "Interface";
            this.InterfaceARP.Name = "InterfaceARP";
            this.InterfaceARP.ReadOnly = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView_WiFi);
            this.tabPage5.Controls.Add(this.dataGridView_CapsMan);
            this.tabPage5.Location = new System.Drawing.Point(25, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(794, 499);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Wi-Fi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView_WiFi
            // 
            this.dataGridView_WiFi.AllowUserToAddRows = false;
            this.dataGridView_WiFi.AllowUserToDeleteRows = false;
            this.dataGridView_WiFi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WiFi.Location = new System.Drawing.Point(549, 67);
            this.dataGridView_WiFi.Name = "dataGridView_WiFi";
            this.dataGridView_WiFi.RowHeadersVisible = false;
            this.dataGridView_WiFi.Size = new System.Drawing.Size(350, 244);
            this.dataGridView_WiFi.TabIndex = 1;
            // 
            // dataGridView_CapsMan
            // 
            this.dataGridView_CapsMan.AllowUserToAddRows = false;
            this.dataGridView_CapsMan.AllowUserToDeleteRows = false;
            this.dataGridView_CapsMan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CapsMan.Location = new System.Drawing.Point(48, 67);
            this.dataGridView_CapsMan.Name = "dataGridView_CapsMan";
            this.dataGridView_CapsMan.RowHeadersVisible = false;
            this.dataGridView_CapsMan.Size = new System.Drawing.Size(350, 244);
            this.dataGridView_CapsMan.TabIndex = 0;
            // 
            // User_tab
            // 
            this.User_tab.Controls.Add(this.groupBox5);
            this.User_tab.Controls.Add(this.groupBox4);
            this.User_tab.Location = new System.Drawing.Point(25, 4);
            this.User_tab.Name = "User_tab";
            this.User_tab.Size = new System.Drawing.Size(794, 499);
            this.User_tab.TabIndex = 4;
            this.User_tab.Text = "User";
            this.User_tab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView_User);
            this.groupBox5.Controls.Add(this.button_AddNewUser);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox5.Location = new System.Drawing.Point(14, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(380, 495);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Пользователи";
            // 
            // dataGridView_User
            // 
            this.dataGridView_User.AllowUserToAddRows = false;
            this.dataGridView_User.AllowUserToDeleteRows = false;
            this.dataGridView_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameLogin,
            this.Group,
            this.LastLogin});
            this.dataGridView_User.Location = new System.Drawing.Point(13, 35);
            this.dataGridView_User.Name = "dataGridView_User";
            this.dataGridView_User.ReadOnly = true;
            this.dataGridView_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_User.RowHeadersVisible = false;
            this.dataGridView_User.Size = new System.Drawing.Size(355, 368);
            this.dataGridView_User.TabIndex = 0;
            // 
            // NameLogin
            // 
            this.NameLogin.HeaderText = "Логин";
            this.NameLogin.Name = "NameLogin";
            this.NameLogin.ReadOnly = true;
            // 
            // Group
            // 
            this.Group.HeaderText = "Группа";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            // 
            // LastLogin
            // 
            this.LastLogin.HeaderText = "Последний вход";
            this.LastLogin.Name = "LastLogin";
            this.LastLogin.ReadOnly = true;
            this.LastLogin.Width = 150;
            // 
            // button_AddNewUser
            // 
            this.button_AddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_AddNewUser.Location = new System.Drawing.Point(113, 428);
            this.button_AddNewUser.Name = "button_AddNewUser";
            this.button_AddNewUser.Size = new System.Drawing.Size(137, 50);
            this.button_AddNewUser.TabIndex = 1;
            this.button_AddNewUser.Text = "Создать пользователя";
            this.button_AddNewUser.UseVisualStyleBackColor = true;
            this.button_AddNewUser.Click += new System.EventHandler(this.button_AddNewUser_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_UserGroup);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox4.Location = new System.Drawing.Point(410, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(834, 495);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Группы";
            // 
            // dataGridView_UserGroup
            // 
            this.dataGridView_UserGroup.AllowUserToAddRows = false;
            this.dataGridView_UserGroup.AllowUserToDeleteRows = false;
            this.dataGridView_UserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UserGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.Policy,
            this.policy_local,
            this.policy_telnet,
            this.policy_ssh,
            this.policy_ftp,
            this.policy_reboot,
            this.policy_read,
            this.policy_write,
            this.policy_policy,
            this.policy_test,
            this.policy_winbox,
            this.policy_password,
            this.policy_web,
            this.policy_sniff,
            this.policy_sensitive,
            this.policy_api,
            this.policy_romon,
            this.policy_dude,
            this.policy_tikapp});
            this.dataGridView_UserGroup.Location = new System.Drawing.Point(20, 35);
            this.dataGridView_UserGroup.Name = "dataGridView_UserGroup";
            this.dataGridView_UserGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_UserGroup.RowHeadersVisible = false;
            this.dataGridView_UserGroup.Size = new System.Drawing.Size(792, 368);
            this.dataGridView_UserGroup.TabIndex = 3;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "Название";
            this.GroupName.Name = "GroupName";
            // 
            // Policy
            // 
            this.Policy.HeaderText = "Политики";
            this.Policy.Name = "Policy";
            this.Policy.Visible = false;
            // 
            // policy_local
            // 
            this.policy_local.HeaderText = "local";
            this.policy_local.Name = "policy_local";
            this.policy_local.ReadOnly = true;
            this.policy_local.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_local.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_telnet
            // 
            this.policy_telnet.HeaderText = "telnet";
            this.policy_telnet.Name = "policy_telnet";
            this.policy_telnet.ReadOnly = true;
            this.policy_telnet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_telnet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_ssh
            // 
            this.policy_ssh.HeaderText = "ssh";
            this.policy_ssh.Name = "policy_ssh";
            this.policy_ssh.ReadOnly = true;
            this.policy_ssh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_ssh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_ftp
            // 
            this.policy_ftp.HeaderText = "ftp";
            this.policy_ftp.Name = "policy_ftp";
            this.policy_ftp.ReadOnly = true;
            this.policy_ftp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_ftp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_reboot
            // 
            this.policy_reboot.HeaderText = "reboot";
            this.policy_reboot.Name = "policy_reboot";
            this.policy_reboot.ReadOnly = true;
            this.policy_reboot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_reboot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_read
            // 
            this.policy_read.HeaderText = "read";
            this.policy_read.Name = "policy_read";
            this.policy_read.ReadOnly = true;
            this.policy_read.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_write
            // 
            this.policy_write.HeaderText = "write";
            this.policy_write.Name = "policy_write";
            this.policy_write.ReadOnly = true;
            this.policy_write.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_write.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_policy
            // 
            this.policy_policy.HeaderText = "policy";
            this.policy_policy.Name = "policy_policy";
            this.policy_policy.ReadOnly = true;
            this.policy_policy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_policy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_test
            // 
            this.policy_test.HeaderText = "test";
            this.policy_test.Name = "policy_test";
            this.policy_test.ReadOnly = true;
            this.policy_test.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_test.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_winbox
            // 
            this.policy_winbox.HeaderText = "winbox";
            this.policy_winbox.Name = "policy_winbox";
            this.policy_winbox.ReadOnly = true;
            this.policy_winbox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_winbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_password
            // 
            this.policy_password.HeaderText = "password";
            this.policy_password.Name = "policy_password";
            this.policy_password.ReadOnly = true;
            this.policy_password.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_web
            // 
            this.policy_web.HeaderText = "web";
            this.policy_web.Name = "policy_web";
            this.policy_web.ReadOnly = true;
            this.policy_web.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_web.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_sniff
            // 
            this.policy_sniff.HeaderText = "sniff";
            this.policy_sniff.Name = "policy_sniff";
            this.policy_sniff.ReadOnly = true;
            this.policy_sniff.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_sniff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_sensitive
            // 
            this.policy_sensitive.HeaderText = "sensitive";
            this.policy_sensitive.Name = "policy_sensitive";
            this.policy_sensitive.ReadOnly = true;
            this.policy_sensitive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_sensitive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_api
            // 
            this.policy_api.HeaderText = "api";
            this.policy_api.Name = "policy_api";
            this.policy_api.ReadOnly = true;
            this.policy_api.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_api.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_romon
            // 
            this.policy_romon.HeaderText = "romon";
            this.policy_romon.Name = "policy_romon";
            this.policy_romon.ReadOnly = true;
            this.policy_romon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_romon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_dude
            // 
            this.policy_dude.HeaderText = "dude";
            this.policy_dude.Name = "policy_dude";
            this.policy_dude.ReadOnly = true;
            this.policy_dude.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_dude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // policy_tikapp
            // 
            this.policy_tikapp.HeaderText = "tikapp";
            this.policy_tikapp.Name = "policy_tikapp";
            this.policy_tikapp.ReadOnly = true;
            this.policy_tikapp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.policy_tikapp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Location = new System.Drawing.Point(340, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Создать группу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // firewall_tab
            // 
            this.firewall_tab.Controls.Add(this.dataGridView_firewall);
            this.firewall_tab.Controls.Add(this.button3);
            this.firewall_tab.Controls.Add(this.button1);
            this.firewall_tab.Location = new System.Drawing.Point(25, 4);
            this.firewall_tab.Name = "firewall_tab";
            this.firewall_tab.Padding = new System.Windows.Forms.Padding(3);
            this.firewall_tab.Size = new System.Drawing.Size(794, 499);
            this.firewall_tab.TabIndex = 6;
            this.firewall_tab.Text = "Firewall";
            this.firewall_tab.UseVisualStyleBackColor = true;
            // 
            // dataGridView_firewall
            // 
            this.dataGridView_firewall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_firewall.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddressList_IP,
            this.AddressList_Timeout});
            this.dataGridView_firewall.Location = new System.Drawing.Point(20, 19);
            this.dataGridView_firewall.Name = "dataGridView_firewall";
            this.dataGridView_firewall.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_firewall.RowHeadersVisible = false;
            this.dataGridView_firewall.Size = new System.Drawing.Size(491, 237);
            this.dataGridView_firewall.TabIndex = 2;
            // 
            // AddressList_IP
            // 
            this.AddressList_IP.HeaderText = "IP";
            this.AddressList_IP.Name = "AddressList_IP";
            // 
            // AddressList_Timeout
            // 
            this.AddressList_Timeout.HeaderText = "Timeout";
            this.AddressList_Timeout.Name = "AddressList_Timeout";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(734, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "Запретить доступ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Разрешить доступ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Tools_tab
            // 
            this.Tools_tab.Controls.Add(this.button7);
            this.Tools_tab.Controls.Add(this.button_Shutdown);
            this.Tools_tab.Controls.Add(this.button_Reboot);
            this.Tools_tab.Controls.Add(this.button6);
            this.Tools_tab.Controls.Add(this.button5);
            this.Tools_tab.Controls.Add(this.button4);
            this.Tools_tab.Location = new System.Drawing.Point(25, 4);
            this.Tools_tab.Name = "Tools_tab";
            this.Tools_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Tools_tab.Size = new System.Drawing.Size(794, 499);
            this.Tools_tab.TabIndex = 7;
            this.Tools_tab.Text = "Tools";
            this.Tools_tab.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(69, 140);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 55);
            this.button7.TabIndex = 16;
            this.button7.Text = "Скачать LOG";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button_Shutdown
            // 
            this.button_Shutdown.BackColor = System.Drawing.Color.LightCoral;
            this.button_Shutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Shutdown.Location = new System.Drawing.Point(952, 501);
            this.button_Shutdown.Name = "button_Shutdown";
            this.button_Shutdown.Size = new System.Drawing.Size(95, 39);
            this.button_Shutdown.TabIndex = 15;
            this.button_Shutdown.Text = "Shutdown";
            this.button_Shutdown.UseVisualStyleBackColor = false;
            // 
            // button_Reboot
            // 
            this.button_Reboot.BackColor = System.Drawing.Color.NavajoWhite;
            this.button_Reboot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Reboot.Location = new System.Drawing.Point(1141, 501);
            this.button_Reboot.Name = "button_Reboot";
            this.button_Reboot.Size = new System.Drawing.Size(95, 39);
            this.button_Reboot.TabIndex = 14;
            this.button_Reboot.Text = "Reboot";
            this.button_Reboot.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(233, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 55);
            this.button6.TabIndex = 2;
            this.button6.Text = "Allow FireWall";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(69, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 55);
            this.button5.TabIndex = 1;
            this.button5.Text = "Del From FireWall";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(602, 166);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 55);
            this.button4.TabIndex = 0;
            this.button4.Text = "WoL";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Service_tab
            // 
            this.Service_tab.Controls.Add(this.button_save);
            this.Service_tab.Controls.Add(this.groupBox9);
            this.Service_tab.Location = new System.Drawing.Point(25, 4);
            this.Service_tab.Name = "Service_tab";
            this.Service_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Service_tab.Size = new System.Drawing.Size(794, 499);
            this.Service_tab.TabIndex = 8;
            this.Service_tab.Text = "Сервисы";
            this.Service_tab.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(247, 395);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(152, 42);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Применить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox_www_ssl_port);
            this.groupBox9.Controls.Add(this.textBox_www_port);
            this.groupBox9.Controls.Add(this.textBox_winbox_port);
            this.groupBox9.Controls.Add(this.textBox_telnet_port);
            this.groupBox9.Controls.Add(this.textBox_ssh_port);
            this.groupBox9.Controls.Add(this.textBox_ftp_port);
            this.groupBox9.Controls.Add(this.textBox_api_ssl_port);
            this.groupBox9.Controls.Add(this.textBox_api_port);
            this.groupBox9.Controls.Add(this.checkBox_wwwssl);
            this.groupBox9.Controls.Add(this.checkBox_www);
            this.groupBox9.Controls.Add(this.checkBox_winbox);
            this.groupBox9.Controls.Add(this.checkBox_telnet);
            this.groupBox9.Controls.Add(this.checkBox_ssh);
            this.groupBox9.Controls.Add(this.checkBox_ftp);
            this.groupBox9.Controls.Add(this.checkBox_apissl);
            this.groupBox9.Controls.Add(this.checkBox_api);
            this.groupBox9.Location = new System.Drawing.Point(20, 23);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(624, 355);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Сервисы для подключения";
            // 
            // textBox_www_ssl_port
            // 
            this.textBox_www_ssl_port.Location = new System.Drawing.Point(496, 271);
            this.textBox_www_ssl_port.Name = "textBox_www_ssl_port";
            this.textBox_www_ssl_port.ReadOnly = true;
            this.textBox_www_ssl_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_www_ssl_port.TabIndex = 15;
            // 
            // textBox_www_port
            // 
            this.textBox_www_port.Location = new System.Drawing.Point(496, 200);
            this.textBox_www_port.Name = "textBox_www_port";
            this.textBox_www_port.ReadOnly = true;
            this.textBox_www_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_www_port.TabIndex = 14;
            // 
            // textBox_winbox_port
            // 
            this.textBox_winbox_port.Location = new System.Drawing.Point(496, 140);
            this.textBox_winbox_port.Name = "textBox_winbox_port";
            this.textBox_winbox_port.ReadOnly = true;
            this.textBox_winbox_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_winbox_port.TabIndex = 13;
            // 
            // textBox_telnet_port
            // 
            this.textBox_telnet_port.Location = new System.Drawing.Point(496, 76);
            this.textBox_telnet_port.Name = "textBox_telnet_port";
            this.textBox_telnet_port.ReadOnly = true;
            this.textBox_telnet_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_telnet_port.TabIndex = 12;
            // 
            // textBox_ssh_port
            // 
            this.textBox_ssh_port.Location = new System.Drawing.Point(144, 269);
            this.textBox_ssh_port.Name = "textBox_ssh_port";
            this.textBox_ssh_port.ReadOnly = true;
            this.textBox_ssh_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_ssh_port.TabIndex = 11;
            // 
            // textBox_ftp_port
            // 
            this.textBox_ftp_port.Location = new System.Drawing.Point(144, 198);
            this.textBox_ftp_port.Name = "textBox_ftp_port";
            this.textBox_ftp_port.ReadOnly = true;
            this.textBox_ftp_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_ftp_port.TabIndex = 10;
            // 
            // textBox_api_ssl_port
            // 
            this.textBox_api_ssl_port.Location = new System.Drawing.Point(144, 140);
            this.textBox_api_ssl_port.Name = "textBox_api_ssl_port";
            this.textBox_api_ssl_port.ReadOnly = true;
            this.textBox_api_ssl_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_api_ssl_port.TabIndex = 9;
            // 
            // textBox_api_port
            // 
            this.textBox_api_port.Location = new System.Drawing.Point(144, 76);
            this.textBox_api_port.Name = "textBox_api_port";
            this.textBox_api_port.ReadOnly = true;
            this.textBox_api_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_api_port.TabIndex = 8;
            // 
            // checkBox_wwwssl
            // 
            this.checkBox_wwwssl.AutoSize = true;
            this.checkBox_wwwssl.Location = new System.Drawing.Point(414, 271);
            this.checkBox_wwwssl.Name = "checkBox_wwwssl";
            this.checkBox_wwwssl.Size = new System.Drawing.Size(76, 21);
            this.checkBox_wwwssl.TabIndex = 7;
            this.checkBox_wwwssl.Text = "www-ssl";
            this.checkBox_wwwssl.UseVisualStyleBackColor = true;
            // 
            // checkBox_www
            // 
            this.checkBox_www.AutoSize = true;
            this.checkBox_www.Location = new System.Drawing.Point(414, 200);
            this.checkBox_www.Name = "checkBox_www";
            this.checkBox_www.Size = new System.Drawing.Size(54, 21);
            this.checkBox_www.TabIndex = 6;
            this.checkBox_www.Text = "www";
            this.checkBox_www.UseVisualStyleBackColor = true;
            // 
            // checkBox_winbox
            // 
            this.checkBox_winbox.AutoSize = true;
            this.checkBox_winbox.Location = new System.Drawing.Point(414, 142);
            this.checkBox_winbox.Name = "checkBox_winbox";
            this.checkBox_winbox.Size = new System.Drawing.Size(69, 21);
            this.checkBox_winbox.TabIndex = 5;
            this.checkBox_winbox.Text = "winbox";
            this.checkBox_winbox.UseVisualStyleBackColor = true;
            // 
            // checkBox_telnet
            // 
            this.checkBox_telnet.AutoSize = true;
            this.checkBox_telnet.Location = new System.Drawing.Point(414, 76);
            this.checkBox_telnet.Name = "checkBox_telnet";
            this.checkBox_telnet.Size = new System.Drawing.Size(62, 21);
            this.checkBox_telnet.TabIndex = 4;
            this.checkBox_telnet.Text = "telnet";
            this.checkBox_telnet.UseVisualStyleBackColor = true;
            // 
            // checkBox_ssh
            // 
            this.checkBox_ssh.AutoSize = true;
            this.checkBox_ssh.Location = new System.Drawing.Point(60, 271);
            this.checkBox_ssh.Name = "checkBox_ssh";
            this.checkBox_ssh.Size = new System.Drawing.Size(49, 21);
            this.checkBox_ssh.TabIndex = 3;
            this.checkBox_ssh.Text = "ssh";
            this.checkBox_ssh.UseVisualStyleBackColor = true;
            // 
            // checkBox_ftp
            // 
            this.checkBox_ftp.AutoSize = true;
            this.checkBox_ftp.Location = new System.Drawing.Point(60, 200);
            this.checkBox_ftp.Name = "checkBox_ftp";
            this.checkBox_ftp.Size = new System.Drawing.Size(43, 21);
            this.checkBox_ftp.TabIndex = 2;
            this.checkBox_ftp.Text = "ftp";
            this.checkBox_ftp.UseVisualStyleBackColor = true;
            // 
            // checkBox_apissl
            // 
            this.checkBox_apissl.AutoSize = true;
            this.checkBox_apissl.Location = new System.Drawing.Point(60, 142);
            this.checkBox_apissl.Name = "checkBox_apissl";
            this.checkBox_apissl.Size = new System.Drawing.Size(67, 21);
            this.checkBox_apissl.TabIndex = 1;
            this.checkBox_apissl.Text = "api ssl";
            this.checkBox_apissl.UseVisualStyleBackColor = true;
            // 
            // checkBox_api
            // 
            this.checkBox_api.AutoSize = true;
            this.checkBox_api.Location = new System.Drawing.Point(60, 76);
            this.checkBox_api.Name = "checkBox_api";
            this.checkBox_api.Size = new System.Drawing.Size(46, 21);
            this.checkBox_api.TabIndex = 0;
            this.checkBox_api.Text = "api";
            this.checkBox_api.UseVisualStyleBackColor = true;
            // 
            // timer_CheckInternet
            // 
            this.timer_CheckInternet.Interval = 10000;
            this.timer_CheckInternet.Tick += new System.EventHandler(this.timer_CheckInternet_Tick);
            // 
            // button_SafeMode
            // 
            this.button_SafeMode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_SafeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_SafeMode.Location = new System.Drawing.Point(101, 32);
            this.button_SafeMode.Name = "button_SafeMode";
            this.button_SafeMode.Size = new System.Drawing.Size(93, 32);
            this.button_SafeMode.TabIndex = 4;
            this.button_SafeMode.Text = "Safe Mode";
            this.button_SafeMode.UseVisualStyleBackColor = false;
            this.button_SafeMode.Click += new System.EventHandler(this.button_SafeMode_Click);
            // 
            // label_timer_safemode
            // 
            this.label_timer_safemode.AutoSize = true;
            this.label_timer_safemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_timer_safemode.Location = new System.Drawing.Point(212, 40);
            this.label_timer_safemode.Name = "label_timer_safemode";
            this.label_timer_safemode.Size = new System.Drawing.Size(46, 17);
            this.label_timer_safemode.TabIndex = 5;
            this.label_timer_safemode.Text = "label2";
            this.label_timer_safemode.Visible = false;
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(74, 23);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 639);
            this.Controls.Add(this.label_timer_safemode);
            this.Controls.Add(this.button_SafeMode);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Internet_connect_status_image);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Form1";
            this.Text = "Панель управления MikroTik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Internet_connect_status_image)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.Main_tab.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Interface_tab.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PhysicalInterface)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VirtualInterface)).EndInit();
            this.ARP_tab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ARP)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WiFi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CapsMan)).EndInit();
            this.User_tab.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserGroup)).EndInit();
            this.firewall_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_firewall)).EndInit();
            this.Tools_tab.ResumeLayout(false);
            this.Service_tab.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem new_connection_Main_Menu;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox Internet_connect_status_image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Main_tab;
        private System.Windows.Forms.Label label_UpTime;
        private System.Windows.Forms.Label label_Model;
        private System.Windows.Forms.Label label_Arch;
        private System.Windows.Forms.Label label_RouterOS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_Memory;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label_RAM;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage ARP_tab;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView_ARP;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView_WiFi;
        private System.Windows.Forms.DataGridView dataGridView_CapsMan;
        private System.Windows.Forms.TabPage User_tab;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView_User;
        private System.Windows.Forms.Button button_AddNewUser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView_UserGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage Interface_tab;
        private System.Windows.Forms.DataGridView dataGridView_PhysicalInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceMac;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DHCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterfaceARP;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dataGridView_VirtualInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TabPage firewall_tab;
        private System.Windows.Forms.DataGridView dataGridView_firewall;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressList_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressList_Timeout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_CheckInternet;
        private System.Windows.Forms.TabPage Tools_tab;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Policy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_local;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_telnet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_ssh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_ftp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_reboot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_read;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_write;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_policy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_test;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_winbox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_password;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_web;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_sniff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_sensitive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_api;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_romon;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_dude;
        private System.Windows.Forms.DataGridViewCheckBoxColumn policy_tikapp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLogin;
        private System.Windows.Forms.TabPage Service_tab;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox checkBox_wwwssl;
        private System.Windows.Forms.CheckBox checkBox_www;
        private System.Windows.Forms.CheckBox checkBox_winbox;
        private System.Windows.Forms.CheckBox checkBox_telnet;
        private System.Windows.Forms.CheckBox checkBox_ssh;
        private System.Windows.Forms.CheckBox checkBox_ftp;
        private System.Windows.Forms.CheckBox checkBox_apissl;
        private System.Windows.Forms.CheckBox checkBox_api;
        private System.Windows.Forms.Button button_SafeMode;
        private System.Windows.Forms.Label label_timer_safemode;
        private System.Windows.Forms.Button button_Shutdown;
        private System.Windows.Forms.Button button_Reboot;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox_www_ssl_port;
        private System.Windows.Forms.TextBox textBox_www_port;
        private System.Windows.Forms.TextBox textBox_winbox_port;
        private System.Windows.Forms.TextBox textBox_telnet_port;
        private System.Windows.Forms.TextBox textBox_ssh_port;
        private System.Windows.Forms.TextBox textBox_ftp_port;
        private System.Windows.Forms.TextBox textBox_api_ssl_port;
        private System.Windows.Forms.TextBox textBox_api_port;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

