<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Page pg = new Page();
        string p = pg.Server.MapPath("~/App_Data/woodProject.accdb");

        itemS items1 = new itemS(p);
        Deals deals1 = new Deals(p);
        costumerS costumers1 = new costumerS(p);
        workerS workers1 = new workerS(p);
        dealDetailsS details = new dealDetailsS(p);
        Days days = new Days(p);
        PositionsS pos = new PositionsS(p);
        TimeShiftS time = new TimeShiftS(p);
        Application["cnt"] = 0;

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Cart crt = new Cart(Session.SessionID);

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
