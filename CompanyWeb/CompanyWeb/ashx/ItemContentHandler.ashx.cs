using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// ItemContentHandler 的摘要说明
    /// </summary>
    public class ItemContentHandler : IHttpHandler
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
                        if (i == 2)
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
                DataSet ds = blltext.GetList(1,"TEXT_ID=" + nId + "","TEXT_ID desc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strcont += "<img src='" + dt.Rows[i]["IMGPATH"] + "'><div class='inst_content'><h2>项目——介绍</h2><h4>" + dt.Rows[i]["TEXT_TITLE"] + ":</h4><p>" + dt.Rows[i]["TEXT_CONTENT"] + "</p></div>";
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