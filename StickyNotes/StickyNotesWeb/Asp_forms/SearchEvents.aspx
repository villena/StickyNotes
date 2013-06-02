<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchEvents.aspx.cs" Inherits="StickyNotesWeb.SearchEvents" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Events.aspx">Events</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Asp_forms/SearchEvents.aspx">Search</asp:HyperLink>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       Search
    </h2>

    <asp:Panel ID="myPanel" CssClass="default_panel" DefaultButton="Button2" runat="server">
        <p align="Right">
            <asp:Button ID="Button3" runat="server" CssClass="button" Text="My Events" PostBackUrl = "Events.aspx"/>
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="New Event" PostBackUrl = "AddEvents.aspx"/>
       
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" CssClass="button" Text="Search" OnClick="Search" />
            <asp:Button ID="Button4" runat="server" CssClass="button" Text="Show All" OnClick="ShowAll" />
            
            &nbsp;&nbsp;&nbsp;
         <!--<asp:TextBox ID="TextBox3" CssClass="search_textbox" runat="server"></asp:TextBox>-->
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
    
    
    </asp:Panel>


</asp:Content>

