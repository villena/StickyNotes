﻿<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       Events
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button1" runat="server" Text="Add Event" CssClass="button white"/>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">

    (List of events)
    </asp:Panel>


</asp:Content>

<asp:Content ID="LoginForm" runat="server" ContentPlaceHolderID="MainContent2">
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <asp:Button ID="Button3" runat="server" Text="Button" CssClass="button white"/>
        
      
</asp:Content>