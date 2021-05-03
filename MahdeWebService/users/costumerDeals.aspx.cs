using System.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_costumerDeals : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request["idKone"] != "" && Request["idKone"] != null)
            {
                ds = Deals.GetDealsByCostumer(Request["idKone"]);
                dataGrid1.Visible = true;

                dataGrid1.DataSource = ds;
                dataGrid1.DataBind();
                if (Request["idDeal"] != null && Request["idDeal"] != "")
                {
                    DataSet dealDetails = dealDetailsS.GetDealDetails(Request["idDeal"]);
                    dataGrid2.DataSource = dealDetails;
                    dataGrid2.DataBind();

                    dataGrid2.Visible = true;
                }

            }
        }
        else
        {
            if (Session["userId"] != null)
            {
                ds = Deals.GetDealsByCostumer(Session["userId"].ToString());
                dataGrid2.Visible = false;
            }
        }
        dataGrid1.DataSource = ds;
        dataGrid1.DataBind();
    }

    protected string ConvertIdWorker(object sender)
    {
        DataSet workerName = workerS.ConvertIdWorker(sender);
        return workerName.Tables[0].Rows[0][0].ToString();

    }
}