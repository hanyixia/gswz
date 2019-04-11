using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CompanyCommon
{
    public class DapperHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        //private static string str_connection = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static string str_connection = "data source=" + ConfigurationSettings.AppSettings["DataSource"].ToString() + ";uid=" + ConfigurationSettings.AppSettings["uid"].ToString() + ";pwd=" + ConfigurationSettings.AppSettings["pwd"].ToString() + ";Database=" + ConfigurationSettings.AppSettings["Database"].ToString(); 


        /// <summary>
        /// 获得数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            var strConn = str_connection;
            IDbConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// 增删改方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(str_connection))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>查询得到的DataTable对象</returns>
        public static DataTable DataAdapter(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(str_connection))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(strSql, conn);
                sda.Fill(dt);
                conn.Close();

                return dt;
            }
        }


        /// <summary>
        /// Command预处理
        /// </summary>
        /// <param name="conn">SqlConnection对象</param>
        /// <param name="trans">MySqlTransaction对象，可为null</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="cmdType">CommandType，存储过程或命令行</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">SqlCommand参数数组，可为null</param>
        private static void PrepareCommand(SqlConnection conn, SqlCommand cmd, string cmdText, params object[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>查询得到的DataReader对象</returns>
        public static SqlDataReader ExecuteReader(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(str_connection);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return dr;
        }
    }
}
