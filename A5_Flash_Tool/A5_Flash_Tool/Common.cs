using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace A5_Flash_Tool
{
    class Common
    {
        public static string Language = "zh-CN";
        public static string Folder;//flash 存放目录

        public static string jdbc_user;
        public static string jdbc_password;
        public static string jdbc_ip;
        public static string jdbc_data_name;
        public static string jdbc_prot;
        public static string pc_name;
        public static string login_user = "未登录";

        //public static int adapter;//适配器
        //public static int com_port;//端口
        //public static int baud_rate;//传输速率
        public static void loadConfig() {
            Common.jdbc_user = ConfigHelper.GetAppConfig("jdbc_user");
            Common.jdbc_password = ConfigHelper.GetAppConfig("jdbc_password");
            Common.jdbc_ip = ConfigHelper.GetAppConfig("jdbc_ip");
            Common.jdbc_data_name = ConfigHelper.GetAppConfig("jdbc_data_name");
            Common.jdbc_prot = ConfigHelper.GetAppConfig("jdbc_prot");
            Common.Folder = ConfigHelper.GetAppConfig("folder");

            Common.pc_name = Dns.GetHostName();//获取本机的计算机名 
        }
    }
}
