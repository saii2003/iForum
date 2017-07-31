<%@ Page Title="" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="iFourms.Member.success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />
    <style>
    .success
    {
        margin:20px 0px 20px 0px;
        text-align:center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="success">
    <h3>註冊成功!請至您的電子信箱進行會員驗證。<asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Forum/index.aspx">回首頁</asp:HyperLink>
    </h3>
</div>
</asp:Content>
