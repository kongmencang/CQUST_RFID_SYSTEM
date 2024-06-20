namespace CqustRfidSystem
{
    partial class Attendence_info_manage
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
            this.load_sno_btn = new System.Windows.Forms.Button();
            this.textbox_sno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_weekday = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_again_time = new System.Windows.Forms.TextBox();
            this.textBox_end_time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_course_section = new System.Windows.Forms.ComboBox();
            this.comboBox_state = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_class_name = new System.Windows.Forms.ComboBox();
            this.comboBox_subject_name = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_department_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_school_name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询条件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基础ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.data_table = new System.Windows.Forms.DataGridView();
            this.comboBox_scheduling_id = new System.Windows.Forms.ComboBox();
            this.label_course_name = new System.Windows.Forms.Label();
            this.addtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course_sections = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacher_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counselor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_table)).BeginInit();
            this.SuspendLayout();
            // 
            // load_sno_btn
            // 
            this.load_sno_btn.Location = new System.Drawing.Point(839, 169);
            this.load_sno_btn.Name = "load_sno_btn";
            this.load_sno_btn.Size = new System.Drawing.Size(75, 23);
            this.load_sno_btn.TabIndex = 37;
            this.load_sno_btn.Text = "加载";
            this.load_sno_btn.UseVisualStyleBackColor = true;
            this.load_sno_btn.Click += new System.EventHandler(this.load_sno_btn_Click);
            // 
            // textbox_sno
            // 
            this.textbox_sno.Location = new System.Drawing.Point(691, 24);
            this.textbox_sno.Name = "textbox_sno";
            this.textbox_sno.Size = new System.Drawing.Size(100, 21);
            this.textbox_sno.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(656, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "学号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "星期";
            // 
            // comboBox_weekday
            // 
            this.comboBox_weekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_weekday.FormattingEnabled = true;
            this.comboBox_weekday.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox_weekday.Location = new System.Drawing.Point(52, 26);
            this.comboBox_weekday.Name = "comboBox_weekday";
            this.comboBox_weekday.Size = new System.Drawing.Size(100, 20);
            this.comboBox_weekday.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "结束时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "开始时间";
            // 
            // textBox_again_time
            // 
            this.textBox_again_time.Location = new System.Drawing.Point(235, 26);
            this.textBox_again_time.Name = "textBox_again_time";
            this.textBox_again_time.Size = new System.Drawing.Size(100, 21);
            this.textBox_again_time.TabIndex = 43;
            // 
            // textBox_end_time
            // 
            this.textBox_end_time.Location = new System.Drawing.Point(428, 27);
            this.textBox_end_time.Name = "textBox_end_time";
            this.textBox_end_time.Size = new System.Drawing.Size(100, 21);
            this.textBox_end_time.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "课程名";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "排课id";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(546, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 51;
            this.label12.Text = "课次";
            // 
            // comboBox_course_section
            // 
            this.comboBox_course_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_course_section.FormattingEnabled = true;
            this.comboBox_course_section.Items.AddRange(new object[] {
            "第一节课",
            "第二节课",
            "第三节课",
            "第四节课",
            "第五节课",
            "第六节课"});
            this.comboBox_course_section.Location = new System.Drawing.Point(599, 30);
            this.comboBox_course_section.Name = "comboBox_course_section";
            this.comboBox_course_section.Size = new System.Drawing.Size(100, 20);
            this.comboBox_course_section.TabIndex = 52;
            // 
            // comboBox_state
            // 
            this.comboBox_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_state.FormattingEnabled = true;
            this.comboBox_state.Items.AddRange(new object[] {
            "正常",
            "迟到",
            "缺勤"});
            this.comboBox_state.Location = new System.Drawing.Point(855, 25);
            this.comboBox_state.Name = "comboBox_state";
            this.comboBox_state.Size = new System.Drawing.Size(100, 20);
            this.comboBox_state.TabIndex = 54;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(807, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 53;
            this.label13.Text = "状态";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox_class_name);
            this.panel1.Controls.Add(this.comboBox_subject_name);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBox_state);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_department_name);
            this.panel1.Controls.Add(this.textbox_sno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox_school_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(43, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 73);
            this.panel1.TabIndex = 63;
            // 
            // comboBox_class_name
            // 
            this.comboBox_class_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_class_name.FormattingEnabled = true;
            this.comboBox_class_name.Location = new System.Drawing.Point(533, 25);
            this.comboBox_class_name.Name = "comboBox_class_name";
            this.comboBox_class_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_class_name.TabIndex = 41;
            // 
            // comboBox_subject_name
            // 
            this.comboBox_subject_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_subject_name.FormattingEnabled = true;
            this.comboBox_subject_name.Location = new System.Drawing.Point(362, 25);
            this.comboBox_subject_name.Name = "comboBox_subject_name";
            this.comboBox_subject_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_subject_name.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "班级";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "专业";
            // 
            // comboBox_department_name
            // 
            this.comboBox_department_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_department_name.FormattingEnabled = true;
            this.comboBox_department_name.Location = new System.Drawing.Point(194, 28);
            this.comboBox_department_name.Name = "comboBox_department_name";
            this.comboBox_department_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_department_name.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "系";
            // 
            // comboBox_school_name
            // 
            this.comboBox_school_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_school_name.FormattingEnabled = true;
            this.comboBox_school_name.Location = new System.Drawing.Point(39, 28);
            this.comboBox_school_name.Name = "comboBox_school_name";
            this.comboBox_school_name.Size = new System.Drawing.Size(100, 20);
            this.comboBox_school_name.TabIndex = 35;
            this.comboBox_school_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_school_name_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "学院";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询条件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 25);
            this.menuStrip1.TabIndex = 64;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询条件ToolStripMenuItem
            // 
            this.查询条件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础ToolStripMenuItem});
            this.查询条件ToolStripMenuItem.Name = "查询条件ToolStripMenuItem";
            this.查询条件ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查询条件ToolStripMenuItem.Text = "查询条件";
            // 
            // 基础ToolStripMenuItem
            // 
            this.基础ToolStripMenuItem.Name = "基础ToolStripMenuItem";
            this.基础ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.基础ToolStripMenuItem.Text = "基础";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_end_time);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox_weekday);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_again_time);
            this.panel2.Controls.Add(this.comboBox_course_section);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(43, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 68);
            this.panel2.TabIndex = 65;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_course_name);
            this.panel3.Controls.Add(this.comboBox_scheduling_id);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(43, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 71);
            this.panel3.TabIndex = 66;
            // 
            // data_table
            // 
            this.data_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addtime,
            this.sno,
            this.sname,
            this.class_name,
            this.course_name,
            this.place,
            this.course_sections,
            this.teacher_name,
            this.counselor_name,
            this.state});
            this.data_table.Location = new System.Drawing.Point(53, 301);
            this.data_table.Name = "data_table";
            this.data_table.RowTemplate.Height = 23;
            this.data_table.Size = new System.Drawing.Size(954, 249);
            this.data_table.TabIndex = 67;
            // 
            // comboBox_scheduling_id
            // 
            this.comboBox_scheduling_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scheduling_id.FormattingEnabled = true;
            this.comboBox_scheduling_id.Location = new System.Drawing.Point(72, 27);
            this.comboBox_scheduling_id.Name = "comboBox_scheduling_id";
            this.comboBox_scheduling_id.Size = new System.Drawing.Size(100, 20);
            this.comboBox_scheduling_id.TabIndex = 51;
            this.comboBox_scheduling_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_scheduling_id_SelectedIndexChanged);
            // 
            // label_course_name
            // 
            this.label_course_name.AutoSize = true;
            this.label_course_name.Location = new System.Drawing.Point(253, 30);
            this.label_course_name.Name = "label_course_name";
            this.label_course_name.Size = new System.Drawing.Size(41, 12);
            this.label_course_name.TabIndex = 52;
            this.label_course_name.Text = "课程名";
            // 
            // addtime
            // 
            this.addtime.HeaderText = "打卡时间";
            this.addtime.Name = "addtime";
            // 
            // sno
            // 
            this.sno.HeaderText = "学号";
            this.sno.Name = "sno";
            // 
            // sname
            // 
            this.sname.HeaderText = "姓名";
            this.sname.Name = "sname";
            // 
            // class_name
            // 
            this.class_name.HeaderText = "班级";
            this.class_name.Name = "class_name";
            // 
            // course_name
            // 
            this.course_name.HeaderText = "课程名";
            this.course_name.Name = "course_name";
            // 
            // place
            // 
            this.place.HeaderText = "地点";
            this.place.Name = "place";
            // 
            // course_sections
            // 
            this.course_sections.HeaderText = "节次";
            this.course_sections.Name = "course_sections";
            // 
            // teacher_name
            // 
            this.teacher_name.HeaderText = "教师";
            this.teacher_name.Name = "teacher_name";
            // 
            // counselor_name
            // 
            this.counselor_name.HeaderText = "辅导员";
            this.counselor_name.Name = "counselor_name";
            // 
            // state
            // 
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            // 
            // Attendence_info_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 611);
            this.Controls.Add(this.data_table);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.load_sno_btn);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Attendence_info_manage";
            this.Text = "Attendence_info_manage";
            this.Load += new System.EventHandler(this.Attendence_info_manage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_sno_btn;
        private System.Windows.Forms.TextBox textbox_sno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_weekday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_again_time;
        private System.Windows.Forms.TextBox textBox_end_time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_course_section;
        private System.Windows.Forms.ComboBox comboBox_state;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询条件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基础ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_class_name;
        private System.Windows.Forms.ComboBox comboBox_subject_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_department_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_school_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView data_table;
        private System.Windows.Forms.Label label_course_name;
        private System.Windows.Forms.ComboBox comboBox_scheduling_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn addtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn place;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_sections;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacher_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn counselor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
    }
}