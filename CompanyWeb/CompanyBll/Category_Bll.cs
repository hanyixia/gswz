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
	/// Category_Bll
	/// </summary>
	public partial class Category_Bll
	{
		Category_Dal dal=new Category_Dal();
		public Category_Bll()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Category_Model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Category_Model model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
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
