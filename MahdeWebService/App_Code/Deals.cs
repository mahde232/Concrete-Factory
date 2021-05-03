using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Deals
/// </summary>
public class Deals
{
    static DBConnection DBconn;
    static string dbPath;

	public Deals(string p)
	{
        dbPath = p;
        DBconn = new DBConnection(dbPath);
	}

    public static DataSet GetDealsItems(string id)
    {
        return DBconn.RunDataSetSQL("Select idItem_X, costPerOne, units From DealDetails Where idDeal = "+id);
    }

    public static DataSet GetDealsByCostumer(string costumerId)
    {
        return DBconn.RunDataSetSQL("Select * From Deals Where idCostumer = " + costumerId);
    }

    public static DataSet GetDealByDate(DateTime date)
    {
        return DBconn.RunDataSetSQL("Select * From Deals Where deliveryTime =#" + date.ToString() + "#");
    }

    public static DataSet GetDealByDateAndCustomer(DateTime date, string costumerId)
    {
        return DBconn.RunDataSetSQL("Select * From Deals Where deliveryTime =#" + date.ToString() + "#" + "and idCostumer=" + costumerId);
    }

    public static DataSet GetAllDeals()
    {
        return DBconn.RunDataSetSQL("Select * From Deals");
    }

    public static string GetDealPrice(string idDeal)
    {
        return DBconn.RunDataSetSQL("Select payment From Deals Where idDeal = " + idDeal.ToString()).Tables[0].Rows[0][0].ToString();
    }

    public static void AddOneDeal(deal deal, string pay, DateTime date)
    {
        int worker = deal.GetIdWorker();
        int customer = deal.GetIdCostumer();
        string payment = pay;

        string strSql = "insert into Deals (idWorkerSeller,idCostumer,deliveryTime,payment) ";
        strSql += "values(";
        strSql += worker + ",";
        strSql += customer + ",";
        strSql += "#" + date.Date.ToShortDateString() + "#,";
        strSql += "'" + pay + "'";


        strSql += ")";
        DBconn.RunNonQuerySQL(strSql);
    }

    public static string GetMaxOrderId()
    {
        DataSet ds = DBconn.RunDataSetSQL("Select max(idDeal) From Deals");
        return ds.Tables[0].Rows[0][0].ToString();
    }

    public static void AddOrderDetails(string deal, DataTable crt)
    {
        int idDeal, idItem, units;
        double total, costPerOne;
        string nameX,nameX2;
        for (int i = 0; i < crt.Rows.Count; i++)
        {
            idDeal = int.Parse(deal);
            idItem = int.Parse(crt.Rows[i]["idItem_X2"].ToString());
            units = int.Parse(crt.Rows[i]["units"].ToString());
            costPerOne = double.Parse(crt.Rows[i]["costPerOne"].ToString());
            total = double.Parse(crt.Rows[i]["total"].ToString());

            nameX = itemS.GetItemNameX(idItem.ToString());
            nameX2 = itemS.GetItemNameX2(idItem.ToString());

            string strSql = "insert into DealDetails (idDeal,idItem_X,costPerOne,units,idItem_X2,total) ";
            strSql += "values(";
            strSql += idDeal + ",";
            strSql += "'" + nameX + "',";
            strSql += costPerOne + ",";
            strSql += units + ",";
            strSql += "'" + nameX2 + "',";
            strSql += "'" + total + "'";

            strSql += ")";
            DBconn.RunNonQuerySQL(strSql);
        }
    }

}