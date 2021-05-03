using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class users_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedIn"] == "yes")
        {
            ErrorLabel.Visible = false;
            ErrorLabel2.Visible = true;
            ErrorLabel2.Text = "You're already logged in.";
            tbl.Visible = false;
            LoginButton.Visible = false;
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (AssistiveMethods.CheckValidUsername(UsernameTextBox.Text.Trim()) == true)
        {
            if (PasswordTextBox.Text.Trim() == Costumers.LoginDetails(UsernameTextBox.Text.Trim()).Tables[0].Rows[0][7].ToString())
            {
                ErrorLabel.Visible = false;
                ErrorLabel2.Visible = true;
                ContinueButton.Visible = true;
                SuccessfulLoginLabel.Visible = true;
                SuccessfulLoginLabel.Text = "You have successfully logged in";
                LoginButton.Visible = false;
                Session["loggedIn"] = "yes";
                Session["id"] = Costumers.LoginDetails(UsernameTextBox.Text.Trim()).Tables[0].Rows[0][0].ToString();
                if (UsernameTextBox.Text.Trim() == "mahde232" || UsernameTextBox.Text.Trim() == "Mahde232")
                    Session["adminAccess"] = "yes";
            }
            else
            {
                ErrorLabel.Text = "Username or Password are incorrect.";
                ErrorLabel.Visible = true;
            }
        }
        else
        {
            ErrorLabel.Text = "Username or Password are incorrect.";
            ErrorLabel.Visible = true;
        }
    }
    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}