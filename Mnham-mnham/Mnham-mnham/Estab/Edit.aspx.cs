using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Session["Items"] == null)
            {
                //Load from DB to Session
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

        protected void LogoutEstablishment(object sender, EventArgs e)
        {

            //Trash Current Session
            Session.Abandon();
            //Logout somehow
        }
    }
}