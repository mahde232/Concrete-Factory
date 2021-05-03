using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;

/// <summary>
/// Summary description for Assistive Methods
/// </summary>
public class AssistiveMethods
{
    static string dbPath;
    static DBConnection DBConn;
	public AssistiveMethods(string p)    //see Global.asax
	{
        dbPath = p;
        DBConn = new DBConnection(dbPath); 
	}

    public static bool CheckValidUsername(string usernameX)
    {
        DataSet ds = Costumers.LoginDetails(usernameX);
        if (ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        return true;
    }

    public static DataSet GetAllLocations()
    {
        return DBConn.RunDataSetSQL("select * from Locations order by LocationName");
    }
    public static DataSet GetAllPositions()
    {
        return DBConn.RunDataSetSQL("select * from Tafkedem order by TafkedName");
    }
    public static DataSet GetAllPositions2()
    {
        return DBConn.RunDataSetSQL("select * from [Copy Of Tafkedem] order by TafkedName");
    }
    public static DataSet GetAllVehicles()
    {
        return DBConn.RunDataSetSQL("select * from Transport order by TransportName");
    }

    public static string GetYeshovNameById(object yshvdNum)
    {
        string yshv = yshvdNum.ToString();
        DataSet dsTm = DBConn.RunDataSetSQL("select * from Locations where idLocation=" + yshv);
        return (string)dsTm.Tables[0].Rows[0]["LocationName"];
    }
    public static string GetTafkedNameById(object tfkdNum)
    {
        string tfkd = tfkdNum.ToString();
        DataSet dsTm = DBConn.RunDataSetSQL("select * from Tafkedem where idTafked=" + tfkd);
        return (string)dsTm.Tables[0].Rows[0]["TafkedName"];
    }
    public static string GetVehicleNameById(object vhcldNum)
    {
        string vhcl = vhcldNum.ToString();
        DataSet dsTm = DBConn.RunDataSetSQL("select * from Transport where idTransport=" + vhcl);
        return (string)dsTm.Tables[0].Rows[0]["TransportName"];
    }
    public static string GetProductNameById(object prdctNum)
    {
        string prdct = prdctNum.ToString();
        DataSet dsTm = DBConn.RunDataSetSQL("select * from Product where idProduct=" + prdct);
        return (string)dsTm.Tables[0].Rows[0]["ProductName"];
    }
    public static string GetLinkForHyperLinkUsingName(object objectName, string type)
    {
        if (type == "costumer")
        {
            string cstmr = objectName.ToString();
            DataSet dsTm = DBConn.RunDataSetSQL("select * from Costumer where CostumerName like '" + cstmr + "'");
            string st = "~/users/Show1Customer.aspx?id=" + dsTm.Tables[0].Rows[0]["idCostumer"];
            return st;
        }
        if (type == "worker")
        {
            string wrkr = objectName.ToString();
            DataSet dsTm = DBConn.RunDataSetSQL("select * from Ovdem where OvedName like '" + wrkr + "'");
            string st = "~/users/Show1Worker.aspx?id=" + dsTm.Tables[0].Rows[0]["idOved"];
            return st;
        }
        if (type == "product")
        {
            string prdct = objectName.ToString();
            DataSet dsTm = DBConn.RunDataSetSQL("select * from Product where ProductName like '" + prdct + "'");
            string st = "~/users/Show1Product.aspx?id=" + dsTm.Tables[0].Rows[0]["idProduct"];
            return st;
        }
        else
            return "Error";
    }

    public static bool CheckEmail(string email)
    {
        if (Regex.IsMatch(email, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
        {
            return true;
        }
        return false;
    }
}
