<%@ Page Title="iForum討論區" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="iFourms.Forum.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/forum.css" rel="stylesheet" type="text/css" />
    
    <link href="../Styles/page.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/watermark.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
        $("#ContentPlaceHolder1_search").autocomplete({
            source: function (request, response) {
               var param = { articletitle: $('#ContentPlaceHolder1_search').val() };
                $.ajax({
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "post",
                    url: "../MemberWebService.asmx/getSearchTitle",
                    data: JSON.stringify(param),
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                        
                                value: item
                            }
                        }))

                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    minLength: 1 //至少輸入1字元

                });
            },
          

        }).Watermark("請輸入查詢字串");
    });
</script>
    <div id="gridcontent">
        <table class="gridcontenttb">
            <tr>
                <td class="left">
        <asp:Label ID="count" runat="server" Text="文章總數：" CssClass="count"></asp:Label>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="right">
                    <asp:TextBox ID="search" runat="server" CssClass="search"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsBottom" 
                        ImageUrl="~/Icon/Search.png" Height="27px" onclick="ImageButton1_Click" />
                    </td>
            </tr>
        </table>
        <asp:GridView ID="articleGrid" runat="server" AutoGenerateColumns="False" 
            CssClass="articleGrid" GridLines="None" PageSize="1" 
            onrowdatabound="articleGrid_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="類型">
                    <ItemTemplate>
                        <asp:Label ID="aid" runat="server" Text='<%# Eval("A_ID") %>' Visible="False"></asp:Label>
                        <asp:Label ID="className" runat="server" CssClass="className" 
                            Text='<%# Eval("ClassName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="h_type" />
                    <ItemStyle CssClass="i_type" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="標題">
                    <ItemTemplate>
                        <asp:HyperLink ID="title" runat="server" CssClass="title" 
                            NavigateUrl='<%# "~/Forum/articledetail.aspx?aid="+Eval("A_ID") %>' 
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle CssClass="h_title" />
                    <ItemStyle CssClass="i_title" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="作者">
                    <ItemTemplate>
                        <asp:HyperLink ID="username" runat="server" CssClass="username" 
                            Text='<%# Eval("Username") %>' 
                            NavigateUrl='<%# "~/Forum/profile.aspx?mid="+Eval("M_ID") %>'></asp:HyperLink>
                        <br />
                        <asp:Label ID="createtime" runat="server" CssClass="createtime" 
                            Text='<%# Eval("CreateTime","{0:yyyy-MM-dd HH:mm}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="h_username" />
                    <ItemStyle CssClass="i_username" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="回復">
                    <ItemTemplate>
                        <asp:Label ID="reply" runat="server" CssClass="reply"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="h_hit" />
                    <ItemStyle CssClass="i_hit" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="最新回覆">
                    <ItemTemplate>
                        <asp:HyperLink ID="replyuser" runat="server" CssClass="replyuser"></asp:HyperLink>
                        <br />
                    </ItemTemplate>
                    <HeaderStyle CssClass="h_time" />
                    <ItemStyle CssClass="i_time" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
        <div id="page">
           <asp:Panel ID="page_panel" runat="server" CssClass="page_panel"></asp:Panel>
        </div>

        <div id="down">
        <asp:Panel ID="Panel1" runat="server" CssClass="panel1">請先<asp:LinkButton 
                ID="downlogin" runat="server" PostBackUrl="~/Member/login.aspx">登入</asp:LinkButton>才能進行發文 </asp:Panel>
            <table class="t_index">
                <tr>
                    <td class="t_title">
                        快速發文</td>
                </tr>
                <tr>
                    <td class="t_title2">
                        <asp:DropDownList ID="fastdrop" runat="server" CssClass="fastdrop" 
                            Height="27px">
                            <asp:ListItem Selected="True">選擇分類</asp:ListItem>
                            <asp:ListItem Value="1">問題</asp:ListItem>
                            <asp:ListItem Value="2">新聞</asp:ListItem>
                            <asp:ListItem Value="3">心得</asp:ListItem>
                            <asp:ListItem Value="4">分享</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="fasttitle" runat="server" CssClass="fasttitle"></asp:TextBox>
                        請勿超過50字</td>
                </tr>
                <tr>
                    <td class="t_content">
                        <asp:TextBox ID="fastcontent" runat="server" CssClass="fastcontent" 
                            Height="120px" TextMode="MultiLine" Width="950px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="t_content">
                        <asp:Button ID="fastbutton" runat="server" CssClass="fastbutton" Text="確定發表" 
                            onclick="fastbutton_Click" />
                    </td>
                </tr>
            </table>
    </div>

</asp:Content>
