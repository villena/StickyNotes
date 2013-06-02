<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="WebApplication1.Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hola</h2>
<div>
    <asp:Button id="BotonEnviar" Text="Enviar" runat="server" OnClick="CargaBase" />
    <asp:Label id="LabelPrueba" runat="server" />
</div>

    
</asp:Content>
