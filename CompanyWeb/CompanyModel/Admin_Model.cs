using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Admin_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Admin_Model
    {
        public Admin_Model()
        { }
        #region Model
        private int _user_id;
        private string _user_name;
        private string _user_password;
        private DateTime? _create_time;
        /// <summary>
        /// 
        /// </summary>
        public int USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USER_PASSWORD
        {
            set { _user_password = value; }
            get { return _user_password; }
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
