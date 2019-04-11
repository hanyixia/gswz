<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="CompanyWeb.Front.Content" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>新闻内容</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/content.css" rel="stylesheet" />
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
            <div class="news_content" id="cont">
				<%--<span>标题</span> 
				<div class="date">发布日期：2019-02-27 10:16</div>
				<h4>文章来源：腾讯新闻</h4>
				<p>昨晚，2018年第一次全市乡镇(街道)党(工)委书记工作交流会举行。我市各地乡镇(街道)、社区村居的基层干部，或是在主会场、各县(市、区)分会场参加活动，或是通过温州新闻APP观看现场图文直播。活动结束后，基层干部们纷纷表示，通过这种摆擂台比竞赛的方式，大家学到了经验、感到了压力、增强了信心。下一步，将围绕市委市政府中心工作，一张蓝图绘到底、一以贯之抓落实，以善担当、有作为、能成事作为干事创业</p>
				<img src="img/item1.png" alt="">
				<p>昨晚，2018年第一次全市乡镇(街道)党(工)委书记工作交流会举行。我市各地乡镇(街道)、社区村居的基层干部，或是在主会场、各县(市、区)分会场参加活动，或是通过温州新闻APP观看现场图文直播。活动结束后，基层干部们纷纷表示，通过这种摆擂台比竞赛的方式，大家学到了经验、感到了压力、增强了信心。下一步，将围绕市委市政府中心工作，一张蓝图绘到底、一以贯之抓落实，以善担当、有作为、能成事作为干事创业</p>--%>
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

        //标题
        function getbt() {
            $.ajax({
                type: "GET",
                url: "../ashx/ContentHandler.ashx?funName=getBT",
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
                url: "../ashx/ContentHandler.ashx?funName=getcont",
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