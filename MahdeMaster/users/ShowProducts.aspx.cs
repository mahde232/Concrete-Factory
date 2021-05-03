using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class users_ShowProducts : System.Web.UI.Page
{
    localhost.WebService srv = new localhost.WebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["loggedIn"] == "yes" && (string)Session["adminAccess"] == "yes")
        {
            AddProduct.Visible = true;
        }
        DataGrid1.Visible = true;
        DataGrid2.Visible = true;
        if (!Page.IsPostBack)
        {
            //DataSet dsForListBox = dbCon.RunDataSetSQL("select * from Costumer");
            //ListBox1.DataSource = dsForListBox;

            if (Request["source"] == "all")
            {
                labelForAdressingOtherProducts.Visible = true;
                DataGrid1.DataSource = Products.GetAllProducts();
                DataGrid1.DataBind();
                DataGrid1.Visible = true;
                ProductsListBox.DataSource = Products.GetAllProducts();
                ProductsListBox.DataTextField = "ProductName";
                ProductsListBox.DataValueField = "idProduct";
                ProductsListBox.DataBind();
                DataGrid2.DataSource = srv.GetAllItems();
                DataGrid2.DataBind();
                DataGrid2.Visible = true;
            }
            if (Request["source"] == "concrete")
            {
                DataGrid1.DataSource = Products.GetAllProducts();
                DataGrid1.DataBind();
                DataGrid1.Visible = true;
                ProductsListBox.DataSource = Products.GetAllProducts();
                ProductsListBox.DataTextField = "ProductName";
                ProductsListBox.DataValueField = "idProduct";
                ProductsListBox.DataBind();
                //DataGrid2.DataSource = srv.GetAllItems();
                //DataGrid2.DataBind();
                //DataGrid2.Visible = true;
            }
            if (Request["source"] == "base")
            {
                labelForAdressingOtherProducts.Visible = true;
                PanelForViewing.Visible = false;
                //DataGrid1.DataSource = Products.GetAllProducts();
                //DataGrid1.DataBind();
                DataGrid1.Visible = false;
                //ProductsListBox.DataSource = Products.GetAllProducts();
                //ProductsListBox.DataTextField = "ProductName";
                //ProductsListBox.DataValueField = "idProduct";
                //ProductsListBox.DataBind();
                DataGrid2.DataSource = srv.GetBaseOnly();
                DataGrid2.DataBind();
                DataGrid2.Visible = true;
            }
            if (Request["source"] == "screw")
            {
                labelForAdressingOtherProducts.Visible = true;
                PanelForViewing.Visible = false;
                //DataGrid1.DataSource = Products.GetAllProducts();
                //DataGrid1.DataBind();
                DataGrid1.Visible = false;
                //ProductsListBox.DataSource = Products.GetAllProducts();
               // ProductsListBox.DataTextField = "ProductName";
               // ProductsListBox.DataValueField = "idProduct";
               // ProductsListBox.DataBind();
                DataGrid2.DataSource = srv.GetScrewOnly();
                DataGrid2.DataBind();
                DataGrid2.Visible = true;
            }
            if (Request["source"] == "wood")
            {
                labelForAdressingOtherProducts.Visible = true;
                PanelForViewing.Visible = false;
                //DataGrid1.DataSource = Products.GetAllProducts();
                //DataGrid1.DataBind();
                DataGrid1.Visible = false;
                //ProductsListBox.DataSource = Products.GetAllProducts();
                //ProductsListBox.DataTextField = "ProductName";
                //ProductsListBox.DataValueField = "idProduct";
                //ProductsListBox.DataBind();
                DataGrid2.DataSource = srv.GetWoodOnly();
                DataGrid2.DataBind();
                DataGrid2.Visible = true;
            }
        }
    }
    protected void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = dbCon.RunDataSetSQL("select * from Orders where Costumer=" + ListBox1.SelectedValue);
        //DataGrid1.DataSource = ds;
        DataGrid1.DataSource = Products.GetSpecificProduct(ProductsListBox.SelectedValue);
        DataGrid1.DataBind();
        DataGrid1.Visible = true;
    }


    protected void AddProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/Add1Product.aspx");
    }
    protected void ShowAll_Click(object sender, EventArgs e)
    {
        DataGrid1.DataSource = Products.GetAllProducts();
        DataGrid1.DataBind();
        DataGrid1.Visible = true;
    }
    protected string ConvertIdItem(object sender)
    {
        DataSet fullName = srv.ConvertItemId(sender);
        return fullName.Tables[0].Rows[0][0].ToString();

    }
}