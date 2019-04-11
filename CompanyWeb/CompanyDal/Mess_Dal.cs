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
	/// 数据访问类:Mess_Dal
	/// </summary>
	public partial class Mess_Dal
	{
		public Mess_Dal()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mess_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.MESSAGE_NAME != null)
			{
				strSql1.Append("MESSAGE_NAME,");
				strSql2.Append("'"+model.MESSAGE_NAME+"',");
			}
			if (model.MESSAGE_EMAIL != null)
			{
				strSql1.Append("MESSAGE_EMAIL,");
				strSql2.Append("'"+model.MESSAGE_EMAIL+"',");
			}
			if (model.MESSAGE_PHONE != null)
			{
				strSql1.Append("MESSAGE_PHONE,");
				strSql2.Append("'"+model.MESSAGE_PHONE+"',");
			}
			if (model.MESSAGE_CONTENT != null)
			{
				strSql1.Append("MESSAGE_CONTENT,");
				strSql2.Append("'"+model.MESSAGE_CONTENT+"',");
			}
			if (model.CREATE_TIME != null)
			{
				strSql1.Append("CREATE_TIME,");
				strSql2.Append("'"+model.CREATE_TIME+"',");
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
		public bool Update(Mess_Model model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update COM_MESSAGE set ");
			if (model.MESSAGE_NAME != null)
			{
				strSql.Append("MESSAGE_NAME='"+model.MESSAGE_NAME+"',");
			}
			else
			{
				strSql.Append("MESSAGE_NAME= null ,");
			}
			if (model.MESSAGE_EMAIL != null)
			{
				strSql.Append("MESSAGE_EMAIL='"+model.MESSAGE_EMAIL+"',");
			}
			else
			{
				strSql.Append("MESSAGE_EMAIL= null ,");
			}
			if (model.MESSAGE_PHONE != null)
			{
				strSql.Append("MESSAGE_PHONE='"+model.MESSAGE_PHONE+"',");
			}
			else
			{
				strSql.Append("MESSAGE_PHONE= null ,");
			}
			if (model.MESSAGE_CONTENT != null)
			{
				strSql.Append("MESSAGE_CONTENT='"+model.MESSAGE_CONTENT+"',");
			}
			else
			{
				strSql.Append("MESSAGE_CONTENT= null ,");
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
			strSql.Append(" where MESSAGE_ID="+ model.MESSAGE_ID+"");
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
		public bool Delete(int MESSAGE_ID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from COM_MESSAGE ");
			strSql.Append(" where MESSAGE_ID="+MESSAGE_ID+"" );
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
			strSql.Append("select MESSAGE_ID,MESSAGE_NAME,MESSAGE_EMAIL,MESSAGE_PHONE,MESSAGE_CONTENT,CREATE_TIME ");
            strSql.Append(" FROM COM_MESSAGE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        #endregion  Method
    }
}
