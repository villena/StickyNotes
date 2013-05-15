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
                  
                  <asp:Button ID="Button1" runat="server" CssClass="cssbutton" Text="New Group" />
                  <asp:Panel ID="Panel1" runat="server">
                  List of groups (not implemented yet)
                     </asp:Panel>
    </asp:Panel>
</asp:Content>


