using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for dealDetailsS
/// </summary>
public class dealDetailsS
{
    static string dbPath;
    static DBConnection DBconn;

    public dealDetailsS(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(dbPath);
    }

    public static DataSet GetDealDetails(string id)
    {
        return DBconn.RunDataSetSQL("Select idItem_X2, costPerOne, units, total From DealDetails Where idDeal=" + id);
    }
}