<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminOptions.aspx.cs" Inherits="admin_adminOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
        <tr>
            <td>
            <asp:Label ID="Label1" runat="server" Text="מצב אדמין" visible ="False" BackColor="Red" Width="300px"/>
            <asp:Button ID="items" runat="server" Visible="true" Text="תפסי מוצרים" OnClick="UpdateItems" />
            <asp:Button ID="customers" runat="server" Visible="true" Text="לקוחות" OnClick="UpdateCustomers" />
            <asp:Button ID="workers" runat="server" Visible="true" Text="עובדים" OnClick="UpdateWorkers" />
            <asp:Button ID="deals" runat="server" Visible="true" Text="עסקאות" OnClick="UpdateDeals" />
            </td>
        </tr>
    </table>

</asp:Content>

