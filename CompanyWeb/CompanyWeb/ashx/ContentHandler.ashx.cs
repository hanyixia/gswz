using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// ContentHandler 的摘要说明
    /// </summary>
    public class ContentHandler : IHttpHandler
    {
        Category_Bll bllcate = new Category_Bll();
        Text_Bll blltext = new Text_Bll();
        public void ProcessRequest(HttpContext context)
        {
            string funcName = context.Request.QueryString["funName"].ToString();
            #region 导航栏
            if (funcName == "getBT")
            {
                string strbt = "";
                DataSet ds = bllcate.GetList(7, "PARENT_ID=0", "CATEGORY_ID");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 3)
                        {
                            strbt += "<li class='active'><a href='" + dt.Rows[i]["CATEGORY_JUMP"] + "'>" + dt.Rows[i]["CATEGORY_NAME"].ToString() + "</a></li>";
                        }
                        else
                        {
                            strbt += "<li><a href='" + dt.Rows[i]["CATEGORY_JUMP"] + "'>" + dt.Rows[i]["CATEGORY_NAME"].ToString() + "</a></li>";
                        }
                    }
                    context.Response.Write(strbt);
                }
            }
            #endregion

            #region 输出
            if (funcName == "getcont")
            {
                int nId = Convert.ToInt32(context.Request.QueryString["TEXT_ID"]);
                string strcont = "";
                DataSet ds = blltext.GetList("TEXT_ID=" + nId + "");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strcont += @"<span>" + dt.Rows[i]["TEXT_TITLE"] + "</span><div class='date'>发布日期："
                            + dt.Rows[i]["CREATE_TIME"] + "</div><h4>文章来源：" + dt.Rows[i]["TEXT_AUTHOR"].ToString()
                            + "</h4><p>" + dt.Rows[i]["TEXT_CONTENT"] + "</p>";
                    }
                    context.Response.Write(strcont);
                }
            }
            #endregion
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}