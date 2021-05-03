using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Teams
/// </summary>
public class Costumers
{
    static string dbPath;
    static DBConnection DBConn;
	public Costumers(string p)    //see Global.asax
	{
        dbPath = p;
        DBConn = new DBConnection(dbPath); 
	}

    public static DataSet LoginDetails(string username)
    {
        return DBConn.RunDataSetSQL("select * from Costumer where SpecialID='" + username + "'");
    }

    public static DataSet GetAllCostumers()
    {
         return DBConn.RunDataSetSQL("select * from Costumer order by CostumerName");
    }
    public static DataSet GetAllCostumers2()
    {
        return DBConn.RunDataSetSQL("select * from CustomersQuery");
    }

    public static DataSet GetAllCostumersByLetter(string ot)
    {
        string st = "select * from Costumer where CostumerName like '" + ot + "%' order by CostumerName";
        return DBConn.RunDataSetSQL( st );
    }

    public static DataSet GetSpecificCostumer(string id)
    {
        string st = "select * from Costumer where idCostumer=" + id;
        return DBConn.RunDataSetSQL(st);
    }

    public static Costumer Get1Costumer(string id)
    {
  
        DataSet ds=  DBConn.RunDataSetSQL("select * from Costumer where idCostumer=" + id);
        int cstmrId      =int.Parse(ds.Tables[0].Rows[0][0].ToString());
        string cstmrName =          ds.Tables[0].Rows[0][1].ToString();
        string cstmrPhone=          ds.Tables[0].Rows[0][2].ToString();
        string cstmrEMail = ds.Tables[0].Rows[0][3].ToString();
        int cstmrLocation    =int.Parse(ds.Tables[0].Rows[0][4].ToString());
        string cstmrPicture = ds.Tables[0].Rows[0][5].ToString();
        string cstmrSpecialID = ds.Tables[0].Rows[0][6].ToString();
        string cstmrPass = ds.Tables[0].Rows[0][7].ToString();


        Costumer cstmr = new Costumer(cstmrId, cstmrName, cstmrPhone, cstmrEMail, cstmrLocation, cstmrPicture, cstmrSpecialID, cstmrPass);
        return cstmr;

    }

    public static DataSet Get1CostumerDataSet(string id)
    {

        DataSet ds = DBConn.RunDataSetSQL("select * from Costumer where idCostumer=" + id);
        return ds;

    }

    public static void Update1Customer(Costumer cstmr)
    {
        string id = cstmr.GetCostumerId().ToString();
        string cstmrName = cstmr.GetCostumerName();
        string cstmrPhone = cstmr.GetPhoneNumber();
        string cstmrEmail = cstmr.GetEmail().ToString();
        string cstmrLocation = cstmr.GetCostumerLocation().ToString();
        string cstmrPicture = cstmr.GetPicture();
        string cstmrSpecialID = cstmr.GetSpecialID();
        string cstmrPass = cstmr.GetPass();

        string strSql = "update Costumer set";
        strSql += " CostumerName='" + cstmrName + "',";
        strSql += " CostumerPhone='" + cstmrPhone + "',";
        strSql += " CustomerEMail='" + cstmrEmail + "',";
        strSql += " CustomerLocation=" + cstmrLocation + ",";
        strSql += " [Picture]='" + cstmrPicture + "',";
        strSql += " SpecialID='" + cstmrSpecialID + "',";
        strSql += " LoginPass='" + cstmrPass + "'";
        strSql += " where idCostumer=" + id;

         DBConn.RunNonQuerySQL(strSql);
     }   
     
    public static void Add1Costumer(Costumer cstmr)
    {
        //string id = pl.GetPlayerId().ToString();

        string cstmrName = cstmr.GetCostumerName();
        string cstmrPhone = cstmr.GetPhoneNumber();
        string cstmrEmail = cstmr.GetEmail().ToString();
        string cstmrLocation = cstmr.GetCostumerLocation().ToString();
        string cstmrPicture = cstmr.GetPicture();
        string cstmrSpecialID = cstmr.GetSpecialID();
        string cstmrPass = cstmr.GetPass();


        string strSql = "insert into Costumer (CostumerName,CostumerPhone,CustomerEMail,CustomerLocation,Picture,SpecialID,LoginPass) ";
        strSql +=  "values(";
        strSql += "'" + cstmrName + "',";
        strSql += "'" + cstmrPhone + "',";
        strSql += "'" + cstmrEmail + "',";
        strSql += "'" + cstmrLocation + "',";
        strSql += "'" + cstmrPicture + "',";
        strSql += "'" + cstmrSpecialID + "',";
        strSql += "'" + cstmrPass + "'";

        strSql +=  ")";
         DBConn.RunNonQuerySQL(strSql);

     }
    public static void Delete1Costumer(Costumer cstmr)
    {
        string id = cstmr.GetCostumerId().ToString();

       string strSql = "delete from Costumer where idCostumer= "+id;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static bool IsNameUsed(string name)
    {
        string st = "select * from Costumer where SpecialID='" + name + "'";
        DataSet ds = DBConn.RunDataSetSQL(st);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
 
}
