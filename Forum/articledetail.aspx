<%@ Page Title="討論區" Language="C#" MasterPageFile="~/iForumsMaster.Master" AutoEventWireup="true" CodeBehind="articledetail.aspx.cs" Inherits="iFourms.Forum.articledetail"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/forum.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/page.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .datalist1
        {
            margin-bottom: 15px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="replytop">
    <asp:LinkButton ID="rbutton" runat="server" CssClass="rbutton" Height="20px" 
        Width="100px" onclick="rbutton_Click">回覆文章</asp:LinkButton>
    </div>
<asp:Panel ID="panel" runat="server">
<div id="articledetail_top">
    <table class="articledetailtb">
        <tr>
            <td class="htop" colspan="2">
                <asp:Label ID="Label11" runat="server" Text="樓主"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="header" rowspan="2">
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    CssClass="profiledetail" GridLines="None">
                    <Fields>
                        <asp:TemplateField>
                            <ItemTemplate>
                                編號：<asp:Label ID="mid" runat="server" Text='<%# Eval("M_ID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="id" />
                            <ItemStyle CssClass="id" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="iusername" runat="server" CssClass="iusername" 
                                    Text='<%# Eval("Username") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle CssClass="username" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="iicon" runat="server" 
                                    CssClass="iicon" Height="100px" 
                                    ImageUrl='<%# "../Member/Icon/"+Eval("Username")+"/"+Eval("Icon") %>' 
                                    Width="100px" />
                            </ItemTemplate>
                            <ItemStyle CssClass="icon" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                註冊日期：<asp:Label ID="iregtime" runat="server" CssClass="iregtime" 
                                    Text='<%# Eval("RegTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="regtime" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                文章：<asp:Label ID="icount" runat="server" CssClass="icount"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="count" />
                            <ItemStyle CssClass="count" />
                        </asp:TemplateField>
                    </Fields>
                    <RowStyle CssClass="row" />
                </asp:DetailsView>
            </td>
            <td class="content" >
                <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" 
                    CssClass="atitlecontent" GridLines="None" HorizontalAlign="Left">
                    <Fields>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                【<asp:Label ID="Label5" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                】<asp:Label ID="Label3" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="atitle" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Contents") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="acontent" />
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
            </td>
            
        </tr>
        <tr>
            <td class="tfooter">
                <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                    Font-Names="新細明體" Font-Size="12pt" ForeColor="#999999" 
                    GridLines="None" CssClass="tcreate">
                    <Fields>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" 
                                    Text='<%# "發文時間："+Eval("acreatetime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="acreatetime" />
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
        </table>

</div>
</asp:Panel>
<div id="articledetail_down">

    <asp:DataList ID="DataList1" runat="server" CssClass="datalist1">
        <ItemTemplate>
        <table class="articledetailtb">
        <tr>
            <td class="htop" colspan="2">
                &nbsp;<asp:Label ID="Label12" runat="server"></asp:Label>
                
            </td>
            
        </tr>
        <tr>
            <td class="header" rowspan="2">
                <table class="title">
                    <tr>
                        <td>
                            編號：<asp:Label ID="Label6" runat="server" CssClass="id" 
                                Text='<%# Eval("M_ID") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="username" 
                                Text='<%# Eval("Username") %>'></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" CssClass="icon" Height="100px" 
                                Width="100px" 
                                ImageUrl='<%# "../Member/Icon/"+Eval("Username")+"/"+Eval("Icon") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            註冊日期：<asp:Label ID="Label7" runat="server" CssClass="time" 
                                Text='<%# Eval("RegTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            文章：<asp:Label ID="Label8" runat="server" CssClass="count"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="content">
                <asp:Label ID="Label10" runat="server" CssClass="acontent" 
                    Text='<%# HttpUtility.HtmlDecode(Eval("Contents").ToString()) %>'></asp:Label>
            </td>
        </tr>
            <tr>
                <td class="tfooter">
                    <asp:Label ID="Label9" runat="server" CssClass="creatime" 
                        Text='<%# "回覆時間："+Eval("CreateTime","{0:yyyy-MM-dd HH:mm:ss}") %>' 
                        Font-Names="新細明體" Font-Size="12pt" ForeColor="#999999"></asp:Label>
                </td>
            </tr>
        </table>                
        </ItemTemplate>
    </asp:DataList>

    <asp:Panel ID="page_panel" runat="server" CssClass="page_panel">
    </asp:Panel>
    <a  name="pb"></a>
</div>
    <asp:Panel ID="Panel1" runat="server">

<div id ="reply">
            <table class="t_index">
                <tr>
                    <td class="t_title">
                        快速回復</td>
                </tr>
                <tr>
                    <td class="t_content">
                        <asp:TextBox ID="fastcontent" runat="server" CssClass="fastcontent" 
                            Height="120px" TextMode="MultiLine" Width="950px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="t_content">
                        <asp:Button ID="fastbutton" runat="server" CssClass="fastbutton" Text="確定發表" 
                            onclick="fastbutton_Click" />
                    </td>
                </tr>
            </table>
</div>
    </asp:Panel>
</asp:Content>
