using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for workerS
/// </summary>
public class workerS
{
    static DBConnection DBconn;
    static string dbPath;

    public workerS(string p)
    {
        dbPath = p;
        DBconn = new DBConnection(p);
    }

    public static DataSet ConvertIdWorker(object convert)
    {
        return DBconn.RunDataSetSQL("Select workerName From Workers Where idWorker = " + convert.ToString());
    }

    public static DataSet GetAllWorkers()
    {
        return DBconn.RunDataSetSQL("Select * From Workers");
    }

    public static DataSet GetWorkersById(object convert)
    {
        return DBconn.RunDataSetSQL("Select * From Workers Where idWorker = " + convert.ToString());
    }

    public static DataSet GetWorkerPosition(object convert)
    {
        return DBconn.RunDataSetSQL("Select positionType From PositionsType Where idPositions = " + convert.ToString());
    }

    public static DataSet GetWorkerTimeShifts(object id)
    {
        return DBconn.RunDataSetSQL("Select * From TimeShifts Where idWorker = " + id.ToString() + " ORDER BY idDay ASC, startsAt ASC");
    }

    public static void UpdateWorker(worker update, bool deleted)
    {
        int id = update.GetId();
        string name = update.GetName();
        int position = update.GetPosition();
        string telephone = update.GetTelephone();
        int salary = update.GetSalary();

        string sql = "update Workers set ";
        sql += "workerName='" + name + "',";
        sql += "[position]=" + position + ",";
        sql += "telephone='" + telephone + "',";
        sql += "salary=" + salary + ",";

        if (deleted)
            sql += "deleted='1'" + " ";
        else
            sql += "deleted='0'" + " ";

        sql += "Where idWorker=" + id;

        DBconn.RunNonQuerySQL(sql);
    }

    public static void add1Worker(worker add)
    {
        int id = add.GetId();
        string name = add.GetName();
        int position = add.GetPosition();
        string phone = add.GetTelephone();
        int salary = add.GetSalary();
        bool delete = add.GetDeleted();

        string sql = "insert into Workers (workerName,[position],telephone,salary,deleted) values (";
        sql += "'" + name + "',";
        sql += position + ",";
        sql += "'" + phone + "',";
        sql += salary + ",";
        sql += "'0'" + ")";

        DBconn.RunNonQuerySQL(sql);
    }
}