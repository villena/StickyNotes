<%@ Page Title="Editor" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Editnotes.aspx.cs" 
Inherits="WebApplication1.Asp_forms.Editnotes" %>





<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:TextBox ID="TextBox1" runat="server" Height="100px" MaxLength="200" 
        Rows="5" TextMode="MultiLine" Width="400px"/>
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel">
    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Send" CssClass="button white" />
    </asp:Panel>
        
    

</asp:Content>