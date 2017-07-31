<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="iAarticle.aspx.cs" Inherits="iFourms.Member.iAarticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="iArticle">

    <table class="iArticletb">
        <tr>
            <td class="header">
                我的文章</td>
        </tr>
        <tr>
            <td class=title>
                <asp:GridView ID="iArticleGrid" runat="server" AutoGenerateColumns="False" 
                    CssClass="iArticleGrid" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="主題">
                            <ItemTemplate>
                                <asp:HyperLink ID="topichyperlink" runat="server" CssClass="topichyperlink" 
                                    Text='<%# Eval("Title") %>' 
                                    NavigateUrl='<%# "~/Forum/articledetail.aspx?aid="+Eval("A_ID") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle CssClass="topic" />
                            <ItemStyle CssClass="topicitem" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發表日期">
                            <ItemTemplate>
                                <asp:Label ID="timelabel" runat="server" CssClass="timelabel" 
                                    Text='<%# Eval("CreateTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="time" />
                            <ItemStyle CssClass="timeitem" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</div>
</asp:Content>
