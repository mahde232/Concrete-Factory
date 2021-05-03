using System;
using System.Collections.Generic;
using System.Web;

public class Product
{
    private int idProduct;
    private string productName;
    private double productPricePerOne;

    public Product()
    { }
    public Product(int idProduct, string productName, double productPricePerOne)
    {
        this.idProduct = idProduct;
        this.productName = productName;
        this.productPricePerOne = productPricePerOne;
    }

    ///////////////////////

    public int ProductId
    {
        get
        { return this.idProduct; }
        set
        { this.idProduct = value; }
    }

    public int GetProductId()
    {
        return this.idProduct;
    }

    ///////////////////////

    public string ProductName
    {
        get
        { return this.productName; }
        set
        { this.productName = value; }
    }

    public string GetProductName()
    {
        return this.productName;
    }
    public void SetProductName(string newName)
    {
        this.productName = newName;
    }

    ///////////////////////

    public double PricePerOne
    {
        get
        { return this.productPricePerOne; }
        set
        { this.productPricePerOne = value; }
    }

    public double GetPricePerOne()
    {
        return this.productPricePerOne;
    }
    public void SetPricePerOne(double newPrice)
    {
        this.productPricePerOne = newPrice;
    }
}