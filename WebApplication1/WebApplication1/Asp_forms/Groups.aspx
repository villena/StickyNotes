<%@ Page Title="My Groups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="WebApplication1.Groups" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Groups.aspx">Groups</asp:HyperLink>

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


