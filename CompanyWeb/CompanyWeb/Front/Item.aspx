<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="CompanyWeb.Front.Item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>项目展示</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/item.css" rel="stylesheet" />
</head>
<body>
    <!-- LOGO -->
    <header>
        <div class="main">
            <div class="logo">山西万里一朝科技有限公司</div>
            <ul class="nav" id="nav">
                <%--<li><a href="index.html">首页</a></li>
                <li><a href="about.html">关于我们</a></li>
                <li class="active"><a href="item.html">项目展示</a></li>
                <li><a href="news.html">公司资讯</a></li>
                <li><a href="recruit.html">招聘信息</a></li>
                <li><a href="contact.html">联系我们</a></li>--%>
            </ul>
        </div>
    </header>
    <!-- 主体内容 -->
    <div class="body">
        <!-- 图片 -->
        <div class="tup" id="XMTP">
            <%--<img src="../Content/img/xmzs.jpg" alt="">--%>
        </div>
        <div class="xm_head">
            <p class="xmal">项目案例</p>
            <p class="sco">Scope of business</p>
            <p class="red"></p>
            <p class="gray"></p>
        </div>
        <!-- 项目案例 -->
        <div class="li_xmal" id="XMZS">
            <%--<li>
                <a href="item_content.html" target="_blank">
                    <img src="img/item1.png" alt="">
                    <p>液晶拼接屏</p>
                </a>
            </li>
            <li>
                <a href="" target="_blank">
                    <img src="img/item2.png" alt="">
                    <p>视频会议室</p>
                </a>
            </li>
            <li>
                <a href="" target="_blank">
                    <img src="img/item8.png" alt="">
                    <p>隧道漏缆卡具安装</p>
                </a>
            </li>
            <li>
                <a href="" target="_blank">
                    <img src="img/item3.png" alt="">
                    <p>XX客专公司信息系统机房</p>
                </a>
            </li>
            <li>
                <a href="" target="_blank">
                    <img src="img/item5.png" alt="">
                    <p>通信铁塔组立</p>
                </a>
            </li>
            <li>
                <a href="" target="_blank">
                    <img src="img/item6.png" alt="">
                    <p>走线架组立</p>
                </a>
            </li>--%>
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
        getbt();
        getxmal();
        getxmtp();

        //导航栏
        function getbt() {
            $.ajax({
                type: "GET",
                url: "../ashx/ItemHandler.ashx?funName=getBT",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#nav").html(data);
                }
            })
        }

        //项目图片
        function getxmtp() {
            $.ajax({
                type: "GET",
                url: "../ashx/ItemHandler.ashx?funName=getxmtp",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#XMTP").html(data);
                }
            })
        }

        //项目案例
        function getxmal() {
            $.ajax({
                type: "GET",
                url: "../ashx/ItemHandler.ashx?funName=getxmal",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#XMZS").html(data);
                }
            })
        }

    })
</script>
</html>
