<%@ Page Language="C#" Title="Group Notes" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Groups_Notes.aspx.cs" Inherits="WebApplication1.Asp_forms.Groups_Notes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h2>
   <p>
       
       <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
       
    </p>
    <asp:Panel ID="Panel2" runat="server" CssClass="default_panel">
    
        <asp:Button ID="Button1" runat="server" Text="Delete Group" CssClass="button white" OnClick="Delete" />

    </asp:Panel>

    <div id="placeholder" runat="server" class="tablon">
   <!-- <asp:Label ID="NotasPrueba" runat="server"></asp:Label> -->
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    <!-- here is where the dinamically created elements will be placed -->
    </div>

    <asp:TextBox ID="DescripcionNota" TextMode = "multiline" CssClass="textarea" runat="server"></asp:TextBox>
       <asp:Button ID="CreateNoteButton" runat="server" Text="New Note" CssClass="button white" OnClick="Create_Note"/>
</asp:Content>