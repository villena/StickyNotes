<%@ Page Language="C#" Title="New Group" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Create_Group.aspx.cs" Inherits="WebApplication1.Asp_forms.Create_Group" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            margin-left: 30px;
            margin-right: 10px;
            margin-top: 30px;
            color: #000000;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    
    
    <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" DefaultButton="Send" HorizontalAlign="Center">


        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"  MaxLength="100"
            Rows="1" Style="resize:none;" TextMode="Multiline" Width="300px" CssClass="textareasingle" ></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Add Friends"></asp:Label>
        <br />
        <br />

        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="false" SelectionMode="Multiple" CssClass="textarea"></asp:ListBox>
        <asp:Button ID="Button1" runat="server" AutoPostBack="false" 
            CssClass="button white" OnClick="Add" Text="Add" />
        <asp:ListBox ID="ListBox2" runat="server" CssClass="textarea"></asp:ListBox>
        <br />
        &nbsp;<asp:Button ID="Remove" runat="server" CssClass="button white" 
            OnClick="RemoveUser" Text="Remove" Width="88px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <br />
        <asp:Button ID="Send" runat="server" Text="Send" OnClick="SendGroup" CssClass="button white"/>

        <br />
        <asp:Label ID="Label3" runat="server" CssClass="failureNotification" Text=""></asp:Label>
        <br />

     </asp:Panel>


</asp:Content>