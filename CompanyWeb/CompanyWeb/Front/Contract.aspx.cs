using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyModel;
using CompanyBll;

namespace CompanyWeb.Front
{
    public partial class Contract : System.Web.UI.Page
    {
        Contract_Model model = new Contract_Model();
        Contract_Bll bll = new Contract_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSave_Cilck(object sender, EventArgs e)
        {
            if (name.Value == "" || tel.Value == "" || con.Value == "" || email.Value == "")
            {
                Response.Write(@"<script>alert('请填写所有信息');</script>");
            }
            else
            {
                model.MESS_NAME = name.Value;
                model.MESS_TEL = tel.Value;
                model.MESS_EMAIL = email.Value.ToString();               
                model.MESS_CONTENT = con.Value;
                model.CREATE_TIME = DateTime.Now;
                int num = bll.Add(model);
                if (num > 0)
                {
                    Response.Write("<script>alert('提交成功！');window.location.href='Contract.aspx'</script>");
                    name.Value = "";
                    tel.Value = "";
                    con.Value = "";
                    email.Value = "";
                }
            }
        }
    }
}