<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CompanyWeb.Front.Index" %>

 <!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>首页</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/index.css" rel="stylesheet" />
    <link href="../Content/css/swiper-4.3.3.min.css" rel="stylesheet" />
    <script src="../Scripts/js/swiper-4.3.3.min.js"></script>
    <script src="../Scripts/js/move_port.js"></script>
    <script src="../Scripts/js/index.js"></script>
</head>
<body>
	<!-- LOGO -->
		<header>
			<div class="main">
				<div class="logo">山西万里一朝科技有限公司</div>
				<ul class="nav" id="nav">
					<%--<li class="active"><a href="Index.aspx">首页</a></li>
					<li><a href="About.aspx">关于我们</a></li>
					<li><a href="javascript:;">项目展示</a></li>
					<li><a href="News.aspx">公司资讯</a></li>
					<li><a href="javascript:;">留言板</a></li>--%>
				</ul>
			</div>
		</header>
	<!-- 主体内容 -->
		<div class="body">
		<!-- banner --> 		
			<div class="banner">
				<div class="swiper-container">
					<div class="swiper-wrapper" id="imglunbo">
						<%--<div class="swiper-slide">
							<img src="../Content/img/1.jpg" />
						</div>
						<div class="swiper-slide">
							<img src="../Content/img/2.jpg" />
						</div>--%>
					</div>
					<!-- 如果需要分页器 -->
					<div class="swiper-pagination"></div>
				</div>
			</div>
		<!-- 业务范围 -->
			<div class="yw_box">
				<div class="yw_head">
					<p class="ywfw">业务范围</p>
					<p class="sco">Scope of business</p>
					<p class="red"></p>
					<p class="gray"></p>
				</div>
				<ul class="ywpic" id="ywpic">
					<%--<li>
						<img src="../Content/img/yw1.png" />
						<div class="mark">软件开发</div>
					</li>
					<li>
						<img src="../Content/img/yw2.png" />
						<div class="mark">硬件集成</div>
					</li>
					<li>
						<img src="../Content/img/yw3.png" />
						<div class="mark">工程管理</div>
					</li>
					<li>
                        <img src="../Content/img/yw4.png" />
						<div class="mark">公寓经营</div>
					</li>--%>
				</ul>
			</div>
			<div class="rq">
			   	<!-- 公司简介 -->  
					<div class="gs_box">
						<div class="gs_head">
							<p class="gsjj">公司简介</p>
							<p class="com">Company profile</p>
							<p class="red"></p>
							<p class="gray"></p>
						</div>
						<div class="gs_body" id="GSJJ">
							<%--<div class="gs_img">
							    <img src="../Content/img/gsjs.png" />
							</div>
							<a href="About.aspx">
								山西万里一朝科技有限公司简介成立于2014年8月，注册资金为510万元，具有ISO9001质量管理体系认证、建筑业劳务分包不分等级施工资质。我公司自成立以来，本着“创办成熟企业，服务铁路行业”的服务宗旨，坚持“团结拼搏
							</a>--%>
						</div>
					</div>
			    <!-- 新闻动态 -->
					<div class="xw_box">
						<div class="xw_head">
							<p class="xwdt">新闻动态</p>
							<p class="new">News</p>
							<p class="red"></p>
							<p class="gray"></p>
						</div>
						<ul class="xwul" id="XWDT">
							<%--<li>
								<img src="../Content/img/al2.jpg" />
								<div class="xw_contemt">
									<a href="Content.aspx">标题</a>
									<p>这篇文章不是教学文，而是一个分享文。我不是专业摄影师，也从来没受过训练，甚至我大部分的照片都是用手机拍...</p>
								</div>
							</li>
							<li>
                                <img src="../Content/img/al2.jpg" />
								<div class="xw_contemt">
									<a href="Content.aspx">标题</a>
									<p>这篇文章不是教学文，而是一个分享文。我不是专业摄影师，也从来没受过训练，甚至我大部分的照片都是用手机拍...</p>
								</div>
							</li>--%>
						</ul>	
					</div>
			</div>
		</div>
	<!-- 底部 -->
		<footer>
			<p>山西万里一朝科技有限公司</p>
            <a href="../Admin/com_login.aspx" target="_bank">后台管理</a>
		</footer>
</body>
<script src="../Scripts/js/jquery-3.3.1.min.js"></script>
<script>
    $(function () {
        //运行
        getbt();
        getywpic();
        getimglunbo();
        getgsjj();
        getxwdt()
       
        $(document).on('click', ".main>li", function () {
            $(".main>li").eq($(this).index()).addClass("active").siblings().removeClass("active");
            $(".logo>.hezi").hide().eq($(this).index()).show();
        })

        //导航栏
        function getbt() {
            $.ajax({
                type: "GET",
                url: "/ashx/IndexHandler.ashx?funName=getBT",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#nav").html(data);
                }
            });
        }

        //业务范围
        function getywpic() {
            $.ajax({
                type: "GET",
                url: "/ashx/IndexHandler.ashx?funName=getywpic",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#ywpic").html(data);
                }
            })
        }

        //公司简介
        function getgsjj() {
            $.ajax({
                type: "GET",
                url: "/ashx/IndexHandler.ashx?funName=getgsjj",
                data: "",
                dataType: "",
                success: function (data) {
                    $("#GSJJ").html(data);
                }
            })
        }

        //新闻动态
        function getxwdt() {
            $.ajax({
                type: "GET",
                url: "/ashx/IndexHandler.ashx?funName=getxwdt",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#XWDT").html(data);
                }
            })
        }

        //轮播图
        function getimglunbo() {
            $.ajax({
                type: "GET",
                url: "/ashx/IndexHandler.ashx?funName=getimglunbo",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#imglunbo").html(data);
                    // 轮播图
                    var mySwiper = new Swiper('.swiper-container', {
                        direction: 'horizontal',
                        loop: true,
                        autoplay: true,
                        autoplay: {
                            delay: 2000,
                            disableOnInteraction: false,
                        },

                        // 分页器
                        pagination: {
                            el: '.swiper-pagination',
                            clickable: true,
                            // type:'fraction'
                        },
                    })
                    var lunbo = document.querySelector('.swiper-container');
                    // 鼠标移入停止图片切换
                    lunbo.onmouseenter = function () {
                        mySwiper.autoplay.stop();
                    };
                    // 鼠标移出继续切换
                    lunbo.onmouseleave = function () {
                        mySwiper.autoplay.start();
                    }
                }
            })
        }
    })
</script>
</html>