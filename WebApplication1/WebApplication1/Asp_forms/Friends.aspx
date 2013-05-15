<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
            My Friends
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button1" runat="server" CssClass="search_button" Text="Search" OnClick="SearchFriend" />
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>
        </p>
        <p align="right">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" align="Right" AutoPostBack="True">
                <asp:ListItem Text="Only my friends" Selected="True"/>
                <asp:ListItem Text="All Users"/>
            </asp:RadioButtonList>
        </p>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
    
    </asp:Panel>


</asp:Content>

