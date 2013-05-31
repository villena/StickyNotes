<%@ Page Title="My Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="WebApplication1.Groups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        My Groups
    </h2>

  
        <asp:Panel ID="Panel2" CssClass="default_panel" runat="server" HorizontalAlign="center">
                  <br />
                  <br />
                  
                  <asp:Button ID="Button1" runat="server" CssClass="cssbutton" OnClick="Create" Text="New Group" />
                  
    </asp:Panel>
    
</asp:Content>


