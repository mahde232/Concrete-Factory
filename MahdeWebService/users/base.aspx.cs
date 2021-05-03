using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_base : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.DataSource = itemS.GetBaseTypes();
            DropDownList1.DataTextField = "typeName";
            DropDownList1.DataValueField = "idType";
            DropDownList1.DataBind();

            ds = itemS.GetBaseOnly();
        }
        else
        {
            ds = itemS.GetBaseByType(DropDownList1.Items[DropDownList1.SelectedIndex].Value);
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