namespace CqustRfidSystem
{
    partial class Attendence
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
            this.log_text = new System.Windows.Forms.RichTextBox();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_school_port = new System.Windows.Forms.ComboBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_student_id = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // log_text
            // 
            this.log_text.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.log_text.Location = new System.Drawing.Point(34, 163);
            this.log_text.Margin = new System.Windows.Forms.Padding(2);
            this.log_text.Name = "log_text";
            this.log_text.Size = new System.Drawing.Size(576, 290);
            this.log_text.TabIndex = 22;
            this.log_text.Text = "";
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(366, 66);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(100, 21);
            this.textBox_place.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "考勤机地址配置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "考勤机串口配置";
            // 
            // comboBox_school_port
            // 
            this.comboBox_school_port.FormattingEnabled = true;
            this.comboBox_school_port.Location = new System.Drawing.Point(127, 66);
            this.comboBox_school_port.Name = "comboBox_school_port";
            this.comboBox_school_port.Size = new System.Drawing.Size(100, 20);
            this.comboBox_school_port.TabIndex = 27;
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(510, 63);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(75, 23);
            this.btn_set.TabIndex = 28;
            this.btn_set.Text = "设置";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "当前打卡学生:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "打卡地点:";
            // 
            // label_student_id
            // 
            this.label_student_id.AutoSize = true;
            this.label_student_id.Location = new System.Drawing.Point(127, 127);
            this.label_student_id.Name = "label_student_id";
            this.label_student_id.Size = new System.Drawing.Size(23, 12);
            this.label_student_id.TabIndex = 33;
            this.label_student_id.Text = "sno";
            // 
            // label_place
            // 
            this.label_place.AutoSize = true;
            this.label_place.Location = new System.Drawing.Point(293, 127);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(17, 12);
            this.label_place.TabIndex = 34;
            this.label_place.Text = "pl";
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(639, 64);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 35;
            this.btn_open.Text = "启用";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click_1);
            // 
            // port
            // 
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // Attendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.label_place);
            this.Controls.Add(this.label_student_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.comboBox_school_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.log_text);
            this.Name = "Attendence";
            this.Text = "Attendence";
            this.Load += new System.EventHandler(this.Attendence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox log_text;
        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_school_port;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_student_id;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.Button btn_open;
        private System.IO.Ports.SerialPort port;
    }
}