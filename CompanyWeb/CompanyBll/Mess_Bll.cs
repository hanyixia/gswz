using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyDal;
using CompanyModel;
using System.Data;

namespace CompanyBll
{
    /// <summary>
	/// Mess_Bll
	/// </summary>
	public class Mess_Bll
	{
		Mess_Dal dal=new Mess_Dal();
		public Mess_Bll()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Mess_Model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mess_Model model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MESSAGE_ID)
		{
			
			return dal.Delete(MESSAGE_ID);
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
     #endregion
    }
}
