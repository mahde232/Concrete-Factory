using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Add1Customer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminAccess"] != "yes")
            Response.Redirect("~/users/forbidden.aspx");
        else
        {
            LocationsDropDown.DataSource = AssistiveMethods.GetAllLocations();
            LocationsDropDown.DataTextField = "LocationName";
            LocationsDropDown.DataValueField = "idLocation";
            LocationsDropDown.DataBind();
        }
    }
    protected void AddCostumerButton_Click(object sender, EventArgs e)
    {
        Costumer cstmr = new Costumer(0, NameTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, int.Parse(LocationsDropDown.SelectedValue.ToString()), "NoPicture.png", SpecialIDTextBox.Text, LoginPassTextBox.Text);
        Costumers.Add1Costumer(cstmr);
        SuccessLabel.Visible = true;
        SuccessLabel.Text = "You've successfully added a new registered costumer";
    }
}