using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    /// Text_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Text_Model
    {
        public Text_Model()
        { }
        #region Model
        private int _text_id;
        private string _text_title;
        private string _text_descript;
        private string _text_content;
        private string _imgpath;
        private string _text_author;
        private DateTime? _create_time;
        private int _category_id;
        /// <summary>
        /// 文本编号
        /// </summary>
        public int TEXT_ID
        {
            set { _text_id = value; }
            get { return _text_id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string TEXT_TITLE
        {
            set { _text_title = value; }
            get { return _text_title; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string TEXT_DESCRIPT
        {
            set { _text_descript = value; }
            get { return _text_descript; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string TEXT_CONTENT
        {
            set { _text_content = value; }
            get { return _text_content; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string IMGPATH
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string TEXT_AUTHOR
        {
            set { _text_author = value; }
            get { return _text_author; }
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
        /// 分类编号
        /// </summary>
        public int CATEGORY_ID
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        #endregion Model

    }
}
