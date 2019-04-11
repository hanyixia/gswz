using CompanyDal;
using CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyBll
{
    public class LoginBll
    {
        LoginDal dal = new LoginDal();

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<LoginModel> GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 根据用户名和密码查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public LoginModel GetByNameAndPass(string name, string pass)
        {
            return dal.GetByNameAndPass(name,pass);
        }
    }
}
