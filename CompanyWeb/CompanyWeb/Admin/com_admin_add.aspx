<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_admin_add.aspx.cs" Inherits="CompanyWeb.Admin.com_admin_add" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>欢迎页面-X-admin2.0</title>
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
    <div class="x-body layui-anim layui-anim-up">
        <div class="layui-form-item">
            <label for="L_username" class="layui-form-label">
                <span class="x-red">*</span>用户名
            </label>
            <div class="layui-input-inline">
                <input type="text" id="textname" class="layui-input" />
            </div>
        </div>
        <div class="layui-form-item">
            <label for="L_pass" class="layui-form-label">
                <span class="x-red">*</span>密码
            </label>
            <div class="layui-input-inline">
                <input type="password" id="textpass" class="layui-input" />
            </div>
        </div>
        <div class="layui-form-item">
            <label for="L_repass" class="layui-form-label"></label>
            <button id="Button1" class="layui-btn" onclick="Save()">保存</button>
            <input id="Button2" name="btnCancle" onclick="javascript: window.location.href = 'com_admin-list.aspx'" type="button" value="取消" class="layui-btn" />
        </div>
    </div>

</body>
<script>
    function Save() {
        var name = $("#textname").val();
        var password = $("#textpass").val();
        var desc = $("#textdesc").val();
        if (name == "") {
            layer.msg('请输入用户名', { icon: 0, time: 1000 });
            $("#textname").focus();
            return;
        }
        if (password == "") {
            layer.msg('请输入密码', { icon: 0, time: 1000 });
            $("#textpass").focus();
            return;
        }

        $.ajax({
            type: "GET",
            url: "../ashx/UserHandler.ashx?funName=AddUser",
            data: { name: name, password: password },
            dataType: "",
            success: function (data) {
                if (data == "error") {
                    layer.msg('用户添加失败', { icon: 0, time: 1000 });
                } else if (data == "UserExists") {
                    layer.msg('用户名已存在', { icon: 0, time: 1000 });
                    $("#textname").focus();
                } else {
                    layer.msg('用户添加成功', { icon: 1, time: 1000 }, function () {
                        window.location.href = 'com_admin-list.aspx';
                    });
                }
            }
        });
    }
</script>
</html>