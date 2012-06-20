<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UbahPassword.aspx.cs" Inherits="NCBasp.UbahPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
    <asp:Label ID="UbahPassLabel" runat="server" >Current Password &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp : &nbsp </asp:Label>
    <asp:TextBox ID="UbahPassBox" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Label ID="UbahPassLabel1" runat="server" >New Password &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  : &nbsp </asp:Label>
    <asp:TextBox ID="UbahPassBox2" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Label ID="UbahPassLabel2" runat="server" >Confirm New Password &nbsp&nbsp&nbsp&nbsp : &nbsp </asp:Label>
    <asp:TextBox ID="UbahPassBox3" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Status" runat="server" />
</p>
<p>
    <asp:Button ID="UbahPassButton" runat="server" Text="LOGIN" OnClick="loginClick" />
</p>
</asp:Content>
