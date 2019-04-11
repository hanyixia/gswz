using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// IndexHandler 的摘要说明
    /// </summary>
    public class IndexHandler : IHttpHandler
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
                        if (i == 0)
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

            #region 业务范围
            if(funcName=="getywpic")
            {
                string strywpic = "";
                DataSet dsText = blltext.GetList(4,"CATEGORY_ID=1001","TEXT_ID asc");
                DataTable dt = dsText.Tables[0];
                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strywpic += "<li><img src='" + dt.Rows[i]["IMGPATH"] + "' alt=''><div class='mark'>" + dt.Rows[i]["TEXT_TITLE"] + "</div></li>";
                    }
                    context.Response.Write(strywpic);
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    { 
                        strgsjj+="<div class='gs_img'><img src='" + dt.Rows[i]["IMGPATH"].ToString().Trim() + "' alt=''></div><a href='About.aspx'>"+dt.Rows[i]["TEXT_DESCRIPT"]+"</a>";
                    }
                    context.Response.Write(strgsjj);
                }
            }
            #endregion

            #region 动态新闻
            if (funcName == "getxwdt")
            {
                string strxwdt = "";
                DataSet ds = blltext.GetList(2, "CATEGORY_ID=13", "TEXT_ID desc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strxwdt += "<li><img src='" + dt.Rows[i]["IMGPATH"] + "' /><div class='xw_contemt'><a href='Content.aspx?TEXT_ID=" + dt.Rows[i]["TEXT_ID"].ToString() + "' target='_blank'>" + dt.Rows[i]["TEXT_TITLE"] + "</a><p>" + dt.Rows[i]["TEXT_DESCRIPT"] + "</p></div></li>";
                    }
                    context.Response.Write(strxwdt);
                }
            }
            #endregion

            #region 轮播图
            if (funcName == "getimglunbo")
            {
                string strimglunbo = "";
                DataSet ds = blltext.GetList(8, "CATEGORY_ID=100201", "TEXT_ID asc");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strimglunbo += "<div class='swiper-slide'><img src='" + dt.Rows[i]["IMGPATH"].ToString().Trim() + "' alt=''/></div>";
                    }
                    context.Response.Write(strimglunbo);
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