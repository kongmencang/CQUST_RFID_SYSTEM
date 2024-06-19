namespace CqustRfidSystem
{
    partial class logincs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_is_pwd_visible = new System.Windows.Forms.PictureBox();
            this.user_password = new System.Windows.Forms.TextBox();
            this.user_id = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.login_but = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_title = new System.Windows.Forms.PictureBox();
            this.pictureBox_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_is_pwd_visible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox_is_pwd_visible);
            this.panel1.Controls.Add(this.user_password);
            this.panel1.Controls.Add(this.user_id);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.login_but);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(219, 188);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 161);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox_is_pwd_visible
            // 
            this.pictureBox_is_pwd_visible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_is_pwd_visible.Image = global::CqustRfidSystem.Properties.Resources.eye1;
            this.pictureBox_is_pwd_visible.Location = new System.Drawing.Point(253, 75);
            this.pictureBox_is_pwd_visible.Name = "pictureBox_is_pwd_visible";
            this.pictureBox_is_pwd_visible.Size = new System.Drawing.Size(33, 30);
            this.pictureBox_is_pwd_visible.TabIndex = 7;
            this.pictureBox_is_pwd_visible.TabStop = false;
            this.pictureBox_is_pwd_visible.Click += new System.EventHandler(this.pictureBox_is_pwd_visible_Click);
            // 
            // user_password
            // 
            this.user_password.Font = new System.Drawing.Font("宋体", 15F);
            this.user_password.Location = new System.Drawing.Point(101, 75);
            this.user_password.Margin = new System.Windows.Forms.Padding(2);
            this.user_password.Name = "user_password";
            this.user_password.PasswordChar = '*';
            this.user_password.Size = new System.Drawing.Size(144, 30);
            this.user_password.TabIndex = 3;
            // 
            // user_id
            // 
            this.user_id.Font = new System.Drawing.Font("宋体", 15F);
            this.user_id.Location = new System.Drawing.Point(101, 27);
            this.user_id.Margin = new System.Windows.Forms.Padding(2);
            this.user_id.MaxLength = 10;
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(144, 30);
            this.user_id.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(212)))), ((int)(((byte)(241)))));
            this.linkLabel1.Location = new System.Drawing.Point(59, 131);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(78, 23);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "忘记密码";
            // 
            // login_but
            // 
            this.login_but.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.login_but.FlatAppearance.BorderSize = 0;
            this.login_but.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(151)))), ((int)(((byte)(226)))));
            this.login_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_but.Location = new System.Drawing.Point(169, 127);
            this.login_but.Margin = new System.Windows.Forms.Padding(2);
            this.login_but.Name = "login_but";
            this.login_but.Size = new System.Drawing.Size(64, 27);
            this.login_but.TabIndex = 4;
            this.login_but.Text = "登录";
            this.login_but.UseVisualStyleBackColor = false;
            this.login_but.Click += new System.EventHandler(this.login_but_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(212)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(27, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(212)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(27, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // pictureBox_title
            // 
            this.pictureBox_title.BackgroundImage = global::CqustRfidSystem.Properties.Resources.logo;
            this.pictureBox_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_title.Location = new System.Drawing.Point(282, 10);
            this.pictureBox_title.Name = "pictureBox_title";
            this.pictureBox_title.Size = new System.Drawing.Size(202, 94);
            this.pictureBox_title.TabIndex = 18;
            this.pictureBox_title.TabStop = false;
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.BackgroundImage = global::CqustRfidSystem.Properties.Resources.闭眼1;
            this.pictureBox_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_left.Location = new System.Drawing.Point(25, 306);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(132, 134);
            this.pictureBox_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_left.TabIndex = 17;
            this.pictureBox_left.TabStop = false;
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_right.Image = global::CqustRfidSystem.Properties.Resources.闭眼;
            this.pictureBox_right.Location = new System.Drawing.Point(643, 306);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(132, 134);
            this.pictureBox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_right.TabIndex = 16;
            this.pictureBox_right.TabStop = false;
            // 
            // logincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox_title);
            this.Controls.Add(this.pictureBox_left);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.panel1);
            this.Name = "logincs";
            this.Text = "logincs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_is_pwd_visible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_title;
        private System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_is_pwd_visible;
        private System.Windows.Forms.TextBox user_password;
        private System.Windows.Forms.TextBox user_id;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button login_but;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}