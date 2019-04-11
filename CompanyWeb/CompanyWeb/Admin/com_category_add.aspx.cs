using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyModel;
using CompanyCommon;
using CompanyBll;
using System.Data;
using CompanyDal;

namespace CompanyWeb.Admin
{
    public partial class com_category_add : System.Web.UI.Page
    {
        Category_Model model = new Category_Model();
        Category_Bll bll = new Category_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_DDL();
            }
        }

        #region 下拉列表显示
        public void Bind_DDL()
        {
            DropDownListHelp ddlHelper = new DropDownListHelp();

            DataTable dt = bll.GetList("").Tables[0];
            ddlHelper.createDropDownTree(dt, "PARENT_ID", "-1", "CATEGORY_ID", "CATEGORY_NAME", "ID asc", ddlTypeList);

        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region 分类添加顺序
                DataTable dtChild = bll.GetList("PARENT_ID='" + ddlTypeList.SelectedValue + "'  order by CATEGORY_ID desc").Tables[0];
                if (dtChild.Rows.Count > 0)
                {
                    int typeCode = Convert.ToInt32(dtChild.Rows[0]["CATEGORY_ID"].ToString());
                    int newCode = typeCode + 1;
                    model.CATEGORY_ID = newCode;

                    model.PARENT_ID = Convert.ToInt32(ddlTypeList.SelectedValue);

                }
                else
                {
                    model.CATEGORY_ID = Convert.ToInt32(ddlTypeList.SelectedValue.ToString() + "01");
                    model.PARENT_ID = Convert.ToInt32(ddlTypeList.SelectedValue);
                }
                #endregion

                string CATEGORY_NAME = this.textname.Text;
                string CATEGORY_JUMP = this.textjump.Text;

                model.CATEGORY_NAME = CATEGORY_NAME;
                model.CATEGORY_JUMP = CATEGORY_JUMP;
                model.CREATE_TIME = DateTime.Now;

                if (txtpath.Text != "" || txtpath.Text != null)
                {//获取上传图片的文件名
                    string fileFullname = this.FileUpload1.FileName;
                    string fileName = fileFullname.Substring(fileFullname.LastIndexOf("\\") + 1);
                    string type = fileFullname.Substring(fileFullname.LastIndexOf(".") + 1);
                    string picName = DateTime.Now.ToString("yyyyMMddhhssmmfff");
                    if (type == "bmp" || type == "jpg" || type == "jpeg" || type == "gif" || type == "JPG"
                        || type == "JPEG" || type == "BMP" || type == "GIF" || type == "png" || type == "PNG")
                    {
                        FileUpload1.SaveAs(Server.MapPath("../NewsImage") + "\\" + picName + "." + type);
                        txtpath.Text = "../NewsImage/" + picName + "." + type;
                    }
                    model.IMGPATH = txtpath.Text.ToString();
                }

                int i = bll.Add(model);
                if (i > 0)
                {
                    Response.Write("<script>alert('新增成功！');window.location.href='com_category_list.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('新增失败！');window.location.href='com_category_list.aspx';</script>");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}