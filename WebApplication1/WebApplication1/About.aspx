<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About Sticky Notes
    </h2>
   

    
   <asp:Panel ID="Panel1" CssClass="default_panel" runat="server">
         <p>
            Advanced Tools for Application Development Project
         </p>

         
        <p>
            Autors:
            <br />
            Gines Baño
            <br />
            Manuel Rives
            <br />
            Alexandre Rubio
            <br />
            Javier Soria
            <br />
            Victor Villena
        </p>
  </asp:Panel>


</asp:Content>

<asp:Content ID="LoginForm" runat="server" ContentPlaceHolderID="MainContent2">
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <asp:Button ID="Button3" runat="server" Text="Button" CssClass="button white"/>
        
      
</asp:Content>