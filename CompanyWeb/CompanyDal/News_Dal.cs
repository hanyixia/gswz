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
    /// 数据访问类:News_Dal
    /// </summary>
    public class News_Dal
    {
        public News_Dal()
        {}
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(News_Model model)
        {
            StringBuilder strSql=new StringBuilder();
            StringBuilder strSql1=new StringBuilder();
            StringBuilder strSql2=new StringBuilder();
            if (model.NEWS_DESC != null)
            {
                strSql1.Append("NEWS_DESC,");
                strSql2.Append("'"+model.NEWS_DESC+"',");
            }
            if (model.NEWS_CONTENT != null)
            {
                strSql1.Append("NEWS_CONTENT,");
                strSql2.Append("'"+model.NEWS_CONTENT+"',");
            }
            if (model.NEWS_IMG != null)
            {
                strSql1.Append("NEWS_IMG,");
                strSql2.Append("'"+model.NEWS_IMG+"',");
            }
            if (model.CREATE_TIME != null)
            {
                strSql1.Append("CREATE_TIME,");
                strSql2.Append("'"+model.CREATE_TIME+"',");
            }
            if (model.NEWS_TITLE != null)
            {
                strSql1.Append("NEWS_TITLE,");
                strSql2.Append("'"+model.NEWS_TITLE+"',");
            }
            strSql.Append("insert into COM_NEWS(");
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
        public bool Update(News_Model model)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("update COM_NEWS set ");
            if (model.NEWS_DESC != null)
            {
                strSql.Append("NEWS_DESC='"+model.NEWS_DESC+"',");
            }
            else
            {
                strSql.Append("NEWS_DESC= null ,");
            }
            if (model.NEWS_CONTENT != null)
            {
                strSql.Append("NEWS_CONTENT='"+model.NEWS_CONTENT+"',");
            }
            else
            {
                strSql.Append("NEWS_CONTENT= null ,");
            }
            if (model.NEWS_IMG != null)
            {
                strSql.Append("NEWS_IMG='"+model.NEWS_IMG+"',");
            }
            else
            {
                strSql.Append("NEWS_IMG= null ,");
            }
            if (model.CREATE_TIME != null)
            {
                strSql.Append("CREATE_TIME='"+model.CREATE_TIME+"',");
            }
            else
            {
                strSql.Append("CREATE_TIME= null ,");
            }
            if (model.NEWS_TITLE != null)
            {
                strSql.Append("NEWS_TITLE='"+model.NEWS_TITLE+"',");
            }
            else
            {
                strSql.Append("NEWS_TITLE= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where NEWS_ID="+ model.NEWS_ID+"");
            int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public bool Delete(int NEWS_ID)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from COM_NEWS ");
            strSql.Append(" where NEWS_ID="+NEWS_ID+"" );
            int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public bool DeleteList(string NEWS_IDlist )
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from COM_NEWS ");
            strSql.Append(" where NEWS_ID in ("+NEWS_IDlist + ")  ");
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select NEWS_ID,NEWS_DESC,NEWS_CONTENT,NEWS_IMG,CREATE_TIME,NEWS_TITLE ");
            strSql.Append(" FROM COM_NEWS ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where "+strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
    }
}
