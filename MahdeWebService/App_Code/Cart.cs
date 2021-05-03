using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart : System.Web.UI.Page
{
    DataTable objDT;
    string sID;

    public Cart(string sid)
    {
        objDT = new DataTable("CartDT");

        objDT.Columns.Add("idItem_X2");
        objDT.Columns.Add("costPerOne");
        objDT.Columns.Add("units");
        objDT.Columns.Add("total");

        this.sID = sid;
        Page.Session["Cart"] = this;
    }

    public void EmptyTheDTofCart()
    {
        this.DeleteAllRows();
    }

    public DataTable GetDT()
    {
        return this.objDT;
    }

    public string GetSID()
    {
        return this.sID;
    }

    public Decimal GetItemTotal()
    {
        int intCounter;
        decimal decRunningTotal = 0;
        objDT = ((Cart)Session["Cart"]).objDT;
        if (objDT.Rows.Count > 0)
        {
            DataRow objDR;

            for (intCounter = 0; intCounter <= objDT.Rows.Count - 1; intCounter++)
            {
                objDR = objDT.Rows[intCounter];
                decRunningTotal += (decimal.Parse(objDR["costPerOne"].ToString()) * int.Parse(objDR["units"].ToString()));
            }

            return decRunningTotal;
        }
        return 0;
    }

    public void UpdateByIdProd(string idProd, string sign)
    {
        int qty = -1;
        int i = 0;
        objDT = ((Cart)Session["Cart"]).objDT;

        while (objDT.Rows[i]["idItem_X2"].ToString() != idProd)
            i++;

        if (sign == "+")
            objDT.Rows[i]["units"] = int.Parse((objDT.Rows[i]["units"]).ToString()) + 1;//= qty
        else
        {
            qty = int.Parse((objDT.Rows[i]["units"]).ToString()) - 1;
            objDT.Rows[i]["units"] = qty; 
            if (qty == 0)
                objDT.Rows[i].Delete();

        }

        if (qty != 0)
            objDT.Rows[i]["total"] = decimal.Parse((objDT.Rows[i]["costPerOne"]).ToString()) * int.Parse((objDT.Rows[i]["units"]).ToString());

        Session["Cart"] = this;
    }

    public void DeleteByIdProd(string idProd)
    {
        int i = 0;
        objDT = ((Cart)Session["Cart"]).objDT;

        while (objDT.Rows[i]["idItem_X2"].ToString() != idProd)
            i++;
        objDT.Rows[i].Delete();
        Session["Cart"] = this;
    }

    public void AddToCart(string idItem, string units, string costPerOne)
    {
        objDT = ((Cart)Session["Cart"]).objDT;

        DataRow objDR;
        bool blnMatch = false;

        foreach (DataRow DR in objDT.Rows)
        {
            if ((string)DR["idItem_X2"] == (string)idItem && blnMatch == false) //productX2
            {
                int temp = int.Parse(DR["units"].ToString()) + int.Parse(units);
                DR["total"] = decimal.Parse(DR["costPerOne"].ToString()) * temp;

                DR["units"] = temp.ToString();
                blnMatch = true;

            }
        }

        if (!blnMatch)
        {
            objDR = (DataRow)objDT.NewRow();
            objDR["idItem_X2"] = idItem;
            objDR["units"] = units;
            objDR["costPerOne"] = costPerOne;
            objDR["total"] = decimal.Parse(costPerOne) * int.Parse(units);

            objDT.Rows.Add(objDR);
        }
        Session["Cart"] = this;// objDT;
    }

    public void Update(int ind, string qty)
    {
        objDT = ((Cart)Session["Cart"]).objDT;
        objDT.Rows[ind]["units"] = qty;
        Session["Cart"] = this;
    }

    public void DeleteAllRows()
    {
        objDT = ((Cart)Session["Cart"]).objDT;
        for (int i = objDT.Rows.Count - 1; i >= 0; i--)
        {
            Delete(i);
        }

        Session["Cart"] = this;
    }

    public void Delete(int ind)
    {
        objDT = ((Cart)Session["Cart"]).objDT;
        objDT.Rows[ind].Delete();
        Session["Cart"] = this;
    }

}