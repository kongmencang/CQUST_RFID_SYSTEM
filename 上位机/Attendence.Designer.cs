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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendence));
            this.log_text = new System.Windows.Forms.RichTextBox();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_student_id = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log_text
            // 
            this.log_text.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.log_text.Location = new System.Drawing.Point(78, 160);
            this.log_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.log_text.Name = "log_text";
            this.log_text.Size = new System.Drawing.Size(576, 290);
            this.log_text.TabIndex = 22;
            this.log_text.Text = "";
            this.log_text.TextChanged += new System.EventHandler(this.log_text_TextChanged);
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(327, 65);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(100, 21);
            this.textBox_place.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(268, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "考勤教室";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "考勤机串口配置";
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(127, 66);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(100, 20);
            this.comboBox_port.TabIndex = 27;
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(500, 62);
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
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(38, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "当前打卡学生:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
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
            this.label_place.Location = new System.Drawing.Point(276, 127);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(17, 12);
            this.label_place.TabIndex = 34;
            this.label_place.Text = "pl";
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(639, 62);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 35;
            this.btn_open.Text = "启用";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click_1);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(639, 102);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 36;
            this.button_close.Text = "停用";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // Attendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::CqustRfidSystem.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.label_place);
            this.Controls.Add(this.label_student_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.comboBox_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.log_text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Attendence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考勤";
            this.Load += new System.EventHandler(this.Attendence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox log_text;
        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_student_id;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button button_close;
    }
}