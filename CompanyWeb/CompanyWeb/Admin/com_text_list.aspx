<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_text_list.aspx.cs" Inherits="CompanyWeb.Admin.com_text_list" %>

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
            <a href="">内容管理</a>
            <a>
                <cite>内容管理</cite></a>
        </span>
        <a class="layui-btn layui-btn-small" style="line-height: 1.6em; margin-top: 3px; float: right" href="javascript:location.replace(location.href);" title="刷新">
            <i class="layui-icon" style="line-height: 30px">ဂ</i></a>
    </div>
    <form id="form1" runat="server" method="post">
        <div class="x-body">
            <xblock style="position: relative;">	        
                <label class="layui-form-label22"></label>
                <div class="layui-form-item">
                    <label class="layui-form-label">分类查询：</label>
                    <div class="layui-input-inline">
                        <asp:DropDownList  runat="server" ID ="ddlTypeList" class="my_select"></asp:DropDownList>
                        <input type ="hidden" name="thispersonValue" id="thispersonValue" runat ="server" class="layui-input"/>
                    </div>
                    <label class="layui-form-label">标题查询：</label>
                    <asp:TextBox runat ="server" ID="txt_title" class="layui-input"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Butn" runat="server" class="layui-btn" name="BtnSelect" onserverclick="BtnSelect" type="button" value="搜索" />
                </div>            
            </xblock>
            <xblock style="position: relative;">	        
                <a href="com_text_add.aspx" class="layui-btn"><i class="layui-icon"></i>添加</a>
                <div style="display:inline-block;position:absolute;right:120px;top:11px;">
                    <span>显示</span>
                    <select id="select" style="width:74px;height:30px">
	                    <option>5</option>
	                    <option  selected="selected">10</option>
	                    <option>15</option>
	                    <option>20</option>
	                </select>
                    <span>条</span>
	            </div>
                <input type="hidden" id="op" value=" " />
                <span class="x-right" style="line-height: 40px">共有数据：<%=count %> 条</span>
            </xblock>

            <table class="layui-table">
                <tr>
                    <td>
                        <asp:GridView ID="gridView" SkinID="myGridView2" runat="server" DataKeyNames="TEXT_ID" AutoGenerateColumns="false"
                            Width="100%" AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging" OnSelectedIndexChanged="gridView_SelectedIndexChanged" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="用户操作">
                                    <ItemTemplate>
                                        <a href='text_edit.aspx?text_id=<%#DataBinder.Eval(Container.DataItem,"TEXT_ID") %>'>
                                            <i class="layui-icon">&#xe642;</i>
                                        </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href='com_text_list.aspx?text_id=<%#DataBinder.Eval(Container.DataItem,"TEXT_ID") %>' onclick='return del();'>
                                            <i class="layui-icon">&#xe640;</i>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="itemStyle" />
                                    <ItemStyle />
                                    <HeaderStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="TEXT_ID" HeaderText="序号" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="TEXT_TITLE" HeaderText="标题" ItemStyle-CssClass="itemStyle" />
                                <%--                                <asp:BoundField DataField="TEXT_DESCRIPT" HeaderText="描述" ItemStyle-CssClass="itemStyle" />--%>
                                <%--<asp:BoundField DataField="TEXT_CONTENT" HeaderText="内容" ItemStyle-CssClass="itemStyle" />--%>
                                <asp:BoundField DataField="CATEGORY_ID" HeaderText="分类编号" ItemStyle-CssClass="itemStyle" />
                                <asp:BoundField DataField="TEXT_AUTHOR" HeaderText="文章来源" ItemStyle-CssClass="itemStyle" />
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

        </div>
    </form>
</body>
</html>
