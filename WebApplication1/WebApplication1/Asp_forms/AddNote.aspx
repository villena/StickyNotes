<%@ Page Language="C#" Title="New Note" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="WebApplication1.Asp_forms.AddNote" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

       <h2>
       New Note
    </h2>
   
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" >

        <asp:Panel ID="Panel2" runat="server" CssClass="postit" Width="310px" HorizontalAlign="Center" DefaultButton="Button1">
        
            <asp:TextBox ID="TextBox1" runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px"/>
        
        <br />
            <asp:Label ID="Label1" runat="server" Text="Set Gategory: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="Label2" runat="server" Text="Kind: "></asp:Label>
            <asp:ListBox ID="ListBox1" runat="server" Rows="2"></asp:ListBox>
        <br />
            <asp:Label ID="Label3" runat="server" Text="Add Users: "></asp:Label>
            <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="false" SelectionMode="Multiple"></asp:ListBox>
            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Add" AutoPostBack="false" />
            <asp:ListBox ID="ListBox3" runat="server"></asp:ListBox>
    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Send" CssClass="button white" />
    <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </asp:Panel>
    </asp:Panel>
        
    

</asp:Content>