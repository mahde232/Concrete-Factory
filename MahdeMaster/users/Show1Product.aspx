<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show1Product.aspx.cs" Inherits="users_Show1Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     Product details<br />

    <table>
    <tr>
    <td>
    <asp:Table ID="tbl" runat="server">
    <asp:TableRow>
    <asp:TableCell>id</asp:TableCell>
    <asp:TableCell><asp:Label ID="LabelID" runat="server" Text="LabelID"/></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Name:</asp:TableCell><asp:TableCell><asp:Label ID="LabelName" runat="server" Text="LabelName"></asp:Label></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Price (per one):</asp:TableCell><asp:TableCell><asp:Label ID="LabelPrice" runat="server" Text="LabelPrice"></asp:Label></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    </asp:Table>
    </td>


    <td>
    <asp:Table ID="tblAdmin" runat="Server" Visible="false">

    <asp:TableRow>
    <asp:TableCell>id</asp:TableCell>
    <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Not changeable"></asp:Label></asp:TableCell>
    <asp:TableCell></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>New Name:</asp:TableCell>
    <asp:TableCell><asp:TextBox ID="NewNameTextBox" runat="server"></asp:TextBox></asp:TableCell>
    <asp:TableCell></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>New Price (per one):</asp:TableCell><asp:TableCell><asp:TextBox ID="NewPriceTextBox" runat="server"></asp:TextBox></asp:TableCell>
    </asp:TableRow>


    <asp:TableRow>
    <asp:TableCell><asp:Button ID="Update" runat="server" Text="Update" onclick="Update_Click" Visible="false" /></asp:TableCell>
    </asp:TableRow>

    </asp:Table>
    </td>
    </tr>
    </table>

    <br />   <input onclick="history.back()" type="button" value="Back" /><br />


</asp:Content>

