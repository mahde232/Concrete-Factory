using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Data;
//using System.Data.OleDb;

public partial class ShowWorkers : System.Web.UI.Page
{
    //DBConnection dbCon;
    protected void Page_Load(object sender, EventArgs e)
    {
        //dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));

        if ((string)Session["loggedIn"] == "yes" && (string)Session["adminAccess"] == "yes")
        {
            AddWorker.Visible = true;
        }




        if (!Page.IsPostBack)
        {
            //DataSet dsForListBox = dbCon.RunDataSetSQL("select * from Ovdem order by OvedName");
            //ListBox1.DataSource = dsForListBox;
            ListBox1.DataSource = Workers.GetAllWorkers();
            ListBox1.DataTextField = "OvedName";
            ListBox1.DataValueField = "idOved";
            ListBox1.DataBind();
            ListBoxLocations.DataSource = AssistiveMethods.GetAllLocations();
            ListBoxLocations.DataTextField = "LocationName";
            ListBoxLocations.DataValueField = "idLocation";
            ListBoxLocations.DataBind();
            DataGrid1.Visible = true;
            Label1.Visible = false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from OvdemInformationQ");
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Workers.GetAllWorkers();
        DataGrid1.DataBind();
    }
    //public string GetTafkedNameById(object tfkdNum)
    //{
    //    dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));
    //    string tfkd = tfkdNum.ToString();
    //    DataSet dsTm = dbCon.RunDataSetSQL("select * from Tafkedem where idTafked=" + tfkd);
    //    return (string)dsTm.Tables[0].Rows[0]["TafkedName"];
    //}
    //public string GetVehicleNameById(object vhcldNum)
    //{
    //    dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));
    //    string vhcl = vhcldNum.ToString();
    //    DataSet dsTm = dbCon.RunDataSetSQL("select * from Transport where idTransport=" + vhcl);
    //    return (string)dsTm.Tables[0].Rows[0]["TransportName"];
    //}
    //public string GetYeshovNameById(object yshvdNum)
    //{
    //    dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));
    //    string yshv = yshvdNum.ToString();
    //    DataSet dsTm = dbCon.RunDataSetSQL("select * from Locations where idLocation=" + yshv);
    //    return (string)dsTm.Tables[0].Rows[0]["LocationName"];
    //}
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Ovdem where idOved=" + ListBox1.SelectedValue);
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Workers.GetSpecificWorker("" + ListBox1.SelectedValue);
        DataGrid1.DataBind();
        hyperLink.NavigateUrl = "Show1Worker.aspx?id=" + ListBox1.SelectedValue;
        hyperLink.Visible = true;
    }
    protected void ListBoxLocations_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Ovdem where idOved=" + ListBox1.SelectedValue);
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Workers.GetWorkersFromSpecificLocation("" + ListBoxLocations.SelectedValue);
        DataGrid1.DataBind();
        if (Workers.GetWorkersFromSpecificLocation(ListBoxLocations.SelectedValue).Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = false;
            Label1.Visible = true;
            Label1.Text = "There are no workers from this location";
            hyperLink.Visible = false;
        }
        else
        {
            DataGrid1.Visible = true;
            Label1.Visible = false;
            hyperLink.Visible = false;
        }
    }
    protected void AddWorker_Click(object sender, EventArgs e)
    {
        if ((string)Session["adminAccess"] == "yes")
        {
            Response.Redirect("~/admin/Add1Worker.aspx");
        }
        else
        {
            Response.Redirect("~/users/forbidden.aspx");
        }
    }
}