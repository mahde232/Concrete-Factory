using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Days
/// </summary>
public class Days
{

	static DBConnection DBconn;
    static string dbPath;

    public Days(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(p);
    }

    public static DataSet GetDays()
    {
        return DBconn.RunDataSetSQL("Select * From DayTypes");
    }

    public static DataSet GetDayByWorkerId(object id)
    {
        return DBconn.RunDataSetSQL("Select DayName From DayTypes Where idDay = " + id.ToString());
    }

    public static void AddDay(TimeShift day)
    {
        int worker = day.GetIdWorker();
        string idDay = day.GetIdDay();
        int start = day.GetStartHour();
        int end = day.GetEndHour();

        string sql = "insert into TimeShifts (idDay,idWorker,startsAt,endsAt) values (";
        sql = sql + "'" + idDay + "',";
        sql = sql + worker + ",";
        sql = sql + start + ",";
        sql = sql + end + ")";

        DBconn.RunNonQuerySQL(sql);
    }

    public static void DeleteDay(int idRow)
    {
        string sql = "Delete from TimeShifts where idRow = " + idRow;
        DBconn.RunNonQuerySQL(sql);
    }
}