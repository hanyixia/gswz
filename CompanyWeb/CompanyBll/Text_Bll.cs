using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyModel;
using CompanyDal;
using System.Data;

namespace CompanyBll
{
    /// <summary>
	/// Text_Bll
	/// </summary>
	public partial class Text_Bll
	{
		Text_Dal dal=new Text_Dal();
		public Text_Bll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TEXT_ID)
		{
			return dal.Exists(TEXT_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Text_Model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Text_Model model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TEXT_ID)
		{
			
			return dal.Delete(TEXT_ID);
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        #endregion  BasicMethod


    }
}
