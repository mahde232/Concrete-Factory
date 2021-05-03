using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminWorkers : System.Web.UI.Page
{
    DataSet ds,ds2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack || Request["worker"]!=null)
        {
            DataSet dWorkers = workerS.GetAllWorkers();

            for (int i = 0; i < dWorkers.Tables[0].Rows.Count; i++)
            {
                if (!(bool)dWorkers.Tables[0].Rows[i][5])
                {
                    ListItem add = new ListItem(dWorkers.Tables[0].Rows[i][1].ToString(), dWorkers.Tables[0].Rows[i][0].ToString());
                    workers.Items.Add(add);
                }
                else
                {
                    ListItem add = new ListItem(dWorkers.Tables[0].Rows[i][1].ToString(), dWorkers.Tables[0].Rows[i][0].ToString());
                    deletedWorkers.Items.Add(add);
                }
            }

            dayDDL.DataSource = Days.GetDays();
            dayDDL.DataTextField = "DayName";
            dayDDL.DataValueField = "idDay";
            dayDDL.DataBind();

            positionDDL.DataSource = PositionsS.GetAllPositions();
            positionDDL.DataTextField = "positionType";
            positionDDL.DataValueField = "idPositions";
            positionDDL.DataBind();

            DropDownList2.DataSource = PositionsS.GetAllPositions();
            DropDownList2.DataTextField = "positionType";
            DropDownList2.DataValueField = "idPositions";
            DropDownList2.DataBind();

            ds = workerS.GetAllWorkers();

            panel2.Visible = false;
            dataGrid2.Visible = false;

            if (Request["worker"] != null)
            {
                ds = workerS.GetWorkersById((object)(Request["worker"]));
                ds2 = workerS.GetWorkerTimeShifts((object)(Request["worker"]));

                panel2.Visible = true;


                idL.Text = ds.Tables[0].Rows[0][0].ToString();
                nameL.Text = ds.Tables[0].Rows[0][1].ToString();
                positionL.Text = (ConvertIdPosition(ds.Tables[0].Rows[0][2]));
                positionDDL.SelectedValue = ds.Tables[0].Rows[0][2].ToString();
                telephoneL.Text = ds.Tables[0].Rows[0][3].ToString();
                salaryL.Text = ds.Tables[0].Rows[0][4].ToString();

                dataGrid2.DataSource = ds2;
                dataGrid2.DataBind();
                dataGrid2.Visible = true;
            }
        }
        else
        {
           
            ds = workerS.GetWorkersById(workers.Items[workers.SelectedIndex].Value);
            ds2 = workerS.GetWorkerTimeShifts(workers.Items[workers.SelectedIndex].Value);
            
            panel2.Visible = true;


            idL.Text = ds.Tables[0].Rows[0][0].ToString();
            nameL.Text = ds.Tables[0].Rows[0][1].ToString();
            positionL.Text = (ConvertIdPosition(ds.Tables[0].Rows[0][2]));
            positionDDL.SelectedValue = ds.Tables[0].Rows[0][2].ToString();
            telephoneL.Text = ds.Tables[0].Rows[0][3].ToString();
            salaryL.Text = ds.Tables[0].Rows[0][4].ToString();

            dataGrid2.DataSource = ds2;
            dataGrid2.DataBind();
            dataGrid2.Visible = true;
        }

        dataGrid1.DataSource = ds;
        dataGrid1.DataBind();
        
    }

    protected void ReturnToAdmin(object sender, EventArgs e)
    {
        Response.Redirect("../admin/adminOptions.aspx");
    }

    protected void UpdateWorker(object sender, EventArgs e)
    {
        int id = int.Parse(idL.Text);
        string name;
        int position;
        string telephone;
        int salary;

        if (nameT.Text == "")
            name = nameL.Text;
        else
            name = nameT.Text;

        position = int.Parse(positionDDL.Items[positionDDL.SelectedIndex].Value.ToString());

        if (teleT.Text == "")
            telephone = telephoneL.Text;
        else
            telephone = teleT.Text;

        if (salaryT.Text == "")
            salary = int.Parse(salaryL.Text);
        else
            salary = int.Parse(salaryT.Text);

        worker update = new worker(id,salary,position,name,telephone,false);
        workerS.UpdateWorker(update, false);

        ds = workerS.GetWorkersById(workers.Items[workers.SelectedIndex].Value);

        idL.Text = ds.Tables[0].Rows[0][0].ToString();
        nameL.Text = ds.Tables[0].Rows[0][1].ToString();
        positionL.Text = (ConvertIdPosition(ds.Tables[0].Rows[0][2]));
        telephoneL.Text = ds.Tables[0].Rows[0][3].ToString();
        salaryL.Text = ds.Tables[0].Rows[0][4].ToString();

        dataGrid1.DataSource = ds;
        dataGrid1.DataBind();
    }

    protected string ConvertIdPosition(object sender)
    {
        return (workerS.GetWorkerPosition(sender.ToString())).Tables[0].Rows[0][0].ToString();
    }

    protected void Add1Day(object sender, EventArgs e)
    {
        TimeShift day = new TimeShift(int.Parse(idL.Text), (dayDDL.Items[dayDDL.SelectedIndex].Text),
            int.Parse(hourST.Text), int.Parse(hourET.Text));

        Days.AddDay(day);

        ds2 = workerS.GetWorkerTimeShifts(workers.Items[workers.SelectedIndex].Value);
        dataGrid2.DataSource = ds2;
        dataGrid2.DataBind();
        dataGrid2.Visible = true;
    }

    protected void addPart1(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        dataGrid2.Visible = false;
        adding.Visible = true;
    }
    protected void addPart2(object sender, EventArgs e)
    {
        string name, phone;
        int position, salary;
        bool delete = false;

        name = TextBox1.Text;
        position = int.Parse(DropDownList2.Items[DropDownList2.SelectedIndex].Value);
        phone = TextBox3.Text;
        salary = int.Parse(TextBox5.Text);

        worker worker = new worker(0, salary, position, name, phone,delete);
        workerS.add1Worker(worker);
        Response.Redirect("adminWorkers.aspx");
    }

    protected void Delete1Worker(object sender, EventArgs e)
    {
        int id = int.Parse(idL.Text);
        string name;
        int position;
        string telephone;
        int salary;

        name = nameL.Text;
        position = int.Parse(positionDDL.Items[positionDDL.SelectedIndex].Value.ToString());
        telephone = telephoneL.Text;
        salary = int.Parse(salaryL.Text);

        worker update = new worker(id, salary, position, name, telephone, true);
        workerS.UpdateWorker(update, true);
        Response.Redirect("adminWorkers.aspx");
    }

    protected void ReturnWorker(object sender, EventArgs e)
    {
        DataSet worker2return = workerS.GetWorkersById(deletedWorkers.Items[deletedWorkers.SelectedIndex].Value);

        int id = int.Parse(worker2return.Tables[0].Rows[0][0].ToString());
        string name;
        int position;
        string telephone;
        int salary;

        name = worker2return.Tables[0].Rows[0][1].ToString();
        position = int.Parse(worker2return.Tables[0].Rows[0][2].ToString());
        telephone = worker2return.Tables[0].Rows[0][3].ToString();
        salary = int.Parse(worker2return.Tables[0].Rows[0][4].ToString());

        worker update = new worker(id, salary, position, name, telephone, false);
        workerS.UpdateWorker(update, false);
        Response.Redirect("adminWorkers.aspx");
    }

    protected void Update(object source, DataGridCommandEventArgs e)
    {
        Label label = new Label();
        string key = dataGrid1.DataKeys[e.Item.ItemIndex].ToString();
        label.Text = key;
       
        TextBox tb;
        string day, st, en;

        tb = (TextBox)(e.Item.Cells[3].Controls[1]);
        day = tb.Text;

        tb = (TextBox)(e.Item.Cells[4].Controls[1]);
        st = tb.Text;

        tb = (TextBox)(e.Item.Cells[5].Controls[1]);
        en = tb.Text;

        TimeShift tm = new TimeShift(int.Parse(idL.Text), day, int.Parse(st), int.Parse(en));
        TimeShiftS.UpdateTime(tm, key);

        dataGrid2.EditItemIndex = -1;

        dataGrid2.DataSource = ds2;
        dataGrid2.DataBind();
    }
    protected void Edit(object source, DataGridCommandEventArgs e)
    {
        dataGrid2.EditItemIndex = e.Item.ItemIndex;
        dataGrid2.DataBind();
    }
    protected void Cancel(object source, DataGridCommandEventArgs e)
    {
        dataGrid2.EditItemIndex = -1;
        dataGrid2.DataBind();
    }
    protected void Close(object sender, EventArgs e)
    {
        dataGrid2.EditItemIndex = -1;
        dataGrid2.DataBind();
    }
}