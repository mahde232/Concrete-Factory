<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="users_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table>
    <tr>
        <td>
            <br />
            <asp:Label Text="מוצרים" ID="itemsLabel" runat="server" Font-Italic="true" Font-Size="20" Font-Bold="true" ForeColor="Blue" Font-Underline="true"/> <br /> <br />
            <asp:Label Text="בחר סוג המוצר" ID="Label3" runat="server" Font-Italic="true" Font-Size="12"/>
            <asp:DropDownList runat="server" ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DPL1changed" /> <br />
            <asp:Label Text="בחר סוג הטיפול" ID="Label2" runat="server" Font-Italic="true" Font-Size="12"/>
            <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DPL1changed" />
        </td>

        <td>
         <asp:Button ID="Button1" runat="server" onclick="EmptyCart" Text="רוקן עסקה" />
         <asp:Button ID="buy" runat="server" OnClick="BuyCart" Text="סגור עסקה" />
        </td>

        <td>    
        <asp:Label ID="totalCostLabel" Visible="true" runat="server" ForeColor="Blue" Font-Size="14" Font-Italic="true" Font-Bold="true" BackColor="White"/>

        <asp:DataGrid Visible="true" ID="DataGrid1" runat="server" BackColor="White" BorderColor="#999999"  AutoGenerateColumns="false"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  Width="100%">
        <AlternatingItemStyle BackColor="#DCDCDC"  />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
        <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

        <Columns>

        <asp:BoundColumn HeaderText="#" DataField="idItem_X2" />

        <asp:TemplateColumn>
            <HeaderTemplate >קוד המוצר</HeaderTemplate>
            <ItemTemplate>
            <asp:Label ID="Label3" runat="server" 
       
            Text='<%# ConvertIdItem(DataBinder.Eval(Container.DataItem,"idItem_X2")) %>'
          />
        </ItemTemplate>
        </asp:TemplateColumn>
         
        <asp:BoundColumn HeaderText="מחיר יחידה" DataField="costPerOne" />

        <asp:TemplateColumn >
           <ItemTemplate> 
             <a href="Cart.aspx?idItemMinus=<%# DataBinder.Eval(Container,"DataItem.idItem_X2") %>">
             <img src="../gifs/plus.jpg" />
             
             </a>
           </ItemTemplate>
          </asp:TemplateColumn> 
            
        <asp:BoundColumn HeaderText="כמות" DataField="units"  ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" />

        <asp:TemplateColumn >
           <ItemTemplate> 
             <a href="Cart.aspx?idItemPlus=<%# DataBinder.Eval(Container,"DataItem.idItem_X2") %>">
             <img src="../gifs/plus.jpg" />
             
             </a>
           </ItemTemplate>
          </asp:TemplateColumn>

          <asp:BoundColumn HeaderText="סה'כ" DataField="total" />

        </Columns>
        </asp:DataGrid>
    </td>    
</tr>
</table>

    <br />
    <asp:DataGrid ID="DataGrid2" runat="server" BackColor="White" BorderColor="#999999"  AutoGenerateColumns="false"
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
    
        
        <asp:TemplateColumn HeaderText="הוסף לסל">           
            <ItemTemplate><a href=Cart.aspx?idItem=<%# DataBinder.Eval(Container.DataItem,"idItem") %> >
                <asp:Label runat="server" ID="add" Text="הוסף" /></a>
            </ItemTemplate>
        </asp:TemplateColumn>

    </Columns>

    </asp:DataGrid>

    <asp:Label Text="המוצר הזה אינו קיים במלאי כרגע" runat="server" ID="Label1" Visible="false" />


</asp:Content>

