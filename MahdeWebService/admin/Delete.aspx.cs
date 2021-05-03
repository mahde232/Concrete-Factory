using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["idRow"]!= null)
        {
            Days.DeleteDay(int.Parse(Request["idRow"]));
            Session["idRow"]=null;
            Response.Redirect("adminWorkers.aspx?worker="+Request["worker"]);
        }
    }
}