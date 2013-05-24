<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        My Categories
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>
        </p>
        <p align="right">
            &nbsp;</p>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" CssClass="tablon" runat="server"></asp:Panel>


</asp:Content>

