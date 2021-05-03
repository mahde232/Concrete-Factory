using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Show1Product : System.Web.UI.Page
{
    string prdct;
    protected void Page_Load(object sender, EventArgs e)
    {
        prdct = Request["id"];
        if (!Page.IsPostBack && Request["id"] != null)
        {
            LabelID.Text = Products.Get1Product(prdct).GetProductId().ToString();
            LabelName.Text = Products.Get1Product(prdct).GetProductName().ToString();
            LabelPrice.Text = Products.Get1Product(prdct).GetPricePerOne().ToString();
            if (Session["adminAccess"] == "yes")
            {
                Update.Attributes.Add("onClick", "javascript:alert('Successfully Updated');"); // HERE WOULD BE THE UPDATE MSG
                tblAdmin.Visible = true;
                Update.Visible = true;

                NewNameTextBox.Text = Products.Get1Product(prdct).GetProductName().ToString();
                NewPriceTextBox.Text = Products.Get1Product(prdct).GetPricePerOne().ToString();

            }
        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        Product productIsUpdating = Products.Get1Product(prdct);
        productIsUpdating.SetProductName(NewNameTextBox.Text.Trim());
        productIsUpdating.SetPricePerOne(double.Parse(NewPriceTextBox.Text.Trim()));
        Products.Update1Product(productIsUpdating);

        Response.Redirect("../users/Show1Product.aspx?id=" + prdct);
    }
}