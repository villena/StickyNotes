<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="StickyNotesWeb.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/About.aspx">About</asp:HyperLink>

</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About Sticky Notes
    </h2>
   

    
   <asp:Panel ID="Panel1" CssClass="default_panel" runat="server" HorizontalAlign="Center">
         
       <asp:Panel ID="Panel2" runat="server" Width="500px" CssClass="postitnotes">
       
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
  </asp:Panel>


</asp:Content>

