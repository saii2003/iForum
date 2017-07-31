<%@ Page Title="上傳個人圖示" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="updateicon.aspx.cs" Inherits="iFourms.Member.updateicon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/Member.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id= "updateicon">
    <table class="updateicontb">
        <tr>
            <td class="header">
                上傳個人圖示</td>
        </tr>
        <tr>
            <td class="explain">
                可上傳圖片格式：jpeg、gif、png、jpg</td>
        </tr>
        <tr>
            <td class="tupdate">
                <asp:FileUpload ID="fileupdate" runat="server" CssClass="fileupdate" 
                    ToolTip="上傳個人圖示" />
            </td>
        </tr>
        <tr>
            <td class="tfooter">
                <asp:Button ID="Button1" runat="server" Text="確定" CssClass="button" 
                    onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
