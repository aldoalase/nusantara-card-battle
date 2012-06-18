<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LastBattle.aspx.cs" Inherits="NCBasp.LastBattle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="kotak1">
    <p><asp:Label ID="LabelUsername" runat="server" Text="User Name" />&nbsp : &nbsp <asp:Label ID="UserName" runat="server" /> </p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</div>
</asp:Content>
