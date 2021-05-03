using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_items : System.Web.UI.Page
{
    DataSet ds, dsType, dsName;
    localhost.WebService srv = new localhost.WebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.DataSource = itemS.GetAllItemsTypes();
            DropDownList1.DataTextField = "typeName";
            DropDownList1.DataValueField = "idType";
            DropDownList1.DataBind();

            DropDownList2.DataSource = itemS.GetAllItemsNames();
            DropDownList2.DataTextField = "itemName";
            DropDownList2.DataValueField = "idItemName";
            DropDownList2.DataBind();
            ds = itemS.GetAllItems();

            DataGrid2.DataSource = srv.GetAllProducts();
            DataGrid2.DataBind();
            DataGrid2.Visible = true;
        }
        else
        {
            ds = itemS.GetItemsByTypeAndName(DropDownList1.Items[DropDownList1.SelectedIndex].Value,
                DropDownList2.Items[DropDownList2.SelectedIndex].Value);
        }

        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();

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
    protected string ConvertIdItem(object sender)
    {
        DataSet fullName = itemS.ConvertItemId(sender);
        return fullName.Tables[0].Rows[0][0].ToString();

    }
}