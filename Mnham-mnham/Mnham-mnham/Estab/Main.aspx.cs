using Mnham_mnham.Security;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mnham_mnham.Estab
{
    public partial class MainEstab : System.Web.UI.Page
    {
        protected TextBox TextBoxItem;
        protected TextBox TextBoxPrice;
        protected FileUpload FileUploadImage;
        protected ImageFormat FileFormat;


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UpdateCache(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Write to DB then
                List<ItemOnMenu> E = (List<ItemOnMenu>)Session["Items"];
                E.Add(new ItemOnMenu(TextBoxItem.Text, TextBoxPrice.Text, FileUploadImage.FileContent, FileFormat));
            }
            else
            {
                Response.Write("Preenchimento Inválido");
                Response.StatusCode = 200;
            }
        }

        protected void ForgetRequest(object sender, EventArgs e)
        {
            Response.Redirect("/Estab/Main");
        }

        protected void ValidateImage(object sender, ServerValidateEventArgs e)
        {
            FileUpload f=(FileUpload)((object)e.Value);
            e.IsValid =
                FileUploadValidator.FileIsWebFriendlyImage(f.FileContent, 2000000, out FileFormat);            
        }

        protected void LogoutEstablishment(object sender, EventArgs e)
        {

            //Trash Current Session
            Session.Abandon();
            //Logout somehow
        }
    }
}