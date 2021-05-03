using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Day
/// </summary>
public class TimeShift
{
    private int idWorker;
    private string idDay;
    private int start;
    private int end;

	public TimeShift(int worker,string day, int startsAt, int endsAt)
	{
        idWorker = worker;
        idDay = day;
        start = startsAt;
        end = endsAt;
	}

    public int GetIdWorker()
    {
        return this.idWorker;
    }

    public string GetIdDay()
    {
        return this.idDay;
    }

    public int GetStartHour()
    {
        return this.start;
    }

    public int GetEndHour()
    {
        return this.end;
    }


}