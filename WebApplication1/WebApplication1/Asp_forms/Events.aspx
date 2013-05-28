<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="WebApplication1.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       My events
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="Search" PostBackUrl = "SearchEvents.aspx"/>
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="New Event" PostBackUrl = "AddEvents.aspx"/>
            &nbsp;&nbsp;&nbsp;
         <!--<asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>-->
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
    
    
    </asp:Panel>


</asp:Content>

