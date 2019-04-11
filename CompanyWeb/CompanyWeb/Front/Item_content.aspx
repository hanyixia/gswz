<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_content.aspx.cs" Inherits="CompanyWeb.Front.Item_content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>项目介绍</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/item_content.css" rel="stylesheet" />
</head>
<body>
	<!-- LOGO -->
		<header>
			<div class="main">
				<div class="logo">山西万里一朝科技有限公司</div>
				<ul class="nav" id="nav">
					<%--<li><a href="index.html">首页</a></li>
					<li><a href="about.html">关于我们</a></li>
					<li  class="active"><a href="item.html">项目展示</a></li>
					<li><a href="news.html">公司资讯</a></li>
					<li><a href="recruit.html">招聘信息</a></li>
					<li><a href="contact.html">联系我们</a></li>--%>
				</ul>
			</div>
		</header>
	<!-- 主体内容 -->
		<div class="body">
			<div class="item_inst" id="cont">
				<%--<img src="img/item1.png" alt="">
				<div class="inst_content">
					<h2>项目——介绍</h2>
					<h4>液晶拼接屏:</h4>
					<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;液晶拼接屏既能单独作为显示器使用，又可以拼接成超大屏幕使用。根据不同使用需求，实现可变大也可变小的百变大屏功能：单屏分割显示、单屏单独显示、任意组合显示、全屏液晶拼接、双重拼接液晶屏拼接、竖屏显示，图像边框可选补偿或遮盖，支持数字信号的漫游、缩放拉伸、跨屏显示，各种显示预案的设置和运行，全高清信号实时处理。
					</p>
				</div>--%>
			</div>						
		</div>
	<!-- 底部 -->
		<footer>
			<p>山西万里一朝科技有限公司</p>
		</footer>
</body>
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
<script>
    $(function () {
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]);
            return null; //返回参数值
        }

        getbt();
        getcont()

        //导航栏
        function getbt() {
            $.ajax({
                type: "GET",
                url: "../ashx/ItemContentHandler.ashx?funName=getBT",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#nav").html(data);
                }
            })
        }

        //内容
        function getcont() {
            var nId = getUrlParam("TEXT_ID");//定义一个变量
            $.ajax({
                type: "GET",
                url: "../ashx/ItemContentHandler.ashx?funName=getcont",
                data: { TEXT_ID: nId },
                dataType: "",
                success: function (data) {
                    $("#cont").html(data);
                }
            });
        }
    })
</script>
</html>
