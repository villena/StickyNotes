<%@ Page Language="C#" Title="New Note" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="WebApplication1.Asp_forms.AddNote" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Notes.aspx">My Notes</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Asp_forms/AddNote.aspx">New Note</asp:HyperLink>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

       <h2>
       New Note
    </h2>
   
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" >

        <asp:Panel ID="Panel2" runat="server" CssClass="postit" Width="543px" 
            HorizontalAlign="Center" DefaultButton="Button1">
        
            <asp:TextBox ID="TextBox1" runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px" CssClass="textarea"/>
        
        <br />
            <asp:Label ID="Label1" runat="server" Text="Set Gategory: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textareasingle"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Kind: "></asp:Label>
            <asp:ListBox ID="ListBox1" runat="server" Rows="2" CssClass="textarea"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Add Users: "></asp:Label>
            <br />
            <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="false" SelectionMode="Multiple" CssClass="textarea"></asp:ListBox>
            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Add" AutoPostBack="false" CssClass="button white"/>
            <asp:ListBox ID="ListBox3" runat="server" CssClass="textarea"></asp:ListBox>
    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Send" CssClass="button white" />
    <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </asp:Panel>
    </asp:Panel>
        
    

</asp:Content>