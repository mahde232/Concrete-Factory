using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private int idOrder;
    private string costumer;
    private DateTime dateOfOrder;
    private string orderTypeWanted;
    private double amount;
    private double actualPrice;
    private string distination;
    private string ovedDriver;

    public Order(int id, string costumer,DateTime dateOfOrder, string orderTypeWanted, double amount, double actualPrice, string distination, string ovedDriver)
    {
        this.idOrder = id;
        this.costumer = costumer;
        this.dateOfOrder = dateOfOrder;
        this.orderTypeWanted = orderTypeWanted;
        this.amount = amount;
        this.actualPrice = actualPrice;
        this.distination = distination;
        this.ovedDriver = ovedDriver;
    }

    public int GetOrderId()
    {
        return this.idOrder;
    }

    public DateTime GetDateOfOrder()
    {
        return this.dateOfOrder;
    }
    public void SetDateOfOrder(DateTime dateOfOrderNew)
    {
        this.dateOfOrder = dateOfOrderNew;
    }


    public string GetCostumerInvolved()
    {
        return this.costumer;
    }
    public void SetCostumerInvolved(string cstmrNew)
    {
        this.costumer = cstmrNew;
    }


    public string GetOrderTypeWanted()
    {
        return this.orderTypeWanted;
    }
    public void SetOrderTypeWanted(string newType)
    {
        this.orderTypeWanted = newType;
    }


    public double GetAmount()
    {
        return this.amount;
    }
    public void SetAmount(double newAmount)
    {
        this.amount = newAmount;
    }


    public double GetActualPrice()
    {
        return this.actualPrice;
    }
    public void SetActualPrice(double newActualPrice)
    {
        this.actualPrice = newActualPrice;
    }


    public string GetDistination()
    {
        return this.distination;
    }
    public void SetDistination(string newDistination)
    {
        this.distination = newDistination;
    }


    public string GetDriverOfOrder()
    {
        return this.ovedDriver;
    }
    public void SetDriverOfOrder(string newDriver)
    {
        this.ovedDriver = newDriver;
    }

}


