<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="costumerDeals.aspx.cs" Inherits="users_costumerDeals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:DataGrid ID="dataGrid1" runat="server" BackColor="White" Visible="false"
        BorderColor="#999999"  AutoGenerateColumns="false"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  
        Width="55%" align="Right">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

    <Columns>
    <asp:BoundColumn DataField="idDeal" HeaderText="מס. עסקה" />

    <asp:TemplateColumn>
        <HeaderTemplate >שם המכרן</HeaderTemplate>
         <ItemTemplate>
          <asp:Label ID="Label3" runat="server" 
       
       Text='<%# ConvertIdWorker(DataBinder.Eval(Container.DataItem,"idWorkerSeller")) %>'
          />
       
          </ItemTemplate>
    </asp:TemplateColumn>
    <asp:TemplateColumn HeaderText="תאריך העסקה">
    <ItemTemplate>
    <asp:Label ID="label2" runat="server"

    Text= '<%# (DataBinder.Eval(Container.DataItem,"deliveryTime","{0:d}")) %>'
    />
    </ItemTemplate>
    </asp:TemplateColumn>  
    <asp:BoundColumn DataField="payment" HeaderText="מחיר" />

    <asp:TemplateColumn HeaderText="פרטי עסקה">           
            <ItemTemplate><a href=costumerDeals.aspx?idDeal=<%# DataBinder.Eval(Container, "DataItem.idDeal") %>&idKone=<%# DataBinder.Eval(Container, "DataItem.idCostumer") %>>
                <asp:Label runat="server" 
                    Text="ראה"></asp:Label></a>
            </ItemTemplate>
     </asp:TemplateColumn>
    </Columns>
    </asp:DataGrid>

<asp:DataGrid  Visible="false" ID="dataGrid2" runat="server" BackColor="White" BorderColor="#999999"  AutoGenerateColumns="false"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Width="45%" align="left">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

    <Columns>
    
        <asp:BoundColumn DataField="units" HeaderText="מס. יחידות" />
        <asp:BoundColumn DataField="idItem_X2" HeaderText="מוצר" />       
        <asp:BoundColumn DataField="costPerOne" HeaderText="מחיר יחידה" />
        <asp:BoundColumn DataField="total" HeaderText="מחיר כולל" />

    </Columns>
  </asp:DataGrid>

</asp:Content>

