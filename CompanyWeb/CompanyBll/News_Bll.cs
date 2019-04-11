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
	/// News_Bll
	/// </summary>
    public class News_Bll
    {
        News_Dal dal = new News_Dal();
        public News_Bll()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(News_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(News_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NEWS_ID)
        {

            return dal.Delete(NEWS_ID);
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
