<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show1Customer.aspx.cs" Inherits="users_Show1Customer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     Customer details<br />

    <br />
    <table>
    <tr>
    <td>

    
    <asp:Table ID="tbl" runat="server">
    <asp:TableRow>
    <asp:TableCell>id</asp:TableCell>
    <asp:TableCell><asp:Label ID="LabelID" runat="server" Text="LabelID"/></asp:TableCell><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Name:</asp:TableCell><asp:TableCell><asp:Label ID="LabelName" runat="server" Text="LabelName"></asp:Label></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Phone-number:</asp:TableCell><asp:TableCell><asp:Label ID="LabelPhone" runat="server" Text="LabelPhone"></asp:Label></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>E-Mail:</asp:TableCell><asp:TableCell><asp:Label runat="server" id="LabelEmail" Text="LabelEmail"></asp:Label> </asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Location:</asp:TableCell><asp:TableCell><asp:Label ID="LabelLocation" runat="server" Text="location"></asp:Label>
    </asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>Picture:</asp:TableCell><asp:TableCell><asp:Image ID="imageForCustomer" runat="server" Width="120"/></asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>
              <br />
              <asp:Button ID="ordersShow" Text="Show orders for this customer" runat="server" onclick="ordersShow_Click" />
              <br />
    </asp:TableCell></asp:TableRow></asp:Table></td><td>
    <asp:Table ID="adminTbl" runat="server" Visible="false">
    
    <asp:TableRow>
    <asp:TableCell>id</asp:TableCell><asp:TableCell><asp:Label runat="server" Text="Un-Changeable"></asp:Label></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>New Name:</asp:TableCell><asp:TableCell><asp:TextBox ID="NewNameTextBox" runat="server"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>New Phone-number:</asp:TableCell><asp:TableCell><asp:TextBox ID="NewPhoneTextBox" runat="server"></asp:TextBox>
    </asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>New Email:</asp:TableCell><asp:TableCell><asp:TextBox ID="NewEmailTextBox" runat="server"></asp:TextBox></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>New Location:</asp:TableCell><asp:TableCell><asp:DropDownList ID="LocationsDropDown" runat="server"></asp:DropDownList></asp:TableCell><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>New Picture:</asp:TableCell><asp:TableCell><asp:FileUpload runat="server" ID="PictureUpload" /></asp:TableCell>
    <asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow><asp:TableRow>
    <asp:TableCell><asp:Button ID="Update" Text="Update" runat="server" onclick="Update_Click" Visible="false" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    </td></tr>
    </table>
    
    
    
    
    <asp:DataGrid ID="dataGridForEachCustomer" runat="Server" AutoGenerateColumns="false" Visible="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="324px">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        
        
        
        <Columns>
        
        <asp:BoundColumn HeaderText="reciept #" DataField="idOrder"></asp:BoundColumn>


        <asp:TemplateColumn HeaderText="Date">
        <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"DateOfOrder","{0:D}")) %>'></asp:Label></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="Product">
        <ItemTemplate>
        <asp:Label ID="Label3" runat="server" Text='<%# AssistiveMethods.GetProductNameById(DataBinder.Eval(Container,"DataItem.OrderTypeWanted"))%>'></asp:Label></ItemTemplate></asp:TemplateColumn><asp:BoundColumn HeaderText="Amount" DataField="Amount"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="Price" DataField="ActualPrice"></asp:BoundColumn>
        
        <asp:TemplateColumn HeaderText="Shipped to">
        <ItemTemplate>
        <asp:Label ID="Label4" runat="server" Text='<%# AssistiveMethods.GetYeshovNameById(DataBinder.Eval(Container,"DataItem.Distination"))%>'></asp:Label></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="Worker Involved">
        <ItemTemplate>
        <asp:Label ID="Label5" runat="server" Text='<%# (Workers.Get1Worker(""+DataBinder.Eval(Container,"DataItem.OvedDriver"))).GetWorkerName()%>'></asp:Label></ItemTemplate></asp:TemplateColumn></Columns></asp:DataGrid><br />    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label><br /> 

    
    <br />   <input onclick="history.back()" type="button" value="Back" /><br />
 

</asp:Content>

