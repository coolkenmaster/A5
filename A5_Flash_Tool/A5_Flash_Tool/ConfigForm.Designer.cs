using System.Windows.Forms;

namespace A5_Flash_Tool
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.ConfigForm_menuStrip = new System.Windows.Forms.MenuStrip();
            this.ConfigForm_language_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigForm_language_MenuItem_en = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigForm_language_MenuItem_zh = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigForm_groupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfigForm_cance_button = new System.Windows.Forms.Button();
            this.ConfigForm_summit_button = new System.Windows.Forms.Button();
            this.ConfigForm_test_button = new System.Windows.Forms.Button();
            this.ConfigForm_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfigForm_user_name_textBox = new System.Windows.Forms.TextBox();
            this.ConfigForm_password_textBox = new System.Windows.Forms.TextBox();
            this.ConfigForm_ip_textBox = new System.Windows.Forms.TextBox();
            this.ConfigForm_prot_textBox = new System.Windows.Forms.TextBox();
            this.ConfigForm_data_name_textBox = new System.Windows.Forms.TextBox();
            this.ConfigForm_user_name_label = new System.Windows.Forms.Label();
            this.ConfigForm_password_label = new System.Windows.Forms.Label();
            this.ConfigForm_ip_label = new System.Windows.Forms.Label();
            this.ConfigForm_prot_label = new System.Windows.Forms.Label();
            this.ConfigForm_data_name_label = new System.Windows.Forms.Label();
            this.ConfigForm_menuStrip.SuspendLayout();
            this.ConfigForm_groupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ConfigForm_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigForm_menuStrip
            // 
            this.ConfigForm_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigForm_language_MenuItem});
            this.ConfigForm_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.ConfigForm_menuStrip.Name = "ConfigForm_menuStrip";
            this.ConfigForm_menuStrip.Size = new System.Drawing.Size(445, 25);
            this.ConfigForm_menuStrip.TabIndex = 0;
            this.ConfigForm_menuStrip.Text = "menuStrip1";
            // 
            // ConfigForm_language_MenuItem
            // 
            this.ConfigForm_language_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigForm_language_MenuItem_en,
            this.ConfigForm_language_MenuItem_zh});
            this.ConfigForm_language_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ConfigForm_language_MenuItem.Image")));
            this.ConfigForm_language_MenuItem.Name = "ConfigForm_language_MenuItem";
            this.ConfigForm_language_MenuItem.Size = new System.Drawing.Size(60, 21);
            this.ConfigForm_language_MenuItem.Text = "语言";
            // 
            // ConfigForm_language_MenuItem_en
            // 
            this.ConfigForm_language_MenuItem_en.Image = ((System.Drawing.Image)(resources.GetObject("ConfigForm_language_MenuItem_en.Image")));
            this.ConfigForm_language_MenuItem_en.Name = "ConfigForm_language_MenuItem_en";
            this.ConfigForm_language_MenuItem_en.Size = new System.Drawing.Size(100, 22);
            this.ConfigForm_language_MenuItem_en.Text = "英文";
            this.ConfigForm_language_MenuItem_en.Click += new System.EventHandler(this.ConfigForm_language_MenuItem_en_Click);
            // 
            // ConfigForm_language_MenuItem_zh
            // 
            this.ConfigForm_language_MenuItem_zh.Image = ((System.Drawing.Image)(resources.GetObject("ConfigForm_language_MenuItem_zh.Image")));
            this.ConfigForm_language_MenuItem_zh.Name = "ConfigForm_language_MenuItem_zh";
            this.ConfigForm_language_MenuItem_zh.Size = new System.Drawing.Size(100, 22);
            this.ConfigForm_language_MenuItem_zh.Text = "中文";
            this.ConfigForm_language_MenuItem_zh.Click += new System.EventHandler(this.ConfigForm_language_MenuItem_zh_Click);
            // 
            // ConfigForm_groupBox
            // 
            this.ConfigForm_groupBox.Controls.Add(this.panel1);
            this.ConfigForm_groupBox.Controls.Add(this.ConfigForm_tableLayoutPanel);
            this.ConfigForm_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigForm_groupBox.Location = new System.Drawing.Point(0, 25);
            this.ConfigForm_groupBox.Name = "ConfigForm_groupBox";
            this.ConfigForm_groupBox.Size = new System.Drawing.Size(445, 388);
            this.ConfigForm_groupBox.TabIndex = 1;
            this.ConfigForm_groupBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConfigForm_cance_button);
            this.panel1.Controls.Add(this.ConfigForm_summit_button);
            this.panel1.Controls.Add(this.ConfigForm_test_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 67);
            this.panel1.TabIndex = 1;
            // 
            // ConfigForm_cance_button
            // 
            this.ConfigForm_cance_button.Location = new System.Drawing.Point(282, 17);
            this.ConfigForm_cance_button.Name = "ConfigForm_cance_button";
            this.ConfigForm_cance_button.Size = new System.Drawing.Size(75, 32);
            this.ConfigForm_cance_button.TabIndex = 2;
            this.ConfigForm_cance_button.Text = "取消";
            this.ConfigForm_cance_button.UseVisualStyleBackColor = true;
            this.ConfigForm_cance_button.Click += new System.EventHandler(this.ConfigForm_cance_button_Click);
            // 
            // ConfigForm_summit_button
            // 
            this.ConfigForm_summit_button.Location = new System.Drawing.Point(184, 17);
            this.ConfigForm_summit_button.Name = "ConfigForm_summit_button";
            this.ConfigForm_summit_button.Size = new System.Drawing.Size(75, 32);
            this.ConfigForm_summit_button.TabIndex = 1;
            this.ConfigForm_summit_button.Text = "确定";
            this.ConfigForm_summit_button.UseVisualStyleBackColor = true;
            this.ConfigForm_summit_button.Click += new System.EventHandler(this.ConfigForm_summit_button_Click);
            // 
            // ConfigForm_test_button
            // 
            this.ConfigForm_test_button.Location = new System.Drawing.Point(91, 17);
            this.ConfigForm_test_button.Name = "ConfigForm_test_button";
            this.ConfigForm_test_button.Size = new System.Drawing.Size(75, 32);
            this.ConfigForm_test_button.TabIndex = 0;
            this.ConfigForm_test_button.Text = "连接测试";
            this.ConfigForm_test_button.UseVisualStyleBackColor = true;
            this.ConfigForm_test_button.Click += new System.EventHandler(this.ConfigForm_test_button_Click);
            // 
            // ConfigForm_tableLayoutPanel
            // 
            this.ConfigForm_tableLayoutPanel.ColumnCount = 2;
            this.ConfigForm_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.33584F));
            this.ConfigForm_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.66416F));
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_user_name_textBox, 1, 0);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_password_textBox, 1, 1);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_ip_textBox, 1, 2);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_prot_textBox, 1, 3);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_data_name_textBox, 1, 4);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_user_name_label, 0, 0);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_password_label, 0, 1);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_ip_label, 0, 2);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_prot_label, 0, 3);
            this.ConfigForm_tableLayoutPanel.Controls.Add(this.ConfigForm_data_name_label, 0, 4);
            this.ConfigForm_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigForm_tableLayoutPanel.Location = new System.Drawing.Point(3, 17);
            this.ConfigForm_tableLayoutPanel.Name = "ConfigForm_tableLayoutPanel";
            this.ConfigForm_tableLayoutPanel.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.ConfigForm_tableLayoutPanel.RowCount = 6;
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.ConfigForm_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConfigForm_tableLayoutPanel.Size = new System.Drawing.Size(439, 368);
            this.ConfigForm_tableLayoutPanel.TabIndex = 0;
            // 
            // ConfigForm_user_name_textBox
            // 
            this.ConfigForm_user_name_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConfigForm_user_name_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_user_name_textBox.Location = new System.Drawing.Point(159, 24);
            this.ConfigForm_user_name_textBox.Name = "ConfigForm_user_name_textBox";
            this.ConfigForm_user_name_textBox.Size = new System.Drawing.Size(200, 26);
            this.ConfigForm_user_name_textBox.TabIndex = 0;
            // 
            // ConfigForm_password_textBox
            // 
            this.ConfigForm_password_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConfigForm_password_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_password_textBox.Location = new System.Drawing.Point(159, 82);
            this.ConfigForm_password_textBox.Name = "ConfigForm_password_textBox";
            this.ConfigForm_password_textBox.Size = new System.Drawing.Size(200, 26);
            this.ConfigForm_password_textBox.TabIndex = 1;
            // 
            // ConfigForm_ip_textBox
            // 
            this.ConfigForm_ip_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConfigForm_ip_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_ip_textBox.Location = new System.Drawing.Point(159, 140);
            this.ConfigForm_ip_textBox.Name = "ConfigForm_ip_textBox";
            this.ConfigForm_ip_textBox.Size = new System.Drawing.Size(200, 26);
            this.ConfigForm_ip_textBox.TabIndex = 2;
            // 
            // ConfigForm_prot_textBox
            // 
            this.ConfigForm_prot_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConfigForm_prot_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_prot_textBox.Location = new System.Drawing.Point(159, 198);
            this.ConfigForm_prot_textBox.Name = "ConfigForm_prot_textBox";
            this.ConfigForm_prot_textBox.Size = new System.Drawing.Size(200, 26);
            this.ConfigForm_prot_textBox.TabIndex = 3;
            // 
            // ConfigForm_data_name_textBox
            // 
            this.ConfigForm_data_name_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConfigForm_data_name_textBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_data_name_textBox.Location = new System.Drawing.Point(159, 256);
            this.ConfigForm_data_name_textBox.Name = "ConfigForm_data_name_textBox";
            this.ConfigForm_data_name_textBox.Size = new System.Drawing.Size(200, 26);
            this.ConfigForm_data_name_textBox.TabIndex = 4;
            // 
            // ConfigForm_user_name_label
            // 
            this.ConfigForm_user_name_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConfigForm_user_name_label.AutoSize = true;
            this.ConfigForm_user_name_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_user_name_label.Location = new System.Drawing.Point(90, 30);
            this.ConfigForm_user_name_label.Name = "ConfigForm_user_name_label";
            this.ConfigForm_user_name_label.Size = new System.Drawing.Size(63, 14);
            this.ConfigForm_user_name_label.TabIndex = 0;
            this.ConfigForm_user_name_label.Text = "用户名：";
            // 
            // ConfigForm_password_label
            // 
            this.ConfigForm_password_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConfigForm_password_label.AutoSize = true;
            this.ConfigForm_password_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_password_label.Location = new System.Drawing.Point(104, 88);
            this.ConfigForm_password_label.Name = "ConfigForm_password_label";
            this.ConfigForm_password_label.Size = new System.Drawing.Size(49, 14);
            this.ConfigForm_password_label.TabIndex = 1;
            this.ConfigForm_password_label.Text = "密码：";
            // 
            // ConfigForm_ip_label
            // 
            this.ConfigForm_ip_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConfigForm_ip_label.AutoSize = true;
            this.ConfigForm_ip_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_ip_label.Location = new System.Drawing.Point(90, 146);
            this.ConfigForm_ip_label.Name = "ConfigForm_ip_label";
            this.ConfigForm_ip_label.Size = new System.Drawing.Size(63, 14);
            this.ConfigForm_ip_label.TabIndex = 2;
            this.ConfigForm_ip_label.Text = "IP地址：";
            // 
            // ConfigForm_prot_label
            // 
            this.ConfigForm_prot_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConfigForm_prot_label.AutoSize = true;
            this.ConfigForm_prot_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_prot_label.Location = new System.Drawing.Point(90, 204);
            this.ConfigForm_prot_label.Name = "ConfigForm_prot_label";
            this.ConfigForm_prot_label.Size = new System.Drawing.Size(63, 14);
            this.ConfigForm_prot_label.TabIndex = 3;
            this.ConfigForm_prot_label.Text = "端口号：";
            // 
            // ConfigForm_data_name_label
            // 
            this.ConfigForm_data_name_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConfigForm_data_name_label.AutoSize = true;
            this.ConfigForm_data_name_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigForm_data_name_label.Location = new System.Drawing.Point(90, 262);
            this.ConfigForm_data_name_label.Name = "ConfigForm_data_name_label";
            this.ConfigForm_data_name_label.Size = new System.Drawing.Size(63, 14);
            this.ConfigForm_data_name_label.TabIndex = 4;
            this.ConfigForm_data_name_label.Text = "实例名：";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 413);
            this.Controls.Add(this.ConfigForm_groupBox);
            this.Controls.Add(this.ConfigForm_menuStrip);
            this.MainMenuStrip = this.ConfigForm_menuStrip;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接配置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ConfigForm_menuStrip.ResumeLayout(false);
            this.ConfigForm_menuStrip.PerformLayout();
            this.ConfigForm_groupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ConfigForm_tableLayoutPanel.ResumeLayout(false);
            this.ConfigForm_tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ConfigForm_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ConfigForm_language_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigForm_language_MenuItem_en;
        private System.Windows.Forms.ToolStripMenuItem ConfigForm_language_MenuItem_zh;
        private System.Windows.Forms.GroupBox ConfigForm_groupBox;
        private System.Windows.Forms.TableLayoutPanel ConfigForm_tableLayoutPanel;
        private Label ConfigForm_user_name_label;
        private Label ConfigForm_password_label;
        private Label ConfigForm_ip_label;
        private Label ConfigForm_prot_label;
        private Label ConfigForm_data_name_label;
        private TextBox ConfigForm_data_name_textBox;
        private TextBox ConfigForm_prot_textBox;
        private TextBox ConfigForm_ip_textBox;
        private TextBox ConfigForm_password_textBox;
        private TextBox ConfigForm_user_name_textBox;
        private Panel panel1;
        private Button ConfigForm_cance_button;
        private Button ConfigForm_summit_button;
        private Button ConfigForm_test_button;
    }
}