 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_category_add.aspx.cs" Inherits="CompanyWeb.Admin.com_category_add" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>添加分类</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />

    <link href="../Content/Admin/css/font.css" rel="stylesheet" />
    <link href="../Content/Admin/css/xadmin.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
    <script src="../Content/Admin/lib/layui/layui.js"></script>
    <script src="../Scripts/Admin/js/xadmin.js"></script>
</head>

<body>
    <form method="post" runat="server">
        <div class="x-body layui-anim layui-anim-up">
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>上级目录
                </label>
                <div class="layui-input-inline">
                    <asp:DropDownList ID="ddlTypeList" runat="server" class="my_select"></asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>分类名
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textname" runat="server" class="layui-input" required="" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>跳转链接
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textjump" runat="server" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>上传图片
                </label>
                <div class="layui-input-inline">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:TextBox ID="txtpath" runat="server" Visible="False" Width="27px" ></asp:TextBox>
                </div>
            </div>          
            <div class="layui-form-item">
                <label class="layui-form-label"></label>
                <asp:Button ID="Button1" runat="server" class="layui-btn" Text="增加" OnClick="Button1_Click"></asp:Button>
                <input id="Button2" name="btnCancle" onclick="javascript: window.location.href = 'com_category_list.aspx'" type="button" value="取消" class="layui-btn" />
            </div>
        </div>
    </form>
</body>
</html>
