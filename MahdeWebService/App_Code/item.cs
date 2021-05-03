using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

public class item
{
    double length, width, cost;
    int type, sellType, name, id;

    public item()
    { }

    public item(int id, double len, double wid, double cost, int type, int sell, int name)
    {
        this.cost = cost;
        this.length = len;
        this.width = wid;
        this.type = type;
        this.sellType = sell;
        this.name = name;
        this.id = id;
    }

    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public int SellType
    {
        get
        {
            return sellType;
        }
        set
        {
            this.sellType = value;
        }
    }
    public int Name
    {
        get
        {
            return name;
        }
        set
        {
            this.name = value;
        }
    }
    public double Length
    {
        get
        {
            return length;
        }
        set
        {
            this.length = value;
        }
    }
    public double Width
    {
        get
        {
            return width;
        }
        set
        {
            this.width = value;
        }
    }
    public double Cost
    {
        get
        {
            return cost;
        }
        set
        {
            this.cost = value;
        }
    }
    public int Type
    {
        get
        {
            return type;
        }
        set
        {
            this.type = value;
        }
    }
}