<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mnham_mnham._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row jumbotron">
        <h1>Mnham-Mnham</h1>
        <p class="lead">Mnham-Mnham is a food recommendation service. 
            Register and begin querying whatever food comes to mind and recommendations and directions will be provided for you.</p>
        <p><a href="~/Account/Register" class="btn btn-default">Register now &raquo;</a></p>
    </div>

    <div class="row jumbotron">
        <div class="col-md-5">
            <h2>For companies</h2>
            <p>
                Mnham-Mnham relies on information submitted directly by you, the company. Register your company and provide us with your contact information
                and menus and be recommended.
            </p>
            <p>
                <a class="btn btn-default" href="~/Account/Register">Register now &raquo;</a>
            </p>
        </div>
        <div class="col-md-2">
        </div>
        <div class="col-md-5">
            <h2>Contacts</h2>
            <p>
                Reach out to us through our contacts anytime.
            </p>
            <p>
                <a class="btn btn-default" href="~/Contact">Contact us &raquo;</a>
            </p>
        </div>
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
