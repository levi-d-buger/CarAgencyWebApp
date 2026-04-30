using System;
using System.Web.UI;

namespace CarAgencyWebApp
{
    public partial class SelectRole : Page
    {
        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Session["Role"] = "Customer";
            Response.Redirect("Default.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Session["Role"] = "Admin";
            Response.Redirect("Default.aspx");
        }
    }
}