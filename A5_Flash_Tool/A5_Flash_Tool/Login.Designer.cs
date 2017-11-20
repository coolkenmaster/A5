namespace A5_Flash_Tool
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_submit_button = new System.Windows.Forms.Button();
            this.login_menuStrip = new System.Windows.Forms.MenuStrip();
            this.login_language_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.login_language_MenuItem_en = new System.Windows.Forms.ToolStripMenuItem();
            this.login_language_MenuItem_zh = new System.Windows.Forms.ToolStripMenuItem();
            this.login_config_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.login_cancel_button = new System.Windows.Forms.Button();
            this.login_account_textBox = new System.Windows.Forms.TextBox();
            this.login_password_textBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.login_groupBox = new System.Windows.Forms.GroupBox();
            this.login_msg_label = new System.Windows.Forms.Label();
            this.login_menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.login_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_submit_button
            // 
            this.login_submit_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_submit_button.Location = new System.Drawing.Point(176, 142);
            this.login_submit_button.Name = "login_submit_button";
            this.login_submit_button.Size = new System.Drawing.Size(106, 32);
            this.login_submit_button.TabIndex = 1;
            this.login_submit_button.Text = "登录";
            this.login_submit_button.UseVisualStyleBackColor = true;
            this.login_submit_button.Click += new System.EventHandler(this.login_submit_button_Click);
            // 
            // login_menuStrip
            // 
            this.login_menuStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.login_language_MenuItem,
            this.login_config_MenuItem});
            this.login_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.login_menuStrip.Name = "login_menuStrip";
            this.login_menuStrip.Size = new System.Drawing.Size(428, 28);
            this.login_menuStrip.TabIndex = 2;
            this.login_menuStrip.Text = "menuStrip1";
            // 
            // login_language_MenuItem
            // 
            this.login_language_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.login_language_MenuItem_en,
            this.login_language_MenuItem_zh});
            this.login_language_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("login_language_MenuItem.Image")));
            this.login_language_MenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.login_language_MenuItem.Name = "login_language_MenuItem";
            this.login_language_MenuItem.Size = new System.Drawing.Size(65, 24);
            this.login_language_MenuItem.Text = "语言";
            // 
            // login_language_MenuItem_en
            // 
            this.login_language_MenuItem_en.Image = ((System.Drawing.Image)(resources.GetObject("login_language_MenuItem_en.Image")));
            this.login_language_MenuItem_en.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.login_language_MenuItem_en.Name = "login_language_MenuItem_en";
            this.login_language_MenuItem_en.Size = new System.Drawing.Size(106, 24);
            this.login_language_MenuItem_en.Text = "英文";
            this.login_language_MenuItem_en.Click += new System.EventHandler(this.login_language_MenuItem_en_Click);
            // 
            // login_language_MenuItem_zh
            // 
            this.login_language_MenuItem_zh.Image = ((System.Drawing.Image)(resources.GetObject("login_language_MenuItem_zh.Image")));
            this.login_language_MenuItem_zh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.login_language_MenuItem_zh.Name = "login_language_MenuItem_zh";
            this.login_language_MenuItem_zh.Size = new System.Drawing.Size(106, 24);
            this.login_language_MenuItem_zh.Text = "中文";
            this.login_language_MenuItem_zh.Click += new System.EventHandler(this.login_language_MenuItem_zh_Click);
            // 
            // login_config_MenuItem
            // 
            this.login_config_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("login_config_MenuItem.Image")));
            this.login_config_MenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.login_config_MenuItem.Name = "login_config_MenuItem";
            this.login_config_MenuItem.Size = new System.Drawing.Size(65, 24);
            this.login_config_MenuItem.Text = "配置";
            this.login_config_MenuItem.Click += new System.EventHandler(this.login_config_MenuItem_Click);
            // 
            // login_cancel_button
            // 
            this.login_cancel_button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_cancel_button.Location = new System.Drawing.Point(308, 142);
            this.login_cancel_button.Name = "login_cancel_button";
            this.login_cancel_button.Size = new System.Drawing.Size(108, 32);
            this.login_cancel_button.TabIndex = 2;
            this.login_cancel_button.Text = "取消";
            this.login_cancel_button.UseVisualStyleBackColor = true;
            this.login_cancel_button.Click += new System.EventHandler(this.login_cancel_button_Click);
            // 
            // login_account_textBox
            // 
            this.login_account_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_account_textBox.Location = new System.Drawing.Point(46, 28);
            this.login_account_textBox.MaxLength = 20;
            this.login_account_textBox.Name = "login_account_textBox";
            this.login_account_textBox.Size = new System.Drawing.Size(188, 26);
            this.login_account_textBox.TabIndex = 4;
            // 
            // login_password_textBox
            // 
            this.login_password_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password_textBox.Location = new System.Drawing.Point(46, 66);
            this.login_password_textBox.MaxLength = 20;
            this.login_password_textBox.Name = "login_password_textBox";
            this.login_password_textBox.PasswordChar = '*';
            this.login_password_textBox.Size = new System.Drawing.Size(188, 26);
            this.login_password_textBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(13, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(157, 145);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // login_groupBox
            // 
            this.login_groupBox.Controls.Add(this.login_password_textBox);
            this.login_groupBox.Controls.Add(this.login_account_textBox);
            this.login_groupBox.Controls.Add(this.pictureBox2);
            this.login_groupBox.Controls.Add(this.pictureBox1);
            this.login_groupBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_groupBox.Location = new System.Drawing.Point(176, 30);
            this.login_groupBox.Name = "login_groupBox";
            this.login_groupBox.Size = new System.Drawing.Size(240, 106);
            this.login_groupBox.TabIndex = 0;
            this.login_groupBox.TabStop = false;
            this.login_groupBox.Text = "用户登录";
            // 
            // login_msg_label
            // 
            this.login_msg_label.AutoSize = true;
            this.login_msg_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_msg_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(112)))), ((int)(((byte)(143)))));
            this.login_msg_label.Location = new System.Drawing.Point(188, 189);
            this.login_msg_label.Name = "login_msg_label";
            this.login_msg_label.Size = new System.Drawing.Size(0, 14);
            this.login_msg_label.TabIndex = 11;
            // 
            // Login
            // 
            this.AcceptButton = this.login_submit_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 224);
            this.Controls.Add(this.login_msg_label);
            this.Controls.Add(this.login_groupBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.login_cancel_button);
            this.Controls.Add(this.login_submit_button);
            this.Controls.Add(this.login_menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.login_menuStrip;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "西安双特智能传动有限公司";
            this.Load += new System.EventHandler(this.Login_Load);
            this.login_menuStrip.ResumeLayout(false);
            this.login_menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.login_groupBox.ResumeLayout(false);
            this.login_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_submit_button;
        private System.Windows.Forms.MenuStrip login_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem login_language_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem login_language_MenuItem_en;
        private System.Windows.Forms.ToolStripMenuItem login_language_MenuItem_zh;
        private System.Windows.Forms.Button login_cancel_button;
        private System.Windows.Forms.TextBox login_account_textBox;
        private System.Windows.Forms.TextBox login_password_textBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox login_groupBox;
        private System.Windows.Forms.Label login_msg_label;
        private System.Windows.Forms.ToolStripMenuItem login_config_MenuItem;
    }
}

