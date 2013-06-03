<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="StickyNotesWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome
    </h2>
    <div id="placeholder" runat="server" class="tablon">
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
        </asp:Panel>
    </div>
   
    
</asp:Content>

  
 


  

               