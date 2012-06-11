<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="NCBasp.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Silankan melakukan registrasi di bawah ini.
    </h2>
    <p>
        *wajib di isi.
    </p>
    <p>
        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserNameBox">Username:</asp:Label>
        <asp:TextBox ID="UserNameBox" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserNameBox" 
            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    *</p>
    <p>
        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="PasswordBox">Password:</asp:Label>
        <asp:TextBox ID="PasswordBox" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="PasswordBox" 
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    *</p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="loginClick" />
    </p>
</asp:Content>
