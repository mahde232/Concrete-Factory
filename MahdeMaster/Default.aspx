<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel runat="server" ID="profilePanel" Visible="false">
<asp:Label Text="User-Profile:" runat="server" Font-Bold="true" Font-Size="Medium" BackColor="AntiqueWhite"></asp:Label>
<asp:Table ID="profileTable" runat="server">

<asp:TableRow>
<asp:TableCell>
<asp:Label ID="userName" Text="Name: " runat="server"></asp:Label>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:Label ID="phoneNumber" Text="Phone: " runat="server"></asp:Label>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:Label ID="email" Text="E-Mail: " runat="server"></asp:Label>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:Label ID="location" Text="Location: " runat="server"></asp:Label>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:Label Text="Picture" runat="server"></asp:Label>
<br />
<asp:Image runat="server" ID="userPicture" Width="100" Height="100" />
</asp:TableCell>
</asp:TableRow>

</asp:Table>

</asp:Panel>

<asp:Panel runat="server" ID="adminPanel" Visible="false">

<asp:Label ID="Label1" Text="Admin-Panel:" runat="server" Font-Bold="true" Font-Size="Medium" BackColor="Red"></asp:Label>
<asp:Table ID="adminTable" runat="server">

<asp:TableRow>
<asp:TableCell>
<asp:HyperLink runat="server" NavigateUrl="~/admin/Add1Customer.aspx" Text="Add Customers"></asp:HyperLink>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:HyperLink runat="server" NavigateUrl="~/admin/Add1Worker.aspx" Text="Add Workers"></asp:HyperLink>
</asp:TableCell>
</asp:TableRow>

<asp:TableRow>
<asp:TableCell>
<asp:HyperLink runat="server" NavigateUrl="~/admin/Add1Order.aspx" Text="Add Orders"></asp:HyperLink>
</asp:TableCell>
</asp:TableRow>


</asp:Table>
</asp:Panel>



</asp:Content>

