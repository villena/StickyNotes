<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Notes.aspx.cs"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        MY NOTES
    </h2>
   <p>
      
       <asp:Button ID="Button2" runat="server" Text="New Note" />

    <asp:Panel ID="Panel1" runat="server" CssClass="tablon">
    </asp:Panel>
    </p>
</asp:Content>

<asp:Content ID="LoginForm" runat="server" ContentPlaceHolderID="MainContent2">
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <asp:Button ID="Button3" runat="server" Text="Button" />
        
      
</asp:Content>

