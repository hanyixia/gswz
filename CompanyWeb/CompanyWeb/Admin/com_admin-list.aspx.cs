using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyBll;

namespace CompanyWeb.Admin
{
    public partial class com_admin_list : System.Web.UI.Page
    {
        public int count = 0;
        Admin_Bll bll = new Admin_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["user_id"] != null && Request.Params["user_id"].Trim() != "")
                {
                    int nId = (Convert.ToInt32(Request.Params["user_id"]));

                    delete_Fun(nId);
                }
            }
            BindData();
        }
        #region 删除
        protected void delete_Fun(int ID)
        {
            bool aa = bll.Delete(ID);
            if (aa)
            {
                Response.Write("<script>alert('删除成功！');window.location.href='com_admin-list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败！');window.location.href='com_admin-list.aspx';</script>");
            }
        }
        #endregion

        #region 绑定
        public void BindData()
        {
            DataSet ds = bll.GetList("");
            DataTable dt = ds.Tables[0];
            //显示顺序
            dt.DefaultView.Sort = "USER_ID asc";
            dt = dt.DefaultView.ToTable();
            if (dt.Rows.Count > 0)
            {
                gridView.DataSource = dt;
                gridView.DataBind();
                count = dt.Rows.Count;
                //用lblCurrentIndex来显示当前页的页数。
                //Lab_CurrentPage.Text = "第 " + (gridView.PageIndex + 1).ToString() + " 页";
                ////用LblPageCount来显示当前数据的总页数。
                //Lab_PageCount.Text = "共 " + gridView.PageCount.ToString() + " 页";
            }
            else
            {
                gridView.DataSource = null;
                gridView.DataBind();
            }
        }
        #endregion

        //分页
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            string str = ((LinkButton)sender).CommandArgument.ToString();
            if (str != null)
            {
                if (!(str == "first"))
                {
                    if (str == "last")
                    {
                        this.gridView.PageIndex = this.gridView.PageCount - 1;
                    }
                    else if (str == "prev")
                    {
                        if (this.gridView.PageIndex >= 1)
                        {
                            this.gridView.PageIndex--;
                        }
                        else
                        {
                            this.gridView.PageIndex = 0;
                        }
                    }
                    else if (str == "next")
                    {
                        this.gridView.PageIndex++;
                    }
                }
                else
                {
                    this.gridView.PageIndex = 0;
                }
            }
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}