using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminLogin : System.Web.UI.Page
{
    DBConnection DBConn;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBConn = new DBConnection(Server.MapPath("~/App_Data/woodProject.accdb"));

        if (Request["what"] == "logoff")
        {
            Session["mutar"] = "";
            Response.Redirect("../default.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dsAdmin = DBConn.RunDataSetSQL("select * from tblAdmin where user='" + TextBox1.Text + "' and pass='" + Request["Password1"] + "'");
        if (dsAdmin.Tables[0].Rows.Count == 1)
        {
            Session["mutar"] = "ok";   // חשוב! זה ילווה אותנו כל הזמן...
            Label1.Visible = false;
        }
        else
        {
            Label1.Visible = true;
        }

        if ((string)Session["mutar"] == "ok") Response.Redirect("../admin/adminOptions.aspx");
    }
}