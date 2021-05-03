using System;
using System.Data;
using System.Data.OleDb;

    /// <summary>
    /// DBConnection is a class used to connect to our site's DB. 
    /// In order to make programming more fluent, these functions will take an SQL Sentence and run it, instead
    /// of requiring the programmer to write the same lines over and over again.
    /// </summary>
public class DBConnection
{
    string path;
    public DBConnection(string path)
	{
        this.path = path;
    }

    /// <summary>
    /// This function will connect to the DB and run a non-query 
    /// SQL Sentence (INSERT, UPDATE or DELETE)
    /// </summary>
    /// <param name="strSQL">The SQL Sentence to run</param>
    /// <returns>The number of rows affected.</returns>
    /// 
    public int RunNonQuerySQL(string strSQL)
    {
    
        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        conn.ConnectionString = @"provider=microsoft.ace.oledb.12.0;data source=" + this.path;

        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        cmd.CommandText = strSQL;
        cmd.Connection = conn;

        conn.Open();
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return rowsAffected;

    }

    /// <summary>
    /// This function will run an SQL sentence and returns the first column of the first row returned by running it.
    /// </summary>
    /// <param name="strSQL">The SQL sentence to run</param>
    /// <returns>The first column of the first row returned by running it. Returned as object and should be converted to the appropriate type before running</returns>
    public object RunScalarSQL(string strSQL)
    {
     
        System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
        conn.ConnectionString = @"provider=microsoft.ace.oledb.12.0;data source=" + this.path;

        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        cmd.CommandText = strSQL;
        cmd.Connection = conn;
        
        conn.Open();
        Object obj = cmd.ExecuteScalar();
        conn.Close();
        return obj;
    }

    /// <summary>
    /// This function will run an SQL function and return a block of data
    /// </summary>
    /// <param name="strSQL">The SQL sentence to run</param>
    /// <returns>All of the data returned by running the SQL sentence, in a DataSet.</returns>
    public DataSet RunDataSetSQL(string strSQL)
    {
        DataSet ds = new System.Data.DataSet();
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"provider=microsoft.ace.oledb.12.0;data source=" + this.path;
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = strSQL;
        cmd.Connection = conn;
        OleDbDataAdapter dAdpt1 = new OleDbDataAdapter(cmd);
        dAdpt1.Fill(ds);
        return ds;
    }
    /*
        public DataSet SelectSQL(string strSelect)
        {


            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"provider=microsoft.jet.oledb.4.0;
                    data source=" + path;
            //  +Server.MapPath("/Db/pics.mdb");

            OleDbDataAdapter cmdThoomim =
            new OleDbDataAdapter(strSelect, conn);//"select * from thoomim "

            //data set
            DataSet dsThoomim = new DataSet("myDS1");
            cmdThoomim.Fill(dsThoomim, "koteret");

            return dsThoomim;

        }
     * 
        public void ExecuteNonQuery(string strQuery)
        {

        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"provider=microsoft.jet.oledb.4.0;
                data source=" + path;
        //Server.MapPath("/Db/pics.mdb");


        OleDbCommand objCmd = new OleDbCommand(strQuery, conn);
        objCmd.Connection.Open();
        objCmd.ExecuteNonQuery();
        objCmd.Connection.Close();

        }
     * * 
     */
}
