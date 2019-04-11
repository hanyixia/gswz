using CompanyModel;
using CompanyDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyBll
{
    /// <summary>
    /// 关于我们业务层
    /// </summary>
    public class AboutBll
    {
        AboutDal aboutDal = new AboutDal();

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<AboutModel> GetAll()
        {
            return aboutDal.GetAll();
        }

        /// <summary>
        /// 根据标题查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public AboutModel GetByTitle(string title)
        {
            return aboutDal.GetByTitle(title);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(AboutModel model)
        {
            return aboutDal.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(AboutModel model)
        {
            return aboutDal.Update(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int ID)
        {
            return aboutDal.Delete(ID);
        }
    }
}
