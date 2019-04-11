using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// AboutHandler 的摘要说明
    /// </summary>
    public class AboutHandler : IHttpHandler
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
                DataSet ds = bllcate.GetList(7, "PARENT_ID=0", "CATEGORY_ID asc");
                DataTable dt = ds.Tables[0];
                //string statusvalue = dt.Rows[0]["CATEGORY_STATUS"].ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 1)
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

            #region 关于我们图片
            if (funcName == "getgytp")
            {
                string strgytp = "";
                DataSet ds = bllcate.GetList("CATEGORY_ID=11");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strgytp += "<img src='" + dt.Rows[i]["IMGPATH"] + "'>";
                    }
                    context.Response.Write(strgytp);
                }
            }
            #endregion

            #region 侧导航
            if (funcName == "getcdh")
            {
                string strcdh = "";
                DataSet ds = bllcate.GetList(6, "PARENT_ID=11", "ID asc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            strcdh += "<li class='active'>" + dt.Rows[i]["CATEGORY_NAME"].ToString() + "</li>";
                        }
                        else
                        {
                            strcdh += "<li>" + dt.Rows[i]["CATEGORY_NAME"].ToString() + "</li>";
                        }
                    }
                    context.Response.Write(strcdh);
                }
            }
            #endregion

            #region 公司简介
            if (funcName == "getgsjj")
            {
                string strgsjj = "";
                DataSet ds = blltext.GetList("CATEGORY_ID=1101");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    strgsjj = dt.Rows[0]["TEXT_CONTENT"].ToString();                 
                }
                context.Response.Write(strgsjj);
            }
            #endregion

            #region 公司文化
            if (funcName == "getgswh")
            {
                string strgswh = "";
                DataSet ds = blltext.GetList(6,"CATEGORY_ID=1102","TEXT_ID asc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strgswh += "<li><h3>"+dt.Rows[i]["TEXT_TITLE"]+"</h3><div class='glfz'><p>"+dt.Rows[i]["TEXT_CONTENT"]+"</p></div></li>";
                    }
                    context.Response.Write(strgswh);
                }               
            }
            #endregion

            #region 公司环境
            if (funcName == "getgshj")
            {
                string strgshj = "";
                DataSet ds = blltext.GetList(9, "CATEGORY_ID=1103", "TEXT_ID desc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strgshj += "<li><img src='"+dt.Rows[i]["IMGPATH"]+"'><p>"+dt.Rows[i]["TEXT_TITLE"]+"</p></li>";
                    }
                    context.Response.Write(strgshj);
                }
            }
            #endregion

            #region 组织架构
            if (funcName == "getzzjg")
            {
                string strzzjg = "";
                DataSet ds = blltext.GetList("CATEGORY_ID=1104");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    strzzjg = @"<img src='" + dt.Rows[0]["IMGPATH"] + "'>";
                }
                context.Response.Write(strzzjg);
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