using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    localhost.WebService srv;
    protected void Page_Load(object sender, EventArgs e)
    {
        string userID;
        if (Session["loggedIn"] == "yes")
        {
            profilePanel.Visible = true;
            userID = (string)(Session["id"]);
            Costumer temporaryCostumer = Costumers.Get1Costumer(userID);
            userName.Text = ""+ userName.Text.ToString() + temporaryCostumer.GetCostumerName();
            phoneNumber.Text = "" + phoneNumber.Text.ToString() + temporaryCostumer.GetPhoneNumber();
            email.Text = "" + email.Text.ToString() + temporaryCostumer.GetEmail() + ".";
            location.Text = "" + location.Text.ToString() + AssistiveMethods.GetYeshovNameById(temporaryCostumer.GetCostumerLocation());
            if (temporaryCostumer.GetPicture() != null)
                userPicture.ImageUrl = "~/images/" + temporaryCostumer.GetPicture();
            else
            {
                userPicture.ImageUrl = "~/images/NoPicture.png";
            }

        }
        if (Session["adminAccess"] == "yes")
        {
            adminPanel.Visible = true;
        }

        if (!Page.IsPostBack)
        {
            if (Session["adminAccess"] == "yes")
            {
                adminTable.Visible = true;
            }
        }

    }

}
