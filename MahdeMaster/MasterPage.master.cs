using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LogoutButton.Attributes.Add("On_Click", "confirmation()");
        if (!Page.IsPostBack)
        {
            LogoutButton.Attributes.Add("On_Click", "confirmation()");
            
            if (Session["adminAccess"] == "yes")
            {
                adminStateLabel.Visible = true;
                adminStateLabel.Text = adminStateLabel.Text + "Enabled!";
            }
        }

        //if (Session["adminAccess"] == "yes")
        //{
        //    adminStateLabel.Visible = true;
        //    adminStateLabel.Text = adminStateLabel.Text + "Enabled!";
        //}
    }
    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MahdeMaster/users/logout.aspx");
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MahdeMaster/users/LoginPage.aspx");
    }

}
