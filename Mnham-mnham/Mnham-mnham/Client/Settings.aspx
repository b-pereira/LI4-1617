﻿<%@ Page Title="Mnham-Mnham" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mnham_mnham.Client.MainClient" %>


<asp:Content runat="server" ID="MainClientSidebar" ContentPlaceHolderID="SideBarContent">
    <li class="sidebar-brand">
        <a class="navbar-brand" runat="server" href="~/"><i class="fa fa-pull-left fa-2x fa-home">
        </i>Home</a>
    </li>
   <li>
        <a runat="server" href="~/Client/Preferences"><i class="fa fa-pull-left fa-2x fa-heart"></i>Preferences</a>
    </li>
    <%--<asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <li><a runat="server" href="~/Account/Register"><i class="fa fa-pull-left fa-2x fa-group"></i>Register</a></li>
            <li><a runat="server" href="~/Account/Login"><i class="fa fa-pull-left fa-2x fa-laptop"></i>Log in</a></li>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <li><a runat="server" href="~/Account/Manage" title="Manage your account"><i class="fa fa-pull-left fa-2x fa-cog">Hello, <%: Context.User.Identity.GetUserName()  %> !</a></li>
            <li>
                <i class="fa fa-pull-left fa-2x fa-power-off">
                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" /></li>
        </LoggedInTemplate>
    </asp:LoginView> --%>

</asp:Content>

<asp:Content runat="server" ID="MainContentClient" ContentPlaceHolderID="MainContent">
    <div class="panel panel-default">
        <p>Name</p>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="fa" Height="31px" Width="600px"></asp:TextBox>        
        <i class="fa fa-lg fa-edit"></i>
    </div >
    <div class="panel panel-default">
        <p>Email</p>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="fa" Height="31px" Width="600px"></asp:TextBox>
        <i class="fa fa-lg fa-edit"></i>
    </div>
    <div class="panel panel-default">
        <p>Password</p>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="fa" Height="31px" Width="600px"></asp:TextBox>
        <i class="fa fa-lg fa-edit"></i>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Remove Account" CssClass="btn-danger btn" />        
    </div>
</asp:Content>
