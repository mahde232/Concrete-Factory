using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for seller
/// </summary>
public class seller
{
    private string name;
    private string phone;
    private string company;
    private string notes;
    private int id;

	public seller(string SellerName, string SellerPhone, string comp, string note, int id)
	{
        this.name = SellerName;
        this.phone = SellerPhone;
        this.company = comp;
        this.notes = note;
        this.id = id;
	}

    public string GetName()
    {
        return name;
    }

    public string GetPhone()
    {
        return phone;
    }

    public string GetNotes()
    {
        return notes;
    }

    public string GetCompany()
    {
        return company;
    }

    public int GetId()
    {
        return id;
    }
}