<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NCBasp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Silahkan melakukan registrasi di bawah ini.
    </h2>
    <p>
        *wajib di isi
    </p>
    <p>
        <asp:Label ID="UserNameLabelRegister" runat="server" AssociatedControlID="UserNameRegisterBox">Username &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:</asp:Label>
        <asp:TextBox ID="UserNameRegisterBox" runat="server" CssClass="textEntry"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserNameRegisterBox" 
            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    *</p>
    <p>
        <asp:Label ID="PasswordLabelRegister" runat="server" AssociatedControlID="PasswordRegisterBox">Password  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:</asp:Label>
        <asp:TextBox ID="PasswordRegisterBox" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="PasswordRegisterBox" 
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    *</p>
    <p>
        <asp:Label ID="PasswordLabelRegister2" runat="server" AssociatedControlID="PasswordRegisterBox2">Confirm Password &nbsp:</asp:Label>
        <asp:TextBox ID="PasswordRegisterBox2" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordRegisterBox2" 
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    *</p>
    <p>
        <asp:Button ID="RegisterButton" runat="server" Text="REGISTER" OnClick="registerClick" />
    </p>
</asp:Content>
