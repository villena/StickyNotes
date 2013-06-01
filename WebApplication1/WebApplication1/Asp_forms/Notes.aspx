<%@ Page Title="My Notes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Notes.aspx.cs"  Inherits="WebApplication1.Notes"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Notes.aspx">My Notes</asp:HyperLink>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        my notes
    </h2>
   <p>
      <!-- <asp:TextBox ID="DescripcionNota" TextMode = "multiline" CssClass="textarea" runat="server"></asp:TextBox> -->
       <asp:Button ID="CreateNoteButton" runat="server" Text="New Note" CssClass="button white" OnClick="Create_Note"/>
       
    </p>

    <div id="placeholder" runat="server" class="tablon">
   <!-- <asp:Label ID="NotasPrueba" runat="server"></asp:Label> -->
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    <!-- here is where the dinamically created elements will be placed -->
    </div>
</asp:Content>



