using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        orderCart.DataSource = ((Cart)(Session["cart"])).GetDT();
        orderCart.DataBind();

        costumer user = costumerS.GetOneCustomer(Session["userId"].ToString());
        Name.Text = user.GetName() + " בבקשה אשר את פרטי חשבונך";
        phone.Text = "מספר הפלפון שלך - " + user.GetTelephone();
        email.Text = "דואר אלקטרוני - " + user.GetEmail();
        address.Text = "כתובת - " + user.GetCountry() + ", " + user.GetCity() + ", " + user.GetAddress();

        totalCostLabel.Text = "מחיר עסקה - " + ((Cart)Page.Session["Cart"]).GetItemTotal();
    }

    protected string ConvertIdItem(object sender)
    {
        DataSet fullName = itemS.ConvertItemId(sender);
        return fullName.Tables[0].Rows[0][0].ToString();
    }

    protected void Order(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        thanks1.Visible = true;
        return1.Visible = true;

        Cart crt = (Cart)(Session["Cart"]);

        DateTime date = DateTime.Now.Date;
        int year = int.Parse(date.Date.Year.ToString()), month = int.Parse(date.Date.Month.ToString()), 
            day = int.Parse(date.Date.Day.ToString());

        double pay = (double)crt.GetItemTotal();

        deal deal = new deal(8, int.Parse(Session["userId"].ToString()), year, month, day);
        Deals.AddOneDeal(deal, (pay + ""), date);

        string st = Deals.GetMaxOrderId();
        Deals.AddOrderDetails(st, crt.GetDT());
    }

    protected void ReturnToCD(object sender, EventArgs e)
    {
        Response.Redirect("costumerDeals.aspx");
    }
}