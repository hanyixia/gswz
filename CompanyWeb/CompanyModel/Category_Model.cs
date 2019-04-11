using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Category_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Category_Model
    {
        public Category_Model()
        { }
        #region Model
        private int _category_id;
        private string _category_name;
        private int _parent_id;
        private int? _category_status;
        private DateTime? _create_time;
        private string _category_jump;
        private int _id;
        private string _imgpath;
        /// <summary>
        /// 分类编号
        /// </summary>
        public int CATEGORY_ID
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CATEGORY_NAME
        {
            set { _category_name = value; }
            get { return _category_name; }
        }
        /// <summary>
        /// 父级编号
        /// </summary>
        public int PARENT_ID
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// 分类状态（0隐藏；1显示）
        /// </summary>
        public int? CATEGORY_STATUS
        {
            set { _category_status = value; }
            get { return _category_status; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 分类级别
        /// </summary>
        public string CATEGORY_JUMP
        {
            set { _category_jump = value; }
            get { return _category_jump; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IMGPATH
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        #endregion Model

    }
}
