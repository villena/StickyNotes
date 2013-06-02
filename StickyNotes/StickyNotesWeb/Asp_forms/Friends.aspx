<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="StickyNotesWeb.Formulario_web1" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Friends.aspx">Friends</asp:HyperLink>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
            My Friends
    </h2>
    
    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button1" runat="server" CssClass="search_button" Text="All" OnClick="SearchAll" Width="75"/>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" CssClass="search_button" Text="Search" OnClick="SearchFriend" Width="75"/>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" align="Right">
                <asp:ListItem Text="Only my friends" />
                <asp:ListItem Text="All Users" />
            </asp:RadioButtonList>
        </p>
        <p align="right">
            &nbsp;</p>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" CssClass="tablon" runat="server">
    
    </asp:Panel>


</asp:Content>

