<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_login.aspx.cs" Inherits="CompanyWeb.Admin.com_login" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>后台登录</title>
    <meta name="renderer" content="webkit|ie-comp|ie-stand">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />

    <link href="../Content/Admin/css/font.css" rel="stylesheet" />
    <link href="../Content/Admin/css/xadmin.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
    <script src="../Content/Admin/lib/layui/layui.js"></script>
    <script src="../Scripts/Admin/js/xadmin.js"></script>

</head>
<body class="login-bg">

    <div class="login layui-anim layui-anim-up">
        <div class="message">后台管理登录</div>
        <div id="darkbannerwrap"></div>

        <form method="post" class="layui-form">
            <input name="username" id="name" placeholder="用户名" type="text" class="layui-input">
            <hr class="hr15">
            <input name="password" id="pass" placeholder="密码" type="password" class="layui-input">
            <hr class="hr15">
            <input value="登录" lay-submit lay-filter="login" style="width: 100%;" type="button" onclick="Login()">
            <hr class="hr20">
        </form>
    </div>
    <script>

        //登录方法
        function Login() {

            var name = $("#name").val();
            var password = $("#pass").val();
            if (name == "") {
                layer.msg('请输入用户名', { icon: 0, time: 1000 });
                $("#name").focus();
                return;
            }
            if (password == "") {
                layer.msg('请输入密码', { icon: 0, time: 1000 });
                $("#pass").focus();
                return;
            }

            $.ajax({
                type: "GET",
                url: "../ashx/LoginHandler.ashx?funName=Login",
                data: { name: name, password: password },
                dataType: "",
                success: function (data) {
                    if (data == "error") {
                        layer.msg('用户名或密码不正确', { icon: 0, time: 1000 });
                    } else {
                        window.location.href = "com_index.aspx";
                    }
                }
            });
        }

    </script>

    <!-- 底部结束 -->

</body>
</html>
