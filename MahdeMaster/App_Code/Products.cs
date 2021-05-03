using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Products
{
    static string dbPath;
    static DBConnection DBConn;
	public Products(string p)    //see Global.asax
	{
        dbPath = p;
        DBConn = new DBConnection(dbPath); 
	}

    public static DataSet GetAllProducts()
    {
        return DBConn.RunDataSetSQL("select * from Product order by ProductName");
    }
    public static DataSet GetSpecificProduct(string id)
    {
        string st = "select * from Product where idProduct=" + id;
        return DBConn.RunDataSetSQL(st);
    }
    public static Product Get1Product(string id)
    {
        DataSet ds = DBConn.RunDataSetSQL("select * from Product where idProduct=" + id);
        int prdctId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        string prdctName = ds.Tables[0].Rows[0][1].ToString();
        double prdctPricePerOne = double.Parse(ds.Tables[0].Rows[0][2].ToString());

        Product prdct = new Product(prdctId, prdctName, prdctPricePerOne);
        return prdct;
    }
    public static void Update1Product(Product prdct)
    {
        string id = prdct.GetProductId().ToString();
        string prdctName = prdct.GetProductName().ToString();
        double pricePerOne = prdct.GetPricePerOne();

        string strSql = "Update Product set ";
        strSql += "ProductName='" + prdctName + "',";
        strSql += "ProductPricePerOne='" + pricePerOne + "' ";
        strSql += " where idProduct=" + id;

        DBConn.RunNonQuerySQL(strSql);
    }
    public static void Add1Product(Product prdct)
    {
        string prdctName = prdct.GetProductName().ToString();
        double pricePerOne = prdct.GetPricePerOne();

        string strSql = "insert into Product (ProductName,ProductPricePerOne) ";
        strSql += "values(";
        strSql += "'" + prdctName + "',";
        strSql += "'" + pricePerOne + "'";

        strSql += ")";
        DBConn.RunNonQuerySQL(strSql);
    }
    public static void Delete1Product(Product prdct)
    {
        string id = prdct.GetProductId().ToString();

        string strSql = "delete from Product where idProduct= " + id;
        DBConn.RunNonQuerySQL(strSql);
    }

}