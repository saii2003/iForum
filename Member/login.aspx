<%@ Page Title="會員登入" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="iFourms.Member.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="memlogin">

    <table class="memlogintb">
        <tr>
            <td colspan="2" class="header">
                會員登入</td>
        </tr>
        <tr>
            <td class="title">
                帳號</td>
            <td>
                <asp:TextBox ID="username" runat="server" CssClass="username"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                密碼</td>
            <td>
                <asp:TextBox ID="password" runat="server" CssClass="password" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                驗證碼</td>
            <td>
                <asp:Image ID="codeimage" runat="server" CssClass="codeimage" 
                    ImageAlign="AbsBottom" ImageUrl="~/validcode.aspx" name="code"/>
                <asp:TextBox ID="code" runat="server" CssClass="code"></asp:TextBox>
                <asp:LinkButton ID="updatevalid" runat="server" 
                    onclientclick="form1.code.src='validcode.aspx'" CssClass="updatevalid">更新驗證碼</asp:LinkButton>
                <asp:Label ID="error" runat="server" CssClass="error" ForeColor="#FF6666"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                &nbsp;</td>
            <td>
                <asp:CheckBox ID="logincheck" runat="server" CssClass="logincheck" 
                    Text="自動登入" />
            </td>
        </tr>
        <tr>
            <td class="title">
                &nbsp;</td>
            <td>
                忘記密碼，<asp:HyperLink ID="setnew_pw" runat="server" CssClass="setnew_pw" 
                    NavigateUrl="~/Member/Forget.aspx">重新設定新密碼</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="footer">
                <asp:Button ID="loginbutton" runat="server" CssClass="loginbutton" Text="確定" 
                    onclick="loginbutton_Click" />
                <asp:Button ID="logincancel" runat="server" CssClass="logincancel" Text="取消" 
                    onclick="logincancel_Click" />
            </td>
        </tr>
    </table>

</div>
</asp:Content>
