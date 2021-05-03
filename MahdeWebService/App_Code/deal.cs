using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for deal
/// </summary>
public class deal
{
    private int idWorker, idCostumer;
    private DateTime deliveryTime;

    public deal(int idWorker, int idCostumer, int year, int month, int day)
	{
        this.idCostumer = idCostumer;
        this.idWorker = idWorker;
        this.deliveryTime = new DateTime(year,month,day);
	}

    public int GetIdWorker()
    {
        return this.idWorker;
    }
    public int GetIdCostumer()
    {
        return this.idCostumer;
    }
    public DateTime GetDeliviryTimer()
    {
        return this.deliveryTime;
    }
}