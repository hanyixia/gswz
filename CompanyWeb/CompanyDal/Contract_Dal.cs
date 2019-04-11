using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyModel;
using DATEBASE;
using System.Data;

namespace CompanyDal
{
    /// <summary>
    /// 数据访问类:Contract_Dal
    /// </summary>
    public partial class Contract_Dal
    {
        public Contract_Dal()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Contract_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MESS_NAME != null)
            {
                strSql1.Append("MESS_NAME,");
                strSql2.Append("'" + model.MESS_NAME + "',");
            }
            if (model.MESS_TEL != null)
            {
                strSql1.Append("MESS_TEL,");
                strSql2.Append("'" + model.MESS_TEL + "',");
            }
            if (model.MESS_EMAIL != null)
            {
                strSql1.Append("MESS_EMAIL,");
                strSql2.Append("'" + model.MESS_EMAIL + "',");
            }
            if (model.MESS_CONTENT != null)
            {
                strSql1.Append("MESS_CONTENT,");
                strSql2.Append("'" + model.MESS_CONTENT + "',");
            }
            if (model.MESS_ADDRESS != null)
            {
                strSql1.Append("MESS_ADDRESS,");
                strSql2.Append("'" + model.MESS_ADDRESS + "',");
            }
            if (model.CREATE_TIME != null)
            {
                strSql1.Append("CREATE_TIME,");
                strSql2.Append("'" + model.CREATE_TIME + "',");
            }
            strSql.Append("insert into COM_MESSAGE(");
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
        public bool Update(Contract_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COM_MESSAGE set ");
            if (model.MESS_NAME != null)
            {
                strSql.Append("MESS_NAME='" + model.MESS_NAME + "',");
            }
            else
            {
                strSql.Append("MESS_NAME= null ,");
            }
            if (model.MESS_TEL != null)
            {
                strSql.Append("MESS_TEL='" + model.MESS_TEL + "',");
            }
            else
            {
                strSql.Append("MESS_TEL= null ,");
            }
            if (model.MESS_EMAIL != null)
            {
                strSql.Append("MESS_EMAIL='" + model.MESS_EMAIL + "',");
            }
            else
            {
                strSql.Append("MESS_EMAIL= null ,");
            }
            if (model.MESS_CONTENT != null)
            {
                strSql.Append("MESS_CONTENT='" + model.MESS_CONTENT + "',");
            }
            else
            {
                strSql.Append("MESS_CONTENT= null ,");
            }
            if (model.MESS_ADDRESS != null)
            {
                strSql.Append("MESS_ADDRESS='" + model.MESS_ADDRESS + "',");
            }
            else
            {
                strSql.Append("MESS_ADDRESS= null ,");
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
            strSql.Append(" where MESS_ID=" + model.MESS_ID + "");
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
        public bool Delete(int MESS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from COM_MESSAGE ");
            strSql.Append(" where MESS_ID=" + MESS_ID + "");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MESS_ID,MESS_NAME,MESS_TEL,MESS_EMAIL,MESS_CONTENT,MESS_ADDRESS,CREATE_TIME ");
            strSql.Append(" FROM COM_MESSAGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MESS_ID,MESS_NAME,MESS_TEL,MESS_EMAIL,MESS_CONTENT,MESS_ADDRESS,CREATE_TIME ");
            strSql.Append(" FROM COM_MESSAGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method

    }
}
