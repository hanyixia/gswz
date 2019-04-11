using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyModel;
using CompanyBll;

namespace CompanyWeb.Admin
{
    public partial class text_edit : System.Web.UI.Page
    {
        Text_Bll bll = new Text_Bll();
        Category_Bll bllCate = new Category_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind_DDL();
                if (Request.Params["text_id"] != null && Request.Params["text_id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["text_id"]));
                    ShowInfo(ID);
                }

            }
        }

        //下拉列表
        public void Bind_DDL()
        {
            DropDownListHelp ddlHelper = new DropDownListHelp();

            DataTable dt = bllCate.GetList("").Tables[0];
            ddlHelper.createDropDownTree(dt, "PARENT_ID", "-1", "CATEGORY_ID", "CATEGORY_NAME", "ID asc", ddlTypeList);

        }
        string Text = "";

        #region 显示
        private void ShowInfo(int ID)
        {


            DataSet ds = bll.GetList("TEXT_ID=" + ID + "");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.ddlTypeList.SelectedValue = dt.Rows[0]["CATEGORY_ID"].ToString().Trim();
                this.textitle.Text = dt.Rows[0]["TEXT_TITLE"].ToString().Trim();
                this.textdesc.Text = dt.Rows[0]["TEXT_DESCRIPT"].ToString().Trim();
                this.textauthor.Text = dt.Rows[0]["TEXT_AUTHOR"].ToString().Trim();
                this.txtEditorContents.Value = dt.Rows[0]["TEXT_CONTENT"].ToString();
                this.lj.Value = dt.Rows[0]["IMGPATH"].ToString().Trim();
                this.txtpath.Text = dt.Rows[0]["IMGPATH"].ToString().Trim();
            }

        }
        #endregion

        #region 保存
        protected void Button1_Click(object sender, EventArgs e)
        {
            int TEXT_ID = Convert.ToInt32(Request.Params["text_id"]);
            string TEXT_TITLE = this.textitle.Text;
            string TEXT_DESCRIPT = this.textdesc.Text;
            string TEXT_AUTHOR = this.textauthor.Text;
            string TEXT_CONTENT = this.txtEditorContents.Value.ToString();
            string CATEGORY_ID = this.ddlTypeList.SelectedValue;


            Text_Model model = new Text_Model();

            model.TEXT_ID = TEXT_ID;
            model.TEXT_TITLE = TEXT_TITLE;
            model.TEXT_DESCRIPT = TEXT_DESCRIPT;
            model.TEXT_AUTHOR = TEXT_AUTHOR;
            model.TEXT_CONTENT = TEXT_CONTENT;
            model.CATEGORY_ID = Convert.ToInt32(CATEGORY_ID);
            model.CREATE_TIME = DateTime.Now;

            string fileFullname = this.FileUpload1.FileName;
            string fileName = fileFullname.Substring(fileFullname.LastIndexOf("\\") + 1);
            string type = fileFullname.Substring(fileFullname.LastIndexOf(".") + 1);
            string picName = DateTime.Now.ToString("yyyyMMddhhssmmfff");
            if (type == "bmp" || type == "jpg" || type == "jpeg" || type == "gif" || type == "JPG" || type == "JPEG" || type == "BMP" || type == "GIF" || type == "png" || type == "PNG")
            {
                FileUpload1.SaveAs(Server.MapPath("../NewsImage") + "\\" + picName + "." + type);
                Text = "../NewsImage/" + picName + "." + type;
            }
            if (lj.Value == Text)//值相等
            {
                model.IMGPATH = lj.Value.ToString();
            }
            else if (fileFullname == null || fileFullname == "")//值等于空
            {
                model.IMGPATH = lj.Value.ToString();
            }
            else if (lj.Value == "")
            {
                model.IMGPATH = Text.ToString();
            }
            else if (Text != "")
            {
                model.IMGPATH = Text.ToString();
            }
            else
            {
                model.IMGPATH = lj.Value;
            } 
            //更改选择状态，如果添加，则此设备状态改为，已经使用
            bool i = bll.Update(model);
            if (i)
            {
                Response.Write("<script>alert('保存成功！');window.location.href='com_text_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert(保存失败！');window.location.href='com_text_list.aspx';</script>");
            }
        }
        #endregion
    }
}