using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CompanyModel;
using CompanyDal;

namespace CompanyBll
{
    /// <summary>
	/// BLL_Com
	/// </summary>
    public  class BLL_Com
    {
        DAl_Com dal = new DAl_Com();
        public BLL_Com()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model_Com model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model_Com model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int COLUMN_ID)
        {

            return dal.Delete(COLUMN_ID);
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