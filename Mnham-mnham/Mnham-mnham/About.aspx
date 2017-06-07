<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Mnham_mnham.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <h2><%: Title %>.</h2>
        <h3>Mnham-Mnham is a web-based food recomendation app.</h3>
        <p>Add your company or register now to reap the benefits.</p>
    </div>
</asp:Content>

<asp:Content ID="Sidebar" ContentPlaceHolderID="SideBarContent" runat="server">
    <li class="sidebar-brand">
        <a class="navbar-brand" runat="server" href="~/"><i class="fa fa-pull-left fa-2x fa-home"></i>Home</a>
    </li>
    <li>
        <a runat="server" href="~/About"><i class="fa fa-pull-left fa-2x fa-id-card"></i>About</a>
    </li>
    <li>
        <a runat="server" href="~/Contact"><i class="fa fa-pull-left fa-2x fa-address-book"></i>Contact</a>
    </li>
    <li>
        <a runat="server" href="~/Client/Main"><i class="fa fa-pull-left fa-2x fa-cutlery"></i>Mnham-Mnham</a>
    </li>
    <li>
        <a runat="server" href="~/Account/Login"><i class="fa fa-pull-left fa-2x fa-cubes"></i>Companies</a>
    </li>

</asp:Content>

