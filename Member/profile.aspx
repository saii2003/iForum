<%@ Page Title="個人資訊" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="iFourms.Member.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="medit">

    <table class="medittb">
        <tr>
            <td colspan="2"  class="header">
                個人資訊</td>
        </tr>
        <tr>
            <td class="title">
                會員編號：</td>
            <td>
                <asp:Label ID="profileid" runat="server" CssClass="meditid"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                帳號：</td>
            <td>
                <asp:Label ID="profileusername" runat="server" CssClass="meditusername"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                暱稱：</td>
            <td>
                <asp:TextBox ID="profilenickname" runat="server" CssClass="meditnickname"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                電子郵件：</td>
            <td>
                <asp:TextBox ID="profileemail" runat="server" CssClass="meditemail"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                註冊日期：</td>
            <td>
                <asp:Label ID="profileregtime" runat="server" CssClass="meditregtime"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                註冊IP：</td>
            <td>
                <asp:Label ID="profileregip" runat="server" CssClass="meditregip"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="footer" colspan="2">
                <asp:Button ID="meditbutton" runat="server" CssClass="meditbutton" Text="儲存" 
                    onclick="meditbutton_Click" />
            </td>
        </tr>
        </table>

</div>
</asp:Content>

