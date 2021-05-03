<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="users_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="ConfirmPassed" runat="server" Visible="true">
<br /><br /><br />
<%--טבלת הרשמות--%>
<table id="RegisterTable" runat="server" dir="rtl" align="center" >

    <%--שם פרטי--%>
    <tr>
        <td>
        <asp:Label ID="FirstNameLabel" runat="server" Text="שם פרטי" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="FirstNameTextBox" runat="server" />
        </td>

        <td>
        <asp:Label ID="ErrorFirstName" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--שם משפחה--%>
    <tr>
        <td>
        <asp:Label ID="LastNameLabel" runat="server" Text="שם משפחה" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="LastNameTextBox" runat="server" />
        </td>
        
        <td>
        <asp:Label ID="ErrorLastName" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td> 
    </tr>

    <%--שם חשבון--%>
    <tr>
        <td>
        <asp:Label ID="AccountNameLable" runat="server" Text="שם חשבון" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="AccountNameTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorAccountName" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--קוד משתמש--%>
    <tr>
        <td>
        <asp:Label ID="PassWordLabel" runat="server" Text="קוד משתמש" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="PassWordTextBox" runat="server" TextMode="Password" />
        </td> 

        <td>
        <asp:Label ID="ErrorPassword" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--דואר אלקטרוני--%>
    <tr>
        <td>
        <asp:Label ID="EmailLable" runat="server" Text="דואר אלקטרוני" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="EmailTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorEmail" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--מספר פלפון--%>
    <tr>
        <td>
        <asp:Label ID="PhoneNumberLabel" runat="server" Text="מספר פלפון" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="PhoneNumberTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorPhone" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--ארץ--%>
    <tr>
        <td>
        <asp:Label ID="CountryLabel" runat="server" Text="ארץ" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="CountryTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorCountry" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--עיר--%>
    <tr>
        <td>
        <asp:Label ID="CityLabel" runat="server" Text="עיר" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="CityTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorCity" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--כתובת--%>
    <tr>
        <td>
        <asp:Label ID="AddressLabel" runat="server" Text="כתובת" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:TextBox ID="AddressTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorAddress" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <%--סוג הלקוח--%>
    <tr>
        <td>
        <asp:Label ID="Label4" runat="server" Text="סוג הלקוח" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0"/>
        </td>

        <td>
        <asp:DropDownList ID="KindOfCustomerDDR" runat="server" >
        <asp:ListItem Text="קבלן" Value="1" />
        <asp:ListItem Text="פרטי" Value="2" />
        </asp:DropDownList>
        </td> 
    </tr>

    <%--סוג העבודה--%>
    <tr>
        <td>
        <asp:Label ID="KindOfWorkLabel" runat="server" Text="סוג העבודה" ForeColor="#0000cc" Font-Bold="true" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="KindOfWorkTextBox" runat="server" />
        </td> 

        <td>
        <asp:Label ID="ErrorKOW" runat="server" Visible="false" ForeColor="#ff0000" BackColor="#c0c0c0"/>
        </td>
    </tr>

    <tr>
        <td colspan="2" valign="baseline" align="center">
        <asp:Button ID="RegisterButton" runat="server" Text="הירשם" OnClick="RegisterToNet" align="center" />
        </td>
    </tr>
</table>
</asp:Panel>
</asp:Content>

