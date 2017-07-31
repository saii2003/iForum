<%@ Page Title="忘記密碼" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="iFourms.Member.Forget" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="forget">
    <table class="forgettb">
        <tr>
            <td class="header" colspan="2">
                忘記密碼</td>
        </tr>
        <tr>
            <td class="explain" colspan="2">
                請輸入帳號和電子郵件確定後，會寄發一封驗證信，驗證通過後可重設您的密碼。</td>
        </tr>
        <tr>
            <td class="title">
                會員帳號</td>
            <td class="button">
                <asp:TextBox ID="Username" runat="server" CssClass="username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="usernamevalid" runat="server" 
                    ControlToValidate="Username" ErrorMessage="不可空白" ForeColor="#FF4D4D" 
                    Height="22px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="title">
                電子郵件</td>
            <td class="button">
                <asp:TextBox ID="Email" runat="server" CssClass="email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="eemailvalid" runat="server" 
                    ControlToValidate="Email" ErrorMessage="不可空白" ForeColor="#FF4D4D" Height="22px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="footer">
                <asp:Button ID="forgetbutton" runat="server" onclick="Button1_Click" Text="確定" 
                    CssClass="forgetbutton" />
                <asp:Button ID="forgetcancel" runat="server" Text="取消" 
                    CssClass="forgetcancel" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>
