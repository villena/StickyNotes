<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register2.aspx.cs" Inherits="WebApplication1.Register2" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <h2>
                        Create new account
 </h2>


 <asp:Panel ID="Panel1" runat="server" CssClass="default_panel" DefaultButton="CreateUserButton">
   
     
           
          

        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                                        
                   
                  
                    <div class="accountInfo">
                       
                             <p>
                                <asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">Name</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Name" runat="server" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="Name" CssClass="failureNotification" 
                                    ErrorMessage="Name required." 
                                    ToolTip="Name required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>

                             <p>
                                <asp:Label ID="SurnameLabel" runat="server" AssociatedControlID="Surname">Surname</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Surname" runat="server" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="Surname" CssClass="failureNotification" 
                                    ErrorMessage="Surname required." 
                                    ToolTip="Surname required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>

                            
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" CssClass="failureNotification" 
                                    ErrorMessage="UserName required." 
                                    ToolTip="UserName required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                            </p>
                            <p>
                                <asp:TextBox ID="Email" runat="server" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" CssClass="failureNotification" 
                                    ErrorMessage="E-mail required." 
                                    ToolTip="E-mail required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                           
                            </p>
                           
                           

                             <p>
                                <asp:Label ID="GenderLabel" runat="server">Gender</asp:Label>
                            </p>
                            <p>
                                <asp:ListBox ID="ListBox1" runat="server" CssClass="textareasingle"></asp:ListBox>
                                 <asp:RequiredFieldValidator ID="GenderValidator" runat="server" 
                                    ControlToValidate="ListBox1" CssClass="failureNotification" 
                                    ErrorMessage="Gender required." 
                                    ToolTip="Gender required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>


                             <p>
                                <asp:Label ID="BirthLabel" runat="server" >Birth date</asp:Label>
                            </p>
                            <p>
                                 <asp:Calendar ID="Calendar1" runat="server" CssClass="button white" Width="230" ></asp:Calendar>
                                
                            </p>

                             <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                            </p>
                                <p>
                                <asp:TextBox ID="Password" runat="server"  
                                    TextMode="Password" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" CssClass="failureNotification" 
                                    ErrorMessage="Password required." 
                                    ToolTip="Password required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>

                            </p>
                     
                            <p>
                                <asp:TextBox ID="ConfirmPassword" runat="server" 
                                    TextMode="Password" CssClass="textareasingle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" CssClass="failureNotification" 
                                    Display="Dynamic" ErrorMessage="Confirm password required." 
                                    ToolTip="Confirm password required." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    CssClass="failureNotification" Display="Dynamic" 
                                    ErrorMessage="Passwords are different." 
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                        <p class="submitButton">
                            <asp:Label ID="SameUserfailure" runat="server" CssClass="failureNotification"></asp:Label>

                            <asp:Button ID="CreateUserButton" runat="server" CssClass="button white" Text="Sign Up"  ValidationGroup="RegisterUserValidationGroup" 
                                OnClick="SignUp_Click"/>
                        </p>


                    </div>
                

                
              
         
                 
          
            
                              
            

     </asp:Panel>

 </asp:Content>
