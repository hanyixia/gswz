<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CompanyWeb.Front.About1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/css/about.css" rel="stylesheet" />
    <link href="../Content/css/common.css" rel="stylesheet" />
</head>
<body>
    <body>
        <!-- LOGO -->
        <header>
            <div class="main">
                <div class="logo">山西万里一朝科技有限公司</div>
                <ul class="nav" id="nav">
                    <%--<li><a href="Index.aspx">首页</a></li>
                    <li class="active"><a href="About.aspx">关于我们</a></li>
                    <li><a href="javascript:;">项目展示</a></li>
                    <li><a href="News.aspx">公司资讯</a></li>
                    <li><a href="javascript:;">联系我们</a></li>--%>
                </ul>
            </div>
        </header>
        <!-- 主体内容 -->
        <div class="body">
            <!-- 图片 -->
            <div class="tup" id="GYTP">
                <%--<img src="../Content/img/3.jpg" alt="">--%>
            </div>
            <div class="com_content">
                <ul class="com_left" id="CDH">
                    <%--<li class="active">公司简介</li>
                    <li>公司展望</li>
                    <li>公司环境</li>
                    <li>组织架构</li>--%>
                </ul>
                <div class="com_right">
                    <!-- 公司简介 -->
                    <div class="hezi li_gsjj active1" id="GSJJ">
                        <%--<p>山西万里一朝科技有限公司简介成立于2014年8月，注册资金为510万元，具有ISO9001质量管理体系认证、建筑业劳务分包不分等级施工资质。</p>
                        <br>
                        <p>我公司自成立以来，本着“创办成熟企业，服务铁路行业”的服务宗旨，坚持“团结拼搏、开拓创新”的企业精神、“以人为本、质量兴企”的经营理念，努力为铁路行业和客户创造超凡价值。历经多年艰苦奋斗，我公司在发展过程中大力拓展市场，各项事业蒸蒸日上，焕发出勃勃生机。在公司发展上始终坚持“以人为本，维护劳务工权益；精雕细琢，确保工程质量”的原则，依托山西境内项目，逐步辐射全国铁路“四电”工程。积极拓展市场，把工程施工做精、做细、做好，为劳务企业在铁路行业赢得良好口碑。</p>
                        <br>
                        <p>我公司主要承建过的项目有：大西高铁站前施工综合监控系统、大西高铁视频会议系统、大西客专公司信息管理系统、太焦高铁站前施工综合监控系统、太焦客专公司管理视频会议系统、太焦高铁站前隧道施工人员定位系统、大张高铁站前施工综合监控系统、大张高铁管理视频会议系统、大张高铁隧道人员定位系统、大原客专视频会议系统、铁建电气化局成贵高铁“四电”通信劳务施工等工程。所有工程项目均获得用户的高度评价及业内良好口碑。</p>
                        <br>
                        <p>公司从成立到现在，已建立并完善了一套完整的组织机构和严格的规章制度，特别注重人才的培养和企业文化的建设，如今拥有一批优秀工程技术人员及管理人员，并拥有一支专业基础扎实、实践经验丰富的技术专业队伍。我公司目前共有成建制劳务施工队伍5支，其中：通信工程专业2支、信息客服专业2支、电力专1支。施工人员年平均数达200人以上，管理人员、技术工人配比规范合理。在传统施工的同时，我们也在积极与客户及合作方探索并尝试新型施工、新型管理模式，如：BIM技术应用、二维码技术、SAAS数据库技术等，并组建专业软件研发团队。</p>
                        <br>
                        <p>目前为客户开发铁路物资管理信息系统软件，包括物资采购招标管理、物资出入库管理及物资可追溯管理等功能。面对快速发展的铁路行业，我们公司将继往开来，发扬“与时俱进，追求卓越”的精神，凭借优质的工程质量、完善的服务体系，以市场化、多元化的经营理念开拓发展，创造出更加辉煌灿烂的美好明天。</p>--%>
                    </div>
                    <!-- 公司文化 -->
                    <div class="hezi li_gszw" id="GSWH">
                       <%-- <li>
                            <h3>【管理方针】</h3>
                            <div class="glfz">
                                <p>安全第一，以人为本;</p>
                                <p>追求无限，探索无止.</p>
                            </div>
                        </li>
                        <li>
                            <h3>【质量方针】</h3>
                            <div class="glfz">
                                <p>以信誉求市场 以科技求发展 以安全求效益</p>
                            </div>
                        </li>
                        <li>
                            <h3>【远程规划】</h3>
                            <div class="glfz">
                                <p>立足山西，面向全国；</p>
                                <p>不懈努力，勇攀高峰。</p>
                            </div>
                        </li>--%>
                    </div>
                    <!-- 公司环境 -->
                    <div class="hezi li_gshj" id="GSHJ">
                        <%--<li>
                            <img src="../Content/img/hj.jpg" />
                            <p>办公区域</p>
                        </li>
                        <li>
                            <img src="../Content/img/hj2.jpg" />
                            <p>休闲区域</p>
                        </li>
                        <li>
                            <img src="../Content/img/hj3.jpg" />
                            <p>茶水区域</p>
                        </li>
                        <li>
                            <img src="../Content/img/hj4.jpg" />
                            <p>接待室</p>
                        </li>
                        <li>
                            <img src="../Content/img/hj5.jpg" />
                            <p>会议室</p>
                        </li>
                        <li>
                            <img src="../Content/img/hj6.jpg" />
                            <p>办公区域</p>
                        </li>--%>
                    </div>
                    <!-- 组织架构 -->
                    <div class="hezi li_zzjg" id="ZZJG">
                        <%--<img src="../Content/img/ZZJG.jpg" />--%>
                    </div>
                </div>
            </div>
        </div>
        <!-- 底部 -->
        <footer>
            <p>山西万里一朝科技有限公司</p>
        </footer>
    </body>
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/js/index.js"></script>
    <script>
        $(function () {// 初始化内容   
            //侧导航
            $(document).on('click', ".com_left>li", function () {
                $(".com_left>li").eq($(this).index()).addClass("active").siblings().removeClass("active");
                $(".com_right>.hezi").hide().eq($(this).index()).show();
            })

            //运行
            getbt();
            getcdh();
            getgsjj();
            getgswh();
            getgshj();
            getzzjg()
            getgytp()

            //导航栏
            function getbt() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getBT",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#nav").html(data);
                    }
                });
            }

            //关于我们图片
            function getgytp() {
                $.ajax({
                    type: "GET",
                    url: "../ashx/AboutHandler.ashx?funName=getgytp",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#GYTP").html(data);
                    }
                })
            }

            //侧导航
            function getcdh() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getcdh",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#CDH").html(data);
                    }
                })
            }

            //公司简介
            function getgsjj() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getgsjj",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#GSJJ").html(data);
                    }
                })
            }

            //公司文化
            function getgswh() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getgswh",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#GSWH").html(data);
                    }
                })
            }

            //公司环境
            function getgshj() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getgshj",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#GSHJ").html(data);
                    }
                })
            }

            //组织架构
            function getzzjg() {
                $.ajax({
                    type: "GET",
                    url: "/ashx/AboutHandler.ashx?funName=getzzjg",
                    data: {},
                    dataType: "",
                    success: function (data) {
                        $("#ZZJG").html(data);
                    }
                })
            }

        })
    </script>
</body>
</html>
