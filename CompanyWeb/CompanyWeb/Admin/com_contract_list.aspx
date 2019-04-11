<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_contract_list.aspx.cs" Inherits="CompanyWeb.Admin.com_contract_list" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>欢迎页面-X-admin2.0</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />

    <link href="../Content/Admin/css/font.css" rel="stylesheet" />
    <link href="../Content/Admin/css/xadmin.css" rel="stylesheet" />
    <script src="../Scripts/js/jquery-3.3.1.min.js"></script>
    <script src="../Content/Admin/lib/layui/layui.js"></script>
    <script src="../Scripts/Admin/js/xadmin.js"></script>
    <script>
        function del() {

            if (confirm("确定要删除吗？")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>

<body>
    <div class="x-nav">
        <span class="layui-breadcrumb">
            <a href="">首页</a>
            <a href="">留言管理</a>
            <a>
                <cite>留言管理</cite></a>
        </span>
        <a class="layui-btn layui-btn-small" style="line-height: 1.6em; margin-top: 3px; float: right" href="javascript:location.replace(location.href);" title="刷新">
            <i class="layui-icon" style="line-height: 30px">ဂ</i></a>
    </div>
    <div class="x-body">
        <xblock>            
                <span class="x-right" style="line-height:40px">共有数据：<%=count %> 条</span>
            </xblock>
        <form id="form1" runat="server" method="post">
            <table class="layui-table">
                <tr>
                    <td>
                        <asp:GridView ID="gridView" SkinID="myGridView2" runat="server" DataKeyNames="MESS_ID" AutoGenerateColumns="false"
                            Width="100%" AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging" OnSelectedIndexChanged="gridView_SelectedIndexChanged" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="用户操作">
                                    <ItemTemplate>
                                        <a href='com_contract_list.aspx?mess_id=<%#DataBinder.Eval(Container.DataItem,"MESS_ID") %>' onclick='return del();'>
                                            <i class="layui-icon">&#xe640;</i>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="itemStyle" />
                                    <ItemStyle />
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="MESS_ID" HeaderText="序号" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="MESS_NAME" HeaderText="姓名" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="MESS_TEL" HeaderText="电话" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="MESS_EMAIL" HeaderText="邮箱" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="MESS_CONTENT" HeaderText="内容" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="MESS_ADDRESS" HeaderText="地址" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="CREATE_TIME" HeaderText="创建时间" ItemStyle-CssClass="itemStyle" />
                            </Columns>
                            <PagerTemplate>
                                <table style="font: 11px Tahoma; background-color: #cfe3fb;">
                                    <tr>
                                        <td style="text-align: right;">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>'></asp:Label>页
                        / 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页&nbsp;&nbsp;
                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False"
                            CommandName="Page" Text="首页" CommandArgument="first" OnClick="btnFirst_Click">
                        </asp:LinkButton>
                                            <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False"
                                                CommandName="Page" Text="上一页" CommandArgument="prev" OnClick="btnFirst_Click">
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False"
                                                CommandName="Page" Text="下一页" CommandArgument="next" OnClick="btnFirst_Click">
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False"
                                                CommandName="Page" Text="尾页" CommandArgument="last" OnClick="btnFirst_Click">
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </form>
    </div>

</body>
</html>