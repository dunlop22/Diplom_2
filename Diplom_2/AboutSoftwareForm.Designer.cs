
namespace Diplom_2
{
    partial class AboutSoftwareForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_path_sys = new System.Windows.Forms.Label();
            this.label_name_user = new System.Windows.Forms.Label();
            this.label_num_cpu = new System.Windows.Forms.Label();
            this.label_cpu = new System.Windows.Forms.Label();
            this.label_os = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_path_sys);
            this.groupBox1.Controls.Add(this.label_name_user);
            this.groupBox1.Controls.Add(this.label_num_cpu);
            this.groupBox1.Controls.Add(this.label_cpu);
            this.groupBox1.Controls.Add(this.label_os);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ресурсы системы";
            // 
            // label_path_sys
            // 
            this.label_path_sys.AutoSize = true;
            this.label_path_sys.Location = new System.Drawing.Point(40, 184);
            this.label_path_sys.Name = "label_path_sys";
            this.label_path_sys.Size = new System.Drawing.Size(77, 17);
            this.label_path_sys.TabIndex = 4;
            this.label_path_sys.Text = "path to sys";
            // 
            // label_name_user
            // 
            this.label_name_user.AutoSize = true;
            this.label_name_user.Location = new System.Drawing.Point(40, 138);
            this.label_name_user.Name = "label_name_user";
            this.label_name_user.Size = new System.Drawing.Size(77, 17);
            this.label_name_user.TabIndex = 3;
            this.label_name_user.Text = "Name user";
            // 
            // label_num_cpu
            // 
            this.label_num_cpu.AutoSize = true;
            this.label_num_cpu.Location = new System.Drawing.Point(40, 111);
            this.label_num_cpu.Name = "label_num_cpu";
            this.label_num_cpu.Size = new System.Drawing.Size(62, 17);
            this.label_num_cpu.TabIndex = 2;
            this.label_num_cpu.Text = "num cpu";
            // 
            // label_cpu
            // 
            this.label_cpu.AutoSize = true;
            this.label_cpu.Location = new System.Drawing.Point(40, 71);
            this.label_cpu.Name = "label_cpu";
            this.label_cpu.Size = new System.Drawing.Size(36, 17);
            this.label_cpu.TabIndex = 1;
            this.label_cpu.Text = "CPU";
            // 
            // label_os
            // 
            this.label_os.AutoSize = true;
            this.label_os.Location = new System.Drawing.Point(40, 45);
            this.label_os.Name = "label_os";
            this.label_os.Size = new System.Drawing.Size(28, 17);
            this.label_os.TabIndex = 0;
            this.label_os.Text = "OS";
            // 
            // AboutSoftwareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "AboutSoftwareForm";
            this.Text = "AboutSoftwareForm";
            this.Load += new System.EventHandler(this.AboutSoftwareForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AboutSoftwareForm_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_name_user;
        private System.Windows.Forms.Label label_num_cpu;
        private System.Windows.Forms.Label label_cpu;
        private System.Windows.Forms.Label label_os;
        private System.Windows.Forms.Label label_path_sys;
    }
}