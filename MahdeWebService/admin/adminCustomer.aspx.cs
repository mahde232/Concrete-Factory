using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminCustomer : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            customers.DataSource = costumerS.GetAllCostumers();
            customers.DataTextField = "costumerName";
            customers.DataValueField = "idCostumer";
            customers.DataBind();
            ds = costumerS.GetAllCostumers();

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
            ds = costumerS.GetCostumerById(customers.Items[customers.SelectedIndex].Value);

            idL.Text = ds.Tables[0].Rows[0][0].ToString();
            nameL.Text = ds.Tables[0].Rows[0][1].ToString();
            phoneL.Text = ds.Tables[0].Rows[0][3].ToString();
            countryL.Text = ds.Tables[0].Rows[0][8].ToString();
            cityL.Text = ds.Tables[0].Rows[0][7].ToString();
            addressL.Text = ds.Tables[0].Rows[0][9].ToString();
            accountL.Text = ds.Tables[0].Rows[0][10].ToString();
            emailL.Text = ds.Tables[0].Rows[0][6].ToString();
            passL.Text = ds.Tables[0].Rows[0][2].ToString();
            kcL.Text = ds.Tables[0].Rows[0][4].ToString();
            kwL.Text = ds.Tables[0].Rows[0][5].ToString();

            dataGrid1.Visible = true;
            dataGrid2.Visible = false;
        }
    }

    protected void ReturnToAdmin(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminOptions.aspx");
    }

    protected void UpdateTheCustomer(object sender, EventArgs e)
    {
        int id = int.Parse(idL.Text);
        string name, city, country, phone, kw, kc, pass, addr, acc, mail;

        if(nameT.Text != "")
            name = nameT.Text;
        else
            name = nameL.Text;

        if (cityT.Text != "")
            city = cityT.Text;
        else
            city = cityL.Text;

        if (countryT.Text != "")
            country = countryT.Text;
        else
            country = countryL.Text;

        if (phoneT.Text != "")
            phone = phoneT.Text;
        else
            phone = phoneL.Text;

        if (kwT.Text != "")
            kw = kwT.Text;
        else
            kw = kwL.Text;

        if (kcT.Text != "")
            kc = kcT.Text;
        else
            kc = kcL.Text;

        if (passT.Text != "")
            pass = passT.Text;
        else
            pass = passL.Text;

        if (addressT.Text != "")
            addr = addressT.Text;
        else
            addr = addressL.Text;

        if (accountT.Text != "")
            acc = accountT.Text;
        else
            acc = accountL.Text;

        if (emailT.Text != "")
            mail = emailT.Text;
        else
            mail = emailL.Text;

        costumer update = new costumer(id, name, pass, phone, kc, kw, mail, city, country, addr, acc);

        costumerS.UpdateCostumer(update);

        ds = costumerS.GetCostumerById(customers.Items[customers.SelectedIndex].Value);

        idL.Text = ds.Tables[0].Rows[0][0].ToString();
        nameL.Text = ds.Tables[0].Rows[0][1].ToString();
        phoneL.Text = ds.Tables[0].Rows[0][3].ToString();
        countryL.Text = ds.Tables[0].Rows[0][8].ToString();
        cityL.Text = ds.Tables[0].Rows[0][7].ToString();
        addressL.Text = ds.Tables[0].Rows[0][9].ToString();
        accountL.Text = ds.Tables[0].Rows[0][10].ToString();
        emailL.Text = ds.Tables[0].Rows[0][6].ToString();
        passL.Text = ds.Tables[0].Rows[0][2].ToString();
        kcL.Text = ds.Tables[0].Rows[0][4].ToString();
        kwL.Text = ds.Tables[0].Rows[0][5].ToString();
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

        dataGrid1.DataSource = Deals.GetDealsByCostumer(customers.Items[customers.SelectedIndex].Value);
        dataGrid1.DataBind();

        if ((Deals.GetDealsByCostumer(customers.Items[customers.SelectedIndex].Value).Tables[0].Rows.Count == 0))
        {
            dataGrid1.Visible = false;
            NoResults.Visible = true;
        }
        else
            dataGrid1.Visible = true;
    }
}