using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace A5_Flash_Tool
{
    class Jdbc
    {

        //private static string connstr = "User Id=a5; password=123456;" + "Data Source=192.168.0.103:1521/liug; Pooling=false;";

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="hostaddress"></param>
        /// <param name="port"></param>
        /// <param name="servername"></param>
        /// <param name="uid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string configDataSource(string hostaddress, string port, string servername, string uid, string password)
        {
            //string connstr = "User Id=" + username + "; password=" + password + ";" +
            //"Data Source=" + ip + ":" + prot + "/" + dataname + "; Pooling=false;";

            string connstr =
                 "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + hostaddress + ")(PORT="+ port + "))(CONNECT_DATA=(SERVICE_NAME=" + servername + ")));" + 
                 "Persist Security Info=True;User ID=" + uid + ";Password=" + password + ";";
            return connstr;
        }

        public static void Test(String username,String password,String ip,String prot,String dataname)
        {
            string connstr = configDataSource(ip, prot, dataname, username, password);

            //Create a connection to Oracle
            OracleConnection con = null;
            try
            {
                con = new OracleConnection();
                con.ConnectionString = connstr;
                con.Open();
                MessageBox.Show("连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，失败原因："+ ex.Message);
            }
            finally {
                if (con != null) {
                    con.Close();
                }
            }
        }
      
        /// <summary>  
        /// 执行数据库查询操作,返回DataTable类型的结果集  
        /// </summary>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataTable类型的结果集</returns>  
        internal static DataTable ExecuteDataTable(string cmdText, params OracleParameter[] commandParameters)
        {

            string connstr = configDataSource(Common.jdbc_ip, Common.jdbc_prot, Common.jdbc_data_name, Common.jdbc_user, Common.jdbc_password);

            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connstr);
            DataTable table = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;
                table = new DataTable();
                adapter.Fill(table);
                command.Parameters.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ex:"+ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return table;
        }
        /// <summary>  
        /// 执行数据库查询操作,返回受影响的行数  
        /// </summary>  
        /// <param name="connection">Oracle数据库连接对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        /// <returns>当前查询操作影响的数据行数</returns>  
        internal static int ExecuteNonQuery(string cmdText, params OracleParameter[] commandParameters)
        {
            string connstr = configDataSource(Common.jdbc_ip, Common.jdbc_prot, Common.jdbc_data_name, Common.jdbc_user, Common.jdbc_password);

            OracleConnection connection = new OracleConnection(connstr);
            if (connection == null) throw new ArgumentNullException("当前数据库连接不存在");
            OracleCommand command = new OracleCommand();
            int result = 0;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>  
        /// 执行数据库命令前的准备工作  
        /// </summary>  
        /// <param name="command">Command对象</param>  
        /// <param name="connection">数据库连接对象</param>  
        /// <param name="trans">事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        private static void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            command.CommandText = cmdText;
            command.CommandType = cmdType;

            if (trans != null) command.Transaction = trans;

                if (commandParameters != null)
                {
                    foreach (OracleParameter parm in commandParameters)
                        command.Parameters.Add(parm);
                }
            }

        /**
         * 
         * 记录日志副表
         * */
        internal static void insertLogsSide(long logid,string logStep,string logMsg,string logResult,long sortIndex) {
            String sql = "insert into a5_interface_logs_side " +
            "(id, log_id, log_step, log_msg, log_result, sort_index)" +
            " values (SEQ_a5_interface_logs_side.Nextval, :log_id, :log_step, :log_msg, :log_result, :sort_index)";

            OracleParameter[] commandParameters = new OracleParameter[]{
                new OracleParameter(":log_id",OracleDbType.Long,40),
                 new OracleParameter(":log_step",OracleDbType.Varchar2,40),
                 new OracleParameter(":log_msg",OracleDbType.Varchar2,4000),
                 new OracleParameter(":log_result",OracleDbType.Varchar2,40),
                 new OracleParameter(":sort_index",OracleDbType.Long)
            };

            commandParameters[0].Value = logid;
            commandParameters[1].Value = logStep;
            commandParameters[2].Value = logMsg;
            commandParameters[3].Value = logResult;
            commandParameters[4].Value = sortIndex;
            int i = ExecuteNonQuery(sql, commandParameters);

        }

        internal static void insertLogs(long id,string station_code,string station_name,string transmission_sn, String start_time, String end_time) {
            String sql = "insert into a5_interface_logs" +
                  "(id,create_date, station_code, pc_name, start_time, end_time, logs_describe, severity, error_msg, transmission_sn, create_user)" +
                  " values (" +
                  ":id, sysdate, :v_station_code, :v_pc_name, to_date(:start_time,'yyyy-mm-dd hh24:mi:ss'), to_date(:end_time,'yyyy-mm-dd hh24:mi:ss'), null, null, null, :transmission_sn, :create_user)";
            
            OracleParameter[] commandParameterslog = new OracleParameter[]{
                        new OracleParameter(":id",OracleDbType.Long,40),
                        new OracleParameter(":v_station_code",OracleDbType.Varchar2,40),
                         new OracleParameter(":v_pc_name",OracleDbType.Varchar2,40),
                         new OracleParameter(":start_time",OracleDbType.Varchar2,40),
                         new OracleParameter(":transmission_sn",OracleDbType.Varchar2,60),
                         new OracleParameter(":create_user",OracleDbType.Varchar2,40),
                    };

            commandParameterslog[0].Value = id;
            commandParameterslog[1].Value = station_code;
            commandParameterslog[2].Value = Common.pc_name;
            commandParameterslog[3].Value = start_time;
            commandParameterslog[4].Value = transmission_sn;
            commandParameterslog[5].Value = Common.login_user;

            int i = ExecuteNonQuery(sql, commandParameterslog);
        }

        internal static long getNextLogid() {
            string cmdText = "select seq_interface_logs.nextval nextid from dual";
            long id = 0L;

            DataTable datatable = ExecuteDataTable(cmdText, null);
            if (datatable!=null&&datatable.Rows.Count > 0)
            {
                DataRow dr = datatable.Rows[0];
                id = long.Parse(dr["nextid"].ToString());
            }
            return id;
        }
    }
}
