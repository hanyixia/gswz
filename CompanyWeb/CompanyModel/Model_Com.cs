using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Model_Com:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public  class Model_Com
    {
        public Model_Com()
        { }
        #region Model
        private int _column_id;
        private string _column_name;
        private DateTime? _create_time;
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int COLUMN_ID
        {
            set { _column_id = value; }
            get { return _column_id; }
        }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string COLUMN_NAME
        {
            set { _column_name = value; }
            get { return _column_name; }
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
