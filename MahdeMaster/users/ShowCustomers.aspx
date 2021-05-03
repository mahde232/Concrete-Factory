<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowCustomers.aspx.cs" Inherits="ShowCustomers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <br />
            <asp:Label ID="labelLetters" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Show all customers" onclick="Button1_Click" />
            <br />
            <br />
    <asp:ListBox ID="ListBox1" runat="Server" AutoPostBack="True" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    &nbsp&nbsp&nbsp&nbsp&nbsp 
    <br />    <br />

    <asp:Button ID="AddCustomer" runat="server" Text="Add a customer" 
                onclick="AddCustomer_Click" Visible="false"/>

    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="labelErrorCode" runat="server" Visible="false"></asp:Label>
    <br />
    <br />
    <asp:HyperLink ID="hyperLink" Text="Go to Customer page" Visible="false" runat="server" />
    <br />
    <br />

    <asp:DataGrid ID="DataGrid1" runat="Server" Visible="False" BackColor="White" 
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

        <asp:BoundColumn HeaderText="מספר לקוח" DataField="idCostumer"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="שם לקוח">
        <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# AssistiveMethods.GetLinkForHyperLinkUsingName(Costumers.Get1Costumer(""+DataBinder.Eval(Container,"DataItem.idCostumer")).GetCostumerName(),"costumer")%>' Text='<%# Costumers.Get1Costumer(""+DataBinder.Eval(Container,"DataItem.idCostumer")).GetCostumerName()%>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateColumn>
        <asp:BoundColumn HeaderText="מספר פלאפון" DataField="CostumerPhone"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="אמייל אלקרטוני" DataField="CustomerEMail" ></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="מקום מגורים">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# AssistiveMethods.GetYeshovNameById(DataBinder.Eval(Container,"DataItem.CustomerLocation")) %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="Picture">
        <ItemTemplate>
        <asp:Image ID="Image1" width="100" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"picture","../Images/{0}")%>' />
        </ItemTemplate>
        </asp:TemplateColumn>
        
        </Columns>

    </asp:DataGrid>

    
</asp:Content>

