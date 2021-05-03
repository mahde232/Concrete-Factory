<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminCustomer.aspx.cs" Inherits="admin_adminCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="panel1" runat="server">
 <table>
        <tr>
        <asp:Button ID="return" runat="server" OnClick="ReturnToAdmin" Text="חזור" />
        </tr>
        
        <tr>
            <td>
            <asp:Label ID="aslkd" runat="server" Text="לקוחות ->" />
            <asp:DropDownList ID="customers" runat="server" AutoPostBack="true" />
            <asp:Button ID="Update1Costumer" runat="server" OnClick="UpdateTheCustomer" Text="עדכן לקוח" />
            <asp:Button ID="search2" runat="server" OnClick="SearchCustomer" Text="חפש עסקה לפי לקוח" />
            </td>
        </tr>
 </table>
</asp:Panel>

<asp:Panel ID="panel2" runat="server">
 <table>
    <tr>
        <td>
        <asp:Label ID="id" runat="server" Text="זיהוי - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="idL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="name" runat="server" Text="שם לקוח - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="nameL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="nameT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="phone" runat="server" Text="מספר פלפון - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="phoneL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="phoneT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="kc" runat="server" Text="פרטי או קבלן - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="kcL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="kcT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="kw" runat="server" Text="עובד כ - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="kwL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="kwT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="country" runat="server" Text="מדינה - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="countryL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="countryT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="city" runat="server" Text="עיר או כפר - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="cityL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="cityT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="address" runat="server" Text="כתובת - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="addressL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="addressT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="account" runat="server" Text="חשבון - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="accountL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="accountT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="email" runat="server" Text="דואר אלקטרוני - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="emailL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="emailT" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="pass" runat="server" Text="סיסמה - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="passL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="passT" runat="server" />
        </td>
    </tr>

</table>
</asp:Panel>

<asp:Label ID="NoResults" runat="server" Text="לא התקימה אף עסקה בתאריך זה" 
        Visible="false" Font-Bold="true" Font-Italic="true" Font-Size="12" ForeColor="Blue" 
        style="text-align: center"/>

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
            <ItemTemplate><a href=adminCustomer.aspx?idDeal=<%# DataBinder.Eval(Container, "DataItem.idDeal") %>&idKone=<%# DataBinder.Eval(Container, "DataItem.idCostumer") %>>
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

