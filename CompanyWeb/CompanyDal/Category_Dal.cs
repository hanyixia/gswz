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
    /// 数据访问类:Category_Dal
    /// </summary>
    public class Category_Dal
    {
        public Category_Dal()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Category_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CATEGORY_ID != null)
            {
                strSql1.Append("CATEGORY_ID,");
                strSql2.Append("" + model.CATEGORY_ID + ",");
            }
            if (model.CATEGORY_NAME != null)
            {
                strSql1.Append("CATEGORY_NAME,");
                strSql2.Append("'" + model.CATEGORY_NAME + "',");
            }
            if (model.PARENT_ID != null)
            {
                strSql1.Append("PARENT_ID,");
                strSql2.Append("" + model.PARENT_ID + ",");
            }
            if (model.CATEGORY_STATUS != null)
            {
                strSql1.Append("CATEGORY_STATUS,");
                strSql2.Append("" + model.CATEGORY_STATUS + ",");
            }
            if (model.CREATE_TIME != null)
            {
                strSql1.Append("CREATE_TIME,");
                strSql2.Append("'" + model.CREATE_TIME + "',");
            }
            if (model.CATEGORY_JUMP != null)
            {
                strSql1.Append("CATEGORY_JUMP,");
                strSql2.Append("'" + model.CATEGORY_JUMP + "',");
            }
            if (model.IMGPATH != null)
            {
                strSql1.Append("IMGPATH,");
                strSql2.Append("'" + model.IMGPATH + "',");
            }
            strSql.Append("insert into COM_CATEGORY(");
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
        public bool Update(Category_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COM_CATEGORY set ");
            if (model.CATEGORY_ID != null)
            {
                strSql.Append("CATEGORY_ID=" + model.CATEGORY_ID + ",");
            }
            if (model.CATEGORY_NAME != null)
            {
                strSql.Append("CATEGORY_NAME='" + model.CATEGORY_NAME + "',");
            }
            else
            {
                strSql.Append("CATEGORY_NAME= null ,");
            }
            if (model.PARENT_ID != null)
            {
                strSql.Append("PARENT_ID=" + model.PARENT_ID + ",");
            }
            if (model.CATEGORY_STATUS != null)
            {
                strSql.Append("CATEGORY_STATUS=" + model.CATEGORY_STATUS + ",");
            }
            else
            {
                strSql.Append("CATEGORY_STATUS= null ,");
            }
            if (model.CREATE_TIME != null)
            {
                strSql.Append("CREATE_TIME='" + model.CREATE_TIME + "',");
            }
            else
            {
                strSql.Append("CREATE_TIME= null ,");
            }
            if (model.CATEGORY_JUMP != null)
            {
                strSql.Append("CATEGORY_JUMP='" + model.CATEGORY_JUMP + "',");
            }
            else
            {
                strSql.Append("CATEGORY_JUMP= null ,");
            }
            if (model.IMGPATH != null)
            {
                strSql.Append("IMGPATH='" + model.IMGPATH + "',");
            }
            else
            {
                strSql.Append("IMGPATH= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from COM_CATEGORY ");
            strSql.Append(" where ID=" + ID + "");
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from COM_CATEGORY ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select CATEGORY_ID,CATEGORY_NAME,PARENT_ID,CATEGORY_STATUS,CREATE_TIME,CATEGORY_JUMP,ID,IMGPATH");
            strSql.Append(" FROM COM_CATEGORY ");
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
            strSql.Append(" CATEGORY_ID,CATEGORY_NAME,PARENT_ID,CATEGORY_STATUS,CREATE_TIME,CATEGORY_JUMP,ID,IMGPATH");
            strSql.Append(" FROM COM_CATEGORY ");
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
