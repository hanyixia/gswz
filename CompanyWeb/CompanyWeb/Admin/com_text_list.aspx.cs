using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyBll;
using System.Data;
using System.Text;


namespace CompanyWeb.Admin
{
    public partial class com_text_list : System.Web.UI.Page
    {
        Category_Bll bllCate = new Category_Bll();
        public int count = 0;
        Text_Bll bll = new Text_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_DDL();
                if (Request.Params["text_id"] != null && Request.Params["text_id"].Trim() != "")
                {
                    int nId = (Convert.ToInt32(Request.Params["text_id"]));

                    delete_Fun(nId);
                }

            }
            BindData("");
        }
        #region 下拉框
        public void Bind_DDL()
        {
            DropDownListHelp ddlHelper = new DropDownListHelp();

            DataTable dt = bllCate.GetList("").Tables[0];
            ddlHelper.createDropDownTree(dt, "PARENT_ID", "-1", "CATEGORY_ID", "CATEGORY_NAME", "ID asc", ddlTypeList);
        }
        #endregion

        #region 删除
        protected void delete_Fun(int ID)
        {
            bool aa = bll.Delete(ID);
            if (aa)
            {
                Response.Write("<script>alert('删除成功！');window.location.href='com_text_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败！');window.location.href='com_text_list.aspx';</script>");
            }
        }
        #endregion

        #region 点击搜索按钮事件
        protected void BtnSelect(object sender, EventArgs e)
        {
            string sqlStr = "1>0";
            string selectvalue = ddlTypeList.SelectedValue;
            string titleText = txt_title.Text; 
            if (selectvalue.Length>0)
            {
                sqlStr += " and  CATEGORY_ID ='" + selectvalue + "'";             
            }
            if (titleText.Length>0)
            {
                sqlStr += " and TEXT_TITLE like '%" + titleText + "%'";
              
            }
            BindData(sqlStr);
        }
        #endregion

        #region 绑定
        public void BindData(string strWhere)
        {
            DataSet ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            dt.DefaultView.Sort = "TEXT_ID desc";
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

        #region 分页
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
            BindData("");
        }
        #endregion
    }
}