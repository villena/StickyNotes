<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" inherits="WebApplication1.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Personal Information
    </h2>

    <asp:Panel ID="Panel1" CssClass="postit" runat="server" style="height: 250px">
        <br />

    <div style="float:left">
        <asp:Image id="Image1" runat="server" style="max-width: 200px; max-height: 200px; border: 5px groove brown;" AlternateText="Imagen no disponible"/>
    </div>
    <div style="clear:right; margin-left:250px">
        Name: <asp:Label ID="Label3" runat="server" Text="Name: "></asp:Label> <br>
        Surname: <asp:Label ID="Label4" runat="server" Text="Surname: "></asp:Label> <br>
        Email: <asp:Label ID="Label5" runat="server" Text="E-mail: "></asp:Label> <br>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" ssClass="cssbutton" Text="Edit Profile" PostBackUrl="~/Account/ChangePassword.aspx" />
        <asp:Button ID="Button2" runat="server" ssClass="cssbutton" Text="Change Password" PostBackUrl="~/Account/ChangePassword.aspx" />
    </div>
    </asp:Panel>
    


</asp:Content>



