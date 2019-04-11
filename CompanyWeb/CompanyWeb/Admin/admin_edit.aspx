<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_edit.aspx.cs" Inherits="CompanyWeb.Admin.admin_edit" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>用户编辑</title>
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
    <form id="form1" runat="server" method="post">
        <div class="x-body">
            <div class="layui-form-item">
                <label for="L_title" class="layui-form-label">
                    <span class="x-red">*</span>用户名
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textname" Width="200px" runat="server" class="layui-input" required="" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label for="L_desc" class="layui-form-label">
                    <span class="x-red">*</span>密码
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textpass" type="password" Width="200px" runat="server" class="layui-input" required="" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label for="L_repass" class="layui-form-label"></label>
                <asp:Button ID="Button1" runat="server" class="layui-btn" Text="保存" OnClick="Button1_Click1"></asp:Button>
                <input id="Button2" name="btnCancle" onclick="javascript: window.location.href = 'com_admin-list.aspx'" type="button" value="取消" class="layui-btn" />
            </div>
        </div>
    </form>
</body>

</html>
