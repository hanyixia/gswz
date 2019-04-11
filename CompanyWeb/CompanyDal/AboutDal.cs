using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyModel;
using CompanyCommon;
using Dapper;

namespace CompanyDal
{
    /// <summary>
    /// 关于我们数据层
    /// </summary>
    public class AboutDal
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<AboutModel> GetAll()
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "select * from TEST";
                return conn.Query<AboutModel>(sql).ToList();
            }
        }

        /// <summary>
        /// 根据标题查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public AboutModel GetByTitle(string title)
        {
            return GetAll().Where(a=>a.TITLE==title).SingleOrDefault();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add(AboutModel model)
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "insert into TEST"
                           + " (TITLE,COM_INTRO,CREATETIME)"
                           + " values "
                           + " (@TITLE,@COM_INTRO,@CREATETIME)";
                return conn.Execute(sql, model);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(AboutModel model)
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "update TEST set"
                           + " TITLE=@TITLE, "
                           + " COM_INTRO=@COM_INTRO, "
                           + " CREATETIME=@CREATETIME";
                return conn.Execute(sql, model);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete(int ID)
        {
            using (var conn = DapperHelper.CreateConnection())
            {
                string sql = "delete from TEST where ID=" + ID;
                return conn.Execute(sql);
            }
        }
    }
}
