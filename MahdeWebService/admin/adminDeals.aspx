<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminDeals.aspx.cs" Inherits="admin_adminDeals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
        <tr>
        <asp:Button ID="return" runat="server" OnClick="ReturnToAdmin" Text="חזור" />
        </tr>
        <tr>
            <td>
            <asp:Label ID="yearLabel" runat="server" Text="שנה - " />
            <asp:DropDownList ID="yearDDL" runat="server" />

            <asp:Label ID="monthLabel" runat="server" Text="חודש - " />
            <asp:DropDownList ID="monthDDL" runat="server" />

            <asp:Label ID="dayLabel" runat="server" Text="יום - " />
            <asp:DropDownList ID="dayDDL" runat="server" />
            </td>
            
            <td>
            <asp:Button ID="search" runat="server" OnClick="SearchDate" Text="חפש לפי התאריך" /> 
            </td>
        </tr>

        <tr>
            <td>
            <asp:Label ID="customerT" runat="server" Text="שם הלקוח - " />
            <asp:DropDownList ID="customerD" runat="server" /> 
            </td>
            <td>
            <asp:Button ID="search2" runat="server" OnClick="SearchCustomer" Text="חפש לפי לקוח" />
            </td>
        </tr>

        <tr>
            <td>
            </td>
        
            <td>
            <asp:Button ID="Button1" runat="server" OnClick="SearchCustomerandDate" Text="חפש לפי לקוח ותאריך" />
            </td>
        </tr>
   </table>
   <br /><br />
<center>
<asp:Label ID="NoResults" runat="server" Text="לא התקימה אף עסקה בתאריך זה" 
        Visible="false" Font-Bold="true" Font-Italic="true" Font-Size="12" ForeColor="Blue" 
        style="text-align: center"/> </center> <br />

        
<p dir="ltr">
<asp:DataGrid ID="dataGrid1" runat="server" BackColor="White" visible="false"
        BorderColor="#999999" AutoGenerateColumns="false"
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

    <asp:BoundColumn DataField="idDeal" HeaderText="מס. עסקה"/>

    <asp:TemplateColumn HeaderText="מוכר">
    <ItemTemplate>
    <asp:Label ID="label1" runat="server"

    Text= '<%# ConvertIdWorker(DataBinder.Eval(Container.DataItem,"idWorkerSeller")) %>'
    />
    </ItemTemplate>
    </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="שם לקוח">
    <ItemTemplate>
    <asp:Label ID="label2" runat="server"

    Text= '<%# ConvertIdCostumer(DataBinder.Eval(Container.DataItem,"idCostumer")) %>'
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
            <ItemTemplate><a href=adminDeals.aspx?idDeal=<%# DataBinder.Eval(Container, "DataItem.idDeal") %>&idKone=<%# DataBinder.Eval(Container, "DataItem.idCostumer") %>>
                <asp:Label ID="Label3" runat="server" 
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
</p>
</asp:Content>

