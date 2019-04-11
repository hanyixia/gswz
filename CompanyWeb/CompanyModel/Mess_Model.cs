using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Mess_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Mess_Model
    {
        public Mess_Model()
        { }
        #region Model
        private int _message_id;
        private string _message_name;
        private string _message_email;
        private string _message_phone;
        private string _message_content;
        private DateTime? _create_time;
        /// <summary>
        /// 留言编号
        /// </summary>
        public int MESSAGE_ID
        {
            set { _message_id = value; }
            get { return _message_id; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MESSAGE_NAME
        {
            set { _message_name = value; }
            get { return _message_name; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string MESSAGE_EMAIL
        {
            set { _message_email = value; }
            get { return _message_email; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MESSAGE_PHONE
        {
            set { _message_phone = value; }
            get { return _message_phone; }
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string MESSAGE_CONTENT
        {
            set { _message_content = value; }
            get { return _message_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

    }
}
