﻿<%@ Page Title="My Notes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Notes.aspx.cs"  Inherits="StickyNotesWeb.Notes"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink> > 
<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Asp_forms/Notes.aspx">My Notes</asp:HyperLink>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        My Notes
    </h2>
   <p>
      <asp:Button ID="CreateNoteButton" runat="server" Text="New Note" CssClass="button white" OnClick="Create_Note"/>
       
    </p>

    <div id="placeholder" runat="server" class="tablon">
        <asp:Panel ID="Panel1" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    </div>
</asp:Content>



