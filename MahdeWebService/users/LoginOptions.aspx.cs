using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_LoginOptions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["mutar"] == "ok")
        {
            Response.Redirect("../admin/adminOptions.aspx");
        }
    }

    protected void GoToRegister(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void LogInCheck(object sender, EventArgs e)
    {
        DataSet ds = costumerS.GetAllUsersByUserName(UserNameT.Text);
        if (ds.Tables[0].Rows.Count != 1)
        {
            error.Text =" שם משתמש או סיסמה שגואים !  נסה שוב";
            error.Visible = true;
        }
        else
        {
            if (PassWordT.Text == ds.Tables[0].Rows[0]["password"].ToString())
            {
                LogingInChecking.Visible = false;
                error.Visible = false;
                loginOptions.Visible = true;
                Session["user"] = UserNameT.Text;
                Session["userId"] = ds.Tables[0].Rows[0]["idCostumer"].ToString();
            }
        }
    }

    protected string ConvertIdWorker(object sender)
    {
        DataSet workerName = workerS.ConvertIdWorker(sender);
        return workerName.Tables[0].Rows[0][0].ToString();
    }

    protected void MyHistoryM(object sender, EventArgs e)
    {
        Response.Redirect("costumerDeals.aspx?idKone=" + Session["userId"]);
    }

    protected void MyCartM(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
}