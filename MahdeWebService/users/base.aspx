<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="base.aspx.cs" Inherits="users_base" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center >
<br />
<asp:Label Text="תושבות" ID="screwsLabel" runat="server" Font-Italic="true" Font-Size="20" Font-Bold="true" ForeColor="Blue" Font-Underline="true"/> <br /> <br />
<asp:Label Text="תבחר סוג התושבת -" ID="Label3" runat="server" Font-Italic="true" Font-Size="12" /> <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack=true OnSelectedIndexChanged="DPL1changed" /> <br />
<asp:Label Text="- המכירה לפי יחידה אחת -" ID="Label4" runat="server" Font-Italic="true" Font-Size="12"/> <br /><br />

<asp:Label Text="המוצר הזה אינו קיים במלאי כרגע" runat="server" ID="Label1" Visible=false />

<asp:DataGrid ID="DataGrid1" runat="server" BackColor="White" BorderColor="#999999"  AutoGenerateColumns=false
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Width="100%">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

    <Columns>

        <asp:TemplateColumn>
            <HeaderTemplate >קוד המוצר</HeaderTemplate>
            <ItemTemplate>
            <asp:Label ID="Label3" runat="server" 
       
            Text='<%# ConvertIdItem(DataBinder.Eval(Container.DataItem,"idItem")) %>'
          />
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:BoundColumn DataField="cost" HeaderText="מחיר ב-שח" />
        <asp:BoundColumn DataField="wid_cm" HeaderText="עובי הלוח" />
        <asp:BoundColumn DataField="len_cm" HeaderText="רוחב הלוח" />

    </Columns>

    </asp:DataGrid>
</center>
</asp:Content>

