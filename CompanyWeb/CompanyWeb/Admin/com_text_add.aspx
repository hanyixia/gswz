<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_text_add.aspx.cs" Inherits="CompanyWeb.Admin.com_text_add" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>添加内容</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />

    <link href="../Content/Admin/css/font.css" rel="stylesheet" />
    <link href="../Content/Admin/css/xadmin.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
    <script src="../Content/Admin/lib/layui/layui.js"></script>
    <script src="../Scripts/Admin/js/xadmin.js"></script>
    <script src="../ueditor/ueditor.config.js"></script>
    <script src="../ueditor/ueditor.all.min.js"></script>
    <script src="../ueditor/lang/zh-cn/zh-cn.js"></script>

    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('editor');
    </script>
    <script lang="javascript" type="text/javascript">
        function check() {
            //取值
            var content = ue.getContent();
            document.getElementById("txtEditorContents").value = content;
            if (document.getElementById("txtEditorContents").value == "") {
                alert("正文不得为空");
                document.getElementById("txtEditorContents").focus();
                return false;
            }
        }
    </script>
</head>

<body>
    <form id="Form1" method="post" runat="server" onsubmit="return check()">
        <div class="x-body layui-anim layui-anim-up">
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>所属版块
                </label>
                <div class="layui-input-inline">
                    <asp:DropDownList ID="ddlTypeList" runat="server" class="my_select"></asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>标题
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textitle" runat="server" class="layui-input" required="" autocomplete="off"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>描述
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textdesc" runat="server" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>文章来源
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="textauthor" runat="server" class="layui-input"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>上传图片
                </label>
                <div class="layui-input-inline">
                    <asp:TextBox ID="txtpath" runat="server" Visible="False"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    <span class="x-red">*</span>内容
                </label>
                <div class="layui-input-inline">
                    <script id="editor" type="text/plain" style="width: 1000px; height: 300px;"></script>
                    <input id="txtEditorContents" type="hidden" runat="server" />
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label"></label>
                <asp:Button ID="Button1" runat="server" class="layui-btn" Text="增加" OnClick="Button1_Click"></asp:Button>
                <input id="Button2" name="btnCancle" onclick="javascript: window.location.href = 'com_text_list.aspx'" type="button" value="取消" class="layui-btn" />
            </div>
        </div>
    </form>
</body>
</html>

