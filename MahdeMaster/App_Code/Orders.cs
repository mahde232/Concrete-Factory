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
public class Orders
{
    static string dbPath;
    static DBConnection DBConn;
	public Orders(string p)    //see Global.asax
	{
        dbPath = p;
        DBConn = new DBConnection(dbPath); 
	}

    public static DataSet GetAllOrders()
    {
        return DBConn.RunDataSetSQL("select * from Orders order by DateOfOrder");
    }
    public static DataSet GetAllOrders2()
    {
        return DBConn.RunDataSetSQL("select * from Orders order by DateOfOrder DESC");
    }

    public static DataSet GetAllOrdersBySpecificDate(DateTime date1)
    {
        return DBConn.RunDataSetSQL("select * from Orders where DateOfOrder=#" +date1.ToString("d") + "#");
    }
    //public static DataSet GetAllOrdersByCostumer(string ot)
    //{
    //    string st = "select * from Orders where Costumer like '" + ot + "%' order by CostumerName";
    //    return DBConn.RunDataSetSQL( st );
    //}


    public static DataSet GetSpecificOrder(string id)
    {
        string st = "select * from Orders where Costumer=" + id;
        return DBConn.RunDataSetSQL(st);
    }

    public static Order Get1Order(string id)
    {
  
        DataSet ds=  DBConn.RunDataSetSQL("select * from Orders where idOrder=" + id);
        int ordrId      =int.Parse(ds.Tables[0].Rows[0][0].ToString());
        string ordrCostumer =          ds.Tables[0].Rows[0][1].ToString();
        DateTime ordrDate=          (DateTime)ds.Tables[0].Rows[0][2];
        string ordrType = ds.Tables[0].Rows[0][3].ToString();
        double ordrAmount    =double.Parse(ds.Tables[0].Rows[0][4].ToString());
		double ordrActualPrice    =double.Parse(ds.Tables[0].Rows[0][5].ToString());
		string ordrDistination    =ds.Tables[0].Rows[0][6].ToString();
		string ordrWorker    =ds.Tables[0].Rows[0][7].ToString();
		
        Order ordr = new Order(ordrId, ordrCostumer, ordrDate, ordrType, ordrAmount, ordrActualPrice, ordrDistination, ordrWorker);
        return ordr;
    }

    public static DataSet Get1OrderDataSet(string id)
    {

        DataSet ds = DBConn.RunDataSetSQL("select * from Orders where idOrder=" + id);
        return ds;

    }

    public static DataSet GetOrdersByWorkerInvolved(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Orders where OvedDriver=" + id);
        return ds;
    }

    //public static DataSet GetAllOrdersByLetterOfCostumer(string ot)
    //{
    //    for (int i = 0; i < length; i++)
    //    {

    //    }
        
    //    string st = "select * from Orders where Costumer= " + ot + " order by Costumer";
    //    return DBConn.RunDataSetSQL(st);
    //}

    //public static int[] GetIDsOfCostumersByLetter(char ot)
    //{
    //    int[] arr = new int[Costumers.GetAllCostumers().Tables[0].Rows.Count];
    //    DataSet test = Costumers.GetAllCostumers();

    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        if(test.Tables[0].Rows[i][1].ToString()[0]==ot)
    //        {
    //            arr[i] = int.Parse(test.Tables[0].Rows[i][0].ToString());
    //        }
           
    //    }
    //    DataSet toReturn= new DataSet();
    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        toReturn.Tables.Add(
    //    }

    //    return arr;
    //}

    //public static void Update1Order(Order ordr)
    //{
    //    string id = ordr.GetOrderId().ToString();
    //    string cstmrName = ordr.GetCostumerInvolved();
    //    string cstmrPhone = ordr.GetPhoneNumber();
    //    string cstmrEmail = ordr.GetEmail().ToString();
    //    string cstmrLocation = ordr.GetCostumerLocation().ToString();

    //    string strSql = "update Costumer set ";
    //    strSql += " CostumerName='" + cstmrName + "',";
    //    strSql += " CostumerPhone='" + cstmrPhone + "',";
    //    strSql += " CustomerEMail=" + cstmrEmail + ",";
    //    strSql += " CustomerLocation='" + cstmrLocation + "' ";
    //    strSql += "  where idCostumer=" + id;

    //     DBConn.RunNonQuerySQL(strSql);
    // }   
     
    public static void Add1Order(Order ordr)
    {
        //string id = pl.GetPlayerId().ToString();

        string cstmrID = ordr.GetCostumerInvolved().ToString();
        DateTime dateOfOrder = ordr.GetDateOfOrder();
        string orderTypeWanted = ordr.GetOrderTypeWanted().ToString();
        double amount = double.Parse(ordr.GetAmount().ToString());
        double actualPrice = double.Parse(ordr.GetActualPrice().ToString());
        string destination = ordr.GetDistination().ToString();
        string wrkrInvolved = ordr.GetDriverOfOrder().ToString();


        string strSql = "insert into Orders (Costumer,DateOfOrder,OrderTypeWanted,Amount,ActualPrice,Distination,OvedDriver) ";
        strSql += "values(";
        strSql += "'" + cstmrID + "',";
        strSql += "'" + dateOfOrder.ToString() + "',";
        strSql += "'" + orderTypeWanted + "',";
        strSql += "'" + amount + "',";
        strSql += "'" + actualPrice + "',";
        strSql += "'" + destination + "',";
        strSql += "'" + wrkrInvolved + "'";

        strSql +=  ")";
         DBConn.RunNonQuerySQL(strSql);

     }
    public static void Delete1Order(Order ordr)
    {
        string id = ordr.GetOrderId().ToString();

       string strSql = "delete from Orders where idOrder= "+id;
        DBConn.RunNonQuerySQL(strSql);
    }

 
}
