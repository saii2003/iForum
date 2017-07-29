<%@ Page Title="" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="reply.aspx.cs" Inherits="iFourms.Forum.reply" validateRequest="false"  %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
    <link href="../Styles/forum.css" rel="stylesheet" type="text/css" />
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="replys">


    <table class="replystb">
        <tr>
            <td class="title">
                回覆文章</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="re" runat="server" CssClass="ckeditor" Height="230px" 
                    TextMode="MultiLine" Width="1000px"></asp:TextBox>
                
            </td>
        </tr>
    </table>



</div>
<div id="replysbutton">
<asp:Button ID="replybutton" runat="server" CssClass="replybutton" Text="回覆" 
        onclick="replybutton_Click" />
</div>
    </asp:Content>
