<%@ Page Title="新密碼設定" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="new_pw.aspx.cs" Inherits="iFourms.Member.new_pw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="new_pw">
    <table class="new_pwtb">
        <tr>
            <td class="header" colspan="2">
                新密碼設定</td>
        </tr>
        <tr>
            <td class="title">
                密碼</td>
            <td class="button">
                <asp:TextBox ID="password" runat="server" TextMode="Password" 
                    CssClass="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="passwordvalid" runat="server" 
                    ControlToValidate="password" ErrorMessage="不可空白" ForeColor="#FF6666" 
                    Height="22px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="title">
                確定密碼</td>
            <td class="button">
                <asp:TextBox ID="repassword" runat="server" TextMode="Password" 
                    CssClass="repassword"></asp:TextBox>
                <asp:RequiredFieldValidator ID="repasswordvalid" runat="server" 
                    ControlToValidate="repassword" ErrorMessage="不可空白" ForeColor="#FF6666" 
                    Height="22px"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="password" ControlToValidate="repassword" 
                    ErrorMessage="和密碼要一致" ForeColor="#FF6666" Height="22px"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="footer" colspan="2">
                <asp:Button ID="enter" runat="server" onclick="enter_Click" Text="確定" 
                    CssClass="new_pwbutton" />
                <asp:Button ID="cancel" runat="server" Text="取消" CssClass="new_pwcancel" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>
