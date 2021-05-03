using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminItems : System.Web.UI.Page
{
    DataSet ds, dsType, dsName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ds = itemS.GetAllItems();
            dataGrid1.DataSource = ds;
            dataGrid1.DataBind();
        }
    }

    protected void ReturnToAdmin(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminOptions.aspx");
    }

    protected void DPL1changed(object sender, EventArgs e)
    {
        if (ds.Tables[0].Rows.Count == 0)
        {
            dataGrid1.Visible = false;
            Label1.Visible = true;
        }
        else
        {
            dataGrid1.Visible = true;
            Label1.Visible = false;
        }

    }

    protected string ConvertIdItem(object sender)
    {
        DataSet fullName = itemS.ConvertItemId(sender);
        return fullName.Tables[0].Rows[0][0].ToString();

    }

    protected void Update(object source, DataGridCommandEventArgs e)
    {
        Label label = new Label();
        string key = dataGrid1.DataKeys[e.Item.ItemIndex].ToString();
        label.Text = key;

        int type, name, len,wid,cost,sell,id;
        TextBox tb;

        DataSet updItem = itemS.Get1Item(key);

        type = int.Parse(updItem.Tables[0].Rows[0][4].ToString());
        sell = int.Parse(updItem.Tables[0].Rows[0][6].ToString());
        name = int.Parse(updItem.Tables[0].Rows[0][3].ToString());

        tb = (TextBox)(e.Item.Cells[3].Controls[1]);
        cost = int.Parse(tb.Text);

        tb = (TextBox)(e.Item.Cells[4].Controls[1]);
        wid = int.Parse(tb.Text);

        tb = (TextBox)(e.Item.Cells[5].Controls[1]);
        len = int.Parse(tb.Text);

        Label lb = (Label)(e.Item.Cells[1].Controls[1]);
        id = int.Parse(lb.Text);

        item up = new item(id, len, wid, cost, type, sell, name);
        itemS.UpdateItem(up);

        dataGrid1.EditItemIndex = -1;
        ds = itemS.GetAllItems();
        dataGrid1.DataSource = ds;
        dataGrid1.DataBind();
    }

    protected void Edit(object source, DataGridCommandEventArgs e)
    {
        ds = itemS.GetAllItems();
        dataGrid1.DataSource = ds;
        dataGrid1.EditItemIndex = e.Item.ItemIndex;
        dataGrid1.DataBind();
    }

    protected void Cancel(object source, DataGridCommandEventArgs e)
    {
        dataGrid1.EditItemIndex = -1;
        dataGrid1.DataBind();
    }

    protected void Close(object sender, EventArgs e)
    {
        dataGrid1.EditItemIndex = -1;
        dataGrid1.DataBind();
    }
}