<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="users_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel runat="server" ID="Panel1">
    <table>
        <tr>
            <td>
            <asp:Panel runat="server" ID="Panel" BackColor="WhiteSmoke">
            <asp:Label Font-Size="12" ID="Name" runat="server" Font-Italic="true" Font-Bold="true" /> <br />
            <asp:Label Font-Size="12" ID="phone" runat="server" Font-Italic="true" Font-Bold="true" /> <br />
            <asp:Label Font-Size="12" ID="email" runat="server" Font-Italic="true" Font-Bold="true" /> <br />
            <asp:Label Font-Size="12" ID="address" runat="server" Font-Italic="true" Font-Bold="true" /> <br />
            </asp:Panel>
            </td>

            <td>
            <asp:Label ID="totalCostLabel" Visible="true" runat="server" ForeColor="Blue" Font-Size="14" Font-Italic="true" Font-Bold="true" BackColor="White"/>
            <asp:DataGrid Visible="true" ID="orderCart" runat="server" BackColor="White" BorderColor="#999999"  AutoGenerateColumns="false"
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
            
            <asp:BoundColumn HeaderText="כמות" DataField="units"  ItemStyle-Width="10" ItemStyle-HorizontalAlign="Center" />

            <asp:BoundColumn HeaderText="סה'כ" DataField="total" />

            </Columns>
            </asp:DataGrid>
            </td>
        </tr>

        <tr>
            <td>
            <input onclick="history.back()" type="button" value="חזור לדף קניות" />
            <asp:Button ID="buying" runat="server" OnClick="Order" Text="אני מאשר" />
            </td>
        </tr>

    </table>
</asp:Panel>

<center>
<asp:Label ID="thanks1" runat="server" Text="תודה רבה לך על הקניה דרך הרשת ותתחדש" Visible="false"/>
<asp:Button ID="return1" runat="server" Text="חזור לדף ההסטוריה" OnClick="ReturnToCD"  Visible="false"/>
</center>
</asp:Content>

