using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class users_Show1Worker : System.Web.UI.Page
{
    string wrk;
    protected void Page_Load(object sender, EventArgs e)
    {
        wrk = Request["id"];
        if (!Page.IsPostBack && Request["id"] != null)
        {
            LabelID.Text = Workers.Get1Worker(wrk).GetWorkerId().ToString();
            LabelName.Text = Workers.Get1Worker(wrk).GetWorkerName();
            LabelPhone.Text = Workers.Get1Worker(wrk).GetWorkerPhone();
            LabelPosition.Text = AssistiveMethods.GetTafkedNameById(Workers.Get1Worker(wrk).GetWorkerPosition());
            LabelVehicle.Text = AssistiveMethods.GetVehicleNameById(Workers.Get1Worker(wrk).GetWorkerVehicle());
            imageForWorker.ImageUrl = "/MahdeMaster/Images/" + (Workers.Get1Worker(wrk).GetPicture());

            LabelLocation.Text = AssistiveMethods.GetYeshovNameById(Workers.Get1Worker(wrk).GetWorkerLocation().ToString());
            if (Session["adminAccess"] == "yes")
            {
                Update.Attributes.Add("onClick", "javascript:alert('Successfully Updated');"); // HERE WOULD BE THE UPDATE MSG
                tblAdmin.Visible = true;
                Update.Visible = true;
                PositionsDropDown.DataSource = AssistiveMethods.GetAllPositions2();
                PositionsDropDown.DataTextField = "TafkedName";
                PositionsDropDown.DataValueField = "idTafked";
                PositionsDropDown.DataBind();

                VehiclesDropDown.DataSource = AssistiveMethods.GetAllVehicles();
                VehiclesDropDown.DataTextField = "TransportName";
                VehiclesDropDown.DataValueField = "idTransport";
                VehiclesDropDown.DataBind();

                LocationsDropDown.DataSource = AssistiveMethods.GetAllLocations();
                LocationsDropDown.DataTextField = "LocationName";
                LocationsDropDown.DataValueField = "idLocation";
                LocationsDropDown.DataBind();

                NewNameTextBox.Text = Workers.Get1Worker(wrk).GetWorkerName();
                NewPhoneTextBox.Text = Workers.Get1Worker(wrk).GetWorkerPhone();


                for (int i = 0; i < PositionsDropDown.Items.Count; i++)
                {
                    if (int.Parse(PositionsDropDown.Items[i].Value) == Workers.Get1Worker(wrk).GetWorkerPosition())
                        PositionsDropDown.SelectedIndex = i;
                }

                for (int i = 0; i < VehiclesDropDown.Items.Count; i++)
                {
                    if (int.Parse(VehiclesDropDown.Items[i].Value) == Workers.Get1Worker(wrk).GetWorkerVehicle())
                        VehiclesDropDown.SelectedIndex = i;
                }

                for (int i = 0; i < LocationsDropDown.Items.Count; i++)
                {
                    if (int.Parse(LocationsDropDown.Items[i].Value) == Workers.Get1Worker(wrk).GetWorkerLocation())
                        LocationsDropDown.SelectedIndex = i;
                }
                
            }
        }
    }
    protected void ordersShow_Click(object sender, EventArgs e)
    {
        dataGridForEachWorker.DataSource = Orders.GetOrdersByWorkerInvolved(wrk);
        dataGridForEachWorker.DataBind();
        if (Orders.GetOrdersByWorkerInvolved(wrk).Tables[0].Rows.Count == 0)
        {
            dataGridForEachWorker.Visible = false;
            Label1.Visible = true;
            Label1.Text = "There are no orders made by this customer";
        }
        else
        {
            dataGridForEachWorker.Visible = true;
            Label1.Visible = false;
        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {

        Worker workerIsUpdating = Workers.Get1Worker(wrk);

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
        ////////////////////////////////////////////////////////////////
        /////////////// DONT FORGET USING SYSTEM.IO ////////////////////
        ////////////////////////////////////////////////////////////////

        //-------------------------------
        string pic = strFileName;
        //---------------------------------------------------------------------------

        workerIsUpdating.SetWorkerName(NewNameTextBox.Text.Trim());
        workerIsUpdating.SetWorkerPhone(NewPhoneTextBox.Text.Trim());
        workerIsUpdating.SetWorkerPosition(int.Parse(PositionsDropDown.SelectedValue));
        workerIsUpdating.SetWorkerVehicle(int.Parse(VehiclesDropDown.SelectedValue));
        workerIsUpdating.SetWorkerLocation(int.Parse(LocationsDropDown.SelectedValue));
        if (pic == null || pic == "")
        {
            workerIsUpdating.SetPicture(workerIsUpdating.GetPicture());
        }
        else
        {
            workerIsUpdating.SetPicture(pic);
        }
        

        Workers.Update1Worker(workerIsUpdating);
        Response.Redirect("../users/Show1Worker.aspx?id=" + wrk);
    }
}