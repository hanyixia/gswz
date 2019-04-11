using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// NewsHandler 的摘要说明
    /// </summary>
    public class NewsHandler : IHttpHandler
    {
        Category_Bll bllcate = new Category_Bll();
        Text_Bll blltext=new Text_Bll();
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

            #region 新闻列表
            if (funcName == "getlist")
            {
                string strlist = "";
                DataSet ds = blltext.GetList(10,"CATEGORY_ID=13","TEXT_ID desc");
                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strlist += "<a href='Content.aspx?TEXT_ID=" + dt.Rows[i]["TEXT_ID"].ToString() + "' target='_blank'><div class='yuan'></div><p>" + dt.Rows[i]["TEXT_TITLE"] + "</p><span>" + dt.Rows[i]["CREATE_TIME"] + "</span></a>";
                       
                    }
                    context.Response.Write(strlist);
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