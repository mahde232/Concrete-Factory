using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["adminAccess"] = null;
            Session["loggedIn"] = null;
            Response.Write("@<script language='javascript'>alert('You have successfully logged out!');</script>");
            Response.Redirect("/MahdeMaster/Default.aspx");
            //Response.Write(@"<script language='javascript'>confirm('Are you sure you want to logout ?');</script>");
            //string response = (@"<script language='javascript'>confirm('Are you sure you want to logout ?');</script>");
        }
    }
}