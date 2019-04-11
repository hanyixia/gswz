using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// ItemHandler 的摘要说明
    /// </summary>
    public class ItemHandler : IHttpHandler
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

            #region 项目图片
            if (funcName == "getxmtp")
            {
                string strxmtp = "";
                DataSet ds = bllcate.GetList("CATEGORY_ID=12");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strxmtp += "<img src='" + dt.Rows[i]["IMGPATH"] + "'>";
                    }
                    context.Response.Write(strxmtp);
                }
            }
            #endregion

            #region 项目案例
            if (funcName == "getxmal")
            {
                string strxmal = "";
                DataSet ds = blltext.GetList(9, "CATEGORY_ID=12", "TEXT_ID");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strxmal += "<li><a href='Item_content.aspx?TEXT_ID=" + dt.Rows[i]["TEXT_ID"].ToString() + "' target='_blank'><img src='" + dt.Rows[i]["IMGPATH"] + "'><p>" + dt.Rows[i]["TEXT_title"] + "</p></a></li>";
                    }
                    context.Response.Write(strxmal);
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