<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="users_ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:Panel runat="server" ID="PanelForViewing">
    <asp:ListBox ID="ProductsListBox" runat="Server" AutoPostBack="True" 
        onselectedindexchanged="ProductsListBox_SelectedIndexChanged"></asp:ListBox>
    &nbsp&nbsp&nbsp&nbsp&nbsp 
    <br />    <br />

    <asp:Button ID="ShowAll" runat="server" Text="Show all products" Visible="true" 
        onclick="ShowAll_Click" />
    <asp:Button ID="AddProduct" runat="server" Text="Add a product" 
                onclick="AddProduct_Click" Visible="false"/>

    </asp:Panel>
    <asp:Label runat="server" ID="labelForAdressingOtherProducts" Visible="false" BackColor="Chocolate" Text="</br>SOME OF THE PRODUCTS IN THIS PAGE DO NOT BELONG TO THIS CONCRETE COMPANY, THEY BELONG TO ANOTHER COMPANY(THEY ARE HERE BECAUSE OF WEB-SERVICE)</br></br>To find out more about the products listed below please contact: Aseel Abo Roken @ 050-000-0000"></asp:Label>
    <br />

    <asp:Table runat="server">
    <asp:TableRow>
    <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
    <asp:DataGrid ID="DataGrid1" runat="Server" Visible="True" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="324px" AutoGenerateColumns="false">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        
        <Columns>

        <asp:BoundColumn HeaderText="Product ID" DataField="idProduct"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="Product Name">
        <ItemTemplate>
        <asp:HyperLink runat="server" NavigateUrl='<%# AssistiveMethods.GetLinkForHyperLinkUsingName(Products.Get1Product(""+DataBinder.Eval(Container,"DataItem.idProduct")).GetProductName(),"product")%>' Text='<%# Products.Get1Product(""+DataBinder.Eval(Container,"DataItem.idProduct")).GetProductName()%>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateColumn>
        <asp:BoundColumn HeaderText="Product Price Per One" DataField="ProductPricePerOne"></asp:BoundColumn>
        
        </Columns>

    </asp:DataGrid>
    </asp:TableCell>
    <asp:TableCell>
    <asp:DataGrid ID="DataGrid2" runat="Server" Visible="True" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="324px" AutoGenerateColumns="false">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        
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
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
</asp:Content>

