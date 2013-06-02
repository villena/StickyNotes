<%@ Page Language="C#" Title="" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UserTable.aspx.cs" Inherits="StickyNotesWeb.Asp_forms.UserTable" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Friends.aspx">Friends</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink3" runat="server"></asp:HyperLink>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="Name" runat="server" ></asp:Label>
         <asp:Label ID="Nick" runat="server" Font-Size="0.8em" Font-Bold="false" Font-Names="Segoe UI Light"></asp:Label>
    </h2>
    <h3>
       
    </h3>
   

    <div id="placeholder" runat="server" class="tablon">
   <!-- <asp:Label ID="NotasPrueba" runat="server"></asp:Label> -->
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    <!-- here is where the dinamically created elements will be placed -->
    </div>
</asp:Content>
