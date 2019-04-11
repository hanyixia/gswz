using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyBll;
using System.Data;
using CompanyModel;
using CompanyCommon;

namespace CompanyWeb.Admin
{
    public partial class admin_edit : System.Web.UI.Page
    {
        Admin_Bll bll = new Admin_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["user_id"] != null && Request.Params["user_id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["user_id"]));
                    ShowInfo(ID);
                }
            }
        }

        #region 显示
        private void ShowInfo(int ID)
        {


            DataSet ds = bll.GetList("USER_ID=" + ID + "");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.textname.Text = dt.Rows[0]["USER_NAME"].ToString().Trim();
                this.textpass.Text = dt.Rows[0]["USER_PASSWORD"].ToString().Trim();
                //userName = dt.Rows[0]["USER_NAME"].ToString().Trim();
                //password = dt.Rows[0]["USER_PASSWORD"].ToString().Trim();
            }

        }
        #endregion

        #region 保存
        protected void Button1_Click1(object sender, EventArgs e)
        {
            int USER_ID = Convert.ToInt32(Request.Params["user_id"]);
            string USER_NAME = this.textname.Text;
            string USER_PASSWORD = this.textpass.Text;

            Admin_Model model = new Admin_Model();

            model.USER_ID = USER_ID;
            model.USER_NAME = USER_NAME;
            model.USER_PASSWORD = EncryptHelper.Encrypt(USER_PASSWORD);
            model.CREATE_TIME = DateTime.Now;


            //更改选择状态，如果添加，则此设备状态改为，已经使用

            bool i = bll.Update(model);
            if (i)
            {
                Response.Write("<script>alert('保存成功！');window.location.href='com_admin-list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert(保存失败！');window.location.href='com_admin-list.aspx';</script>");
            }
        }
        #endregion
    }
}