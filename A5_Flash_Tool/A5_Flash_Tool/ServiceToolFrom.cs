using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FLASHSERVERLib;
using System.Threading;
using Oracle.ManagedDataAccess.Client;
using System.Net;

namespace A5_Flash_Tool
{
    public partial class ServiceToolFrom : Form, FLASHSERVERLib.IFlashDetectStatus, FLASHSERVERLib.IFlashValidationStatus, FLASHSERVERLib.IFlashStatus
    {
        #region 定义变量：处理接口

        //检测接口是否完成

        /// <summary>
        /// 设备检测过程是否完成
        /// </summary>
        public bool bFlashDetectStatus = false; //设备检测过程是否完成
        /// <summary>
        /// 文件校验过程是否完成
        /// </summary>
        public bool bFlashValidationStatus = false; //文件校验过程是否完成
        /// <summary>
        /// 刷写过程是否完成
        /// </summary>
        public bool bFlashStatus = false; //刷写过程是否完成

        //检测是否正确

        /// <summary>
        /// 设备是否已连接
        /// </summary>
        public bool bConnectFlag = false; //设备是否已连接
        /// <summary>
        /// 文件是否正确
        /// </summary>
        public bool bFileFlag = false; //文件是否正确
        /// <summary>
        /// 刷写是否正确
        /// </summary>
        public bool bFlashFlag = false; //刷写是否正确

        /// <summary>
        /// 错误代码
        /// </summary>
        public int iCode = 0;
        /// <summary>
        /// 错误描述
        /// </summary>
        public string sDescription = "";
        #endregion

        #region 定义变量：Flash常量
        public static string ClientLogin = "3A65BB15-1088-4373-AED4-07158E5EAC38";
        public static string AuthenticationKey = "EEB04F02CAEE07A60089D3642BBB1200654B0090FE";

        public FLASHSERVERLib.Flash m_FlashServer;
        public int m_DataLinkCount = 1;
        public FLASHSERVERLib.T_FLASH_DATALINK m_DataLinks;
        public FLASHSERVERLib.T_FLASH_COMPORT m_ComPort;
        public FLASHSERVERLib.T_FLASH_BAUDRATE m_BaudRate;
        public FLASHSERVERLib.T_FLASH_COMADAPTER m_ComAdapt;
        public FLASHSERVERLib.IControlCollection m_ControlCollection;
        #endregion

        #region 定义变量：刷写参数
        public static int wr_status;//变量写入状态 0 成功
        Dictionary<int, string> dic = new Dictionary<int, string> { };//读取变量
        public static Dictionary<int, string> wr_dic = new Dictionary<int, string> { };//写入变量
        #endregion

        #region 定义全局变量
        public static Boolean start_on_off = false;//查询到结果后状态变更为true；
        public static string flash_file_name;//Flash文件名称
        
        public static string station_code, station_name;
        public object OracleType { get; private set; }

        public static long logsid;
        public static long MsgIndex = 0; //刷写数据库日志顺序
        public static string start_time; //刷机开始时间
        public static string end_time;  //刷机结束时间
        #endregion

        #region 实现外部接口方法

        #region 设备接口

        //设备连接中
        void IFlashDetectStatus.DataLinkInProgress(T_FLASH_DATALINK DataLink)
        {
            string DLString = "";
            switch (DataLink)
            {
                case FLASHSERVERLib.T_FLASH_DATALINK.FLASH_DATALINK_PDL:
                    DLString = "PDL";
                    break;
                case FLASHSERVERLib.T_FLASH_DATALINK.FLASH_DATALINK_CDL:
                    DLString = "CDL";
                    break;
                case FLASHSERVERLib.T_FLASH_DATALINK.FLASH_DATALINK_J1939:
                    DLString = "J1939";
                    break;
                case FLASHSERVERLib.T_FLASH_DATALINK.FLASH_DATALINK_ATA:
                    DLString = "ATA";
                    break;
                default:
                    DLString = "Unknown";
                    break;
            }

            // 显示状态
            WriteMessageText("正在检测DataLink：" + DLString);
        }

        //设备连接完成
        void IFlashDetectStatus.DetectFinished(int DetectedControls)
        {
            bConnectFlag = false;

            if (DetectedControls == 0)
            {
                WriteMessageText("设备连接失败：没有检测到设备", true); //未上电触发
            }

            // 获取检测控件的集合
            FLASHSERVERLib.IControlCollection CAColl;
            FLASHSERVERLib.IControlInformation ControlInfo;
            this.m_FlashServer.GetDetectedControls(out CAColl);
            ControlInfo = CAColl.At(0);

            //如果检测到是A5
            if (ControlInfo.FlashType.ToString() == FLASHSERVERLib.__MIDL___MIDL_itf_FlashServer_0000_0008_0001.FLASHECM_TYPE_FLASHABLE.ToString())
            {
                WriteMessageText("设备连接成功！", true);
                bConnectFlag = true;
            }
            else {
                WriteMessageText("设备连接失败：TCU类型不是A5", true);
            }

            this.m_ControlCollection = CAColl;
            CAColl = null;
            
            bFlashDetectStatus = true;
        }

        //设备连接失败
        void IFlashDetectStatus.Error(int Code, string Description)
        {
            iCode = Code;
            sDescription = Description;

            if (Code != 0)
            {
                bConnectFlag = false;
                WriteMessageText("设备连接失败："+ "错误代码：" + Code.ToString() + "，错误信息：" + Description,true );
            }
        }

        #endregion

        #region 校验Flash文件接口

        //Flash文件校验完成
        void IFlashValidationStatus.Complete(int Result)
        {
            bFileFlag = false;

            if (Result != 0)
            {
                WriteMessageText("Flash文件校验错误：" + "错误代码：" + Result.ToString(), true);
            }
            else
            {
                bFileFlag = true;
                WriteMessageText("Flash文件校验完成！", true);
            }

            bFlashValidationStatus = true;
        }

       //Flash文件校验失败
        void IFlashValidationStatus.Error(int Code, string Description)
        {
            iCode = Code;
            sDescription = Description;

            if (Code > 0)
            {
                bFileFlag = false;
                WriteMessageText("Flash文件校验错误：" + "错误代码：" + Code.ToString() + "，错误信息：" + Description, true);
            }
        }

        //Flash文件校验出现警告
        void IFlashValidationStatus.Warning(int Code, string Description)
        {
            iCode = Code;
            sDescription = Description;

            if (Code > 0)
            {
                bFileFlag = false;
                WriteMessageText("Flash文件校验警告：" + "错误代码：" + Code.ToString() + "，错误信息：" + Description, true);
            }
        }

        #endregion

        #region 刷写Flash接口

        //Flash刷写进度
        void IFlashStatus.PercentageComplete(int Percent)
        {
            toolStripProgressBar1.Value = Percent;

            WriteMessageText("当前进度：" + Percent + "%", true);
        }

        //Flash刷写完成
        void IFlashStatus.Complete()
        {
            bFlashFlag = true;
            WriteMessageText("Flash刷写完成！",true);

            bFlashStatus = true;
        }

        //Flash刷写失败
        void IFlashStatus.Error(int Code, string Description)
        {
            iCode = Code;
            sDescription = Description;

            if (Code > 0)
            {
                bFlashFlag = false;
                WriteMessageText("Flash刷写错误：" + "错误代码：" + Code.ToString() + "，错误信息：" + Description, true);
            }
        }

        //Flash刷写警告
        void IFlashStatus.Warning(int Code, string Description)
        {
            iCode = Code;
            sDescription = Description;

            if (Code > 0)
            {
                bFlashFlag = false;
                WriteMessageText("Flash刷写警告：" + "错误代码：" + Code.ToString() + "，错误信息：" + Description, true);
            }
        }

        //Flash刷写状态
        void IFlashStatus.Status(string Description)
        {

        }
        
        #endregion

        #endregion

        public ServiceToolFrom()
        {
            InitializeComponent();
        }

        private void ServiceToolFrom_Load(object sender, EventArgs e)
        {
            //线程能安全的访问窗体控件
            Control.CheckForIllegalCrossThreadCalls = false;

            string hostInfo = Dns.GetHostName();
            String ip = "";
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                ip = addressList[i].ToString();
            }
            ServiceToolFrom_station_toolStripStatusLabel.Text = "工位IP:"+ip+"|机器名："+ Common.pc_name;
            
            string cmdText = "select* from a5_station where station_pc = :station_pc";

            OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":station_pc",OracleDbType.Varchar2,40)
            };
            commandParameters[0].Value = Common.pc_name;
            string station_id = "";
            DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
            if (datatable!=null&&datatable.Rows.Count > 0)
            {
                DataRow dr = datatable.Rows[0];
                station_code = dr["station_code"].ToString();//
                station_name = dr["station_name"].ToString();//
                station_id = dr["id"].ToString();
                ServiceToolFrom_station_toolStripStatusLabel.Text += "|"+station_name;
            }

            ServiceToolFrom_login_toolStripStatusLabel.Text = "操作员："+Common.login_user;
            ServiceToolFrom_statusStrip_msg.Text = "加载完成";

            string cmdText2 = "select distinct a.station_id,a.power_code,b.name from a5_station_power a join a5_dictionary b on a.power_code = b.code and "+
            "b.pid IN (select id from a5_dictionary where code = 'stationRole2') and b.state = 1 where station_id = :station_id";
            OracleParameter[] commandParameters2 = new OracleParameter[]{
                new OracleParameter(":station_id",OracleDbType.Varchar2,40)
            };
            commandParameters2[0].Value = station_id;

            DataTable datatable2 = Jdbc.ExecuteDataTable(cmdText2, commandParameters2);
            foreach (DataRow drop in datatable2.Rows)
            {
                String power_code = drop["power_code"].ToString();
                String name = drop["name"].ToString();
                ToolStripItem item = new ToolStripMenuItem();
                item.Name = "temp_role" + power_code + "_ToolStripMenuItem";
                item.Size = new System.Drawing.Size(153, 22);
                item.Text = name;
                item.Click += new System.EventHandler(this.dcbg_ToolStripMenuItem_Click);
                this.gjgn_ToolStripMenuItem.DropDownItems.Add(item);
            }

            string cmdText1 = "select * from a5_interface_config";
            
            DataTable datatable1 = Jdbc.ExecuteDataTable(cmdText1, null);
            int x = 0;
            foreach (DataRow drop in datatable1.Rows)
            {
                String id = drop["id"].ToString();
                String interface_name = drop["interface_name"].ToString();
                ToolStripItem item = new ToolStripMenuItem();
                item.Name = "temp_"+id+"_ToolStripMenuItem";
                item.Size = new System.Drawing.Size(153, 22);
                item.Text = interface_name;
                item.Click += new System.EventHandler(this.lanMenu1_UserControlMenuItemClick);
                this.jkpz_ToolStripMenuItem.DropDownItems.Add(item);
                if (x == 0)
                {
                    setInterfaceCofig(interface_name);
                    ((ToolStripMenuItem)item).Checked = true;
                    ((ToolStripMenuItem)item).CheckState = System.Windows.Forms.CheckState.Checked;
                    x++;
                }
            }
           
        }

        //开始刷写
        private void ServiceToolFrom_start_button_Click(object sender, EventArgs e)
        {
            string transmission_sn = ServiceToolFrom_Product_Serial_No.Text;
            if (start_on_off)
            {
                logsid = Jdbc.getNextLogid(); //获取日志ID
                start_time = DateTime.Now.ToLocalTime().ToString(); //开始时间

                //刷写Flash
                int returnFlash = startFlashProc();

                //成功后刷写参数
                if (returnFlash == 0)
                {
                    //刷写参数
                    int returnConfig = startConfig();
                    if (returnConfig == 0)
                    {
                        WriteMessageText("刷写结束！", true);
                    }
                    else
                    {
                        WriteMessageText("刷写终止!", true);
                    }
                }
                else
                {
                    WriteMessageText("刷写终止!", true);
                }

                //刷写完成写入日志
                end_time = DateTime.Now.ToLocalTime().ToString(); //结束时间
                WriteMessageText("结束时间：" + end_time);
                Jdbc.insertLogs(logsid, station_code, station_name, transmission_sn, start_time, end_time);
            }
            else
            {
                MessageBox.Show("请查询到结果后进行操作！");
            }
        }

        //根据序列号查询变速箱信息
        private void ServiceToolFrom_detail_button_Click(object sender, EventArgs e)
        {
            string serialNo = ServiceToolFrom_Serial_No_textbox.Text;
            if (!(serialNo != null && serialNo.Length - 8 == 0))
            {
                MessageBox.Show("变速箱编号必须是8位!");
            }
            else
            {
                string cmdText = "select * from a5_transmission where transmission_model = :transmission_model";

                OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":transmission_model",OracleDbType.Varchar2,40)
            };
                commandParameters[0].Value = serialNo;

                DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                if (datatable.Rows.Count > 0)
                {
                    DataRow dr = datatable.Rows[0];
                    String transmission_model = dr["transmission_model"].ToString();//变速箱编号
                    String torque_converter_sn = dr["torque_converter_sn"].ToString();//变矩器编号
                    String arrangement_pn = dr["arrangement_pn"].ToString();//总称号

                    String state = dr["state"].ToString();//出库状态 1在库，2出库
                    String order_id = dr["order_id"].ToString();//关联订单
                    ServiceToolFrom_Product_Serial_No.Text = transmission_model;
                    ServiceToolFrom_Product_Arrangement.Text = arrangement_pn;
                    ServiceToolFrom_Product_Engr_Model.Text = torque_converter_sn;
                    if (state.Equals("2"))
                    {
                        //查询订单信息，加载FLASH文件名称，加载变量信息；
                        if (true)
                        {
                            cmdText = "select * from a5_order where id = :id";
                            commandParameters = new OracleParameter[]{
                            new OracleParameter(":id",OracleDbType.Long,10)
                        };
                            commandParameters[0].Value = order_id;

                            DataTable datatableOrder = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                            if (datatableOrder != null && datatableOrder.Rows.Count > 0)
                            {
                                DataRow drorder = datatableOrder.Rows[0];
                                String order_number = drorder["order_number"].ToString();
                                string flash_id = drorder["flash_id"].ToString();

                                ServiceToolFrom_Product_Order.Text = order_number;

                                cmdText = "select b.file_name from a5_flash_softw a left join a5_flash_file_relation b on a.id = b.flash_id where b.status = 1 and a.id=:flash_id";
                                commandParameters = new OracleParameter[]{
                                 new OracleParameter(":flash_id",OracleDbType.Long,10)
                              };
                                commandParameters[0].Value = flash_id;
                                DataTable datatableFlash = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                                if (datatableFlash != null && datatableFlash.Rows.Count > 0)
                                {
                                    DataRow filedrop = datatableFlash.Rows[0];
                                    flash_file_name = filedrop["file_name"].ToString();
                                    start_on_off = true;
                                }
                                /* cmdText = "select * from A5_ORDER_FLASH_PARAMETER where order_id = :order_id";
                                 commandParameters = new OracleParameter[]{
                                     new OracleParameter(":order_id",OracleDbType.Long,10)
                                  };
                                 commandParameters[0].Value = order_id;
                                 DataTable datatableOrderP = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                                 foreach (DataRow drop in datatableOrderP.Rows) {
                                     String field_name = drop["field_name"].ToString();
                                     String v_value = drop["v_value"].ToString();
                                     if (field_name.Equals("srcFile")) {
                                         flash_file_name = v_value;//设定Flash值
                                        // MessageBox.Show("flash_file_name："+ flash_file_name);
                                         start_on_off = true;
                                     }
                                 }*/
                                if (start_on_off)
                                {   //查询订单下变量(过去掉组名)
                                    cmdText = "select sotr_index,varable_name,trim(v_value) v_value from a5_order_flash_variable where order_id = :order_id and group_id > 1 and group_id <>10  order by sotr_index";
                                    commandParameters = new OracleParameter[]{
                                new OracleParameter(":id",OracleDbType.Long,10)
                                };
                                    commandParameters[0].Value = order_id;
                                    DataTable datatableOrderV = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                                    wr_dic.Clear();
                                    foreach (DataRow drov in datatableOrderV.Rows)
                                    {
                                        int sotr_index = int.Parse(drov["sotr_index"].ToString());//索引
                                        String varable_name = drov["varable_name"].ToString();//字段名称
                                        String v_value = drov["v_value"].ToString();//值

                                        wr_dic.Add(sotr_index, v_value);
                                    }
                                    if (datatableOrderV.Rows.Count > 0)
                                    {
                                        start_on_off = true;//标记可刷机
                                    }
                                }
                            }
                            else
                            {
                                start_on_off = false;
                                MessageBox.Show("没有订单信息!");
                            }
                        }
                    }
                    else
                    {
                        start_on_off = false;
                        MessageBox.Show("设备状态为在库,请出库后再试!");
                    }
                }
                else
                {
                    start_on_off = false;
                    MessageBox.Show("没有查询到结果!");
                }
            }
        }

        private void ServiceToolFrom_language_MenuItem_en_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("en-US", this, typeof(ServiceToolFrom));
        }

        private void ServiceToolFrom_language_MenuItem_zh_Click(object sender, EventArgs e)
        {
            LanguageHelper.SetLang("zh-CN", this, typeof(ServiceToolFrom));
        }

        private void ServiceToolFrom_config_MenuItem_Click(object sender, EventArgs e)
        {
            //ConfigForm configForm = new ConfigForm();
            //configForm.ShowDialog();
        }

        //重置界面
        private void ServiceToolFrom_reset_button_Click(object sender, EventArgs e)
        {
            ServiceToolFrom_Serial_No_textbox.Text = "";
            start_on_off = false;
            ServiceToolFrom_Product_Serial_No.Text = "";
            ServiceToolFrom_Product_Engr_Model.Text = "";
            ServiceToolFrom_Product_Arrangement.Text = "";
            ServiceToolFrom_Product_Order.Text = "";
            ServiceToolFrom_log_richTextBox.Text = "";
            ServiceToolFrom_listView.Items[0].SubItems[1].Text = "待执行";
            ServiceToolFrom_listView.Items[1].SubItems[1].Text = "待执行";
            ServiceToolFrom_listView.Items[2].SubItems[1].Text = "待执行";
            ServiceToolFrom_listView.Items[3].SubItems[1].Text = "待执行";
            ServiceToolFrom_listView.Items[4].SubItems[1].Text = "待执行";
            ServiceToolFrom_listView.Items[5].SubItems[1].Text = "待执行";
            //startConfig();//刷参数测试
            toolStripProgressBar1.Value = 0;
        }

        //导出报告
        private void dcbg_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能待定!");
        }
       
        private void lanMenu1_UserControlMenuItemClick(object sender, EventArgs e)
        {
            //获取当前点击的是自定义控件里面的哪一个按钮
            ToolStripMenuItem Nbi = (ToolStripMenuItem)sender;
            //弹出按钮的名称、按钮上面的文本
            setInterfaceCofig(Nbi.Text);
            ((ToolStripMenuItem)sender).Checked= true;
        }

        //数据库配置
        private void toolStripMenuDataConfig_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }
        
        private void ServiceToolFrom_statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //配置接口
        private void setInterfaceCofig(String interface_name) {
            string cmdText = "select id, interface_name, interface_state, create_time, user_name, check_value, adapter_type, prot, transmission_speed,datalink from a5_interface_config where interface_name = :interface_name";

            OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":interface_name",OracleDbType.Varchar2,60)
            };
            commandParameters[0].Value = interface_name;

            DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
            if (datatable != null && datatable.Rows.Count > 0)
            {
                DataRow dr = datatable.Rows[0];
                String user_name = dr["user_name"].ToString();//
                String check_value = dr["check_value"].ToString();//
                int adapter_type = int.Parse(dr["adapter_type"].ToString());//
                int prot = int.Parse(dr["prot"].ToString());//
                int transmission_speed = int.Parse(dr["transmission_speed"].ToString());//
                int datalink = int.Parse(dr["datalink"].ToString());//

                ClientLogin = user_name;
                AuthenticationKey = check_value;
                m_ComAdapt = (T_FLASH_COMADAPTER)adapter_type;
                m_ComPort = (T_FLASH_COMPORT)prot;
                m_BaudRate = (T_FLASH_BAUDRATE)transmission_speed;
                m_DataLinks = (T_FLASH_DATALINK)datalink;
                
            }
        }

        /// <summary>
        /// 刷机过程写入消息
        /// 2017-11-7 18:32 by CK
        /// </summary>
        /// <param name="str">写入的内容</param>
        /// <param name="statusStripText">是否状态栏显示</param>
        /// <param name="richTextBox">是否列表显示</param>
        private void WriteMessageText(string str, bool statusStripText = false, bool richTextBox = true)
        {
            //默认不写状态栏
            if (statusStripText)
            {

                ServiceToolFrom_statusStrip_msg.Text = str;
            }

            //写文本
            if (richTextBox)
            {
                ServiceToolFrom_log_richTextBox.Text += str + "\r\n";
            }

        }

        /// <summary>
        /// 刷机过程写入数据库
        /// </summary>
        /// <param name="step">刷机步骤名称</param>
        /// <param name="str">刷机内容</param>
        /// <param name="isOK">是否成功</param>
        /// <param name="Code">错误代码</param>
        /// <param name="Description">错误描述信息</param>
        private void WriteDBLog(string step, string str, bool isOK = true, int Code = 0, string Description="")
        {
            string now = DateTime.Now.ToLocalTime().ToString() + "：";
            str = now + str + "。";

            if (Code > 0)
            {
                str = str + "错误码:" + Code.ToString() + "；错误信息：" + Description;
            }

            MsgIndex ++;

            Jdbc.insertLogsSide(logsid, step, str, isOK?"成功":"失败", MsgIndex);
            //Jdbc.insertLogsSide(logsid, "连接设备", DateTime.Now.ToLocalTime().ToString() + ":连接设备失败！错误码" + iCode.ToString() + "|" + sDescription, "失败", 1);
        }

        //刷写Flash过程
        private int startFlashProc()
        {
          
            #region 重置接口变量状态
            bFlashDetectStatus = false; //设备检测是否完成
            bFlashValidationStatus = false; //文件校验是否完成
            bFlashStatus = false; //刷写是否完成
            bConnectFlag = false; //设备是否已连接
            bFileFlag = false; //文件是否合法
            bFlashFlag = false; //刷写是否正确
            #endregion

            toolStripProgressBar1.Value = 0;

            WriteMessageText("开始刷写...", true);
            WriteMessageText("开始时间：" + start_time);

            #region 1.连接设备

            ServiceToolFrom_listView.Items[0].SubItems[1].Text = "执行中";
            WriteMessageText("正在连接设备...");

            //连接设备，并判断是否成功
            connectDevice();
            if (!bConnectFlag)
            {
                //连接失败
                WriteDBLog("连接设备", "设备连接失败", false, iCode, sDescription);
                ServiceToolFrom_listView.Items[0].SubItems[1].Text = "失败";
                return 1;
            }
            else
            {
                WriteDBLog("连接设备", "设备连接成功");
                ServiceToolFrom_listView.Items[0].SubItems[1].Text = "完成";
            }

            #endregion

            #region 2.1 下载服务器的Flash文件

            string path = "";
            try
            {
                ServiceToolFrom_listView.Items[1].SubItems[1].Text = "执行中";
                string cmdText = "select * from a5_file where file_name = :file_name";

                OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":file_name",OracleDbType.Varchar2,40)
                };
                commandParameters[0].Value = flash_file_name;

                DataTable datatable = Jdbc.ExecuteDataTable(cmdText, commandParameters);
                if (datatable != null && datatable.Rows.Count > 0)
                {
                    DataRow dr = datatable.Rows[0];
                    String source_file = dr["source_file"].ToString();//变速箱编号
                    path = FileHandler.createFile(flash_file_name, source_file);
                    WriteDBLog("校验文件", "Flash文件 " + flash_file_name + " 下载成功");
                }
                else
                {
                    WriteMessageText("Flash文件校验失败，没有找到文件：" + flash_file_name, true);
                    WriteDBLog("校验文件", "Flash文件校验失败", false, 1, "没有找到文件 " + flash_file_name);
                    ServiceToolFrom_listView.Items[1].SubItems[1].Text = "失败";
                    return 21;
                }
            }
            catch (Exception ex)
            {
                WriteMessageText("Flash文件校验（下载）异常：" + ex.Message);
                return 100;
            }
            #endregion

            #region 2.2 校验Flash文件

            WriteMessageText("加载Flash文件：" + flash_file_name);
            WriteMessageText("正在校验Flash文件：" + flash_file_name);


            //校验文件，并判断是否成功
            validateFlashFile(path);
            if (!bFileFlag)
            {
                //校验失败                    
                WriteDBLog("校验文件", "Flash文件校验失败", false, iCode, sDescription);
                ServiceToolFrom_listView.Items[1].SubItems[1].Text = "失败";
                return 22;
            }
            else
            {
                WriteDBLog("校验文件", "Flash文件校验成功");
                ServiceToolFrom_listView.Items[1].SubItems[1].Text = "完成";
            }

            #endregion

            #region 3.刷写FLash文件
            ServiceToolFrom_listView.Items[2].SubItems[1].Text = "执行中";
            WriteMessageText("开始刷写Flash文件...");

            //刷写文件，并判断是否成功
            startFlashFile(path); 
            if (!bFlashFlag)
            {
                //刷写失败
                WriteDBLog("刷写Flash", "刷写Flash失败", false, iCode, sDescription);
                ServiceToolFrom_listView.Items[2].SubItems[1].Text = "失败";
                return 3;
            }
            else
            {
                WriteDBLog("刷写Flash", "刷写Flash成功");
                ServiceToolFrom_listView.Items[2].SubItems[1].Text = "完成"; 

            }
            #endregion

            return 0;

        }

        //认证加密算法
        private string CalculatePassKey(ref int Offset, ref int Mask, ref string PassCode)
        {
            string szPassKey = "";
            short nMask;
            short nOffset;

            short newChar;
            char[] PassCodeR = PassCode.ToCharArray();

            for (int i = 0; i <= PassCode.Length - 1; i++)
            {
                nOffset = (short)((int)Math.Floor(Offset / (Math.Pow(16, (i % 8)))) & 0x7);
                nMask = (short)((int)Math.Floor(Mask / (Math.Pow(16, nOffset))) & 0xF);
                newChar = (short)((int)(PassCodeR[i]) ^ nMask);
                szPassKey = szPassKey + (Char)newChar;
            }
            return szPassKey;
        }

        #region 调用外部接口

        //连接设备 调用外部接口
        public void connectDevice()
        {
            #region 权限认证
            FLASHSERVERLib.IAuthenticationEx FlashAuthorization;
            FLASHSERVERLib.IAuthenticationData AuthenticationData;

            int lRandomSeed1 = 0;
            int lRandomSeed2 = 0;
            string szPassKey;

            m_FlashServer = new FLASHSERVERLib.Flash();
            FlashAuthorization = (FLASHSERVERLib.IAuthenticationEx)m_FlashServer;
            m_FlashServer.Language = "ENG";

            AuthenticationData = FlashAuthorization.GetAuthenticationDataInterface();
            AuthenticationData.ClientPath = "Comet.exe";

            object AuthenticationData1 = AuthenticationData;

            FlashAuthorization.Init(ClientLogin, ref AuthenticationData1, ref lRandomSeed1, ref lRandomSeed2);
            szPassKey = CalculatePassKey(ref lRandomSeed1, ref lRandomSeed2, ref AuthenticationKey);
            FlashAuthorization.ValidatePassKey(szPassKey);

            FlashAuthorization = null;
            #endregion

            try
            {
                //设置鼠标状态为等待
                Cursor = System.Windows.Forms.Cursors.WaitCursor;

                //设置通信
                m_FlashServer.SetupCommunications(m_ComAdapt, m_ComPort, m_BaudRate);

                //开始连接设备
                m_FlashServer.StartDetect(m_DataLinkCount, ref m_DataLinks, 1, 0, this);

                //判断是否完成，等待接口返回
                while (!bFlashDetectStatus)
                {
                    Thread.Sleep(3 * 1000);
                    Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                WriteMessageText("设备连接（外部接口）异常：" + ex.Message);
            }
            finally
            {
                bFlashDetectStatus = false;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        //校验文件 调用外部接口
        public void validateFlashFile(string FileName)
        {
            try
            {
                //设置鼠标状态为等待
                Cursor = System.Windows.Forms.Cursors.WaitCursor;

                //设置文件
                m_FlashServer.SetFlashFile(FileName);

                //校验文件
                m_FlashServer.Validate(1, this);

                //判断是否完成，等待接口返回
                while (!bFlashValidationStatus)
                {
                    Thread.Sleep(3 * 1000);
                    Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                WriteMessageText("Flash文件校验（外部接口）异常：" + ex.Message);
            }
            finally
            {
                bFlashValidationStatus = false;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        //刷写文件 调用外部接口
        public void startFlashFile(string FileName)
        {
            try
            {
                //设置鼠标状态为等待
                Cursor = System.Windows.Forms.Cursors.WaitCursor;

                //刷写文件
                m_FlashServer.StartFlash(1, this);

                //判断是否完成，等待接口返回
                while (!bFlashStatus)
                {
                    Thread.Sleep(1 * 1000);
                    Application.DoEvents();
                }
                
            }
            catch (Exception ex)
            {
                WriteMessageText("文件刷写（外部接口）异常：" + ex.Message);
            }
            finally
            {
                bFlashStatus = false;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        //刷写参数(变量)
        public int startConfig()
        {
            //4.读取设备参数 5.写入参数 6.验证参数
            try
            {
                Thread.Sleep(5 * 1000);//暂停5秒，防止设备没有及时释放
                WriteMessageText("开始刷写参数...");

                #region 4. 读取设备参数

                WriteMessageText("开始读取参数...");
                ServiceToolFrom_listView.Items[3].SubItems[1].Text = "执行中";

                dic.Clear();
                dic = FC_ServiceTool.Config.ReadConfigPara();

                foreach (var item in dic)
                {
                    WriteMessageText("Key=(" + item.Key + "),Value=(" + item.Value + ")");

                    #region 如果第0项不等于0，那么提示错误，并返回
                    if (item.Key == 0 && !item.Value.ToString().Equals("0"))
                    {
                        string str = "";
                        switch (item.Value.ToString())
                        {
                            case "1":
                                //Please check your device connection!
                                str = "请检查设备连接";
                                goto default;
                            case "2":
                                //TCU Response Timeout!
                                str = "TCU超时";
                                goto default;
                            default:
                                WriteMessageText("读取参数失败：" + "错误代码：" + item.Value.ToString() + "，错误信息：" + str, true);
                                WriteDBLog("读取参数", "读取参数失败", false, 2, str);

                                ServiceToolFrom_listView.Items[3].SubItems[1].Text = "失败";
                                return 4;
                        }
                    }
                    #endregion
                }

                WriteDBLog("读取参数", "读取参数：读取到参数个数：" + dic.Count);
                ServiceToolFrom_listView.Items[3].SubItems[1].Text = "完成";
                WriteMessageText("读取完成！");

                #endregion

                #region 5. 写入参数

                WriteMessageText("开始写入参数...");
                ServiceToolFrom_listView.Items[4].SubItems[1].Text = "执行中";

                wr_status = FC_ServiceTool.Config.WriteConfigPara(wr_dic);

                #region 如果返回值不等于0，那么提示错误，并返回
                if (wr_status != 0)
                {
                    string str = "";
                    switch (wr_status)
                    {
                        case 1:
                            //Please check your device connection!
                            str = "请检查设备连接";
                            goto default;
                        case 2:
                            //The key is invalid!
                            str = "键值无效";
                            goto default;
                        case 3:
                            //Device write failed!TCU echo 2A 2A 2A 2A
                            str = "TCU返回 2A 2A 2A 2A";
                            goto default;
                        case 4:
                            //The Value is invalid!
                            str = "值无效";
                            goto default;
                        case 5:
                            //TCU Response Timeout!
                            str = "TCU超时";
                            goto default;
                        case 6:
                            //PGN invalid!
                            str = "PGN无效";
                            goto default;
                        default:
                            WriteMessageText("写入参数失败：" + "错误代码：" + wr_status.ToString() + "，错误信息：" + str, true);
                            WriteDBLog("写入参数", "写入参数失败", false, wr_status, str);
                            ServiceToolFrom_listView.Items[4].SubItems[1].Text = "失败";
                            return 5;
                    }
                }
                #endregion

                WriteDBLog("写入参数", "写入参数完成" );
                ServiceToolFrom_listView.Items[4].SubItems[1].Text = "完成";
                WriteMessageText("写入完成！");

                #endregion

                #region 6. 验证参数

                Thread.Sleep(2 * 1000);//暂停2秒，防止设备没有及时释放

                WriteMessageText("开始验证参数...");
                ServiceToolFrom_listView.Items[5].SubItems[1].Text = "执行中";

                dic.Clear();
                dic = FC_ServiceTool.Config.ReadConfigPara();

                Boolean isflag = true;
                foreach (var item in wr_dic)
                {
                    if (!dic[item.Key].Equals(item.Value))
                    {
                        WriteMessageText("验证参数失败：Key = (" + item.Key + "),读出值：(" + dic[item.Key] + "),写入值：(" + item.Value + ")");
                        WriteDBLog("验证参数", "验证参数失败", false, 1, "Key = (" + item.Key + "),读出值：(" + dic[item.Key] + "),写入值：(" + item.Value + ")");
                        isflag = false;
                    }
                }
                if (!isflag)
                {
                    ServiceToolFrom_listView.Items[5].SubItems[1].Text = "失败";
                    WriteMessageText("刷写参数结束！", true);
                    return 6;
                }

                WriteMessageText("验证参数完成！", true);
                WriteDBLog("验证参数", "验证参数完成");

                ServiceToolFrom_listView.Items[5].SubItems[1].Text = "完成";
                WriteMessageText("刷写参数结束！", true);
                return 0;

                #endregion

            }
            catch (Exception ex)
            {
                WriteMessageText("刷写参数异常：" + ex.ToString());
                return 100;
            }

        }


    }
}
