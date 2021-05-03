using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for worker
/// </summary>
public class worker
{
    private int id, salary, position;
    private string name, telephone;
    private bool deleted;
    private object p;
    private string phone;
    private bool delete;

	public worker(int id, int salary, int position, string name, string telephone, bool delete)
	{
        this.id = id;
        this.salary = salary;
        this.position = position;
        this.name = name;
        this.telephone = telephone;
        this.deleted = delete;
	}

    public worker(object p, int salary, int position, string name, string phone, bool delete)
    {
        // TODO: Complete member initialization
        this.p = p;
        this.salary = salary;
        this.position = position;
        this.name = name;
        this.phone = phone;
        this.delete = delete;
    }

    public int GetId()
    {
        return this.id;
    }
    public int GetSalary()
    {
        return this.salary;
    }
    public int GetPosition()
    {
        return this.position;
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetTelephone()
    {
        return this.telephone;
    }
    public bool GetDeleted()
    {
        return this.deleted;
    }
}