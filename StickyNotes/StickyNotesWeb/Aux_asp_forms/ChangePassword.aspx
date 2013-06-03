<%@ Page Title="Cambiar contraseña" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="StickyNotesWeb.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Change password
    </h2>
    <p>
        Use the following form to change the password
    </p>
    <p>
        New password must have at least 6 characters.
    </p>
            <div class="accountInfo">
                    <legend>Información de cuenta</legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Current Password:</asp:Label></br>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                             CssClass="failureNotification" ErrorMessage="*</br>The current password is mandatory." ToolTip="The current password is mandatory " 
                             ></asp:RequiredFieldValidator>
                        
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label></br>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                             CssClass="failureNotification" ErrorMessage="*</br>The new password is mandatory." ToolTip="The new password is mandatory." 
                             ></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Comfirm the password:</asp:Label></br>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="*</br>Comfirm the new password is mandatory."
                             ToolTip="Confirmar la nueva contraseña es obligatorio." ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="*</br>The passwords must be the same."
                             ></asp:CompareValidator>
                    </p>
                <p class="submitButton">
                    <asp:Button ID="CancelPushButton" runat="server" Text="Cancelar"/>
                    <asp:Button ID="ChangePasswordPushButton" runat="server" Text="Cambiar contraseña" OnClick="Change_Pass"/>
                </p>
            </div>
</asp:Content>
