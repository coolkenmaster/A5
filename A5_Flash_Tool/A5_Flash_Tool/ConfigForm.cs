using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A5_Flash_Tool
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_summit_button_Click(object sender, EventArgs e)
        {
            String username = ConfigForm_user_name_textBox.Text;
            String password = ConfigForm_password_textBox.Text;
            String ip = ConfigForm_ip_textBox.Text;
            String prot = ConfigForm_prot_textBox.Text;
            String dataname = ConfigForm_data_name_textBox.Text;

            //保存到配置文件
            ConfigHelper.UpdateAppConfig("jdbc_user", username);
            ConfigHelper.UpdateAppConfig("jdbc_password", password);
            ConfigHelper.UpdateAppConfig("jdbc_ip", ip);
            ConfigHelper.UpdateAppConfig("jdbc_prot", prot);
            ConfigHelper.UpdateAppConfig("jdbc_data_name", dataname);
            //更新连接配置到全局变量
            Common.loadConfig();
            //关闭窗体
            this.Close();
        }

        private void ConfigForm_test_button_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigForm_test_button.Enabled = false;
                ConfigForm_summit_button.Enabled = false;
                ConfigForm_cance_button.Enabled = false;
                String username = ConfigForm_user_name_textBox.Text;
                String password = ConfigForm_password_textBox.Text;
                String ip = ConfigForm_ip_textBox.Text;
                String prot = ConfigForm_prot_textBox.Text;
                String dataname = ConfigForm_data_name_textBox.Text;
                Jdbc.Test(username, password, ip, prot, dataname);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败："+ ex.Message);
            }
            finally {
                ConfigForm_test_button.Enabled = true;
                ConfigForm_summit_button.Enabled = true;
                ConfigForm_cance_button.Enabled = true;
            }
        }

        private void ConfigForm_cance_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigForm_language_MenuItem_en_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("en-US", this, typeof(ConfigForm));
        }

        private void ConfigForm_language_MenuItem_zh_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("zh-CN", this, typeof(ConfigForm));
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            ConfigForm_user_name_textBox.Text = Common.jdbc_user;
            ConfigForm_password_textBox.Text = Common.jdbc_password;
            ConfigForm_ip_textBox.Text = Common.jdbc_ip;
            ConfigForm_prot_textBox.Text = Common.jdbc_prot;
            ConfigForm_data_name_textBox.Text = Common.jdbc_data_name;
        }
    }
}
