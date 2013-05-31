<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        My Categories
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" DefaultButton="SearchButton" runat="server">
        <p align="Right">
        <asp:TextBox ID="SearchBox" CssClass="search_textbox" runat="server"></asp:TextBox>
        <asp:Button ID="SearchButton" CssClass="search_button" runat="server" OnClick="searchCategory" Text="Buscar"/>
        </p>
        <p align="right">
            &nbsp;</p>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" CssClass="tablon" runat="server"></asp:Panel>


</asp:Content>

