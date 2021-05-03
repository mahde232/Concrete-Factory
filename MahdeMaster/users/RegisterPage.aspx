<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterPage.aspx.cs" Inherits="users_RegisterPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label runat="server" ID="alreadyLoggedInError" Visible="false"></asp:Label>
    <asp:Panel runat="server" ID="PanelForRegister">
    <br />
    <br />
    <asp:Label runat="server" Text="Which of these are you?"></asp:Label>
    <br />
    <asp:ListBox runat="server" ID="ChooseTypeListBox" Height="36" 
            onselectedindexchanged="ChooseTypeListBox_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Value="Worker">
    </asp:ListItem>
    <asp:ListItem Value="Customer">
    </asp:ListItem>
    </asp:ListBox>


    <br />
    <br />
    <asp:Panel runat="server" ID="PanelForRegister2" Visible="false">
    <asp:Table ID="RegisterTable" runat="server">

    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="UsernameErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="PasswordErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow Visible="false">
    <asp:TableCell>
    <asp:Label ID="ReferalCodeLabel" runat="server" Text="Referal Code:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="ReferalCodeTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="ReferalCodeErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="NameLabel" runat="server" Text="Full Name:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="NameErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="PhoneLabel" runat="server" Text="Phone Number:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="PhoneErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="LocationLabel" runat="server" Text="Location:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:DropDownList ID="LocationDropDown" runat="server">
    </asp:DropDownList>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow Visible="false">
    <asp:TableCell>
    <asp:Label ID="EmailLabel" runat="server" Text="E-Mail Address:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
    <asp:Label ID="EmailErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow Visible="false">
    <asp:TableCell>
    <asp:Label ID="PositionLabel" runat="server" Text="Position:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:DropDownList ID="PositionsDropDown" runat="server">
    </asp:DropDownList>
    </asp:TableCell>
    </asp:TableRow>

    </asp:Table>
    <asp:Button ID="RegisterButton" runat="server" Text="Register" onclick="RegisterButton_Click" />
    <asp:Label ID="SuccessLabel" runat="server" Visible="false" BackColor="Yellow"></asp:Label>
    </asp:Panel>
        </asp:Panel>
















</asp:Content>
