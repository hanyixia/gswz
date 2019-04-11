using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyBll;
using System.Data;
using CompanyModel;

namespace CompanyWeb.Admin
{
    public partial class category_edit : System.Web.UI.Page
    {
        string aa = "";
        Category_Bll bll = new Category_Bll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(ID);
                }
             
            }
        }


        #region 显示
        private void ShowInfo(int ID)
        {


            DataSet ds = bll.GetList("ID=" + ID + "");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.textcateid.Text = dt.Rows[0]["CATEGORY_ID"].ToString().Trim();
                this.textpid.Text = dt.Rows[0]["PARENT_ID"].ToString().Trim(); 
                this.textname.Text = dt.Rows[0]["CATEGORY_NAME"].ToString().Trim();
                this.textjump.Text = dt.Rows[0]["CATEGORY_JUMP"].ToString().Trim();
                this.lj.Value = dt.Rows[0]["IMGPATH"].ToString().Trim();
                
            }

        }
        #endregion

        #region 保存
        protected void Button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.Params["id"]);
            string CATEGORY_NAME = this.textname.Text;
            string CATEGORY_ID = this.textcateid.Text;
            string PARENT_ID = this.textpid.Text;
            string CATEGORY_JUMP = this.textjump.Text;
            

            Category_Model model = new Category_Model();

            model.ID = ID;
            model.CATEGORY_ID =Convert.ToInt32( CATEGORY_ID);
            model.PARENT_ID = Convert.ToInt32(PARENT_ID);
            model.CATEGORY_NAME = CATEGORY_NAME;
            model.CATEGORY_JUMP = CATEGORY_JUMP;
            model.CREATE_TIME = DateTime.Now;

            string fileFullname = this.FileUpload2.FileName;
            string fileName = fileFullname.Substring(fileFullname.LastIndexOf("\\") + 1);
            string type = fileFullname.Substring(fileFullname.LastIndexOf(".") + 1);
            string picName = DateTime.Now.ToString("yyyyMMddhhssmmfff");
            if (type == "bmp" || type == "jpg" || type == "jpeg" || type == "gif" || type == "JPG" || type == "JPEG"
             || type == "BMP" || type == "GIF" || type == "PNG" || type == "png")
            {
                FileUpload2.SaveAs(Server.MapPath("../NewsImage") + "\\" + picName + "." + type);
                aa = "../NewsImage/" + picName + "." + type;
            }
            if (aa == lj.Value)
            {
                model.IMGPATH = lj.Value.ToString();
            }
            else if (fileFullname == null || fileFullname == "")
            {
                model.IMGPATH = lj.Value.ToString();
            }
            else
            {
                model.IMGPATH = aa.ToString();
            }


            //更改选择状态，如果添加，则此设备状态改为，已经使用
            bool i = bll.Update(model);
            if (i)
            {
                Response.Write("<script>alert('保存成功！');window.location.href='com_category_list.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert(保存失败！');window.location.href='com_category_list.aspx';</script>");
            }
        }
        #endregion
    }
}