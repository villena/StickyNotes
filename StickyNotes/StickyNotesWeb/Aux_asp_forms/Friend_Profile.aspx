﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friend_Profile.aspx.cs" Inherits="StickyNotesWeb.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Personal Information
    </h2>
    <asp:Panel ID="Content" CssClass="tablon" runat="server" style="height: 250px">
    <asp:Panel ID="Panel1" CssClass="postit" runat="server" style="height: 250px">
        <br />

        <div style="float:left" width="33%">
        <asp:Image id="Image1" runat="server" style="max-width: 200px; max-height: 200px; border: 5px groove brown;" AlternateText="Imagen no disponible"/>
    </div>
    <div style="float:left; clear:right; margin-left:20px" width="33%">
        Nick: <asp:Label ID="Label1" runat="server" Text="Nick: "></asp:Label> <br>
        Name: <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label> <br>
        Surname: <asp:Label ID="Label3" runat="server" Text="Surname: "></asp:Label> <br>
        Email: <asp:Label ID="Label4" runat="server" Text="E-mail: "></asp:Label> <br>
    </div>
    <div style="float:left; margin-left:20px" width="33%">
        Gender: <asp:Label ID="Label5" runat="server" Text="Gender: "></asp:Label> <br>
        Entry Date: <asp:Label ID="Label6" runat="server" Text="Entry Date: "></asp:Label> <br>
        Birth Date: <asp:Label ID="Label7" runat="server" Text="Birth Date: "></asp:Label> <br>
        <br />
        <br />
    </div>
    </asp:Panel>
    </asp:Panel>
</asp:Content>
