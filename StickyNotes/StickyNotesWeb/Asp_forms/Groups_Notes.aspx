<%@ Page Language="C#" Title="Group Notes" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Groups_Notes.aspx.cs" Inherits="StickyNotesWeb.Asp_forms.Groups_Notes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Groups.aspx">Groups</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink3" runat="server"></asp:HyperLink>
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

        <br />

    </asp:Panel>

    <div id="placeholder" runat="server" class="tablon">
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    </div>


    <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
    
        <br />
    
    <asp:TextBox ID="DescripcionNota" runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px" CssClass="textarea"    />
       <asp:Button ID="CreateNoteButton" runat="server" Text="New Note" CssClass="button white" OnClick="Create_Note"/>
     </asp:Panel>
</asp:Content>