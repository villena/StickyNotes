<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register2.aspx.cs" Inherits="WebApplication1.Register2" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <h2>
                        Create a new account
 </h2>


 <asp:Panel ID="Panel1" runat="server" CssClass="default_panel">
   
     
           
          

        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                                        
                   
                  
                    <div class="accountInfo">
                       
                            
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" CssClass="failureNotification" 
                                    ErrorMessage="El nombre de usuario es obligatorio." 
                                    ToolTip="El nombre de usuario es obligatorio." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" CssClass="failureNotification" 
                                    ErrorMessage="El correo electrónico es obligatorio." 
                                    ToolTip="El correo electrónico es obligatorio." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                           
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" CssClass="failureNotification" 
                                    ErrorMessage="La contraseña es obligatoria." 
                                    ToolTip="La contraseña es obligatoria." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>







                            </p>
                     
                            <p>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" CssClass="failureNotification" 
                                    Display="Dynamic" ErrorMessage="Confirmar contraseña es obligatorio." 
                                    ToolTip="Confirmar contraseña es obligatorio." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    CssClass="failureNotification" Display="Dynamic" 
                                    ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                     
                        <p class="submitButton">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                            <asp:Button ID="CreateUserButton" runat="server" CssClass="button white" Text="Sign Up"  ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="SignUp_Click"/>
                        </p>
                    </div>
                

                
              
         
                 
          
            
                              
            

     </asp:Panel>

 </asp:Content>
