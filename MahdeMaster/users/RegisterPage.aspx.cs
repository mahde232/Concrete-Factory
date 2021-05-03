using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_RegisterPage : System.Web.UI.Page
{
    bool yesErrors = false;
    bool referalError = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggedIn"] == "yes")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('You cant register while being logged in.');", true);
            PanelForRegister.Visible = false;
            alreadyLoggedInError.Visible = true;
            string url="<a href=" + "/MahdeMaster/Default.aspx" + ">here</a>";
            alreadyLoggedInError.Text = "Click " + url + " to be redirected to the main page.";
            //Response.Redirect("~/Default.aspx");
            //Response.AddHeader("REFRESH", "1;URL=~/Default.aspx");
        }
        PasswordErrorLabel.Visible = false;
        UsernameErrorLabel.Visible = false;
        NameErrorLabel.Visible = false;
        PhoneErrorLabel.Visible = false;
        EmailErrorLabel.Visible = false;
        SuccessLabel.Visible = false;
        ReferalCodeErrorLabel.Visible = false;
        if (!Page.IsPostBack)
        {
            PasswordErrorLabel.Visible = false;
            UsernameErrorLabel.Visible = false;
            NameErrorLabel.Visible = false;
            PhoneErrorLabel.Visible = false;
            EmailErrorLabel.Visible = false;
            SuccessLabel.Visible = false;
            ReferalCodeErrorLabel.Visible = false;
        }
        if (ChooseTypeListBox.SelectedValue == "Worker")
        {
            RegisterTable.Rows[6].Visible = false;
            RegisterTable.Rows[7].Visible = true;
            RegisterTable.Rows[2].Visible = true;
        }
        if (ChooseTypeListBox.SelectedValue == "Customer")
        {
            RegisterTable.Rows[6].Visible = true;
            RegisterTable.Rows[7].Visible = false;
            RegisterTable.Rows[2].Visible = false;
        }
    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        if (ChooseTypeListBox.SelectedValue == "Worker")
        {
            if (UsernameTextBox.Text.Trim() == "")
            {
                UsernameErrorLabel.Visible = true;
                UsernameErrorLabel.Text = "Username cannot be blank";
                yesErrors = true;
            }
            if (Workers.IsNameUsed(UsernameTextBox.Text) == true)
            {
                UsernameErrorLabel.Visible = true;
                UsernameErrorLabel.Text = "The Username: " + UsernameTextBox.Text + " is already Taken, Please User Another";
                yesErrors = true;
            }
        }

        if (ChooseTypeListBox.SelectedValue == "Customer")
        {
            if (UsernameTextBox.Text.Trim() == "")
            {
                UsernameErrorLabel.Visible = true;
                UsernameErrorLabel.Text = "Username cannot be blank";
                yesErrors = true;
            }
            if (Costumers.IsNameUsed(UsernameTextBox.Text) == true)
            {
                UsernameErrorLabel.Visible = true;
                UsernameErrorLabel.Text = "The Username: " + UsernameTextBox.Text + " is already Taken, Please User Another";
                yesErrors = true;
            }

        }
        if (PasswordTextBox.Text.Trim().Length < 6)
        {
            PasswordErrorLabel.Visible = true;
            PasswordErrorLabel.Text = "Password is too short";
            yesErrors = true;
        }
        if (PasswordTextBox.Text.Trim() == "")
        {
            PasswordErrorLabel.Visible = true;
            PasswordErrorLabel.Text = "Password cannot be blank";
            yesErrors = true;
        }
        if (ReferalCodeTextBox.Text.Trim() == "" && ChooseTypeListBox.SelectedValue != "Customer")
        {
            ReferalCodeErrorLabel.Visible = true;
            ReferalCodeErrorLabel.Text = "Referal Code cannot be blank";
            yesErrors = true;
        }
        if (ReferalCodeTextBox.Text.Trim() != "Dani")
        {
            referalError = true;
            ReferalCodeErrorLabel.Visible = true;
            ReferalCodeErrorLabel.Text = "Referal Code is wrong";
        }
        if (NameTextBox.Text.Trim() == "")
        {
            NameErrorLabel.Visible = true;
            NameErrorLabel.Text = "Name cannot be blank";
            yesErrors = true;
        }
        if (PhoneTextBox.Text.Trim() == "")
        {
            PhoneErrorLabel.Visible = true;
            PhoneErrorLabel.Text = "Phone cannot be blank";
            yesErrors = true;
        }
        if (ChooseTypeListBox.SelectedValue == "Customer")
        {
            if (AssistiveMethods.CheckEmail(EmailTextBox.Text.Trim()) == false)
            {
                EmailErrorLabel.Visible = true;
                EmailErrorLabel.Text = "E-Mail Address isn't in correct format";
                yesErrors = true;
            }
        }
        if (ChooseTypeListBox.SelectedValue == "Worker" && yesErrors == false && ReferalCodeTextBox.Text.Trim()=="Dani")
        {
            Worker wrkr = new Worker(0, NameTextBox.Text, PhoneTextBox.Text, int.Parse(PositionsDropDown.SelectedValue.ToString()), 1, int.Parse(LocationDropDown.SelectedValue.ToString()), "NoPicture.png", UsernameTextBox.Text, PasswordTextBox.Text);
            Workers.Add1Worker(wrkr);
            SuccessLabel.Visible = true;
            SuccessLabel.Text = "You've successfully registered";
        }
        if (ChooseTypeListBox.SelectedValue == "Customer" && yesErrors == false)
        {
            Costumer cstmr = new Costumer(0, NameTextBox.Text, PhoneTextBox.Text, EmailTextBox.Text, int.Parse(LocationDropDown.SelectedValue.ToString()), "NoPicture.png", UsernameTextBox.Text, PasswordTextBox.Text);
            Costumers.Add1Costumer(cstmr);
            SuccessLabel.Visible = true;
            SuccessLabel.Text = "You've successfully registered";
        }
    }
    protected void ChooseTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelForRegister2.Visible = true;
        PositionsDropDown.DataSource = AssistiveMethods.GetAllPositions2();
        PositionsDropDown.DataTextField = "TafkedName";
        PositionsDropDown.DataValueField = "idTafked";
        PositionsDropDown.DataBind();

        LocationDropDown.DataSource = AssistiveMethods.GetAllLocations();
        LocationDropDown.DataTextField = "LocationName";
        LocationDropDown.DataValueField = "idLocation";
        LocationDropDown.DataBind();
    }
}