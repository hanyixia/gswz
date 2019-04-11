<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_welcome.aspx.cs" Inherits="CompanyWeb.Admin.com_welcome" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
        <meta name="renderer" content="webkit">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />

        <link href="../Content/Admin/css/font.css" rel="stylesheet" />
        <link href="../Content/Admin/css/xadmin.css" rel="stylesheet" />
    </head>
    <body>
    <div class="x-body layui-anim layui-anim-up">
        <blockquote class="layui-elem-quote">欢迎：
            <span class="x-red"><%=userName %></span>！当前时间:<span class="x-red"><%=dataTime %></span>
        </blockquote>
    </div>
    </body>
</html>
