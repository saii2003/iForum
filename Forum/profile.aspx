<%@ Page Title="個人資訊" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="iFourms.Forum.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/forum.css" rel="stylesheet" type="text/css" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="profile">
<div class="right">
   
    <table class="right_tb">
        <tr>
            <td class="title">
                個人文章</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hyper" 
                                    NavigateUrl='<%# "~/Forum/articledetail.aspx?aid="+Eval("A_ID") %>' 
                                    Text='<%# Eval("Title") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle CssClass="gtitle" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                發表時間：<asp:Label ID="Label5" runat="server" 
                                    Text='<%# Eval("CreateTime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="gtime" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
   
    </div>
<div class="left">
    <table class="left_tb">
        <tr>
            <td class="title">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    CssClass="profiledetail" GridLines="None">
                    <Fields>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" 
                                    ImageUrl='<%# Eval("Icon") %>' />
                            </ItemTemplate>
                            <HeaderStyle CssClass="profile_icon" />
                            <ItemStyle CssClass="profile_icon" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                會員編號：<asp:Label ID="Label1" runat="server" Text='<%# Eval("M_ID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="profile_mid" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                會員帳號：<asp:Label ID="Label2" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="profile_user" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                暱稱：<asp:Label ID="Label3" runat="server" Text='<%# Eval("Nickname") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="profile_nickname" />
                            <ItemStyle CssClass="profile_nick" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                註冊日期：<asp:Label ID="Label4" runat="server" 
                                    Text='<%# Eval("RegTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="profile_regtime" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                文章數：<asp:Label ID="count" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="profile_count" />
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
    </div>
</div>
</asp:Content>
