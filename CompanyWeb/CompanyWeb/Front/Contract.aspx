<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="CompanyWeb.Front.Contract" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>联系我们</title>
    <link href="../Content/css/common.css" rel="stylesheet" />
    <link href="../Content/css/contract.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
</head>
<body>
    <!-- LOGO -->
    <header>
        <div class="main">
            <div class="logo">山西万里一朝科技有限公司</div>
            <ul class="nav" id="nav">
                <%--<li><a href="index.html">首页</a></li>
                <li><a href="about.html">关于我们</a></li>
                <li><a href="item.html">项目展示</a></li>
                <li><a href="news.html">公司资讯</a></li>
                <li><a href="recruit.html">招聘信息</a></li>
                <li class="active"><a href="contact.html">联系我们</a></li>--%>
            </ul>
        </div>
    </header>
    <div class="body">
        <div class="lx_head">
            <p class="lxwm">联系我们</p>
            <p class="sco">Contact us</p>
            <p class="red"></p>
            <p class="gray"></p>
        </div>
        <div class="lx_content">
            <div class="dz" id="info">
                <%--<span>邮箱： ***@qq.com</span>
                <span>电话： ***********</span>
                <span>地址： 太原市小店区平阳景苑9号楼6单元1704室</span>--%>
            </div>
            <div class="message">
                <form action="" id="form1" runat="server">
                    <div class="top_box">
                        <label class="xing">*</label>
                        <label class="title">姓名:</label>
                        <input type="text" id="name" autocomplete="off" runat="server" maxlength="30">
                        <asp:RequiredFieldValidator CssClass="check" runat="server" ControlToValidate="name" ForeColor="Red" ID="RFVname" ErrorMessage="名称不得为空" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="check" runat="server" ID="REVname" ControlToValidate="name" ErrorMessage="请输入汉字" 
                            ValidationExpression="^[\u4e00-\u9fa5]{0,}$"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="top_box">
                        <label class="xing">*</label>
                        <label class="title">电话:</label>
                        <input type="text" id="tel" runat="server" autocomplete="off" maxlength="11">
                        <asp:RequiredFieldValidator CssClass="check" runat="server" ControlToValidate="tel" ForeColor="Red" ID="RFVtel" ErrorMessage="电话不得为空" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="check" runat="server" ID="REVtel" ControlToValidate="tel" ErrorMessage="电话格式不正确"
                             ValidationExpression="^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="top_box">
                        <label class="xing">*</label>
                        <label class="title">邮箱:</label>
                        <input type="text" id="email" autocomplete="off" runat="server" maxlength="20">
                        <asp:RequiredFieldValidator CssClass="check" runat="server" ControlToValidate="email" ForeColor="Red" ID="RFVemail" ErrorMessage="邮箱不得为空" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="check" runat="server" ID="REVemail" ControlToValidate="email" ErrorMessage="邮箱格式不正确" 
                            ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="top_box">
                        <label class="xing">*</label>
                        <label class="title">内容:</label>
                        <textarea id="con" runat="server" autocomplete="off"></textarea>
                        <asp:RequiredFieldValidator CssClass="check" runat="server" ControlToValidate="con" ForeColor="Red" ID="RFVcon" ErrorMessage="简介不得为空" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <button id="btnSave" runat="server" onserverclick="btnSave_Cilck">提交</button>
                </form>
            </div>
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
        //运行
        getbt();

        //导航栏
        function getbt() {
            $.ajax({
                type: "GET",
                url: "/ashx/ContractHandler.ashx?funName=getBT",
                data: {},
                dataType: "",
                success: function (data) {
                    $("#nav").html(data);
                }
            });
        }

        //联系人信息
        $.ajax({
            type: "GET",
            url: "/ashx/ContractHandler.ashx?funName=getinfo",
            data: {},
            dataType: "",
            success: function (data) {
                $("#info").html(data);
            }
        });
    })
</script>
</html>
