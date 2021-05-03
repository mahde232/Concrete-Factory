using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Costumers
/// </summary>
public class costumerS
{
    static DBConnection DBconn;
    static string dbPath;

	public costumerS(string p)
	{
        dbPath = p;
        DBconn = new DBConnection(dbPath);
	}

    public static DataSet GetAllCostumers()
    {
        return DBconn.RunDataSetSQL("select * From costumer");
    }
    public static DataSet GetCostumerById(object id)
    {
        return DBconn.RunDataSetSQL("select * From costumer Where idCostumer = " + id.ToString());
    }
    public static DataSet ConvertIdCostumer(object convert)
    {
        return DBconn.RunDataSetSQL("Select costumerName From costumer Where idCostumer = " + convert.ToString());
    }

    public static void Add1Customer(costumer add)
    {
        string name = add.GetName();
        string password = add.GetPassword();
        string telephone = add.GetTelephone();
        string isKblan = add.GetWork();
        string work = add.GetTypeOfWork();
        string email = add.GetEmail();
        string city = add.GetCity();
        string country = add.GetCountry();
        string adress = add.GetAddress();
        string account = add.GetAccount();

        string strSql = "insert into costumer (costumerName,[password],telephone,kindOfCostumer,kindOfWork,email,country,city,address,accountName) ";
        strSql += "values(";
        strSql += "'" + name + "',";
        strSql += "'" + password + "',";
        strSql += "'" + telephone + "',";
        strSql += "'" + isKblan + "',";
        strSql += "'" + work + "',";
        strSql += "'" + email + "',";
        strSql += "'" + country + "',";
        strSql += "'" + city + "',";
        strSql += "'" + adress + "',";
        strSql += "'" + account + "'";

        strSql += ")";
        DBconn.RunNonQuerySQL(strSql);
    }

    public static DataSet GetAllUsersByUserName(string accountName)
    {
        return DBconn.RunDataSetSQL("Select * From costumer Where accountName = '" + accountName + "'");
    }

    public static costumer GetOneCustomer(object id)
    {
        DataSet one = DBconn.RunDataSetSQL("Select * From costumer Where idCostumer = " + id);

        string name = one.Tables[0].Rows[0][1].ToString();
        string password = one.Tables[0].Rows[0][2].ToString();
        string telephone = one.Tables[0].Rows[0][3].ToString();
        string isKblan = one.Tables[0].Rows[0][4].ToString();
        string work = one.Tables[0].Rows[0][5].ToString();
        string email = one.Tables[0].Rows[0][6].ToString();
        string city = one.Tables[0].Rows[0][7].ToString();
        string country = one.Tables[0].Rows[0][8].ToString();
        string adress = one.Tables[0].Rows[0][9].ToString();
        string account = one.Tables[0].Rows[0][10].ToString();

        return new costumer(name, password, telephone, isKblan, work, email, city, country, adress, account);
    }

    public static void UpdateCostumer(costumer update)
    {
        int id = update.GetId();
        string name = update.GetName();
        string phone = update.GetTelephone();
        string city = update.GetCity();
        string country = update.GetCountry();
        string address = update.GetAddress();
        string account = update.GetAccount();
        string password = update.GetPassword();
        string kw = update.GetTypeOfWork();
        string kc = update.GetWork();
        string email = update.GetEmail();

        string sql = "update costumer set ";
        sql += "costumerName='" + name + "',";
        sql += "[password]='" + password + "',";
        sql += "telephone='" + phone + "',";
        sql += "kindOfCostumer='" + kc + "',";
        sql += "kindOfWork='" + kw + "',";
        sql += "email='" + email + "',";
        sql += "city='" + city + "',";
        sql += "country='" + country + "',";
        sql += "address='" + address + "',";
        sql += "accountName='" + account + "' ";

        sql += "Where idCostumer=" + id;

        DBconn.RunNonQuerySQL(sql);
    }
}