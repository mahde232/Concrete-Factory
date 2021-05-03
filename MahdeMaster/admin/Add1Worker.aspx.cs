using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Add1Worker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminAccess"] != "yes")
            Response.Redirect("~/users/forbidden.aspx");
        else
        {

            TafkedemDropDown.DataSource = AssistiveMethods.GetAllPositions2();
            TafkedemDropDown.DataTextField = "TafkedName";
            TafkedemDropDown.DataValueField = "idTafked";
            TafkedemDropDown.DataBind();
            LocationsDropDown.DataSource = AssistiveMethods.GetAllLocations();
            LocationsDropDown.DataTextField = "LocationName";
            LocationsDropDown.DataValueField = "idLocation";
            LocationsDropDown.DataBind();



        }
    }
    protected void AddWorkerButton_Click(object sender, EventArgs e)
    {
        Worker wrkr = new Worker(0, NameTextBox.Text, PhoneTextBox.Text, int.Parse(TafkedemDropDown.SelectedValue.ToString()), 1, int.Parse(LocationsDropDown.SelectedValue.ToString()), "NoPicture.png", SpecialIDTextBox.Text, LoginPassTextBox.Text);
        Workers.Add1Worker(wrkr);
        SuccessLabel.Visible = true;
        SuccessLabel.Text = "You've successfully added a new registered worker";
    }
}