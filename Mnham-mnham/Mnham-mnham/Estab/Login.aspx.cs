using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Mnham_mnham.Models;
using System.Security.Principal;

namespace Mnham_mnham.Estab
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] s = new string[2] { "Client", "Estab" };
            Context.User = new GenericPrincipal(new GenericIdentity("SUPER"), s);
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                AreaCliente a = (AreaCliente)Session["ClientArea"];

                if (a.Login(Email.Text, Password.Text))
                {
                    Response.Redirect("/Client/Main");
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
            }
        }
}