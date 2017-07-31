<%@ Page Title="變更密碼" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="changepw.aspx.cs" Inherits="iFourms.Member.changepw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="changepw">
    <table class="changepwtb">
        <tr>
            <td colspan="2" class="header">
                變更密碼</td>
        </tr>
        <tr>
            <td class="title">
                舊密碼</td>
            <td>
                <asp:TextBox ID="oldpassword" runat="server" CssClass="oldpassword" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="oldpassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="title">
                新密碼</td>
            <td>
                <asp:TextBox ID="password" runat="server" CssClass="password" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="password" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="title">
                確定新密碼</td>
            <td>
                <asp:TextBox ID="repassword" runat="server" CssClass="repassword" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="repassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="footer" colspan="2">
                <asp:Button ID="changepwbutton" runat="server" Text="確定" 
                    CssClass="changepwbutton" onclick="changepwbutton_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="changepwcancel" Text="取消" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>
