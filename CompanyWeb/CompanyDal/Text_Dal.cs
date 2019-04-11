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
	/// 数据访问类:Text_Dal
	/// </summary>
	public partial class Text_Dal
	{
		public Text_Dal()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TEXT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from COM_TEXT");
			strSql.Append(" where TEXT_ID="+TEXT_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Text_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.TEXT_TITLE != null)
			{
				strSql1.Append("TEXT_TITLE,");
				strSql2.Append("'"+model.TEXT_TITLE+"',");
			}
			if (model.TEXT_DESCRIPT != null)
			{
				strSql1.Append("TEXT_DESCRIPT,");
				strSql2.Append("'"+model.TEXT_DESCRIPT+"',");
			}
			if (model.TEXT_CONTENT != null)
			{
				strSql1.Append("TEXT_CONTENT,");
				strSql2.Append("'"+model.TEXT_CONTENT+"',");
			}
			if (model.IMGPATH != null)
			{
				strSql1.Append("IMGPATH,");
				strSql2.Append("'"+model.IMGPATH+"',");
			}
			if (model.TEXT_AUTHOR != null)
			{
				strSql1.Append("TEXT_AUTHOR,");
				strSql2.Append("'"+model.TEXT_AUTHOR+"',");
			}
			if (model.CREATE_TIME != null)
			{
				strSql1.Append("CREATE_TIME,");
				strSql2.Append("'"+model.CREATE_TIME+"',");
			}
			if (model.CATEGORY_ID != null)
			{
				strSql1.Append("CATEGORY_ID,");
				strSql2.Append(""+model.CATEGORY_ID+",");
			}
			strSql.Append("insert into COM_TEXT(");
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
        public bool Update(Text_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update COM_TEXT set ");
			if (model.TEXT_TITLE != null)
			{
				strSql.Append("TEXT_TITLE='"+model.TEXT_TITLE+"',");
			}
			else
			{
				strSql.Append("TEXT_TITLE= null ,");
			}
			if (model.TEXT_DESCRIPT != null)
			{
				strSql.Append("TEXT_DESCRIPT='"+model.TEXT_DESCRIPT+"',");
			}
			else
			{
				strSql.Append("TEXT_DESCRIPT= null ,");
			}
			if (model.TEXT_CONTENT != null)
			{
				strSql.Append("TEXT_CONTENT='"+model.TEXT_CONTENT+"',");
			}
			else
			{
				strSql.Append("TEXT_CONTENT= null ,");
			}
			if (model.IMGPATH != null)
			{
				strSql.Append("IMGPATH='"+model.IMGPATH+"',");
			}
			else
			{
				strSql.Append("IMGPATH= null ,");
			}
			if (model.TEXT_AUTHOR != null)
			{
				strSql.Append("TEXT_AUTHOR='"+model.TEXT_AUTHOR+"',");
			}
			else
			{
				strSql.Append("TEXT_AUTHOR= null ,");
			}
			if (model.CREATE_TIME != null)
			{
				strSql.Append("CREATE_TIME='"+model.CREATE_TIME+"',");
			}
			else
			{
				strSql.Append("CREATE_TIME= null ,");
			}
			if (model.CATEGORY_ID != null)
			{
				strSql.Append("CATEGORY_ID="+model.CATEGORY_ID+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where TEXT_ID="+ model.TEXT_ID+"");
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
		public bool Delete(int TEXT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from COM_TEXT ");
			strSql.Append(" where TEXT_ID="+TEXT_ID+"" );
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
			strSql.Append("select TEXT_ID,TEXT_TITLE,TEXT_DESCRIPT,TEXT_CONTENT,IMGPATH,TEXT_AUTHOR,CREATE_TIME,CATEGORY_ID ");
			strSql.Append(" FROM COM_TEXT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append(" TEXT_ID,TEXT_TITLE,TEXT_DESCRIPT,TEXT_CONTENT,IMGPATH,TEXT_AUTHOR,CREATE_TIME,CATEGORY_ID ");
            strSql.Append(" FROM COM_TEXT ");
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
