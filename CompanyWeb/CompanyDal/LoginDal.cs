using CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using CompanyCommon;

namespace CompanyDal
{
    public class LoginDal
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<LoginModel> GetAll()
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "select * from COM_USER";
                return conn.Query<LoginModel>(sql).ToList();
            }
        }

        /// <summary>
        /// 根据用户名和密码查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public LoginModel GetByNameAndPass(string name, string pass)
        {
            return GetAll().Where(a => a.USER_NAME == name && a.USER_PASSWORD==pass).SingleOrDefault();
        }
    }
}
