using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Contract_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Contract_Model
    {
        public Contract_Model()
        { }
        #region Model
        private int _mess_id;
        private string _mess_name;
        private string _mess_tel;
        private string _mess_email;
        private string _mess_content;
        private string _mess_address;
        private DateTime? _create_time;
        /// <summary>
        /// 
        /// </summary>
        public int MESS_ID
        {
            set { _mess_id = value; }
            get { return _mess_id; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MESS_NAME
        {
            set { _mess_name = value; }
            get { return _mess_name; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string MESS_TEL
        {
            set { _mess_tel = value; }
            get { return _mess_tel; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string MESS_EMAIL
        {
            set { _mess_email = value; }
            get { return _mess_email; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string MESS_CONTENT
        {
            set { _mess_content = value; }
            get { return _mess_content; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string MESS_ADDRESS
        {
            set { _mess_address = value; }
            get { return _mess_address; }
        }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

    }
}
