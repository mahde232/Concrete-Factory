using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for PositionsS
/// </summary>
public class PositionsS
{
    static DBConnection DBconn;
    static string dbPath;

    public PositionsS(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(p);
	}

    public static DataSet GetAllPositions()
    {
        return DBconn.RunDataSetSQL("Select * From PositionsType");
    }
}