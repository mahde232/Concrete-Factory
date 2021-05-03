<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="users_LoginPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Table ID="tbl" runat="server">
    <asp:TableRow>
    <asp:TableCell>
    <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
    <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
    </asp:TableCell>
    <asp:TableCell>
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
    <asp:Label ID="ErrorLabel" runat="server" Visible="false" BackColor="Red"></asp:Label>
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Button ID="LoginButton" runat="server" Text="Login" onclick="LoginButton_Click" />
    <asp:Label ID="SuccessfulLoginLabel" runat="server" Visible="false" BackColor="Yellow"></asp:Label>
    <asp:Button ID="ContinueButton" runat="server" Text="Continue" OnClick="ContinueButton_Click" Visible="false" />


    <asp:Label ID="ErrorLabel2" runat="server" Visible="false" BackColor="Aqua"></asp:Label>
















</asp:Content>

