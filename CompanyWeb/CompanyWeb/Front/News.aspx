<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="CompanyWeb.Front.News" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>新闻资讯</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/news.css" rel="stylesheet" />
</head>
<body>
	<!-- LOGO -->
		<header>
			<div class="main">
				<div class="logo">山西万里一朝科技有限公司</div>
				<ul class="nav" id="nav">
					<%--<li><a href="Index.aspx">首页</a></li>
					<li><a href="About.aspx">关于我们</a></li>
					<li><a href="javascript:;">项目展示</a></li>
					<li class="active"><a href="News.aspx">公司资讯</a></li>
					<li><a href="javascript:;">留言板</a></li>--%>
				</ul>
			</div>
		</header>
	<!-- 主体内容 -->
		<div class="body">
		<!-- 新闻列表 -->
			<div class="news_ul" id="NewsList">
				<%--<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>
				<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>
				<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>
				<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>
				<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>
				<a href="Content.aspx">
					<div class="yuan"></div>
					<p>标题标题标题标题</p>
					<span>2018.12.12</span>
				</a>--%>
			</div>
		</div>
	<!-- 底部 -->
		<footer>
			<p>山西万里一朝科技有限公司</p>
		</footer>
</body>
<script src="../Scripts/js/jquery-3.3.1.min.js"></script>
<script>
    $(function () { //初始化内容
        $(document).on('click', ".main>body", function () {
            $(".main>body").eq($(this).index()).addClass("active").siblings().removeClass("active");
            $(".logo>.hezi").hide().eq($(this).index()).show();
        })

        getbt();
        getlist()

        //导航栏
        function getbt() {
            $.ajax({
                type: "GET",
                url: "../ashx/NewsHandler.ashx?funName=getBT",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#nav").html(data);
                }
            })
        }

        //新闻列表
        function getlist(){
            $.ajax({
                type: "GET",
                url: "../ashx/NewsHandler.ashx?funName=getlist",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#NewsList").html(data);
                }
            })
        }

    })
</script>
</html>