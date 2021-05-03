using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for TimeShiftS
/// </summary>
public class TimeShiftS
{
    
	static DBConnection DBconn;
    static string dbPath;

    public TimeShiftS(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(p);
    }

    public static void UpdateTime(TimeShift tm,string idRow)
    {
        int worker = tm.GetIdWorker();
        int starts = tm.GetStartHour();
        int ends = tm.GetEndHour();
        string day = tm.GetIdDay();

        string sql = "update TimeShifts set ";
        sql += "idWorker=" + worker + ",";
        sql += "startsAt=" + starts + ",";
        sql += "endsAt=" + ends + ",";
        sql += "idDay='" + day + "'";

        sql += "Where idRow=" + idRow;

        DBconn.RunNonQuerySQL(sql);
    }
}