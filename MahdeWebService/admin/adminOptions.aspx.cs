using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminOptions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UpdateItems(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminItems.aspx");
    }
    protected void UpdateWorkers(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminWorkers.aspx");
    }
    protected void UpdateDeals(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminDeals.aspx");
    }
    protected void UpdateCustomers(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminCustomer.aspx");
    }
}