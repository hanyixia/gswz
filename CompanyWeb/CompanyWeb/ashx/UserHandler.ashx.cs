using CompanyBll;
using CompanyCommon;
using CompanyModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CompanyWeb.ashx
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //添加
            string funcName = context.Request.QueryString["funName"].ToString();
            if (funcName == "AddUser")
            {
                string name = context.Request.QueryString["name"].ToString();
                string password = context.Request.QueryString["password"].ToString();
                Admin_Bll bll = new Admin_Bll();
                DataSet ds = bll.GetList("");
                DataTable dt = ds.Tables[0];
                bool validate = false;
                if (dt.Rows.Count > 0)
                { 
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        if (dt.Rows[i]["USER_NAME"].ToString() == name)
                        {
                            validate = true;
                            break;
                        }
                    }
                }
                if (validate == true)
                {
                    context.Response.Write("UserExists");
                }
                else
                {
                    Admin_Model model = new Admin_Model();
                    model.USER_NAME = name;
                    model.USER_PASSWORD = EncryptHelper.Encrypt(password);
                    model.CREATE_TIME = DateTime.Now;

                    int j = bll.Add(model);
                    if (j > 0)
                    {
                        context.Response.Write("OK");
                    }
                    else
                    {
                        context.Response.Write("error");
                    }
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