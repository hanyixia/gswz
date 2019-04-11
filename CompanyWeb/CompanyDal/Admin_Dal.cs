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
	/// 数据访问类:Admin_Dal
	/// </summary>
	public class Admin_Dal
	{
		public Admin_Dal()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Admin_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.USER_NAME != null)
			{
				strSql1.Append("USER_NAME,");
				strSql2.Append("'"+model.USER_NAME+"',");
			}
			if (model.USER_PASSWORD != null)
			{
				strSql1.Append("USER_PASSWORD,");
				strSql2.Append("'"+model.USER_PASSWORD+"',");
			}
			if (model.CREATE_TIME != null)
			{
				strSql1.Append("CREATE_TIME,");
				strSql2.Append("'"+model.CREATE_TIME+"',");
			}
			strSql.Append("insert into COM_USER(");
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
        public bool Update(Admin_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update COM_USER set ");
			if (model.USER_NAME != null)
			{
				strSql.Append("USER_NAME='"+model.USER_NAME+"',");
			}
			else
			{
				strSql.Append("USER_NAME= null ,");
			}
			if (model.USER_PASSWORD != null)
			{
				strSql.Append("USER_PASSWORD='"+model.USER_PASSWORD+"',");
			}
			else
			{
				strSql.Append("USER_PASSWORD= null ,");
			}
			if (model.CREATE_TIME != null)
			{
				strSql.Append("CREATE_TIME='"+model.CREATE_TIME+"',");
			}
			else
			{
				strSql.Append("CREATE_TIME= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where USER_ID="+ model.USER_ID+"");
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
		public bool Delete(int USER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from COM_USER ");
			strSql.Append(" where USER_ID="+USER_ID+"" );
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select USER_ID,USER_NAME,USER_PASSWORD,CREATE_TIME ");
			strSql.Append(" FROM COM_USER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
                strSql.Append(" order by CREATE_TIME desc");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        #endregion  Method
    }

}
