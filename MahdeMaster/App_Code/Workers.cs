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
public class Workers
{
    static string dbPath;
    static DBConnection DBConn;
	public Workers(string p)    //see Global.asax
	{
        dbPath = p;
        DBConn = new DBConnection(dbPath); 
	}
 
    public static DataSet GetAllWorkersByPosition(string id)
    {
          return   DBConn.RunDataSetSQL("select * from Ovdem where OvedTafked="+id);
    }

    public static DataSet GetAllWorkers()
    {
         return DBConn.RunDataSetSQL("select * from Ovdem order by OvedName");
    }
    public static DataSet GetAllWorkers2()
    {
        return DBConn.RunDataSetSQL("select * from OvdemInformationQ");
    }

    public static DataSet GetAllWorkersByLetter(string ot)
    {
        string st = "select * from Ovdem where OvedName like '" + ot + "%' order by OvedName";
        return DBConn.RunDataSetSQL( st );
    }
    public static DataSet GetSpecificWorker(string id)
    {
        string st = "select * from Ovdem where idOved=" + id;
        return DBConn.RunDataSetSQL(st);
    }
    public static DataSet GetWorkersFromSpecificLocation(string id)
    {
        string st = "select * from Ovdem where Yeshov=" + id;
        return DBConn.RunDataSetSQL(st);
    }
  
    public static Worker Get1Worker(string id)
    {
  
        DataSet ds=  DBConn.RunDataSetSQL("select * from Ovdem where idOved=" + id);
        int wrkrId      =int.Parse(ds.Tables[0].Rows[0][0].ToString());
        string wrkrName =          ds.Tables[0].Rows[0][1].ToString();
        string wrkrPhone=          ds.Tables[0].Rows[0][2].ToString();
        int wrkrPosition    =int.Parse(ds.Tables[0].Rows[0][3].ToString());
        int wrkrVehicle    =int.Parse(ds.Tables[0].Rows[0][4].ToString());
        int wrkrLocation    =int.Parse(ds.Tables[0].Rows[0][5].ToString());
        string wrkrPicture = ds.Tables[0].Rows[0][6].ToString();
        string wrkrSpecialID = ds.Tables[0].Rows[0][7].ToString();
        string wrkrPass = ds.Tables[0].Rows[0][8].ToString();

        Worker wrkr = new Worker(wrkrId, wrkrName, wrkrPhone, wrkrPosition, wrkrVehicle, wrkrLocation, wrkrPicture, wrkrSpecialID, wrkrPass);
        return wrkr;

    }

    public static void Update1Worker(Worker wrkr)
    {
        string id = wrkr.GetWorkerId().ToString();
        string wrkrName   = wrkr.GetWorkerName();
        string wrkrPhone  = wrkr.GetWorkerPhone();
        string wrkrPosition   = wrkr.GetWorkerPosition().ToString();
        string wrkrVehicle = wrkr.GetWorkerVehicle().ToString();
        string wrkrLocation = wrkr.GetWorkerLocation().ToString();
        string wrkrPicture = wrkr.GetPicture();
        string wrkrSpecialID = wrkr.GetSpecialID();
        string wrkrPass = wrkr.GetPass();

        string strSql = "update Ovdem set ";
        strSql += " OvedName='"  + wrkrName +"',";
        strSql += " OvedPhone='" + wrkrPhone+"',";
        strSql += " OvedTafked="     + wrkrPosition +",";
        strSql += " VehicleOwned='"         + wrkrVehicle+"', ";
        strSql += " Picture='" + wrkrPicture + "', ";
        strSql += " SpecialID='" + wrkrSpecialID + "', ";
        strSql += " LoginPass='" + wrkrPass + "' ";
        strSql += "  where idOved=" + id;

         DBConn.RunNonQuerySQL(strSql);
     }   
     
    public static void Add1Worker(Worker wrkr)
    {
        //string id = pl.GetPlayerId().ToString();

        string wrkrName = wrkr.GetWorkerName();
        string wrkrPhone = wrkr.GetWorkerPhone();
        string wrkrPosition = wrkr.GetWorkerPosition().ToString();
        string wrkrVehicle = wrkr.GetWorkerVehicle().ToString();
        string wrkrLocation = wrkr.GetWorkerLocation().ToString();
        string wrkrPicture = wrkr.GetPicture();
        string wrkrSpecialID = wrkr.GetSpecialID();
        string wrkrPass = wrkr.GetPass();

        //string strSql = "insert into Ovdem (wrkrName,wrkrPhone,wrkrPosition,wrkrVehicle,wrkrLocation,wrkrPicture,wrkrSpecialID,wrkrPass) ";
        string strSql = "insert into Ovdem (OvedName,OvedPhone,OvedTafked,VehicleOwned,Yeshov,Picture,SpecialID,LoginPass) ";
        strSql +=  "values(";
        strSql +=  "'" + wrkrName  +"',";
        strSql +=  "'" + wrkrPhone +"'," ;
        strSql += "'" + wrkrPosition + "',";
        strSql += "'" + wrkrVehicle + "',";
        strSql +=  "'" + wrkrLocation   +"',";
        strSql += "'" + wrkrPicture + "',";
        strSql += "'" + wrkrSpecialID + "',";
        strSql += "'" + wrkrPass + "'";

        strSql +=  ")";
         DBConn.RunNonQuerySQL(strSql);

         
     }
    public static void Delete1Worker(Worker wrkr)
    {
        string id = wrkr.GetWorkerId().ToString();

       string strSql = "delete from Ovdem where idOved= "+id;
        DBConn.RunNonQuerySQL(strSql);
    }

    public static bool IsNameUsed(string name)
    {
        string st = "select * from Ovdem where SpecialID='" + name + "'";
        DataSet ds = DBConn.RunDataSetSQL(st);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
}
