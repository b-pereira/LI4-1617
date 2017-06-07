<%@ Page Title="Mnham-Mnham" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mnham_mnham.Client.MainClient" %>


<asp:Content runat="server" ID="MainClientSidebar" ContentPlaceHolderID="SideBarContent">
    <li class="sidebar-brand">
        <a class="navbar-brand" runat="server" href="~/"><i class="fa fa-pull-left fa-2x fa-home"></i>Home</a>
    </li>
    <li>
        <a runat="server" href="~/Estab/Main"><i class="fa fa-pull-left fa-2x fa-plus"></i>Add Menu</a>
    </li>
    <li>
        <a runat="server" href="~/Estab/Edit"><i class="fa fa-pull-left fa-2x fa-edit"></i>Edit Menu</a>
    </li>
    <li>
        <a runat="server" href="~/Estab/Settings"><i class="fa fa-pull-left fa-2x fa-cog"></i>Settings</a>
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
<asp:Content runat="server" ID="MainEstab" ContentPlaceHolderID="MainContent">
    <div class="page-header row">
    <div class="col-sm-3">
    <i class="fa fa-5x fa-book" style="color: #ffffff"></i>
    </div>
    <div class="col-sm-6">
    <h2 class="fa fa-2x" style="color: #ffffff">Add a menu item</h2>
    </div>
    <div class="col-sm-3">
    </div>
    </div>
    <div class="row">
        <div class="col-sm-3">

        </div>
        <div class="col-sm-6">
            <div class="panel" style="background: rgba(255,255,255,0.3)">
                <p>Item</p>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="fa" Height="31px" Width="1200px"></asp:TextBox>
                <i class="fa fa-lg fa-edit"></i>
            </div>
            <div class="panel" style="background: rgba(255,255,255,0.3)">
                <p>Price</p>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="fa" Height="31px" Width="1200px"></asp:TextBox>
                <i class="fa fa-lg fa-edit"></i>
            </div>
            <div class="panel" style="background: rgba(255,255,255,0.3)">
                <p class="fa">Image</p>
                <i class="fa fa-lg fa-file-image-o"></i>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn fa" />
            </div>
            <div class="panel" style="background: rgba(255,255,255,0.3)">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg fa fa-2x fa-check" Text="Submit"></asp:Button>
            </div>
            <div class="panel" style="background: rgba(255,255,255,0.3)">
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg fa fa-2x fa-cross" Text="Cancel"></asp:Button>
            </div>
         </div>
    </div>

</asp:Content>
