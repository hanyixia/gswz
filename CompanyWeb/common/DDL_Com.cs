using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Class_Common;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace Maticsoft.Common
{
    public class DDL_Com
    {
        #region 绑定下拉列表
        /// <summary>
        /// 绑定路局
        /// </summary>
        public static void Bind_DDLLj(HtmlSelect ddlLjbh)
        {
            DataTable dt = DAL_G_Common.GetList("ShLjb", "");
            if (dt.Rows.Count > 0)
            {
                ddlLjbh.DataSource = dt;
                ddlLjbh.DataBind();
            }
            ddlLjbh.Items.Add("==请选择==");
            ddlLjbh.SelectedIndex = ddlLjbh.Items.Count - 1;
        }

        /// <summary>
        /// 绑定所属段
        /// </summary>
        public static void Bind_DDL_Ssgwd(HtmlSelect ddlGwdID, string strWhere)
        {
            DataTable dt = DAL_G_Common.GetList("ShJwd", strWhere);
            if (dt.Rows.Count > 0)
            {
                ddlGwdID.DataSource = dt;
                ddlGwdID.DataBind();
            }
            ddlGwdID.Items.Add("==请选择==");
            ddlGwdID.SelectedIndex = ddlGwdID.Items.Count - 1;
        }

        /// <summary>
        /// 绑定所属段
        /// </summary>
        public static void Bind_DDL_Ssgwd(DropDownList ddlGwdID, string strWhere)
        {
            DataTable dt = DAL_G_Common.GetList("ShJwd", strWhere);
            if (dt.Rows.Count > 0)
            {
                ddlGwdID.DataSource = dt;
                ddlGwdID.DataBind();
            }
            ddlGwdID.Items.Add("==请选择==");
            ddlGwdID.SelectedIndex = ddlGwdID.Items.Count - 1;
        }
        /// <summary>
        /// 绑定所属段
        /// </summary>
        public static void Bind_DDLGwd_Lab(Label labGwd,string strWhere)
        {
            string str1 = "<script>var subcat01 = new Array();";
            DataTable dt = DAL_G_Common.GetList("ShJwd", strWhere);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str1 += "subcat01[" + i + "]=new Array('" + dt.Rows[i]["ID"].ToString() + "','" + dt.Rows[i]["JWDmc"].ToString() + "','" + dt.Rows[i]["Sslj"].ToString() + "');";
                }
            }

            str1 += "</script>";
            labGwd.Text = str1;
        }
        /// <summary>
        /// 绑定监测点
        /// </summary>
        /// <param name="ddlGqID"></param>
        public static void Bind_DDLGq(DropDownList ddlGqID,string strWhere)
        {
            DataTable dt = DAL_G_Common.GetList("ShGqb", strWhere);
            if (dt.Rows.Count > 0)
            {
                ddlGqID.DataSource = dt;
                ddlGqID.DataBind();
            }
            ddlGqID.Items.Add("==请选择==");
            ddlGqID.SelectedIndex = ddlGqID.Items.Count - 1;
        }

        public static void Bind_DDLGq_Lab(Label labGq, string strWhere)
        {
            string str1 = "<script>var subcat02 = new Array();";
            DataTable dt = DAL_G_Common.GetList("ShGqb",strWhere);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str1 += "subcat02[" + i + "]=new Array('" + dt.Rows[i]["ID"].ToString() + "','" + dt.Rows[i]["Gqmc"].ToString() + "','" + dt.Rows[i]["Ssjwd"].ToString() + "');";
                }
            }

            str1 += "</script>";
            labGq.Text = str1;
        }
    
        /// <summary>
        /// 绑定监控所
        /// </summary>
        public static void Bind_DDL_Jks(DropDownList ddlJks, string strWhere)
        {
            DataTable dt = DAL_G_Common.GetList("Shjks", strWhere);
            if (dt.Rows.Count > 0)
            {

                ddlJks.DataSource = dt;
                ddlJks.DataBind();
            }
            ddlJks.Items.Add("==请选择==");
            ddlJks.SelectedIndex = ddlJks.Items.Count - 1;
        }

        /// <summary>
        /// 绑定监控所
        /// </summary>
        public static void Bind_DDLJks_Lab(Label labJks, string strWhere)
        {
            string str2 = "<script>var subcat02 = new Array();";
            DataTable dt = DAL_G_Common.GetList("Shjks",strWhere);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str2 += "subcat02[" + i + "]=new Array('" + dt.Rows[i]["ID"].ToString() + "','" + dt.Rows[i]["Jksmc"].ToString() + "','" + dt.Rows[i]["Sslj"].ToString() + "');";
                }
            }

            str2 += "</script>";
            labJks.Text = str2;
        }

        /// <summary>
        /// 绑定车型表
        /// </summary>
        public static void Bind_DDL_Jcb(DropDownList ddlCx,string strWhere)
        {
            DataTable dt = DAL_G_Common.GetList("ShJcb", strWhere);
            if (dt.Rows.Count > 0)
            {

                ddlCx.DataSource = dt;
                ddlCx.DataBind();
            }
            ddlCx.Items.Add("==请选择==");
            ddlCx.SelectedIndex = ddlCx.Items.Count - 1;
        }



        /// <summary>
        /// 查找所属段ID
        /// </summary>
        public static string Find_GwdID(string strWhere)
        {
            string strGwdID = "";
            DataTable dt = DAL_G_Common.GetList("ShJwd", strWhere);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strGwdID += dt.Rows[i]["ID"].ToString() + ",";
                }
            }
            if (strGwdID.Length > 0)
            {
                strGwdID = strGwdID.Substring(0, strGwdID.Length - 1);
            }
            return strGwdID;
        }

        /// <summary>
        /// 查找nID下所有下级的ID
        /// </summary>
        /// <param name="nID"></param>
        public static string SelGwdID_By_Ljbh(string nLjbh)
        {
            string allIdList = "";
            DataTable dt = DAL_G_Common.GetList("ShJwd", "Sslj='" + nLjbh + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string nGwdID = dt.Rows[i]["ID"].ToString();
                allIdList += nGwdID + ",";
            }
            if (allIdList.Length > 0)
            {
                allIdList.Remove(allIdList.LastIndexOf(","), 1);
            }
            return allIdList;
        }
        #endregion

        
    }
}
