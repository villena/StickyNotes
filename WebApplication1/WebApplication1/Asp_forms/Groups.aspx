<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="WebApplication1.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        My Groups
    </h2>

  
        <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
                  <br />
                  <br />
                  
                  <asp:Button ID="Button1" runat="server" CssClass="button white" Text="New Group" />
                  <asp:Panel ID="Panel1" runat="server">
                  List of groups (not implemented yet)
                     </asp:Panel>
    </asp:Panel>
</asp:Content>

<asp:Content ID="LoginForm" runat="server" ContentPlaceHolderID="MainContent2">
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <asp:Button ID="Button3" runat="server" Text="Button" CssClass="button white"/>
        
      
</asp:Content>

