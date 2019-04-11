using System;
using System.Data;  
using System.IO;  
using System.Text;  
using System.Web;  
using System.Collections;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.Util;

namespace ShLedger.Common
{
    public class NPOIHelper
    {
        private static string templatefilepath = HttpContext.Current.Server.MapPath("~/Template/");
        private static string tempfilepath = HttpContext.Current.Server.MapPath("~/TempExcel/");

        /// <summary>      
        /// DataTable导出到Excel文件    
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>      
        protected static string Export(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            string strfile = string.Empty;
            if (strSheetName == "")
            {
                strSheetName = "Sheet";
            }
            using (MemoryStream ms = Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames))
            {
                using (FileStream fs = new FileStream(tempfilepath + strFileName + ".xls", FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    strfile = fs.Name;
                }
            }
            return strfile;
        }

        /// <summary>      
        /// DataTable导出到Excel的MemoryStream      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strSheetName">工作表名称</param>         
        protected static MemoryStream Export(DataTable dtSource, string strHeaderText, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (oldColumnNames.Length != newColumnNames.Length)
            {
                return new MemoryStream();
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(strSheetName);

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.User.Identity.Name != null)
                {
                    si.Author = HttpContext.Current.User.Identity.Name;
                }                                    //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "山西世恒系统";           //填加xls文件最后保存者信息      
                si.Comments = "山西世恒系统文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 取得列宽
            int[] arrColWidth = new int[oldColumnNames.Length];
            for (int i = 0; i < oldColumnNames.Length; i++)
            {
                arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
            }

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < oldColumnNames.Length; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            #endregion
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet(strSheetName + ((int)rowIndex / 65535).ToString());
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion


                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(1);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        for (int i = 0; i < oldColumnNames.Length; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);
                            headerRow.GetCell(i).CellStyle = headStyle;
                            //设置列宽   
                            sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                        }
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[oldColumnNames[i]].ToString();

                    switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                    {
                        case "System.String"://字符串类型      
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型      
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示      
                            break;
                        case "System.Boolean"://布尔型      
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型      
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型      
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理      
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                workbook = null;
                return ms;
            }
        }

        /// <summary>      
        /// DataTable导出到Excel文件      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>      
        protected static string Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            string strfile = string.Empty;

            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(tempfilepath + strFileName + ".xls", FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    strfile = fs.Name;
                }
            }
            return strfile;
        }

        /// <summary>      
        /// DataTable导出到Excel的MemoryStream      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        protected static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.User.Identity.Name != null)
                {
                    si.Author = HttpContext.Current.User.Identity.Name;
                }                                    //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "山西世恒系统";           //填加xls文件最后保存者信息      
                si.Comments = "山西世恒系统文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            NPOI.SS.UserModel.ICellStyle dateStyle = workbook.CreateCellStyle();
            NPOI.SS.UserModel.IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        NPOI.SS.UserModel.ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐
                        NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));

                    }
                    #endregion


                    #region 列头及样式
                    {
                        NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(1);
                        NPOI.SS.UserModel.ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐
                        NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }

                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                NPOI.SS.UserModel.IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    NPOI.SS.UserModel.ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                workbook = null;
                return ms;
            }
        }

        /// <summary>      
        /// DataTable导出到Excel文件      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>      
        protected static string Export(DataTable dtSource, string strHeaderText, string strFileName, string[] datafield)
        {
            string strfile = string.Empty;

            using (MemoryStream ms = Export(dtSource, strHeaderText, datafield))
            {
                using (FileStream fs = new FileStream(tempfilepath + strFileName + ".xls", FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    strfile = fs.Name;
                }
            }
            return strfile;
        }

        /// <summary>      
        /// DataTable导出到Excel的MemoryStream      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        protected static MemoryStream Export(DataTable dtSource, string strHeaderText, string[] datafield)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.User.Identity.Name != null)
                {
                    si.Author = HttpContext.Current.User.Identity.Name;
                }                                    //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "山西世恒系统";           //填加xls文件最后保存者信息      
                si.Comments = "山西世恒系统文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            NPOI.SS.UserModel.ICellStyle dateStyle = workbook.CreateCellStyle();
            NPOI.SS.UserModel.IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            Hashtable ht = new Hashtable();
            for (int s = 0; s < datafield.Length; s++)
            {
                if (datafield[s].Contains("{0:"))
                {
                    ht.Add(s, datafield[s].Split('|')[2]);
                }
            }

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        NPOI.SS.UserModel.ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐
                        NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));

                    }
                    #endregion


                    #region 列头及样式
                    {
                        NPOI.SS.UserModel.IRow headerRow = sheet.CreateRow(1);
                        NPOI.SS.UserModel.ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐
                        NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }

                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                NPOI.SS.UserModel.IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    NPOI.SS.UserModel.ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();


                    if (ht.ContainsKey(column.Ordinal))
                    {
                        drValue = string.Format(ht[column.Ordinal].ToString(),drValue);
                    }
                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);
                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                workbook = null;
                return ms;
            }
        }

        /// <summary>      
        /// WEB导出DataTable到Excel      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">文件名</param>           
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet");
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名，包含扩展名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string[] oldColumnNames, string[] newColumnNames)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet", oldColumnNames, newColumnNames);
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名</param>   
        /// <param name="strSheetName">工作表名称</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            //生成列   
            string columns = "";
            for (int i = 0; i < dtSource.Columns.Count; i++)
            {
                if (i > 0)
                {
                    columns += ",";
                }
                columns += dtSource.Columns[i].ColumnName;
            }

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, columns.Split(','), columns.Split(',')).GetBuffer());
            curContext.Response.End();

        }

        /// <summary>   
        /// 导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">要导出的DataTable</param>   
        /// <param name="strHeaderText">标题文字</param>   
        /// <param name="strFileName">文件名，包含扩展名</param>   
        /// <param name="strSheetName">工作表名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>读取excel      
        /// 默认第一行为表头，导入第一个工作表   
        /// </summary>      
        /// <param name="strFileName">excel文档路径</param>      
        /// <returns></returns>      
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, string SheetName, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, int SheetIndex, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                string SheetName = workbook.GetSheetName(SheetIndex);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            string SheetName = workbook.GetSheetName(SheetIndex);
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="workbook">要处理的工作薄</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(IWorkbook workbook, string SheetName, int HeaderRowIndex)
        {
            ISheet sheet = workbook.GetSheet(SheetName);
            DataTable table = new DataTable();
            try
            {
                IRow headerRow = sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                #region 循环各行各列,写入数据到DataTable
                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell == null)
                        {
                            dataRow[j] = null;
                        }
                        else
                        {
                            switch (cell.CellType)
                            {
                                case CellType.BLANK:
                                    dataRow[j] = null;
                                    break;
                                case CellType.BOOLEAN:
                                    dataRow[j] = cell.BooleanCellValue;
                                    break;
                                case CellType.NUMERIC:
                                    dataRow[j] = cell.ToString();
                                    break;
                                case CellType.STRING:
                                    dataRow[j] = cell.StringCellValue;
                                    break;
                                case CellType.ERROR:
                                    dataRow[j] = cell.ErrorCellValue;
                                    break;
                                case CellType.FORMULA:
                                default:
                                    dataRow[j] = "=" + cell.CellFormula;
                                    break;
                            }
                        }
                    }
                    table.Rows.Add(dataRow);
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                table.Clear();
                table.Columns.Clear();
                table.Columns.Add("出错了");
                DataRow dr = table.NewRow();
                dr[0] = ex.Message;
                table.Rows.Add(dr);
                return table;
            }
            finally
            {
                workbook = null;
                sheet = null;
            }
            #region 清除最后的空行
            for (int i = table.Rows.Count - 1; i > 0; i--)
            {
                bool isnull = true;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Rows[i][j] != null)
                    {
                        if (table.Rows[i][j].ToString() != "")
                        {
                            isnull = false;
                            break;
                        }
                    }
                }
                if (isnull)
                {
                    table.Rows[i].Delete();
                }
            }
            #endregion
            return table;
        }

        /// <summary>   
        /// 从Excel模板对比中是否一致  
        /// </summary>   
        /// <param name="strFileName">要处理的工作薄名称</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <returns></returns>   
        public static bool TemplateExcelCompare(Stream fs, string templatefilename)
        {
            bool issite = true;

            FileStream file = new FileStream(templatefilepath + templatefilename + ".xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet tworksheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);
            file.Close();   //获取模板

            HSSFWorkbook hssfworkbook_p = new HSSFWorkbook(fs);
            HSSFSheet tworksheet_p = (HSSFSheet)hssfworkbook_p.GetSheetAt(0);   //获取比较文件

            try
            {
                System.Collections.IEnumerator rows = tworksheet.GetRowEnumerator();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        if (row.Cells[j].StringCellValue.Trim() == tworksheet_p.GetRow(row.RowNum).Cells[j].StringCellValue.Trim())
                        {
                            continue;
                        }
                        else
                        {
                            issite = false;
                        }
                    }
                }
            }
            catch
            {
                issite = false;
            }
            tworksheet.Dispose();
            hssfworkbook.Dispose();
            tworksheet_p.Dispose();
            hssfworkbook_p.Dispose();

            return issite;
        }
        /// <summary>   
        /// 从Excel模板对比中获取参数  
        /// </summary>   
        /// <param name="strFileName">要处理的工作薄名称</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <returns></returns>   
        protected static NoSortHashTable GetExcelParameters(string templatefilepath, string tempfilepath, string strFileName)
        {
            FileStream file = new FileStream(templatefilepath + strFileName + ".xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            HSSFSheet tworksheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);
            file.Close();

            FileStream file_p = new FileStream(templatefilepath + strFileName + "_Parameter.xls", FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook_p = new HSSFWorkbook(file_p);
            HSSFSheet tworksheet_p = (HSSFSheet)hssfworkbook_p.GetSheetAt(0);
            file_p.Close();

            NoSortHashTable ht = new NoSortHashTable();

            System.Collections.IEnumerator rows = tworksheet.GetRowEnumerator();
            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                for (int j = 0; j < row.LastCellNum; j++)
                {
                    if (row.Cells[j].StringCellValue.Trim() == tworksheet_p.GetRow(row.RowNum).Cells[j].StringCellValue.Trim())
                    {
                        continue;
                    }
                    else
                    {
                        if (row.RowNum == tworksheet.LastRowNum)
                        {
                            ht.Add(j, row.Cells[j].StringCellValue.Trim() + "," + tworksheet_p.GetRow(row.RowNum).Cells[j].StringCellValue.Trim());
                        }
                    }
                }
            }
            tworksheet.Dispose();
            hssfworkbook.Dispose();
            tworksheet_p.Dispose();
            hssfworkbook_p.Dispose();

            return ht;
        }

        /// <summary>   
        /// 根据从Excel模板对比中获取得到的参数，获取数据库中数据  
        /// </summary>   
        /// <param name="ht">获取得到的参数表</param>
        /// <param name="condition">附加的查询条件</param>/// 
        /// <returns></returns>   
        protected static string GetSqlTable(NoSortHashTable ht, string condition)
        {
            DataTable dt = new DataTable();
            string sql = "Select ";
            string sqltemp = string.Empty;
            string sqltable = string.Empty;

            for (int i = 0; i < ht.Count; i++)
            {
                sql += ht[i].ToString().Split(',')[1] + ",";
                sqltemp = ht[i].ToString().Split(',')[1].Split('.')[0] + ",";
            }

            sql = sql.Substring(0, sql.Length - 1) + " from ";
            sqltemp = sqltemp.Substring(0, sqltemp.Length - 1);

            foreach (string i in sqltemp.Split(','))
            {
                string t = string.Empty;
                if (t != i)
                {
                    sqltable += i + ",";
                    t = i;
                }
            }
            sqltable = sqltable.Substring(0, sqltable.Length - 1);

            sql = sql + sqltable + " where 1=1 " + condition;

            return sql;
        }

        ///// <summary>   
        ///// 根据模板和参数模板中的配置，导出数据集为模板形式，目前支持单表
        ///// </summary>   
        ///// <param name="strFileName">要导出的数据模板名称</param>
        ///// <param name="condition">查询where条件</param>
        //public static void ExportByModel(string strFileName, string condition)
        //{
        //    string sql = GetSqlTable(GetExcelParameters(templatefilepath, tempfilepath, strFileName), condition);

        //    DataSet ds = Sxsh.BaseClass.DbUtility.DbHelperOracle.Query(sql);

        //    string path = OutputExcelByModel(ds.Tables[0], templatefilepath, tempfilepath, strFileName);

        //    OutputExcel(path);
        //}

        ///// <summary>   
        ///// 根据页面中生成GridView类似的方法，在网页上输出excel  
        ///// </summary>   
        ///// <param name="strCaption">表名称</param>
        ///// <param name="strsql">查询sql</param>
        ///// <param name="orderby">排序</param>
        ///// <param name="tablename">表名</param>
        ///// <param name="datafield">字段内容</param>        
        //public static void ExportCommon(string strCaption, string strsql, string orderby, string tablename,string datafield)
        //{
        //    string sqldata = string.Empty;
        //    string path = string.Empty;
        //    for (int i = 0; i < datafield.Split(',').Length; i++)
        //    {
        //        sqldata += datafield.Split(',')[i].Split('|')[0].ToString() + " AS " + datafield.Split(',')[i].Split('|')[1].ToString() + ",";
        //    }
        //    sqldata = sqldata.Substring(0, sqldata.Length - 1);

        //    strsql = strsql.Replace("*", sqldata) + orderby;
        //    DataSet ds = Sxsh.BaseClass.DbUtility.DbHelperOracle.Query(strsql);

        //    if (!datafield.Contains("{0:"))
        //    {
        //        path = Export(ds.Tables[0], strCaption, strCaption);
        //    }
        //    else
        //    {
        //        path = Export(ds.Tables[0], strCaption, strCaption, datafield.Split(','));
        //    }

        //    OutputExcel(path);
        //}

        protected static string OutputExcelByModel(DataTable dt, string templatefilepath, string tempfilepath, string templatefilename)
        {
            try
            {
                #region NPOI方式
                FileStream file = new FileStream(templatefilepath + templatefilename + ".xls", FileMode.Open, FileAccess.Read);
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
                HSSFSheet tworksheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);
                file.Close();
                //设置样式
                HSSFCellStyle style = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;     //水平居中
                style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;   //垂直居中
                style.WrapText = true;  //自动换行
                style.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                style.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                style.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                style.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;    //边框

                HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
                font.FontName = "宋体"; //设置字体
                font.FontHeightInPoints = 9;   //设置字号
                style.SetFont(font);
                //起始行起始列
                int startrow = tworksheet.LastRowNum + 2;
                int startcol = 0;
                System.Collections.IEnumerator rows = tworksheet.GetRowEnumerator();
                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    if (row.RowNum == tworksheet.LastRowNum)
                    {
                        startcol = row.FirstCellNum + 1;
                    }
                }

                //传入数据
                for (int i = startrow; i <= dt.Rows.Count + startrow - 1; i++)
                {
                    HSSFRow row = (HSSFRow)tworksheet.CreateRow(i - 1);
                    for (int j = startcol; j <= dt.Columns.Count + startcol - 1; j++)
                    {
                        HSSFCell cell = (HSSFCell)row.CreateCell(j - 1);
                        cell.SetCellValue(dt.Rows[i - startrow][j - startcol].ToString().Trim());
                        cell.CellStyle = style;
                    }
                }

                ////设置表头框格
                //int captionrow = 0;
                //int captioncol = 0;
                //string s = string.Empty;
                //for (int k = 0; k < subcaption.Length; k++)
                //{
                //    s = subcaptionpos[k].ToString();
                //    captionrow = Convert.ToInt32(s.Split(',')[0]) - 1;
                //    captioncol = Convert.ToInt32(s.Split(',')[1]) - 1;
                //    if (subcaption[k].ToString().Length != 0)
                //    {
                //        tworksheet.GetRow(captionrow).GetCell(captioncol).SetCellValue(subcaption[k].ToString());
                //    }
                //}
                //写文件
                FileStream file1 = new FileStream(tempfilepath + templatefilename + ".xls", FileMode.Create);
                hssfworkbook.Write(file1);
                file1.Close();

                return file1.Name;
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>   
        /// 获取模板文件
        /// </summary>   
        /// <param name="sListName">文件名称</param>
        public static void GetTemplateFile(string sListName)
        {
            string templatefileName = sListName + "模板.xls";//客户端保存的文件名
            string templatefilePath = HttpContext.Current.Server.MapPath("~/Template/" + sListName + ".xls");//路径
            //以字符流的形式下载文件
            FileStream fs = new FileStream(templatefilePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(templatefileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        ///// <summary>   
        ///// 获取表中非空列集合
        ///// </summary>   
        ///// <param name="sTable">表名称</param>
        //public static string GetNullDisable(string sTable)
        //{
        //    string notNullCol = string.Empty;
        //    Oracle.DataAccess.Client.OracleDataReader dr = null;
        //    try
        //    {
        //        dr = Sxsh.BaseClass.DbUtility.DbHelperOracle.ExecuteReader("select t.COLUMN_NAME from all_tab_columns t where lower(t.TABLE_NAME) = lower('" + sTable + "') and t.nullable = 'N' and t.DEFAULT_LENGTH is null");
        //        while (dr.Read())
        //        {
        //            notNullCol += dr[0].ToString() + ",";
        //        }
        //        notNullCol = notNullCol.Substring(0, notNullCol.Length - 1);
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        dr.Close();
        //    }
        //    return notNullCol;
        //}

        /// <summary>   
        /// 将指定路径的excel文件读入到datatable中
        /// </summary>   
        /// <param name="fileName">excel文件名称</param>
        public static DataTable XlsToData(string fileName)
        {
            OleDbConnection oleDBConn = null;
            OleDbDataAdapter oleAdMaster = null;
            DataTable m_tableName = new DataTable();
            DataSet ds = new DataSet();
            string sqlMaster = string.Empty;

            string oleDBConnString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            oleDBConn = new OleDbConnection(oleDBConnString);

            if (fileName == string.Empty)
            {
                throw new ArgumentNullException("Excel文件上传失败！");
            }

            try
            {
                oleDBConn.Open();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {
                    m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();
                }
                sqlMaster = " select * from [" + m_tableName.TableName.Trim() + "] ";
                oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                oleAdMaster.Fill(ds, "m_tableName");
                DataTable dt1 = ds.Tables[0];
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();

                return dt1;
            }
            catch (Exception ex)
            {
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();
                throw ex;
            }
        }

        /// <summary>   
        /// 根据从Excel模板对比中获取得到的文件路径，在网页上输出excel  
        /// </summary>   
        /// <param name="path">获取得到的文件路径</param>
        protected static void OutputExcel(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpContext.Current.Server.UrlEncode(file.Name));
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.End();
        }

        /// <summary>   
        /// 非乱序的哈希表 
        /// </summary>        
        protected class NoSortHashTable : Hashtable
        {
            private ArrayList list = new ArrayList();
            public override void Add(object key, object value)
            {
                base.Add(key, value);
                list.Add(key);
            }
            public override void Clear()
            {
                base.Clear();
                list.Clear();
            }
            public override void Remove(object key)
            {
                base.Remove(key);
                list.Remove(key);
            }
            public override ICollection Keys
            {
                get
                {
                    return list;
                }
            }
        }
    }
}
