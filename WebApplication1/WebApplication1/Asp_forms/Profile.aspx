<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Personal Information
    </h2>

    <br />
    <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
        <br />

    (Image here)

    <br />
    <br />

    <asp:Label ID="Label3" runat="server" CssClass="csslabel" Text="Name: "></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Surname: "></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="E-mail: "></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" ssClass="cssbutton" Text="Edit" CssClass="button white"/>
    </asp:Panel>
    


</asp:Content>

<asp:Content ID="LoginForm" runat="server" ContentPlaceHolderID="MainContent2">
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <asp:Button ID="Button3" runat="server" Text="Button" CssClass="button white"/>
        
      
</asp:Content>

