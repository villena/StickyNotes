<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeAccountData.aspx.cs" Inherits="WebApplication1.Formulario_web17" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <h2>
                        Modify Data
 </h2>


 <asp:Panel ID="Panel1" runat="server" CssClass="default_panel">
   
     
           
          

        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                                        
                   
                  
                    <div class="accountInfo">
                       
                            
                            <p>
                                <asp:Label ID="NickLabel" runat="server" AssociatedControlID="Nick">Nick</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Nick" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                           
                            </p>
                            <p>
                                <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">Name</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Name" runat="server" CssClass="textEntry"></asp:TextBox>

                            </p>
                            <p>
                                <asp:Label ID="SurnameLabel" runat="server">Surname</asp:Label>
                            </p>
                     
                            <p>
                                <asp:TextBox ID="Surname" runat="server" CssClass="textEntry"></asp:TextBox>

                            </p>
                     
                            <p>
                                <asp:Label ID="GenderLabel" runat="server">Gender</asp:Label>
                            </p>
                            <p>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Text="Male" />
                                    <asp:ListItem Text="Female" />
                                </asp:RadioButtonList>
                            </p>
                            <p>
                                <asp:Label ID="ImageUrlLabel" runat="server" AssociatedControlID="ImageUrl">ImageUrl</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="ImageUrl" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                &nbsp;</p>
                     
                        <p class="submitButton">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                            <asp:Button ID="CreateUserButton" runat="server" CssClass="button white" Text="Change Data"  ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="ChangeData"/>
                        </p>
                    </div>
                

                
              
         
                 
          
            
                              
            

     </asp:Panel>
</asp:Content>
