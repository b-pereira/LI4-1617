using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mnham_mnham.Client
{
    public partial class MainClient : System.Web.UI.Page
    {
        protected List<Item> pedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            MM.AreaCliente a = (MM.AreaCliente)Session["ClientArea"];
            if(a==null)
            {
                Session["ClientArea"] = new MM.AreaCliente();
            }
            Context.User = (GenericPrincipal)Session["User"];
            if (User != null && !User.IsInRole("Client"))
            {
                Session["User"] = Application["Logout"];
                Context.User = (GenericPrincipal)Session["User"];
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Business.Iguaria> DvQuery_GetData()
        {
            return pedido.AsQueryable();
        }
    }
}