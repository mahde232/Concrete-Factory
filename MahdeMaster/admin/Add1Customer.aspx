<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add1Customer.aspx.cs" Inherits="admin_Add1Customer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Label runat="server" Text="This is for adding customers using admin state." ForeColor="Green" BackColor="Salmon"></asp:Label>

<asp:Table ID="Table1" runat="server">

<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Costumer Name:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="NameTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Costumer Phone:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="PhoneTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Costumer E-Mail:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="EmailTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Location:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:DropDownList runat="server" ID="LocationsDropDown"></asp:DropDownList>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Picture:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:FileUpload runat="server" ID="PictureUpload" />
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Username:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="SpecialIDTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


<asp:TableRow>
<asp:TableCell>
<asp:Label runat="server" Text="Password:"></asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox runat="server" ID="LoginPassTextBox"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>


</asp:Table>

<asp:Button runat="server" ID="AddCostumerButton" Text="Add Costumer" 
        onclick="AddCostumerButton_Click" />
        
<asp:Label runat="server" ID="SuccessLabel" BackColor="Green"></asp:Label>


</asp:Content>

