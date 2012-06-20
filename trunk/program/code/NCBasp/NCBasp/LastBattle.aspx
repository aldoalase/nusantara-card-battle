<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LastBattle.aspx.cs" Inherits="NCBasp.LastBattle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="kotak1">
    <h1><asp:Label ID="LabelUsername" runat="server" Text="User Name" />&nbsp : &nbsp <asp:Label ID="UserName" runat="server" /> </h1>
    <h2><asp:Label ID="LabelLastBattle" runat="server" /></h2>
    <p><asp:Label ID="LabelNULL" runat="server" /></p>
    <p><asp:Label ID="Player1" runat="server" />&nbsp <asp:Label ID="LabelVS" runat="server" /> &nbsp <asp:Label ID="Player2" runat="server" /></p>
    <p><asp:Label ID="LabelWinner" runat="server" />&nbsp <asp:Label ID="LabelTitikDua" runat="server" /> &nbsp <asp:Label ID="Winner" runat="server" /></p>
    <p><asp:Label ID="LabelTime" runat="server" />&nbsp <asp:Label ID="LabelTitikDuaJuga" runat="server" /> &nbsp <asp:Label ID="Time" runat="server" /></p>
</div>
</asp:Content>
