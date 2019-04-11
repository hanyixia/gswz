using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DATEBASE
{
    
    public class DataBase
    {
        private DbConnection cnn;
        private static string ConnectionString = "data source=" + ConfigurationSettings.AppSettings["DataSource"].ToString() + ";uid=" + ConfigurationSettings.AppSettings["uid"].ToString() + ";pwd=" + ConfigurationSettings.AppSettings["pwd"].ToString() + ";Database=" + ConfigurationSettings.AppSettings["Database"].ToString();
        private static string ProviderName = ConfigurationSettings.AppSettings["ProviderName"].ToString();



        public DataBase()
        {
            cnn = CreateConnection();
        }
        public DataBase(string cnnstr)
        {
            cnn = CreateConnection(cnnstr);
        }


        public static DbConnection CreateConnection()
        {

            DbConnection Connection = DbProviderFactories.GetFactory(ProviderName).CreateConnection();
            Connection.ConnectionString = ConnectionString;
            return Connection;
        }
        public static DbConnection CreateConnection(string cnnstr)
        {

            DbConnection Connection = DbProviderFactories.GetFactory(ProviderName).CreateConnection();
            Connection.ConnectionString = cnnstr;
            return Connection;
        }

        public DataSet ExecuteDataSet(DbCommand com)
        {
            if (com == null)
            {
                throw new ArgumentNullException("com");
            }
            DbDataAdapter ad = DbProviderFactories.GetFactory(ProviderName).CreateDataAdapter();
            ad.SelectCommand = com;

            //System.Data.SqlClient.SqlTransaction sqltra=com.

            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }

        public DataTable ExecuteDataTable(DbCommand com)
        {
            if (com == null)
            {
                throw new ArgumentNullException("com");
            }
            DbDataAdapter ad = DbProviderFactories.GetFactory(ProviderName).CreateDataAdapter();
            ad.SelectCommand = com;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(DbCommand com)
        {
            if (com == null)
            {
                throw new ArgumentNullException("com");
            }
            com.Connection.Open();
            int num = com.ExecuteNonQuery();
            com.Connection.Close();
            return num;
        }

        public int ExecuteReturnValue(DbCommand com)
        {
            if (com == null)
            {
                throw new ArgumentNullException("com");
            }
            com.Connection.Open();
            com.ExecuteNonQuery();
            int num = Convert.ToInt32(com.Parameters["ReturnValue"].Value);
            com.Connection.Close();
            return num;
        }

        public DbDataReader ExecuteReader(DbCommand com)
        {
            if (com == null)
            {
                throw new ArgumentNullException("com");
            }
            com.Connection.Open();
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DbCommand CreateSqlCommand(string sql)
        {
            if (sql == null || sql.Length == 0)
            {
                throw new ArgumentNullException("sql");
            }
            DbCommand com = this.cnn.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sql;
            return com;
        }

        public DbCommand CreateProCommand(string ProName)
        {
            if (ProName == null || ProName.Length == 0)
            {
                throw new ArgumentNullException("ProName");
            }
            DbCommand com = this.cnn.CreateCommand();
            com.CommandText = ProName;
            com.CommandType = CommandType.StoredProcedure;
            return com;
        }

        public void AttachInParam(DbCommand com, string ParameterName, DbType dbType, object value)
        {
            DbParameter dbParameter = com.CreateParameter();
            dbParameter.ParameterName = ParameterName;
            dbParameter.DbType = dbType;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            com.Parameters.Add(dbParameter);
        }
        public void AttachOutParam(DbCommand com, string ParameterName, DbType dbType, int Size)
        {
            DbParameter dbParameter = com.CreateParameter();
            dbParameter.ParameterName = ParameterName;
            dbParameter.DbType = dbType;
            dbParameter.Size = Size;
            dbParameter.Direction = ParameterDirection.Output;
            com.Parameters.Add(dbParameter);
        }
        public void AttachReturnValue(DbCommand com)
        {
            DbParameter dbParameter = com.CreateParameter();
            dbParameter.ParameterName = "ReturnValue";
            dbParameter.Direction = ParameterDirection.ReturnValue;
            com.Parameters.Add(dbParameter);
        }
        public void CloseCnn()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cnn.Dispose();
            }
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="Sql">SQL语句</param>
        /// <returns>返回所影响的行</returns>
        public int ExecuteSqlNonQuery(string Sql)
        {
            if (Sql == null || Sql.Length == 0)
            {
                throw new ArgumentNullException("Sql");
            }
            DbCommand Com = CreateSqlCommand(Sql);
            Com.Connection.Open();
            int Num = Com.ExecuteNonQuery();
            CloseCnn();
            Com.Dispose();
            return Num;
        }
        /// <summary>
        /// 执行SQL语句,返回DbDataReader对象
        /// </summary>
        /// <param name="Sql">SQL语句</param>
        /// <returns></returns>
        public DbDataReader ExecuteSqlReader(string Sql)
        {
            if (Sql == null || Sql.Length == 0)
            {
                throw new ArgumentNullException("Sql");
            }
            DbCommand Com = CreateSqlCommand(Sql);
            Com.Connection.Open();
            return Com.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 执行SQL语句,返回DataSet对象
        /// </summary>
        /// <param name="Sql">SQL语句</param>
        /// <returns></returns>
        public DataSet ExecuteSqlDataSet(string Sql)
        {
            if (Sql == null || Sql.Length == 0)
            {
                throw new ArgumentNullException("Sql");
            }
            DataSet ds = new DataSet();
            DbDataAdapter ad = DbProviderFactories.GetFactory(ProviderName).CreateDataAdapter();
            ad.SelectCommand = CreateSqlCommand(Sql);
            ad.Fill(ds);
            CloseCnn();
            return ds;
        }

        /// <summary>
        /// 执行多条SQL语句，采用事务处理
        /// </summary>
        /// <param name="sqllist">sql语句组</param>
        /// <returns></returns>
        public static int ExecuteSqlGroup(ArrayList sqllist)
        {
            int num = 0;
            DbConnection conn = CreateConnection();  //定义连接
            conn.Open();
            DbCommand cmd = conn.CreateCommand();   //定义cmd变量
            DbTransaction trans = conn.BeginTransaction(); //定义并开始事务
            cmd.Transaction = trans;   //开始事务
            try
            {
                for (int i = 0; i < sqllist.Count; i++)
                {
                    string strsql = sqllist[i].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();

                    }
                }
                trans.Commit();
                num = 1;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            return num;
        }



    }
}
