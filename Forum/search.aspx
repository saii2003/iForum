<%@ Page Title="" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="iFourms.Forum.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../Styles/forum.css" rel="stylesheet" type="text/css" />
    
    <link href="../Styles/page.css" rel="stylesheet" type="text/css" />
   <script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/watermark.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(function () {
        $("#ContentPlaceHolder1_searchs").autocomplete({
            source: function (request, response) {
               var param = { articletitle: $('#ContentPlaceHolder1_searchs').val() };
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
        <asp:Label ID="count" runat="server" Text="搜尋數：" CssClass="count"></asp:Label>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="right">
                    <asp:TextBox ID="searchs" runat="server" CssClass="search"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsBottom" 
                        ImageUrl="~/Icon/Search.png" Height="27px" />
                    </td>
            </tr>
        </table>
        <asp:DataList ID="DataList1" runat="server" CssClass="searchdatalist" 
            ondatabinding="DataList1_DataBinding">
            <ItemTemplate>
                <table class="listtb">
                    <tr>
                        <td class="tbtitle">
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="searchtitle" 
                                Text='<%# Eval("Title") %>' 
                                NavigateUrl='<%# "articledetail.aspx?aid="+Eval("A_ID") %>'></asp:HyperLink>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class= "tbcontent">
                            <asp:Label ID="Label2" runat="server" CssClass="searchcontent" 
                                Text='<%# Eval("Contents") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbtime">
                            <asp:Label ID="Label3" runat="server" CssClass="searchtime" 
                                Text='<%# "發表時間："+Eval("CreateTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>

    </div>
        <div id="page">
           <asp:Panel ID="page_panel" runat="server" CssClass="page_panel"></asp:Panel>
        </div>
</asp:Content>
