using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.SessionState;
using ctsky_nt_common;
using Class_DataBase;
namespace Maticsoft.Common
{
    public partial class CheckUser
    {

        /// <summary>
        /// 根据用户传入的PageID.检查当前用户是否对指定的页面具有访问权限。
        /// </summary>
        /// <param name="PID"></param>
        public static void Check_User()
        {

            Hashtable hOnline = (Hashtable)System.Web.HttpContext.Current.Application["Online"];
            if (hOnline != null)
            {
                IDictionaryEnumerator idE = hOnline.GetEnumerator();
                while (idE.MoveNext())
                {
                    if (idE.Key != null && idE.Key.ToString().Equals(System.Web.HttpContext.Current.Session.SessionID))
                    {
                        //already login
                        if (idE.Value != null && "XXXXXX".Equals(idE.Value.ToString()))
                        {
                            hOnline.Remove(System.Web.HttpContext.Current.Session.SessionID);
                            System.Web.HttpContext.Current.Application.Lock();
                            System.Web.HttpContext.Current.Application["Online"] = hOnline;
                            System.Web.HttpContext.Current.Application.UnLock();
                            //Maticsoft.Common.MessageBox.ShowAndRedirect( "你的帐号已在别处登陆，你被强迫下线!!!", "../Admin/login.aspx");
                            JScript.AlertandRedirectParent("你的帐号已在别处登陆，你被强迫下线!!!", "../Admin/login.aspx");

                        }
                        break;
                    }
                }
            }
            string UserID = string.Empty;
            if (System.Web.HttpContext.Current.Session["UserID"] == null)
            {
                JScript.AlertandRedirectParent("服务已经超时，请重新登录!!!", "../Admin/login.aspx");
            }
            //当用户ID不为空时，保存他登录的日志  

            else
            {
                UserID = System.Web.HttpContext.Current.Session["UserID"].ToString();
                string Ljbh = System.Web.HttpContext.Current.Session["Ljbh"].ToString();
                string currentFilePath = System.Web.HttpContext.Current.Request.FilePath;
                string CurrentPageName = currentFilePath.Substring(currentFilePath.LastIndexOf("/") + 1);
                ArrayList list = new ArrayList();
                //增加操作日志 
                string strSql1 = "INSERT INTO ShDaily([UserID],[OperPage],[Ljbh])VALUES('" + UserID + "','" +CurrentPageName+ "','" + Ljbh + "')";
                list.Add(strSql1);
                DataBase.ExecuteSqlGroup(list);
            }    
        }

       /// <summary>
       /// 增加设备的操作记录,用于设备跟踪
       /// </summary>
       /// <param name="nSbid">设备ID</param>
       /// <param name="nSbmc">设备名称</param>
       /// <param name="nSbStatue">设备状态</param>
       /// <param name="nInDate">操作日期</param>
       /// <param name="nDemo">备注</param>
       /// <returns></returns>
        public static int Sb_Daily(string nSbid,string nSbmc,int nSbStatue,string nDemo)
        {
            ArrayList list = new ArrayList();
            //增加操作日志 
            string strSql1="";
            strSql1 += "INSERT INTO Sb_Daily([sbid],[sbmc],[SbStatue],[Demo]) VALUES ";
            strSql1 += " ('" + nSbid + "','" + nSbmc + "'," + nSbStatue + ",'" + nDemo + "')";
            list.Add(strSql1);
            int i=DataBase.ExecuteSqlGroup(list);
            return i;
        }

        /// <summary>
        /// 增加设备的操作记录的sql
        /// </summary>
        /// <param name="nSbid">设备ID</param>
        /// <param name="nSbmc">设备名称</param>
        /// <param name="nSbStatue">设备状态</param>
        /// <param name="nInDate">操作日期</param>
        /// <param name="nDemo">备注</param>
        /// <returns></returns>
        public static string Sb_Daily_Sql(string nSbid, string nSbmc, int nSbStatue, string nDemo)
        {
            //增加操作日志 
            string strSql1 = "";
            strSql1 += "INSERT INTO Sb_Daily([sbid],[sbmc],[SbStatue],[Demo]) VALUES ";
            strSql1 += " ('" + nSbid + "','" + nSbmc + "'," + nSbStatue + ",'" + nDemo + "')";
            return strSql1;
        }

        /// <summary>
        /// 增加设备的操作记录的sql
        /// </summary>
        /// <param name="nSbid">设备ID</param>
        /// <param name="nSbmc">设备名称</param>
        /// <param name="nSbStatue">设备状态</param>
        /// <param name="nInDate">操作日期</param>
        /// <param name="nDemo">备注</param>
        /// <returns></returns>
        public static string Sb_Daily_Sql(string nSbid, string nSbmc, int nSbStatue, string nDemo,string nLjbh,string nSssb)
        {
            //增加操作日志 
            string strSql1 = "";
            strSql1 += "INSERT INTO Sb_Daily([sbid],[sbmc],[SbStatue],[Demo],Ljbh,Sssb) VALUES ";
            strSql1 += " ('" + nSbid + "','" + nSbmc + "'," + nSbStatue + ",'" + nDemo + "','" + nLjbh + "','" + nSssb + "')";
            return strSql1;
        }
    }
}
