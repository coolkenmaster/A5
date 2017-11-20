using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Client;

namespace A5_Flash_Tool
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //语言切换（英文）
        private void login_language_MenuItem_en_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("en-US", this, typeof(Login));
        }
        //语言切换（中文）
        private void login_language_MenuItem_zh_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("zh-CN", this, typeof(Login));
        }

        //登录事件
        private void login_submit_button_Click(object sender, EventArgs e)
        {
            Boolean flg = false;
            if (Common.Language.Equals("zh-CN")) {
                login_msg_label.Text = "正在登录中,请稍候...";
            } else {
                login_msg_label.Text = "Logging, please wait...";
            }
            login_submit_button.Enabled = false;
            login_cancel_button.Enabled = false;
            Application.DoEvents();
            byte[] result = Encoding.Default.GetBytes(this.login_password_textBox.Text.Trim());    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String pwd = BitConverter.ToString(output).Replace("-", "");
            String account = this.login_account_textBox.Text.Trim();

            string cmdText = "select * from wp_person where wp_account = :wp_account and upper(wp_password)=upper(:wp_password)";
           
            OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":wp_account",OracleDbType.Varchar2,40),
                new OracleParameter(":wp_password",OracleDbType.Varchar2,40)

            };
            commandParameters[0].Value = account;
            commandParameters[1].Value = pwd;

            DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
            
            if (datatable!=null&&datatable.Rows.Count > 0)
            {
                flg = true;
            }
            
            if (flg)
            {
                string cmdText1 = "select* from a5_station where station_pc = :station_pc";

                OracleParameter[] commandParameters1 = new OracleParameter[]{
                new OracleParameter(":station_pc",OracleDbType.Varchar2,40)
                 };
                commandParameters1[0].Value = Common.pc_name;

                DataTable datatable1 = Jdbc.ExecuteDataTable(cmdText1, commandParameters1);
                if (datatable1 != null && datatable1.Rows.Count > 0)
                {
                    flg = true;
                }
                else {
                    flg = false;
                }
                if (flg)
                {
                    Common.login_user = datatable.Rows[0]["wp_name"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else {
                    login_msg_label.Text = Common.pc_name+" 没有配置工位信息！";
                    login_submit_button.Enabled = true;
                    login_cancel_button.Enabled = true;
                }
            }
            else {
                if (Common.Language.Equals("zh-CN"))
                {
                    login_msg_label.Text = "账号或密码错误！";
                }
                else
                {
                    login_msg_label.Text = "Account or password error!";
                }
                login_submit_button.Enabled = true;
                login_cancel_button.Enabled = true;
            }
           
        }
        //取消登录
        private void login_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_config_MenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("zh-CN", this, typeof(Login));
        }

        private void csToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "http://cdn.bootcss.com/jquery/2.2.4/jquery.min.js";
            string fileName = FileHandler.DownloadFile(url);
            if (!String.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("文件下载成功，文件名称：" + fileName);

                string cmdText = "select * from a5_file where file_name = :file_name";

                OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":file_name",OracleDbType.Varchar2,40)
                };
                commandParameters[0].Value = "TN00002V69.fls";

                DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                if (datatable.Rows.Count > 0)
                {
                    DataRow dr = datatable.Rows[0];
                    String source_file = dr["source_file"].ToString();//变速箱编号

                    //Console.WriteLine("haha" + source_file);
                    FileHandler.createFile("TN00002V69.fls", source_file);
                }
            }
            else
            {
                Console.WriteLine("文件下载失败");
            }
            Console.ReadLine();
        }

        private void 写库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sql = "insert into a5_interface_logs"+
            "(create_date, station_code, pc_name, start_time, end_time, logs_describe, severity, error_msg, transmission_sn, create_user)"+
            " values ("+
            " sysdate, :v_station_code, :v_pc_name, sysdate, sysdate, :v_logs_describe, null, null, '01', null)";
            
            OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":v_station_code",OracleDbType.Varchar2,40),
                 new OracleParameter(":v_pc_name",OracleDbType.Varchar2,40),
                 new OracleParameter(":v_logs_describe",OracleDbType.Varchar2,4000)
            };

            commandParameters[0].Value = "100001";
            commandParameters[1].Value = "第一个工位";
            commandParameters[2].Value = "测试描述";
            int i = Jdbc.ExecuteNonQuery(sql, commandParameters);
            Console.WriteLine("i="+i);
        }
    }
}
