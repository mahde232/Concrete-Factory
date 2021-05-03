using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for costumer
/// </summary>
public class costumer
{   
    private int id;
	private string name;
    private string password;
    private string telephone;
    private string isKblan;
    private string work;
    private string email;
    private string city;
    private string country;
    private string adress;
    private string acount;

    public costumer(int id, string name, string password,string telephone, string kblan, string typeOfWork, string email,
        string city, string country, string adress, string account)
	{   
        this.name = name;
        this.password = password;
        this.telephone = telephone;
        this.isKblan = kblan;
        this.work = typeOfWork;
        this.email = email;
        this.city = city;
        this.country = country;
        this.adress = adress;
        this.acount = account;
        this.id = id;
	}

    public costumer(string name, string password, string telephone, string kblan, string typeOfWork, string email,
        string city, string country, string adress, string account)
    {
        this.name = name;
        this.password = password;
        this.telephone = telephone;
        this.isKblan = kblan;
        this.work = typeOfWork;
        this.email = email;
        this.city = city;
        this.country = country;
        this.adress = adress;
        this.acount = account;
    }

    public string GetName()
    {
        return name;
    }

    public string GetTelephone()
    {
        return telephone;
    }

    public string GetWork()
    {
        return this.isKblan;
    }

    public string GetTypeOfWork()
    {
        return work;
    }

    public int GetId()
    {
        return this.id;
    }

    public string GetEmail()
    {
        return email;
    }

    public string GetCountry()
    {
        return country;
    }

    public string GetCity()
    {
        return city;
    }

    public string GetAddress()
    {
        return adress;
    }

    public string GetPassword()
    {
        return password;
    }

    public string GetAccount()
    {
        return this.acount;
    }

}