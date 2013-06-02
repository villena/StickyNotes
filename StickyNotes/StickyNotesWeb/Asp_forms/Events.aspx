<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="StickyNotesWeb.Events" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Events.aspx">Events</asp:HyperLink>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       My events
    </h2>

    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <p align="Right">
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="Search New Events" PostBackUrl = "SearchEvents.aspx"/>
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Create New Event" PostBackUrl = "AddEvents.aspx"/>
            &nbsp;&nbsp;&nbsp;
         <!--<asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>-->
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
    
    
    </asp:Panel>


</asp:Content>

