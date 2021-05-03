using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminDeals : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            customerD.DataSource = costumerS.GetAllCostumers();
            customerD.DataTextField = "costumerName";
            customerD.DataValueField = "idCostumer";
            customerD.DataBind();

            for (int i = 1; i <= 31; i++)
            {
                ListItem item = new ListItem("" + i, "" + i);

                if (i < 10)
                {
                    item.Text = "0" + i;
                    dayDDL.Items.Add(item);
                    monthDDL.Items.Add(item);
                }

                if (i > 9 && i < 13)
                {
                    dayDDL.Items.Add(item);
                    monthDDL.Items.Add(item);
                }

                if (i > 12)
                    dayDDL.Items.Add(item);

            }

            for (int i = 2010; i < 2016; i++)
            {
                yearDDL.Items.Add(new ListItem("" + i, "" + i));
            }

            if (Request["idKone"] != "" && Request["idKone"] != null)
            {
                ds = Deals.GetDealsByCostumer(Request["idKone"]);
                dataGrid1.Visible = true;

                dataGrid1.DataSource = ds;
                dataGrid1.DataBind();

                DataSet dealDetails = dealDetailsS.GetDealDetails(Request["idDeal"]);
                dataGrid2.DataSource = dealDetails;
                dataGrid2.DataBind();

                dataGrid2.Visible = true;

            }
            NoResults.Visible = false;
        }
        else
        {
            dataGrid1.Visible = true;
            dataGrid2.Visible = false;
        }
        dataGrid1.DataSource = ds;
        dataGrid1.DataBind();
    }

    protected void SearchDate(object sender, EventArgs e)
    {
        int d = int.Parse(dayDDL.Items[dayDDL.SelectedIndex].Text.ToString());
        int m = int.Parse(monthDDL.Items[monthDDL.SelectedIndex].Text.ToString());
        int y = int.Parse(yearDDL.Items[yearDDL.SelectedIndex].Text.ToString());

        DateTime date = new DateTime(y, m, d);

        dataGrid1.DataSource = Deals.GetDealByDate(date);
        dataGrid1.DataBind();

        if (Deals.GetDealByDate(date).Tables[0].Rows.Count == 0)
        {
            dataGrid1.Visible = false;
            NoResults.Visible = true;
        }
        else
            dataGrid1.Visible = true;
    }

    protected string ConvertIdWorker(object sender)
    {
        DataSet workerName = workerS.ConvertIdWorker(sender);
        return workerName.Tables[0].Rows[0][0].ToString();
    }
    protected string ConvertIdCostumer(object sender)
    {
        DataSet costumerName = costumerS.ConvertIdCostumer(sender);
        return costumerName.Tables[0].Rows[0][0].ToString();
    }

    protected void SearchCustomer(object sender, EventArgs e)
    {
        NoResults.Visible = false;

        dataGrid1.DataSource = Deals.GetDealsByCostumer(customerD.Items[customerD.SelectedIndex].Value);
        dataGrid1.DataBind();

        if ((Deals.GetDealsByCostumer(customerD.Items[customerD.SelectedIndex].Value).Tables[0].Rows.Count == 0))
        {
            dataGrid1.Visible = false;
            NoResults.Visible = true;
        }
        else
            dataGrid1.Visible = true;
    }

    protected void SearchCustomerandDate(object sender, EventArgs e)
    {
        NoResults.Visible = false;

        int d = int.Parse(dayDDL.Items[dayDDL.SelectedIndex].Text.ToString());
        int m = int.Parse(monthDDL.Items[monthDDL.SelectedIndex].Text.ToString());
        int y = int.Parse(yearDDL.Items[yearDDL.SelectedIndex].Text.ToString());

        DateTime date = new DateTime(y, m, d);

        dataGrid1.DataSource = Deals.GetDealByDateAndCustomer(date, customerD.Items[customerD.SelectedIndex].Value);
        dataGrid1.DataBind();

        if (Deals.GetDealByDateAndCustomer(date, customerD.Items[customerD.SelectedIndex].Value).Tables[0].Rows.Count == 0)
        {
            dataGrid1.Visible = false;
            NoResults.Visible = true;
        }
    }

    protected void ReturnToAdmin(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminOptions.aspx");
    }
}