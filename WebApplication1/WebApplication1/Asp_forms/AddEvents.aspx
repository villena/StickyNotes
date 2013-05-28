<%@ Page Title="Add Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEvents.aspx.cs" Inherits="WebApplication1.AddEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       New Event
    </h2>

    <asp:Panel ID="Panel1" DefaultButton="CreateEventButton" CssClass="default_panel" runat="server">
        <p align="Left">
            <p>
                <asp:Label ID="LabelDate" runat="server" Text="Date:"></asp:Label>
                <!--<asp:TextBox ID="TextBoxDate" runat="server" EnableTheming="True"></asp:TextBox>-->
                <asp:Calendar ID="Calendar1" runat="server" CssClass="button white" Width="230" ></asp:Calendar>
            </p>
            <p>
                <asp:Label ID="LabelLocation" runat="server" Text="Location:"></asp:Label>
                </p>
                <asp:TextBox ID="TextBoxLocation"  runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px" CssClass="textarea"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="LabelDescription" runat="server" Text="Description:" ></asp:Label>
            </p>
                <asp:TextBox ID="TextBoxDescription"  runat="server" Height="100px" MaxLength="100"
            Rows="5" Style="resize:none;" TextMode="Multiline" Width="300px" CssClass="textarea"></asp:TextBox>
            <p>
                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="false" SelectionMode="Multiple" CssClass="textarea"></asp:ListBox>
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Add" AutoPostBack="false" CssClass="button white" />
                <asp:Button ID="Button2" runat="server" Text="Remove" OnClick="Remove" AutoPostBack="false" CssClass="button white" />
                <asp:ListBox ID="ListBox2" runat="server" CssClass="textarea"></asp:ListBox>
            </p>
        </p>
        <asp:Button ID="CreateEventButton" runat="server" Text="New Event" CssClass="button white" OnClick="newEvent"/>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="default_panel" runat="server">
    </asp:Panel>


</asp:Content>

