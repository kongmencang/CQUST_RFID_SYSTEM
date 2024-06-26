namespace CqustRfidSystem
{
    partial class SendCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendCard));
            this.card_id = new System.Windows.Forms.TextBox();
            this.commit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_student_id = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_school_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_department_name = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_subject_name = new System.Windows.Forms.ComboBox();
            this.comboBox_class_name = new System.Windows.Forms.ComboBox();
            this.lable_student_name = new System.Windows.Forms.Label();
            this.log_text = new System.Windows.Forms.RichTextBox();
            this.panel_portconf = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.PortName = new System.Windows.Forms.ComboBox();
            this.b_lable = new System.Windows.Forms.Label();
            this.p_lable = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.配置串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.panel_portconf.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // card_id
            // 
            this.card_id.Location = new System.Drawing.Point(290, 369);
            this.card_id.Margin = new System.Windows.Forms.Padding(6);
            this.card_id.Name = "card_id";
            this.card_id.Size = new System.Drawing.Size(196, 35);
            this.card_id.TabIndex = 0;
            // 
            // commit
            // 
            this.commit.Location = new System.Drawing.Point(710, 369);
            this.commit.Margin = new System.Windows.Forms.Padding(6);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(150, 46);
            this.commit.TabIndex = 1;
            this.commit.Text = "写入";
            this.commit.UseVisualStyleBackColor = true;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(220, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "待发卡学号";
            // 
            // comboBox_student_id
            // 
            this.comboBox_student_id.FormattingEnabled = true;
            this.comboBox_student_id.Location = new System.Drawing.Point(290, 259);
            this.comboBox_student_id.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_student_id.Name = "comboBox_student_id";
            this.comboBox_student_id.Size = new System.Drawing.Size(196, 32);
            this.comboBox_student_id.TabIndex = 7;
            this.comboBox_student_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_student_id_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(220, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "学院";
            // 
            // comboBox_school_name
            // 
            this.comboBox_school_name.FormattingEnabled = true;
            this.comboBox_school_name.Location = new System.Drawing.Point(290, 70);
            this.comboBox_school_name.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_school_name.Name = "comboBox_school_name";
            this.comboBox_school_name.Size = new System.Drawing.Size(196, 32);
            this.comboBox_school_name.TabIndex = 9;
            this.comboBox_school_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_school_name_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(650, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "系";
            // 
            // comboBox_department_name
            // 
            this.comboBox_department_name.FormattingEnabled = true;
            this.comboBox_department_name.Location = new System.Drawing.Point(696, 70);
            this.comboBox_department_name.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_department_name.Name = "comboBox_department_name";
            this.comboBox_department_name.Size = new System.Drawing.Size(196, 32);
            this.comboBox_department_name.TabIndex = 11;
            this.comboBox_department_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_department_name_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(220, 173);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "专业";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(626, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "班级";
            // 
            // comboBox_subject_name
            // 
            this.comboBox_subject_name.FormattingEnabled = true;
            this.comboBox_subject_name.Location = new System.Drawing.Point(290, 170);
            this.comboBox_subject_name.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_subject_name.Name = "comboBox_subject_name";
            this.comboBox_subject_name.Size = new System.Drawing.Size(196, 32);
            this.comboBox_subject_name.TabIndex = 14;
            this.comboBox_subject_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_subject_name_SelectedIndexChanged);
            // 
            // comboBox_class_name
            // 
            this.comboBox_class_name.FormattingEnabled = true;
            this.comboBox_class_name.Location = new System.Drawing.Point(696, 170);
            this.comboBox_class_name.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_class_name.Name = "comboBox_class_name";
            this.comboBox_class_name.Size = new System.Drawing.Size(196, 32);
            this.comboBox_class_name.TabIndex = 15;
            this.comboBox_class_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_class_name_SelectedIndexChanged);
            // 
            // lable_student_name
            // 
            this.lable_student_name.AutoSize = true;
            this.lable_student_name.BackColor = System.Drawing.Color.Transparent;
            this.lable_student_name.ForeColor = System.Drawing.Color.Transparent;
            this.lable_student_name.Location = new System.Drawing.Point(626, 262);
            this.lable_student_name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lable_student_name.Name = "lable_student_name";
            this.lable_student_name.Size = new System.Drawing.Size(58, 24);
            this.lable_student_name.TabIndex = 20;
            this.lable_student_name.Text = "姓名";
            // 
            // log_text
            // 
            this.log_text.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.log_text.Location = new System.Drawing.Point(18, 476);
            this.log_text.Margin = new System.Windows.Forms.Padding(4);
            this.log_text.Name = "log_text";
            this.log_text.Size = new System.Drawing.Size(1261, 576);
            this.log_text.TabIndex = 21;
            this.log_text.Text = "";
            this.log_text.TextChanged += new System.EventHandler(this.log_text_TextChanged);
            // 
            // panel_portconf
            // 
            this.panel_portconf.Controls.Add(this.button3);
            this.panel_portconf.Controls.Add(this.button2);
            this.panel_portconf.Controls.Add(this.BaudRate);
            this.panel_portconf.Controls.Add(this.PortName);
            this.panel_portconf.Controls.Add(this.b_lable);
            this.panel_portconf.Controls.Add(this.p_lable);
            this.panel_portconf.Location = new System.Drawing.Point(391, 200);
            this.panel_portconf.Margin = new System.Windows.Forms.Padding(6);
            this.panel_portconf.Name = "panel_portconf";
            this.panel_portconf.Size = new System.Drawing.Size(486, 316);
            this.panel_portconf.TabIndex = 22;
            this.panel_portconf.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(151)))), ((int)(((byte)(226)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 12F);
            this.button3.Location = new System.Drawing.Point(254, 242);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 46);
            this.button3.TabIndex = 37;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(151)))), ((int)(((byte)(226)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.Location = new System.Drawing.Point(76, 242);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 36;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BaudRate
            // 
            this.BaudRate.AutoCompleteCustomSource.AddRange(new string[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRate.Font = new System.Drawing.Font("宋体", 12F);
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.BaudRate.Location = new System.Drawing.Point(252, 162);
            this.BaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(180, 41);
            this.BaudRate.TabIndex = 35;
            // 
            // PortName
            // 
            this.PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName.Font = new System.Drawing.Font("宋体", 12F);
            this.PortName.FormattingEnabled = true;
            this.PortName.Location = new System.Drawing.Point(254, 60);
            this.PortName.Margin = new System.Windows.Forms.Padding(4);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(180, 41);
            this.PortName.TabIndex = 34;
            // 
            // b_lable
            // 
            this.b_lable.AutoSize = true;
            this.b_lable.BackColor = System.Drawing.Color.Transparent;
            this.b_lable.Font = new System.Drawing.Font("宋体", 15F);
            this.b_lable.Location = new System.Drawing.Point(68, 162);
            this.b_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.b_lable.Name = "b_lable";
            this.b_lable.Size = new System.Drawing.Size(137, 40);
            this.b_lable.TabIndex = 33;
            this.b_lable.Text = "波特率";
            // 
            // p_lable
            // 
            this.p_lable.AutoSize = true;
            this.p_lable.BackColor = System.Drawing.Color.Transparent;
            this.p_lable.Font = new System.Drawing.Font("宋体", 15F);
            this.p_lable.Location = new System.Drawing.Point(68, 68);
            this.p_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.p_lable.Name = "p_lable";
            this.p_lable.Size = new System.Drawing.Size(137, 40);
            this.p_lable.TabIndex = 32;
            this.p_lable.Text = "串口号";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置串口ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1292, 39);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 配置串口ToolStripMenuItem
            // 
            this.配置串口ToolStripMenuItem.Name = "配置串口ToolStripMenuItem";
            this.配置串口ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.配置串口ToolStripMenuItem.Text = "配置串口";
            this.配置串口ToolStripMenuItem.Click += new System.EventHandler(this.配置串口ToolStripMenuItem_Click);
            // 
            // port
            // 
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // SendCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::CqustRfidSystem.Properties.Resources.bg3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1292, 1074);
            this.Controls.Add(this.panel_portconf);
            this.Controls.Add(this.log_text);
            this.Controls.Add(this.lable_student_name);
            this.Controls.Add(this.comboBox_class_name);
            this.Controls.Add(this.comboBox_subject_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_department_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_school_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_student_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.card_id);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SendCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发卡";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendCard_FormClosed);
            this.Load += new System.EventHandler(this.SendCard_Load);
            this.panel_portconf.ResumeLayout(false);
            this.panel_portconf.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_id;
        private System.Windows.Forms.Button commit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_student_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_school_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_department_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_subject_name;
        private System.Windows.Forms.ComboBox comboBox_class_name;
        private System.Windows.Forms.Label lable_student_name;
        private System.Windows.Forms.RichTextBox log_text;
        private System.Windows.Forms.Panel panel_portconf;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.ComboBox PortName;
        private System.Windows.Forms.Label b_lable;
        private System.Windows.Forms.Label p_lable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置串口ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Button button3;
    }
}