using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Common.SqlHelper.MySql
{
    /// <summary>
    /// 简单版
    /// </summary>
    public class MysqlHelper
    {
        public MysqlHelper()
        {

        }

        /// <summary>
        /// 是否读操作
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 计数器
        /// </summary>
        static long UseCount = 0;

        #region 数据库连接字符串
        /// <summary>
        /// 写连接字符串
        /// </summary>
        static string ConnectionStringWrite = ConfigurationManager.AppSettings["ConnectionStringWrite"].ToString();

        /// <summary>
        /// 读连接字符串
        /// </summary>
        static string ConnectionStringRead = ConfigurationManager.AppSettings["ConnectionStringRead"].ToString();


        /// <summary>
        /// 读链接字符串数据
        /// </summary>
        static string[] _ConnectionStringReadArr = ConnectionStringRead.Split(',');


        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="IsRead"></param>
        /// <returns></returns>
        public static string GetConnectionString(bool IsRead = true)
        {
            if (IsRead)
            {
                return _ConnectionStringReadArr[UseCount % _ConnectionStringReadArr.Length];
            }
            else
            {
                return ConnectionStringWrite;
            }
        }
        #endregion


        #region  执行简单SQL语句,使用MySQL查询
        //static string GetConnectionString() = "server=.;database=Data20180608;uid=sa;pwd=123456;integrated Security=SSPI;persist Security info=false;";
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString(SQLString.ToLower().StartsWith("select"))))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataTable QueryOld(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                DataSet ds = new DataSet();
                DataTable table = new DataTable();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(table);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return table;
            }
        }

        public static DataTable Query(string SQLString)
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection))
                {
                    command.Fill(table);
                }
                return table;
            }
        }


        public static MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] ps)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            using (MySqlCommand cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = sql;
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                return cmd.ExecuteReader();
            }
        }


        public static T ExecuteObject<T>(string SQLString)
        {
            DataTable dt = Query(SQLString);
            return AutoMapper.Mapper.DynamicMap<List<T>>(dt.CreateDataReader()).FirstOrDefault();

        }

        public static List<T> ExecuteObjects<T>(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            using (MySqlCommand cmd = connection.CreateCommand())
            {
                connection.Open();
                cmd.CommandText = SQLString;
                return AutoMapper.Mapper.DynamicMap<List<T>>(cmd.ExecuteReader());
            }
        }
        #endregion
    }
}
