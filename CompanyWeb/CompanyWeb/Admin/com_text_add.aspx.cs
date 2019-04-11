using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyBll;
using CompanyModel;
using System.Data;

namespace CompanyWeb.Admin
{
    public partial class com_text_add : System.Web.UI.Page
    {
        Category_Bll bllCate = new Category_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_DDL();
            }
        }

        public void Bind_DDL()
        {
            DropDownListHelp ddlHelper = new DropDownListHelp();

            DataTable dt = bllCate.GetList("").Tables[0];
            ddlHelper.createDropDownTree(dt, "PARENT_ID", "-1", "CATEGORY_ID", "CATEGORY_NAME", "ID asc", ddlTypeList);

        }

        //添加
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string uppath = "";//用于保存图片上传路径
            //获取上传图片的文件名
            string fileFullname = this.FileUpload1.FileName;
            //获取图片上传的时间，以时间作为图片的名字可以防止图片重名
            //string dataName = DateTime.Now.ToString("yyMMddhhmmss");
            //获取图片的文件名（不含扩展名）
            string fileName = fileFullname.Substring(fileFullname.LastIndexOf("\\") + 1);
            //获取图片扩展名
            string type = fileFullname.Substring(fileFullname.LastIndexOf(".") + 1);
            string picName = DateTime.Now.ToString("yyyyMMddhhssmmfff");
            //判断是否为要求的格式
            if (type == "bmp" || type == "jpg" || type == "jpeg" || type == "gif" || type == "JPG" || type == "JPEG"
             || type == "BMP" || type == "GIF" || type == "png" || type == "PNG")
            {
                //将图片上传到指定路径的文件夹
                FileUpload1.SaveAs(Server.MapPath("../NewsImage") + "\\" + picName + "." + type);
                //将路径保存到变量，将该变量的值保存到数据库相应字段即可
                txtpath.Text = "../NewsImage/" + picName + "." + type;
                //txtpath.Text = uppath;
            }

            string TEXT_TITLE = this.textitle.Text;
            string TEXT_DESCRIPT = this.textdesc.Text;
            string TEXT_AUTHOR = this.textauthor.Text;
            string TEXT_CONTENT = this.txtEditorContents.Value.ToString();
            string CATEGORY_ID = this.ddlTypeList.SelectedValue;

            Text_Model model = new Text_Model();
            model.TEXT_TITLE = TEXT_TITLE;
            model.TEXT_DESCRIPT = TEXT_DESCRIPT;
            model.TEXT_AUTHOR = TEXT_AUTHOR;
            model.IMGPATH = txtpath.Text.ToString();//图片路径
            model.TEXT_CONTENT = TEXT_CONTENT;
            model.CREATE_TIME = DateTime.Now;
            model.CATEGORY_ID = Convert.ToInt32(CATEGORY_ID);

            Text_Bll bll = new Text_Bll();
            int i = bll.Add(model);
            if (i > 0)
            {
                Response.Write("<script>alert('新增成功！');window.location.href='com_text_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('新增失败！');window.location.href='com_text_list.aspx';</script>");

            }
        }
    }
}