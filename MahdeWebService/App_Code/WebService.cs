using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() 
    {
        return "Hello World";
    }

    /// <summary>
    /// itemS Methods that you need
    /// </summary>

    [WebMethod]
    public DataSet GetAllItemsNames()//needed
    {
        return itemS.GetAllItemsNames();
    }

    [WebMethod]
    public DataSet GetItemsByTypeAndName(string type, string name)
    {
        return itemS.GetItemsByTypeAndName(type, name);
    }

    [WebMethod]
    public DataSet GetAllItems()
    {
        return itemS.GetAllItems();
    }

    [WebMethod]
    public DataSet Get1Item(string key)
    {
        return itemS.Get1Item(key);
    }

    [WebMethod]
    public DataSet GetWoodOnly()
    {
        return itemS.GetWoodOnly();
    }

    [WebMethod]
    public DataSet GetWoodTypes()
    {
        return itemS.GetWoodTypes();
    }

    [WebMethod]
    public DataSet GetWoodNames()
    {
        return itemS.GetWoodNames();
    }

    [WebMethod]
    public DataSet GetScrewOnly()
    {
        return itemS.GetScrewOnly();
    }

    [WebMethod]
    public DataSet GetScrewTypes()
    {
        return itemS.GetScrewTypes();
    }

    [WebMethod]
    public DataSet GetScrewsByType(string type)
    {
        return itemS.GetScrewsByType(type);
    }

    [WebMethod]
    public DataSet GetBaseOnly()
    {
        return itemS.GetBaseOnly();
    }

    [WebMethod]
    public DataSet GetBaseTypes()
    {
        return itemS.GetBaseTypes();
    }

    [WebMethod]
    public DataSet GetBaseByType(string type)
    {
        return itemS.GetBaseByType(type);
    }

    [WebMethod]
    public DataSet ConvertItemId(object convert)
    {
        return itemS.ConvertItemId(convert);
    }

    [WebMethod]
    public string GetItemCost(string id)
    {
        return itemS.GetItemNameX(id);
    }

    [WebMethod]
    public string GetItemNameX(string id)
    {
        return itemS.GetItemNameX(id);
    }

    [WebMethod]
    public string GetItemNameX2(string id)
    {
        return itemS.GetItemNameX2(id);
    }
}
