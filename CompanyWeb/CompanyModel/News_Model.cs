using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyModel
{
    /// <summary>
    ///  News_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class News_Model
    {
        public News_Model()
        { }
        #region Model
        private int _news_id;
        private string _news_desc;
        private string _news_content;
        private string _news_img;
        private DateTime? _create_time;
        private string _news_title;
        /// <summary>
        /// 新闻编号
        /// </summary>
        public int NEWS_ID
        {
            set { _news_id = value; }
            get { return _news_id; }
        }
        /// <summary>
        /// 新闻描述
        /// </summary>
        public string NEWS_DESC
        {
            set { _news_desc = value; }
            get { return _news_desc; }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string NEWS_CONTENT
        {
            set { _news_content = value; }
            get { return _news_content; }
        }
        /// <summary>
        /// 新闻图片
        /// </summary>
        public string NEWS_IMG
        {
            set { _news_img = value; }
            get { return _news_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NEWS_TITLE
        {
            set { _news_title = value; }
            get { return _news_title; }
        }
        #endregion Model

    }
}
