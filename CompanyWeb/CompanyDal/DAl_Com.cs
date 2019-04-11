using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyModel;
using CompanyCommon;
using Dapper;
using DATEBASE;
using System.Data;

namespace CompanyDal
{
    /// <summary>
    /// 数据访问类:DAl_Com
    /// </summary>
    public class DAl_Com
    {
        public DAl_Com()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model_Com model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.COLUMN_NAME != null)
            {
                strSql1.Append("COLUMN_NAME,");
                strSql2.Append("'" + model.COLUMN_NAME + "',");
            }
            if (model.CREATE_TIME != null)
            {
                strSql1.Append("CREATE_TIME,");
                strSql2.Append("'" + model.CREATE_TIME + "',");
            }
            strSql.Append("insert into COM_COLUMN(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model_Com model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COM_COLUMN set ");
            if (model.COLUMN_NAME != null)
            {
                strSql.Append("COLUMN_NAME='" + model.COLUMN_NAME + "',");
            }
            else
            {
                strSql.Append("COLUMN_NAME= null ,");
            }
            if (model.CREATE_TIME != null)
            {
                strSql.Append("CREATE_TIME='" + model.CREATE_TIME + "',");
            }
            else
            {
                strSql.Append("CREATE_TIME= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where COLUMN_ID=" + model.COLUMN_ID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int COLUMN_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from COM_COLUMN ");
            strSql.Append(" where COLUMN_ID=" + COLUMN_ID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string COLUMN_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from COM_COLUMN ");
            strSql.Append(" where COLUMN_ID in (" + COLUMN_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select COLUMN_ID,COLUMN_NAME,CREATE_TIME ");
        //    strSql.Append(" FROM COM_COLUMN ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}
        public DataSet GetList(string strWhere)
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "select * from COM_COLUMN";
                return DbHelperSQL.Query(sql.ToString());
            }
        }


        #endregion  Method
    }
}