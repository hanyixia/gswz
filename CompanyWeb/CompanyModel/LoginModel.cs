using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    public class LoginModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int USER_ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string USER_NAME { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string USER_PASSWORD { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
    }
}
