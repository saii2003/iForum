<%@ Page Title="會員註冊" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="iFourms.Member.Register" %>
<%@ Register src="../UserControl/birthday.ascx" tagname="birthday" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=Username.ClientID %> , #<%=Password.ClientID %> ,#<%=rePassword.ClientID %> ,#<%=Nickname.ClientID %>,#<%=birthday1.ClientID %>, #<%=Email.ClientID %>").tooltip({
            position: {
            my: "left top",
            at: "right+5 top-5"
      }
        });
        //datepicker
        $("#<%=birthday1.ClientID %>").datepicker({
            dateFormat: 'yy-mm-dd',
            changeYear: true,
            yearRange: '1911:y-10',
        });

        //檢查帳號是否重複
        $('#checkusername').click(function () {
            $.ajax({
                type: "post",
                url: "../MemberWebService.asmx/check_username",
                data: "username=" + $('#<%=Username.ClientID %>').val(),

                success: function (data) {
                    alert($(data).text());
                }
            });
        });
    });
</script>
<div id="registermem" title="會員註冊">
    <table class="registertb">
    <tr>
        <td colspan="2" class="header">
            會員註冊</td>
    </tr>
    <tr>
        <td class="title">
            帳號</td>
        <td class="button">
            <asp:TextBox ID="Username" runat="server" CssClass="username" title="請輸入8~12字元"></asp:TextBox>
            
            
        </td>
    </tr>
    <tr>
        <td class="title">
            密碼</td>
        <td class="button">
            <asp:TextBox ID="Password" runat="server" TextMode="Password" 
                CssClass="password" title="請輸入8~12字元"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="title">
            確認密碼</td>
        <td class="button">
            <asp:TextBox ID="rePassword" runat="server" TextMode="Password" 
                CssClass="repassword" title="必須跟密碼一致"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="title">
            暱稱</td>
        <td class="button">
            <asp:TextBox ID="Nickname" runat="server" CssClass="nickname" title="請輸入暱稱"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="title">
            性別</td>
        <td class="button">
            <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal" 
                CssClass="gender">
                <asp:ListItem Selected="True">男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="title">
            生日</td>
        <td class="button">
            <asp:TextBox ID="birthday1" runat="server" CssClass="birthday1" title="請選擇日期"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="title">
            電子郵件</td>
        <td class="button">
            <asp:TextBox ID="Email" runat="server" Width="300px" CssClass="email" title="請輸入電子郵件"></asp:TextBox>
        </td>
    </tr>
    <tr class="button">
        <td colspan="2" class="footer">
            <asp:Button ID="loginbutton" runat="server" Text="確定" onclick="Button1_Click" 
                CssClass="registerbutton" ToolTip="確定" />
            <asp:Button ID="logincancel" runat="server" Text="取消" CssClass="registercancel" 
                ToolTip="取消" />
        </td>
    </tr>
</table>
</div>
</asp:Content>
