using System;
using System.Collections.Generic;
using System.Text;


public class Costumer
{
    private int idCostumer;
    private string costumerName;
    private string costumerPhone;
    private string customerEmail;
    private int customerLocation;
    private string picture;
    private string specialID;
    private string loginPass;

    public Costumer(int id, string name, string phone, string email, int locationID, string picture,string specialID ,string loginPass)
    {
        this.idCostumer = id;
        this.costumerName = name;
        this.costumerPhone = phone;
        this.customerEmail = email;
        this.customerLocation = locationID;
        this.picture = picture;
        this.specialID = specialID;
        this.loginPass = loginPass;
    }
    public int GetCostumerId()
    {
        return this.idCostumer;
    }
    public string GetCostumerName()
    {
        return this.costumerName;
    }
    public void SetCostumerName(string name)
    {
        this.costumerName = name;
    }
    public string GetPhoneNumber()
    {
        return this.costumerPhone;
    }
    public void SetPhoneNumber(string num)
    {
        this.costumerPhone = num;
    }
    public string GetEmail()
    {
        return this.customerEmail;
    }
    public void SetEmail(string email)
    {
        this.customerEmail = email;
    }
    public int GetCostumerLocation() 
    {
        return this.customerLocation;
    }
    public void SetCostumerLocation(int locationID)
    {
        this.customerLocation = locationID;
    }
    public string GetPicture()
    {
        return this.picture;
    }
    public void SetPicture(string picture)
    {
        this.picture = picture;
    }
    public string GetSpecialID()
    {
        return this.specialID;
    }
    public void SetSpecialID(string newID)
    {
        this.specialID = newID;
    }
    public string GetPass()
    {
        return this.loginPass;
    }
    public void SetPass(string newPass)
    {
        this.loginPass = newPass;
    }
}

