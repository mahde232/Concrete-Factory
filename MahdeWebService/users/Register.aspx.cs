using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;

public partial class users_Register : System.Web.UI.Page
{
    bool Errors = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorAccountName.Visible = false;
        ErrorAddress.Visible = false;
        ErrorCity.Visible = false;
        ErrorCountry.Visible = false;
        ErrorEmail.Visible = false;
        ErrorFirstName.Visible = false;
        ErrorKOW.Visible = false;
        ErrorLastName.Visible = false;
        ErrorPassword.Visible = false;
        ErrorPhone.Visible = false;

    }

    protected void RegisterToNet(object sender, EventArgs e)
    {
        string name = FirstNameTextBox.Text + LastNameTextBox.Text;
        string password = PassWordTextBox.Text;
        string telephone = PhoneNumberTextBox.Text.Trim();
        string isKblan = KindOfCustomerDDR.Items[KindOfCustomerDDR.SelectedIndex].Text;
        string work = KindOfWorkTextBox.Text;
        string email = EmailTextBox.Text.Trim();
        string city = CityTextBox.Text;
        string country = CountryTextBox.Text;
        string adress = AddressTextBox.Text;
        string account = AccountNameTextBox.Text;

        DataSet ds = costumerS.GetAllUsersByUserName(AccountNameTextBox.Text);
        if (ds.Tables[0].Rows.Count > 0 || AccountNameTextBox.Text.Trim() == "")
        {
            ErrorAccountName.Text = "שם משתמש כבר משומש או ריק";
            ErrorAccountName.Visible = true;
            Errors = true;
        }

        if (FirstNameTextBox.Text.Trim() == "")
        {
            ErrorFirstName.Text = "ריק";
            ErrorFirstName.Visible = true;
            Errors = true;
        }

        if (LastNameTextBox.Text.Trim() == "")
        {
            ErrorLastName.Text = "ריק";
            ErrorLastName.Visible = true;
            Errors = true;
        }


        if (PassWordTextBox.Text.Trim().Length <= 5 || PassWordTextBox.Text.Trim() == "")
        {
            ErrorPassword.Text = "קצר מדי";
            ErrorPassword.Visible = true;
            Errors = true;
        }

        if (CheckEmail(EmailTextBox.Text.Trim()) == false)
        {
            ErrorEmail.Visible = true;
            ErrorEmail.Text = "דואר אלקטרוני אינו חוקי";
            Errors = true;
        }

        if (PhoneNumberTextBox.Text.Trim().Length != 10)
        {
            ErrorPhone.Visible = true;
            ErrorPhone.Text = "קצר מדי";
            Errors = true;
        }

        if (CountryTextBox.Text.Trim() == "")
        {
            ErrorCountry.Visible = true;
            ErrorCountry.Text = "ריק";
            Errors = true;
        }

        if (CountryTextBox.Text.Trim() == "")
        {
            ErrorCountry.Visible = true;
            ErrorCountry.Text = "ריק";
            Errors = true;
        }

        if (CityTextBox.Text.Trim() == "")
        {
            ErrorCity.Visible = true;
            ErrorCity.Text = "ריק";
            Errors = true;
        }

        if (AddressTextBox.Text.Trim() == "")
        {
            ErrorAddress.Visible = true;
            ErrorAddress.Text = "ריק";
            Errors = true;
        }

        if (KindOfWorkTextBox.Text.Trim() == "")
        {
            ErrorKOW.Visible = true;
            ErrorKOW.Text = "ריק";
            Errors = true;
        }

        if (!Errors)
        {
            costumer addCustomer = new costumer(name, password, telephone, isKblan, work, email, city, country, adress, account);
            costumerS.Add1Customer(addCustomer);

            Response.Redirect("LoginOptions.aspx");
        }
    }

    static bool CheckEmail(string email)
    {
        if (Regex.IsMatch(email, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
        {
            return true;
        }
        return false;
    }
}