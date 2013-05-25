<%@ Page Title="Editor" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Editnotes.aspx.cs" 
Inherits="WebApplication1.Asp_forms.Editnotes" %>





<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

   
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" >

     <asp:Label ID="Label1" runat="server" Text="Old text: "></asp:Label>
     <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" CssClass="postit" Width="310px" HorizontalAlign="Center">
        
            <asp:TextBox ID="TextBox1" runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px"/>
        
        <br />
        <br />
    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Send" CssClass="button white" />
    </asp:Panel>
    </asp:Panel>
        
    

</asp:Content>