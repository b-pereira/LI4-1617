using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mnham_mnham.Estab
{
    public partial class Edit : System.Web.UI.Page
    {
        protected GridView gvMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Estab"))
            {
                Session["User"] = Application["Logout"];
                Context.User = (GenericPrincipal)Session["User"];
            }
            gvMenu = new GridView();
            if (Session["Items"] == null)
            {
                //Load from DB to Session
                Session["Items"] = new List<ItemOnMenu>();
            }
            List<ItemOnMenu> l = (List<ItemOnMenu>)Session["Items"];
            if(l!=null)
            {
                int index = 0;
                foreach (var item in l)
                {
                    item.ImgURL = "GetImg.ImgGetClient?id=" + index;
                    index++;
                }
                gvMenu.DataSource = l;
                gvMenu.DataBind();
            }
        }


    }
}