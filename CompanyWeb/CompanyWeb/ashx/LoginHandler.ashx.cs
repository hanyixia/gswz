using CompanyBll;
using CompanyCommon;
using CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        LoginBll loginBll = new LoginBll();

        public void ProcessRequest(HttpContext context)
        {
            string funcName=context.Request.QueryString["funName"].ToString();
            if (funcName == "Login")
            {
                string name = context.Request.QueryString["name"].ToString();
                string password = context.Request.QueryString["password"].ToString();
                context.Session["name"]=name;

                LoginModel model = loginBll.GetByNameAndPass(name, EncryptHelper.Encrypt(password));
                if (model != null)
                {
                    context.Response.Write("OK");
                }
                else
                {
                    context.Response.Write("error");
                }
            }
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