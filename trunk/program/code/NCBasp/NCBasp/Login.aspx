<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NCBasp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        LOG IN :
    </h2>
    <p>* wajib di isi</p>
    <p>
        <asp:Label ID="UserNameLabelLogin" runat="server" AssociatedControlID="UserNameLoginBox">User Name &nbsp : &nbsp </asp:Label>
        <asp:TextBox ID="UserNameLoginBox" runat="server" CssClass="textEntry"></asp:TextBox>*
        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserNameLoginBox" 
            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
            ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="PasswordLabelLogin" runat="server" AssociatedControlID="PasswordLoginBox">Password &nbsp : &nbsp </asp:Label>
        <asp:TextBox ID="PasswordLoginBox" runat="server" CssClass="passwordEntry" TextMode="Password">*</asp:TextBox>*
        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="PasswordLoginBox" 
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
            ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="loginClick" />
    </p>
</asp:Content>
