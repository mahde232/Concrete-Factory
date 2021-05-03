<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add1Order.aspx.cs" Inherits="admin_Add1Order" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Label runat="server" Text="This is for adding orders using admin state." ForeColor="Green" BackColor="Salmon"></asp:Label>

<asp:Table ID="Table1" runat="server">

<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Costumer Name:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:DropDownList runat="server" ID="costumersDropDown"></asp:DropDownList>
</asp:TableCell>
<asp:TableCell>
<asp:LinkButton runat="server" Text="Add a new costumer" PostBackUrl="~/admin/Add1Customer.aspx"></asp:LinkButton>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Date of order:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" Text="Year" ID="DateYearTextBox"></asp:TextBox>
</br>
<asp:TextBox runat="server" Text="Month" ID="DateMonthTextBox"></asp:TextBox>
</br>
<asp:TextBox runat="server" Text="Day" ID="DateDayTextBox"></asp:TextBox>
</br>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Order type:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:DropDownList runat="server" ID="OrderTypeDropDown"></asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Amount:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="AmountTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Actual Price:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="ActualPriceTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Destination:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:DropDownList runat="server" ID="LocationsDropDown"></asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Worker involved:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<<asp:DropDownList runat="server" ID="WorkersDropDown"></asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


</asp:Table>

<asp:Button runat="server" ID="AddOrderrButton" Text="Add Order" 
        onclick="AddOrderButton_Click" />
        
<asp:Label runat="server" ID="SuccessLabel" BackColor="Green"></asp:Label>

</asp:Content>


