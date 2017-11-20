using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace A5_Flash_Tool
{
    class FileHandler
    {
        private static String tempPath = Path.GetTempPath();//临时文件夹
        /// <summary>  
        /// 下载文件  
        /// </summary>  
        /// <param name="url">下载地址</param>  
        /// <returns>文件名称</returns>  
        public static string DownloadFile(string url)
        {
            try
            {
                string fileName = CreateFileName(url);
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                WebClient client = new WebClient();
                client.DownloadFile(url, tempPath +"\\"+ fileName);
                return fileName;
            }
            catch
            {
                return "";
            }
            //http://cdn.bootcss.com/jquery/2.2.4/jquery.min.js
        }
        public static string CreateFileName(string url)
        {
            string fileName = "";
            string fileExt = url.Substring(url.LastIndexOf(".")).Trim().ToLower();
            Random rnd = new Random();
            fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString() + fileExt;
            return fileName;
        }
        public static String createFile(String fileName,String data) {
            BinaryWriter bw = null;
            String path = "";
            try {
                fileName = CreateFileName(fileName);
                path = tempPath + "\\" + fileName;
                bw = new BinaryWriter(new FileStream(path, FileMode.Create));
           
                bw.Write(data.ToCharArray());
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
            }
            finally {
                if (bw != null)
                {
                bw.Close();
                }
            }
            return path;
        }
        public static string strtobytes(string s)
        {
            byte[] data = Encoding.Unicode.GetBytes(s);
            StringBuilder result = new StringBuilder(data.Length * 8);


            foreach (byte b in data)
            {
                result.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return result.ToString();
        }
    }
}
