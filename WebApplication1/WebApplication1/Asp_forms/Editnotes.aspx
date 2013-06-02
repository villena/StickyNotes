<%@ Page Title="Editor" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Editnotes.aspx.cs" 
Inherits="WebApplication1.Asp_forms.Editnotes" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Notes.aspx">My Notes</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Asp_forms/Editnotes.aspx">Editor</asp:HyperLink>
</asp:Content>




<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

   
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" >

     <!--<asp:Label ID="Label1" runat="server" Text="Old text: "></asp:Label>-->
        <asp:Panel ID="Panel3" runat="server" CssClass="postitnotes">
        
             <asp:Label ID="Label2" runat="server"></asp:Label>

        </asp:Panel>
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