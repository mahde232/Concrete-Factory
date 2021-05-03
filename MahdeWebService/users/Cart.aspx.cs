using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class users_Cart : System.Web.UI.Page
{
    DataSet ds;
    Cart crt;
    string idProd, idProdPlus, idProdMinus, id;
    string cost, units;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //------ Dealing with items data
            DropDownList1.DataSource = itemS.GetAllItemsTypes();
            DropDownList1.DataTextField = "typeName";
            DropDownList1.DataValueField = "idType";
            DropDownList1.DataBind();

            DropDownList2.DataSource = itemS.GetAllItemsNames();
            DropDownList2.DataTextField = "itemName";
            DropDownList2.DataValueField = "idItemName";
            DropDownList2.DataBind();
            ds = itemS.GetAllItems();
        }
        else
        {
            ds = itemS.GetItemsByTypeAndName(DropDownList1.Items[DropDownList1.SelectedIndex].Value,
                DropDownList2.Items[DropDownList2.SelectedIndex].Value);
        }

        DataGrid2.DataSource = ds;
        DataGrid2.DataBind();

        //----- dealing with the cart data

        crt = (Cart)(Page.Session["Cart"]);
        idProd = Request["idItem"];
        idProdMinus = Request["idItemMinus"];
        idProdPlus = Request["idItemPlus"];

        if (idProdPlus != null)
            crt.UpdateByIdProd(idProdPlus, "+");
        if (idProdMinus != null)
            crt.UpdateByIdProd(idProdMinus, "-");

        id = Request["idItem"];
        if (id != null)
        {
            units = "1";
            cost = itemS.GetItemCost(id);

            crt = (Cart)Page.Session["Cart"];

            crt.AddToCart(id, units, cost);
            DataGrid1.Visible = true;
            totalCostLabel.Visible = true;
        }

        crt = (Cart)Page.Session["Cart"];

        DataGrid1.DataSource = crt.GetDT();
        DataGrid1.DataBind();

        totalCostLabel.Text = "מחיר עסקה: " + crt.GetItemTotal();

    }
    protected string ConvertIdItem(object sender)
    {
        DataSet fullName = itemS.ConvertItemId(sender);
        return fullName.Tables[0].Rows[0][0].ToString();
    }

    protected void DPL1changed(object sender, EventArgs e)
    {
        if (ds.Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = false;
            Label1.Visible = true;
        }
        else
        {
            DataGrid1.Visible = true;
            Label1.Visible = false;
        }

    }

    protected void EmptyCart(object sender, EventArgs e)
    {

        crt = (Cart)Page.Session["Cart"];
        crt.EmptyTheDTofCart();
        DataGrid1.Visible = false;
        totalCostLabel.Visible = false;
    }

    protected void BuyCart(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }

}