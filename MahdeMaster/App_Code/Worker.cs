using System;
using System.Collections.Generic;
using System.Text;


public class Worker
{
    private int workerId;
    private string workerName;
    private string workerPhone;
    private int workerPosition;
    private int vehicleOwned;
    private int yeshov;
    private string picture;
    private string specialID;
    private string loginPass;

    public Worker(int id, string name, string workerPhone, int workerPosition, int vehicleOwned, int yeshov, string picture,string specialID, string loginPass)
    {
        this.workerId = id;
        this.workerName = name;
        this.workerPhone = workerPhone;
        this.workerPosition = workerPosition;
        this.vehicleOwned = vehicleOwned;
        this.yeshov = yeshov;
        this.picture = picture;
        this.specialID = specialID;
        this.loginPass = loginPass;
    }
    public int GetWorkerId()
    {
        return this.workerId;
    }
    public string GetWorkerName()
    {
        return this.workerName;
    }
    public void SetWorkerName(string name)
    {
        this.workerName = name;
    }
    public string GetWorkerPhone()
    {
        return this.workerPhone;
    }
    public void SetWorkerPhone(string num)
    {
        this.workerPhone = num;
    }
    public int GetWorkerPosition()
    {
        return this.workerPosition;
    }
    public void SetWorkerPosition(int workerPosition)
    {
        this.workerPosition = workerPosition;
    }
    public int GetWorkerVehicle()
    {
        return this.vehicleOwned;
    }
    public void SetWorkerVehicle(int vehicleOwned)
    {
        this.vehicleOwned = vehicleOwned;
    }
    public int GetWorkerLocation()
    {
        return this.yeshov;
    }
    public void SetWorkerLocation(int yeshov)
    {
        this.yeshov = yeshov;
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

