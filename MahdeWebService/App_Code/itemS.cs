using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// Summary description for itemS
/// </summary>
public class itemS
{
    static DBConnection DBconn;
    static string dbPath;

    public itemS(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(dbPath);
    }

    public static DataSet GetAllItemsTypes()
    {
        return DBconn.RunDataSetSQL("Select * From ItemType");
    }
    public static DataSet GetAllItemsNames()
    {
        return DBconn.RunDataSetSQL("Select * From ItemNames");
    }
    public static DataSet GetItemsByTypeAndName(string type, string name)
    {
        return DBconn.RunDataSetSQL("select * from items where type= " + type + "and itemName = "+name);
    }

    public static DataSet GetAllItems()
    {
        return DBconn.RunDataSetSQL("Select * From Items");
    }
    public static DataSet Get1Item(string key)
    {
        return DBconn.RunDataSetSQL("Select * From Items where idItem=" + key);
    }

    public static DataSet GetWoodOnly()
    {
        return DBconn.RunDataSetSQL("Select * From items Where itemName = 1");
    }
    public static DataSet GetWoodTypes()
    {
        return DBconn.RunDataSetSQL("Select * From WoodTypes");
    }
    public static DataSet GetWoodNames()
    {
        return DBconn.RunDataSetSQL("Select * From WoodNames");
    }

    public static DataSet GetScrewOnly()
    {
        return DBconn.RunDataSetSQL("Select * From items Where itemName = 5");
    }
    public static DataSet GetScrewTypes()
    {
        return DBconn.RunDataSetSQL("Select * From ScrewTypes");
    }
    public static DataSet GetScrewsByType(string type)
    {
        return DBconn.RunDataSetSQL("select * from items where type= " + type + "and itemName = 5" );
    }

    public static DataSet GetBaseOnly()
    {
        return DBconn.RunDataSetSQL("Select * From items Where itemName = 4");
    }
    public static DataSet GetBaseTypes()
    {
        return DBconn.RunDataSetSQL("Select * From BaseTypes");
    }
    public static DataSet GetBaseByType(string type)
    {
        return DBconn.RunDataSetSQL("select * from items where type= " + type + "and itemName = 4");
    }

    public static DataSet ConvertItemId(object convert)
    {
       return DBconn.RunDataSetSQL("Select IdFullName From itemsFullName_Q2 Where idItem = " + convert.ToString());
    }

    public static string GetItemCost(string id)
    {
        DataSet cost = DBconn.RunDataSetSQL("Select cost From items Where idItem = " + id);
        return cost.Tables[0].Rows[0][0].ToString();
    }
    public static string GetItemNameX(string id)
    {
        DataSet cost = DBconn.RunDataSetSQL("Select IdFullName From itemsFullName_Q Where idItem = " + id);
        return cost.Tables[0].Rows[0][0].ToString();
    }
    public static string GetItemNameX2(string id)
    {
        DataSet cost = DBconn.RunDataSetSQL("Select IdFullName From itemsFullName_Q2 Where idItem = " + id);
        return cost.Tables[0].Rows[0][0].ToString();
    }

    public static void UpdateItem(item upd)
    {
        int id = upd.Id;
        double cost = upd.Cost;
        int sell = upd.SellType;
        int type = upd.Type;
        int name = upd.Name;
        double len = upd.Length;
        double wid = upd.Width;

        string sql = "update items set ";
        sql += "len_cm = " + len + ",";
        sql += "wid_cm = " + wid + ",";
        sql += "itemName = " + name + ",";
        sql += "type = " + type + ",";
        sql += "cost = " + cost + ",";
        sql += "sellType = " + sell;

        sql += " Where idItem = " + id;

        DBconn.RunNonQuerySQL(sql);
    }
}