using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class users_Show1Customer : System.Web.UI.Page
{
    string cstm;
    protected void Page_Load(object sender, EventArgs e)
    {
        cstm = Request["id"];
        if (!Page.IsPostBack && Request["id"]!=null)
        {
            LabelID.Text = Costumers.Get1Costumer(cstm).GetCostumerId().ToString();
            LabelName.Text = Costumers.Get1Costumer(cstm).GetCostumerName();
            LabelPhone.Text = Costumers.Get1Costumer(cstm).GetPhoneNumber();
            LabelEmail.Text = Costumers.Get1Costumer(cstm).GetEmail();
            imageForCustomer.ImageUrl = "/MahdeMaster/Images/"+(Costumers.Get1Costumer(cstm).GetPicture());

            LabelLocation.Text = AssistiveMethods.GetYeshovNameById(Costumers.Get1Costumer(cstm).GetCostumerLocation().ToString());

            if (Session["adminAccess"] == "yes")
            {
                adminTbl.Visible = true;
                Update.Visible = true;

                LocationsDropDown.DataSource = AssistiveMethods.GetAllLocations();
                LocationsDropDown.DataTextField = "LocationName";
                LocationsDropDown.DataValueField = "idLocation";
                LocationsDropDown.SelectedValue = ""+Costumers.Get1Costumer(cstm).GetCostumerLocation();
                LocationsDropDown.DataBind();

                NewNameTextBox.Text = Costumers.Get1Costumer(cstm).GetCostumerName().ToString();
                NewPhoneTextBox.Text = Costumers.Get1Costumer(cstm).GetPhoneNumber().ToString();
                NewEmailTextBox.Text = Costumers.Get1Costumer(cstm).GetEmail().ToString();

                for (int i = 0; i < LocationsDropDown.Items.Count; i++)
                {
                    if (int.Parse(LocationsDropDown.Items[i].Value) == Costumers.Get1Costumer(cstm).GetCostumerLocation())
                        LocationsDropDown.SelectedIndex = i;
                }




                Update.Attributes.Add("onClick", "javascript:alert('Successfully Updated');"); // HERE WOULD BE THE UPDATE MSG
            }

        }
    }
    protected void ordersShow_Click(object sender, EventArgs e)
    {
        dataGridForEachCustomer.DataSource = Orders.GetSpecificOrder(cstm);
        dataGridForEachCustomer.DataBind();
        if (Orders.GetSpecificOrder(cstm).Tables[0].Rows.Count == 0)
        {
            dataGridForEachCustomer.Visible = false;
            Label1.Visible = true;
            Label1.Text = "There are no orders made by this customer";
        }
        else
        {
            dataGridForEachCustomer.Visible = true;
            Label1.Visible = false;
        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        Costumer costumerIsUpdating=Costumers.Get1Costumer(cstm);

        costumerIsUpdating.SetCostumerName(NewNameTextBox.Text.Trim());
        costumerIsUpdating.SetPhoneNumber(NewPhoneTextBox.Text.Trim());
        costumerIsUpdating.SetEmail(NewEmailTextBox.Text.Trim());
        costumerIsUpdating.SetCostumerLocation(int.Parse(LocationsDropDown.Items[LocationsDropDown.SelectedIndex].Value));
        
        //-------------------------------

        //pictures

        string strBaseDir, strFileName = "";
        FileUpload fu = (FileUpload)PictureUpload;
        //Has the file been uploaded properly?
        if (!(fu.PostedFile == null))
        {
            //Save the file if it has a filename and exists...
            if (fu.PostedFile.FileName.Trim().Length > 0 &&
               fu.PostedFile.ContentLength > 0)
            {
                strBaseDir = Server.MapPath("~/images/");

                strFileName =
                   Path.GetFileName(fu.PostedFile.FileName);
                fu.PostedFile.SaveAs(strBaseDir + strFileName);
            }
        }
        //

        //-------------------------------
        string pic = strFileName;
        if (pic == null || pic == "")
        {
            costumerIsUpdating.SetPicture(costumerIsUpdating.GetPicture());
        }
        else
        {
            costumerIsUpdating.SetPicture(pic);
        }
        Costumers.Update1Customer(costumerIsUpdating);
        Response.Redirect("../users/Show1Customer.aspx?id=" + cstm);
    }
}