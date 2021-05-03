using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Add1Order : System.Web.UI.Page
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

            costumersDropDown.DataSource = Costumers.GetAllCostumers();
            costumersDropDown.DataTextField = "CostumerName";
            costumersDropDown.DataValueField = "idCostumer";
            costumersDropDown.DataBind();

            OrderTypeDropDown.DataSource = Products.GetAllProducts();
            OrderTypeDropDown.DataTextField = "ProductName";
            OrderTypeDropDown.DataValueField = "idProduct";
            OrderTypeDropDown.DataBind();

            WorkersDropDown.DataSource = Workers.GetAllWorkers();
            WorkersDropDown.DataTextField = "OvedName";
            WorkersDropDown.DataValueField = "idOved";
            WorkersDropDown.DataBind();
        }
    }
    protected void AddOrderButton_Click(object sender, EventArgs e)
    {
        Order ordr = new Order(0, costumersDropDown.SelectedValue.ToString(), new DateTime(int.Parse(DateYearTextBox.Text), int.Parse(DateMonthTextBox.Text), int.Parse(DateDayTextBox.Text)), OrderTypeDropDown.SelectedValue, double.Parse(AmountTextBox.Text), double.Parse(ActualPriceTextBox.Text), LocationsDropDown.SelectedValue, WorkersDropDown.SelectedValue);
        Orders.Add1Order(ordr);
        SuccessLabel.Visible = true;
        SuccessLabel.Text = "You've successfully added a new registered costumer";
    }
}