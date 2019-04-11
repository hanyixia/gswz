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
	/// Admin_Bll
	/// </summary>
    public class Admin_Bll
    {
        Admin_Dal dal = new Admin_Dal();
        public Admin_Bll()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Admin_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Admin_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int USER_ID)
        {

            return dal.Delete(USER_ID);
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
