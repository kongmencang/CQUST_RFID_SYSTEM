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
            this.card_id = new System.Windows.Forms.TextBox();
            this.commit = new System.Windows.Forms.Button();
            this.uart = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.student_snos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_school_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_department_name = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_subject_name = new System.Windows.Forms.ComboBox();
            this.comboBox_class_name = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textbox_sno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.load_sno_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // card_id
            // 
            this.card_id.Location = new System.Drawing.Point(93, 192);
            this.card_id.Name = "card_id";
            this.card_id.Size = new System.Drawing.Size(100, 21);
            this.card_id.TabIndex = 0;
            // 
            // commit
            // 
            this.commit.Location = new System.Drawing.Point(269, 190);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(75, 23);
            this.commit.TabIndex = 1;
            this.commit.Text = "写入";
            this.commit.UseVisualStyleBackColor = true;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // uart
            // 
            this.uart.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.uart_DataReceived);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 238);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 278);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "待发卡学号";
            // 
            // student_snos
            // 
            this.student_snos.FormattingEnabled = true;
            this.student_snos.Location = new System.Drawing.Point(83, 127);
            this.student_snos.Name = "student_snos";
            this.student_snos.Size = new System.Drawing.Size(100, 20);
            this.student_snos.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "学院";
            // 
            // comboBox_school_name
            // 
            this.comboBox_school_name.FormattingEnabled = true;
            this.comboBox_school_name.Location = new System.Drawing.Point(83, 24);
            this.comboBox_school_name.Name = "comboBox_school_name";
            this.comboBox_school_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_school_name.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "系";
            // 
            // comboBox_department_name
            // 
            this.comboBox_department_name.FormattingEnabled = true;
            this.comboBox_department_name.Location = new System.Drawing.Point(244, 24);
            this.comboBox_department_name.Name = "comboBox_department_name";
            this.comboBox_department_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_department_name.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "专业";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "班级";
            // 
            // comboBox_subject_name
            // 
            this.comboBox_subject_name.FormattingEnabled = true;
            this.comboBox_subject_name.Location = new System.Drawing.Point(442, 24);
            this.comboBox_subject_name.Name = "comboBox_subject_name";
            this.comboBox_subject_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_subject_name.TabIndex = 14;
            // 
            // comboBox_class_name
            // 
            this.comboBox_class_name.FormattingEnabled = true;
            this.comboBox_class_name.Location = new System.Drawing.Point(83, 63);
            this.comboBox_class_name.Name = "comboBox_class_name";
            this.comboBox_class_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_class_name.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "学号";
            // 
            // textbox_sno
            // 
            this.textbox_sno.Location = new System.Drawing.Point(244, 63);
            this.textbox_sno.Name = "textbox_sno";
            this.textbox_sno.Size = new System.Drawing.Size(100, 21);
            this.textbox_sno.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // load_sno_btn
            // 
            this.load_sno_btn.Location = new System.Drawing.Point(442, 66);
            this.load_sno_btn.Name = "load_sno_btn";
            this.load_sno_btn.Size = new System.Drawing.Size(75, 23);
            this.load_sno_btn.TabIndex = 19;
            this.load_sno_btn.Text = "加载";
            this.load_sno_btn.UseVisualStyleBackColor = true;
            // 
            // SendCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 537);
            this.Controls.Add(this.load_sno_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox_sno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_class_name);
            this.Controls.Add(this.comboBox_subject_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_department_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_school_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.student_snos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.card_id);
            this.Name = "SendCard";
            this.Text = "SendCard";
            this.Load += new System.EventHandler(this.SendCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_id;
        private System.Windows.Forms.Button commit;
        private System.IO.Ports.SerialPort uart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox student_snos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_school_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_department_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_subject_name;
        private System.Windows.Forms.ComboBox comboBox_class_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textbox_sno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button load_sno_btn;
    }
}