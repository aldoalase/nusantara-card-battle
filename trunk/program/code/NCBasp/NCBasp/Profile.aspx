<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NCBasp.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>Login Berhasil</p>
<div id="kotak1">
    <p><asp:Label ID="Label1" runat="server" Text="User Name" />&nbsp : &nbsp <asp:Label ID="UserName" runat="server" /> </p>
    <p><asp:Label ID="Label2" runat="server" Text="Player Win" />&nbsp : &nbsp <asp:Label ID="PlayerWin" runat="server" /> </p>
    <p><asp:Label ID="Label3" runat="server" Text="Player Lose" />&nbsp : &nbsp <asp:Label ID="PlayerLose" runat="server" /> </p>
    <p><asp:Label ID="Label4" runat="server" Text="Player Money" />&nbsp : &nbsp <asp:Label ID="PlayerMoney" runat="server" /> </p>
</div>
</asp:Content>
