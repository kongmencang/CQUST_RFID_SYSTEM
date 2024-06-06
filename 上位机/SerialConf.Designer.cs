namespace CqustRfidSystem
{
    partial class SerialConf
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.p_lable = new System.Windows.Forms.Label();
            this.b_lable = new System.Windows.Forms.Label();
            this.PortName = new System.Windows.Forms.ComboBox();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.commit = new System.Windows.Forms.Button();
            this.Serialport1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // p_lable
            // 
            this.p_lable.AutoSize = true;
            this.p_lable.BackColor = System.Drawing.Color.Transparent;
            this.p_lable.Font = new System.Drawing.Font("宋体", 15F);
            this.p_lable.Location = new System.Drawing.Point(25, 29);
            this.p_lable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p_lable.Name = "p_lable";
            this.p_lable.Size = new System.Drawing.Size(69, 20);
            this.p_lable.TabIndex = 28;
            this.p_lable.Text = "串口号";
            // 
            // b_lable
            // 
            this.b_lable.AutoSize = true;
            this.b_lable.BackColor = System.Drawing.Color.Transparent;
            this.b_lable.Font = new System.Drawing.Font("宋体", 15F);
            this.b_lable.Location = new System.Drawing.Point(25, 76);
            this.b_lable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.b_lable.Name = "b_lable";
            this.b_lable.Size = new System.Drawing.Size(69, 20);
            this.b_lable.TabIndex = 29;
            this.b_lable.Text = "波特率";
            // 
            // PortName
            // 
            this.PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName.Font = new System.Drawing.Font("宋体", 12F);
            this.PortName.FormattingEnabled = true;
            this.PortName.Location = new System.Drawing.Point(118, 25);
            this.PortName.Margin = new System.Windows.Forms.Padding(2);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(92, 24);
            this.PortName.TabIndex = 30;
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
            this.BaudRate.Location = new System.Drawing.Point(117, 76);
            this.BaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(92, 24);
            this.BaudRate.TabIndex = 31;
            // 
            // commit
            // 
            this.commit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.commit.FlatAppearance.BorderSize = 0;
            this.commit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(151)))), ((int)(((byte)(226)))));
            this.commit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commit.Font = new System.Drawing.Font("宋体", 12F);
            this.commit.Location = new System.Drawing.Point(68, 126);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(75, 23);
            this.commit.TabIndex = 35;
            this.commit.Text = "确认";
            this.commit.UseVisualStyleBackColor = false;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // SerialConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 189);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.PortName);
            this.Controls.Add(this.b_lable);
            this.Controls.Add(this.p_lable);
            this.Name = "SerialConf";
            this.Text = "串口设置";
            this.Load += new System.EventHandler(this.SerialConf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label p_lable;
        private System.Windows.Forms.Label b_lable;
        private System.Windows.Forms.ComboBox PortName;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Button commit;
        private System.IO.Ports.SerialPort Serialport1;
    }
}

