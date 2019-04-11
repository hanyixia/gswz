using CompanyBll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb.Admin
{
    public partial class com_contract_list : System.Web.UI.Page
    {
        public int count = 0;
        int nId;
        Contract_Bll bll = new Contract_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["mess_id"] != null && Request.Params["mess_id"].Trim() != "")
                {
                    nId = (Convert.ToInt32(Request.Params["mess_id"]));

                    delete_Fun(nId);
                }
            }
            BindData();
        }
        #region 删除
        protected void delete_Fun(int ID)
        {
            int nid;
           DataSet  ds = bll.GetList(1, "", "MESS_ID asc");
           DataTable dt = ds.Tables[0];
           if (dt.Rows.Count > 0)
           {
               nid = Convert.ToInt32(dt.Rows[0]["MESS_ID"]);
               if (nid != nId)
               {
                   bool aa = bll.Delete(ID);
                   if (aa)
                   {
                       Response.Write("<script>alert('删除成功！');window.location.href='com_contract_list.aspx';</script>");
                   }
               }
               else
               {
                   Response.Write("<script>alert('对不起，你不能删除此条信息!');window.location.href='com_contract_list.aspx';</script>");
               }
           }
        }
        #endregion

        #region 绑定
        public void BindData()
        {
            DataSet ds = bll.GetList("");
            DataTable dt = ds.Tables[0];
            //显示顺序
            dt.DefaultView.Sort = "MESS_ID desc";
            dt = dt.DefaultView.ToTable();
            if (dt.Rows.Count > 0)
            {
                gridView.DataSource = dt;
                gridView.DataBind();
                count = dt.Rows.Count;
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