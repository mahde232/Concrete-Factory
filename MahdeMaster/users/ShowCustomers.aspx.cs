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

public partial class ShowCustomers : System.Web.UI.Page
{
    //DBConnection dbCon;
    protected void Page_Load(object sender, EventArgs e)
    {
        // dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));

        if ((string)Session["loggedIn"] == "yes" && (string)Session["adminAccess"] == "yes")
        {
            AddCustomer.Visible = true;
        }



        string st = "";
        for (char i = 'a'; i <= 'z'; i++)
            st = st + "<a href='ShowCustomers.aspx?ot=" + i + "'>" + i + "</a> ";
        labelLetters.Text = st;

        if (Request["ot"] != null && Costumers.GetAllCostumersByLetter(Request["ot"]).Tables[0].Rows.Count != 0)
        {
            DataGrid1.DataSource = Costumers.GetAllCostumersByLetter(Request["ot"]);
            DataGrid1.DataBind();
            DataGrid1.Visible = true;
        }
        if (Costumers.GetAllCostumersByLetter(Request["ot"]).Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = false;
            labelErrorCode.Visible = true;
            labelErrorCode.Text = "There are no costumers that falls under this specific letter";
        }
        if (!Page.IsPostBack)
        {
            //DataSet dsForListBox = dbCon.RunDataSetSQL("select * from Costumer order by CostumerName");
            //ListBox1.DataSource = dsForListBox;

            ListBox1.DataSource = Costumers.GetAllCostumers();
            ListBox1.DataTextField = "CostumerName";
            ListBox1.DataValueField = "idCostumer";
            ListBox1.DataBind();
            DataGrid1.Visible = true;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Costumer order by CostumerName");
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Costumers.GetAllCostumers();
        DataGrid1.DataBind();
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Costumer where idCostumer=" + ListBox1.SelectedValue);
        //DataGrid1.DataSource = ds;

        DataGrid1.DataSource = Costumers.Get1CostumerDataSet(ListBox1.SelectedValue);
        DataGrid1.DataBind();
        // if (ds.Tables[0].Rows.Count == 0)
        // {
        //     DataGrid1.Visible = false;
        // }
        // else
        // {
        //    DataGrid1.Visible = true;
        //}
        hyperLink.NavigateUrl = "Show1Customer.aspx?id=" + ListBox1.SelectedValue;
        hyperLink.Visible = true;
        DataGrid1.Visible = true;
    }
    //public string GetYeshovNameById(object yshvdNum)
    //{
    //    dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));
    //    string yshv = yshvdNum.ToString();
    //    DataSet dsTm = dbCon.RunDataSetSQL("select * from Locations where idLocation=" + yshv);
    //    return (string)dsTm.Tables[0].Rows[0]["LocationName"];
    //}
    protected void AddCustomer_Click(object sender, EventArgs e)
    {
        if ((string)Session["adminAccess"] == "yes")
        {
            Response.Redirect("~/admin/Add1Customer.aspx");
        }
        else
        {
            Response.Redirect("~/users/forbidden.aspx");
        }
    }
}