using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyBll;
using System.Data;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// ContractHandler 的摘要说明
    /// </summary>
    public class ContractHandler : IHttpHandler
    {
        Category_Bll bllcate = new Category_Bll();
        Contract_Bll bllcontract = new Contract_Bll();
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
                        if (i == 4)
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

            #region 联系人信息
            if (funcName == "getinfo")
            {
                string strinfo = "";
                DataSet ds = bllcontract.GetList("MESS_ID=1");
                DataTable dt = ds.Tables[0];
                //string statusvalue = dt.Rows[0]["CATEGORY_STATUS"].ToString();
                if (dt.Rows.Count > 0)
                {
                    strinfo = "<span>联系人：" + dt.Rows[0]["MESS_NAME"] + "</span><span>邮&nbsp;&nbsp;&nbsp;箱：" + dt.Rows[0]["MESS_EMAIL"] + "</span><span>电&nbsp;&nbsp;&nbsp;话：" + dt.Rows[0]["MESS_TEL"] + "</span><span>地&nbsp;&nbsp;&nbsp;址：" + dt.Rows[0]["MESS_ADDRESS"] + "</span>";                  
                }
                context.Response.Write(strinfo);
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