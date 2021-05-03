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

public partial class ShowOrders : System.Web.UI.Page
{
    //DBConnection dbCon;
    protected void Page_Load(object sender, EventArgs e)
    {
        //dbCon = new DBConnection(Server.MapPath("~/App_Data/Sadran.accdb"));

        if ((string)Session["loggedIn"] == "yes" && (string)Session["adminAccess"] == "yes")
        {
            AddOrder.Visible = true;
        }

        if (!Page.IsPostBack)
        {
            //DataSet dsForListBox = dbCon.RunDataSetSQL("select * from Costumer");
            //ListBox1.DataSource = dsForListBox;
            ListBox1.DataSource = Costumers.GetAllCostumers();
            ListBox1.DataTextField = "CostumerName";
            ListBox1.DataValueField = "idCostumer";
            ListBox1.DataBind();
            Label1.Visible = false;

            GenerateDropDownListsForDate();
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Orders where Costumer=" + ListBox1.SelectedValue);
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Orders.GetSpecificOrder(ListBox1.SelectedValue);
        DataGrid1.DataBind();
        if (Orders.GetSpecificOrder(ListBox1.SelectedValue).Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = false;
            Label1.Visible = true;
            Label1.Text = "There are no orders made by this customer";
        }
        else
        {
            DataGrid1.Visible = true;
            Label1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Orders");
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Orders.GetAllOrders();
        Label1.Visible = false;
        DataGrid1.DataBind();
        DataGrid1.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Orders");
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Orders.GetAllOrders2();
        Label1.Visible = false;
        DataGrid1.DataBind();
        DataGrid1.Visible = true;
    }
    protected void GenerateDropDownListsForDate()
    {
        for (int i = DateTime.Now.Year; i >= 1900; i--)
        {
            DropDownListYears.Items.Add(i.ToString());
        }

        for (int i = 1; i <= 31; i++)
        {
            DropDownListDays.Items.Add(i.ToString());
        }

        for (int i = 1; i <= 12; i++)
        {
            //DropDownListMonths.Items.Add(i.ToString());
            ListItem mnth;
            if (i == 1)
            {
                mnth = new ListItem("January","1");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 2)
            {
                mnth = new ListItem("February", "2");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 3)
            {
                mnth = new ListItem("March", "3");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 4)
            {
                mnth = new ListItem("April", "4");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 5)
            {
                mnth = new ListItem("May", "5");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 6)
            {
                mnth = new ListItem("June", "6");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 7)
            {
                mnth = new ListItem("July", "7");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 8)
            {
                mnth = new ListItem("August", "8");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 9)
            {
                mnth = new ListItem("September", "9");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 10)
            {
                mnth = new ListItem("October", "10");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 11)
            {
                mnth = new ListItem("November", "11");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
            if (i == 12)
            {
                mnth = new ListItem("December", "12");
                DropDownListMonths.Items.Add(mnth.ToString());
            }
        }
    }
    protected void SearchByDateButton_Click(object sender, EventArgs e)
    {
        int day = int.Parse(DropDownListDays.SelectedValue);
        int month = (DropDownListMonths.SelectedIndex) + 1;
        int year = int.Parse(DropDownListYears.SelectedValue);

        //string st = (""+day + "/" + month + "/" + year);

        DateTime dateToSearch = new DateTime(year, month, day);

        DataGrid1.DataSource = Orders.GetAllOrdersBySpecificDate(dateToSearch);
        //DataGrid1.DataSource = Orders.GetAllOrdersBySpecificDate(st);
        DataGrid1.DataBind();
        if (Orders.GetAllOrdersBySpecificDate(dateToSearch).Tables[0].Rows.Count == 0)
        {
            DataGrid1.Visible = false;
            Label1.Visible = true;
            Label1.Text = "There are no orders made in this date.";
        }
        else
        {
            DataGrid1.Visible = true;
        }
    }
    public void CustomerClick(object sender, DataGridCommandEventArgs e)
    {
        int row = e.Item.DataSetIndex;
        string st = Costumers.GetAllCostumers().Tables[0].Rows[row][0].ToString();
        if (e.CommandName == "LinkClick")
        {
            Response.Redirect("Show1Customer.aspx?id=" + st);
        }
    }
    protected void AddOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/Add1Order.aspx");
    }
}