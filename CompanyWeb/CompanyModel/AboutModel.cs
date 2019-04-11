using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// 关于我们
    /// </summary>
    public class AboutModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string TITLE { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string COM_INTRO { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CREATETIME { get; set; }

        
    }
}
