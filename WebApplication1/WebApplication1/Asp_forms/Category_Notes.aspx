﻿<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Category_Notes.aspx.cs"  Inherits="WebApplication1.Category_Notes"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        my notes
    </h2>
   <p>
       <asp:TextBox ID="DescripcionNota" TextMode = "multiline" CssClass="textarea" runat="server"></asp:TextBox>
       <asp:Button ID="CreateNoteButton" runat="server" Text="New Note" CssClass="button white" OnClick="Create_Note"/>
       
    </p>

    <div id="placeholder" runat="server" class="tablon">
   <!-- <asp:Label ID="NotasPrueba" runat="server"></asp:Label> -->
        <asp:Panel ID="Panelnota" runat="server" CssClass="defaultPanel">
           
        </asp:Panel>
    <!-- here is where the dinamically created elements will be placed -->
    </div>
</asp:Content>