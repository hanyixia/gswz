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
    /// Contract_Bll
    /// </summary>
    public partial class Contract_Bll
    {
        Contract_Dal dal = new Contract_Dal();
        public Contract_Bll()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Contract_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Contract_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MESS_ID)
        {

            return dal.Delete(MESS_ID);
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