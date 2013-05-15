<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="WebApplication1.Formulario_web1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        My Friends
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button1" runat="server" CssClass="search_button" Text="Search" />
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">

    (List of friends)
    </asp:Panel>


</asp:Content>

