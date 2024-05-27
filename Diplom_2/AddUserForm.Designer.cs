
namespace Diplom_2
{
    partial class AddUserForm
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
            this.button_Create = new System.Windows.Forms.Button();
            this.label_Login = new System.Windows.Forms.Label();
            this.label_Group = new System.Windows.Forms.Label();
            this.label_Pass1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.comboBox_Group = new System.Windows.Forms.ComboBox();
            this.textBox_Pass1 = new System.Windows.Forms.TextBox();
            this.textBox_Pass2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Create
            // 
            this.button_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Create.Location = new System.Drawing.Point(171, 304);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(116, 46);
            this.button_Create.TabIndex = 0;
            this.button_Create.Text = "Создать";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // label_Login
            // 
            this.label_Login.AutoSize = true;
            this.label_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Login.Location = new System.Drawing.Point(73, 39);
            this.label_Login.Name = "label_Login";
            this.label_Login.Size = new System.Drawing.Size(55, 20);
            this.label_Login.TabIndex = 1;
            this.label_Login.Text = "Логин";
            // 
            // label_Group
            // 
            this.label_Group.AutoSize = true;
            this.label_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Group.Location = new System.Drawing.Point(73, 97);
            this.label_Group.Name = "label_Group";
            this.label_Group.Size = new System.Drawing.Size(61, 20);
            this.label_Group.TabIndex = 2;
            this.label_Group.Text = "Группа";
            // 
            // label_Pass1
            // 
            this.label_Pass1.AutoSize = true;
            this.label_Pass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_Pass1.Location = new System.Drawing.Point(73, 152);
            this.label_Pass1.Name = "label_Pass1";
            this.label_Pass1.Size = new System.Drawing.Size(76, 40);
            this.label_Pass1.TabIndex = 3;
            this.label_Pass1.Text = "Введите\nпароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(73, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "Подтвердите\nпароль";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Login.Location = new System.Drawing.Point(216, 36);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(182, 26);
            this.textBox_Login.TabIndex = 5;
            // 
            // comboBox_Group
            // 
            this.comboBox_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox_Group.FormattingEnabled = true;
            this.comboBox_Group.Location = new System.Drawing.Point(216, 94);
            this.comboBox_Group.Name = "comboBox_Group";
            this.comboBox_Group.Size = new System.Drawing.Size(182, 28);
            this.comboBox_Group.TabIndex = 6;
            // 
            // textBox_Pass1
            // 
            this.textBox_Pass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Pass1.Location = new System.Drawing.Point(216, 166);
            this.textBox_Pass1.Name = "textBox_Pass1";
            this.textBox_Pass1.PasswordChar = '*';
            this.textBox_Pass1.Size = new System.Drawing.Size(182, 26);
            this.textBox_Pass1.TabIndex = 7;
            // 
            // textBox_Pass2
            // 
            this.textBox_Pass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Pass2.Location = new System.Drawing.Point(216, 235);
            this.textBox_Pass2.Name = "textBox_Pass2";
            this.textBox_Pass2.PasswordChar = '*';
            this.textBox_Pass2.Size = new System.Drawing.Size(182, 26);
            this.textBox_Pass2.TabIndex = 8;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 382);
            this.Controls.Add(this.textBox_Pass2);
            this.Controls.Add(this.textBox_Pass1);
            this.Controls.Add(this.comboBox_Group);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Pass1);
            this.Controls.Add(this.label_Group);
            this.Controls.Add(this.label_Login);
            this.Controls.Add(this.button_Create);
            this.Name = "AddUserForm";
            this.Text = "AddUserForm";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Label label_Login;
        private System.Windows.Forms.Label label_Group;
        private System.Windows.Forms.Label label_Pass1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.ComboBox comboBox_Group;
        private System.Windows.Forms.TextBox textBox_Pass1;
        private System.Windows.Forms.TextBox textBox_Pass2;
    }
}