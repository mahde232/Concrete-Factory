<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowOrders.aspx.cs" Inherits="ShowOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <br />
     <asp:Button ID="Button1" runat="server" Text="הזמנות לפי תאריך עולה" onclick="Button1_Click" />
     <asp:Button ID="Button2" runat="server" Text="הזמנות לפי תאריך יורד" onclick="Button2_Click" />
        <br />
                <br />
    <asp:ListBox ID="ListBox1" runat="Server" AutoPostBack="True" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
     
     &nbsp&nbsp&nbsp&nbsp&nbsp
             <br />
                     <br />
    <asp:Label ID="Label2" runat="server" Text="Day:"></asp:Label>

    <asp:DropDownList ID="DropDownListDays" runat="server">
    </asp:DropDownList>

    &nbsp&nbsp&nbsp&nbsp&nbsp

    <asp:Label ID="Label3" runat="server" Text="Month:"></asp:Label>


    <asp:DropDownList ID="DropDownListMonths" runat="server">
    </asp:DropDownList>

    &nbsp&nbsp&nbsp&nbsp&nbsp

    <asp:Label ID="Label4" runat="server" Text="Year:"></asp:Label>

    <asp:DropDownList ID="DropDownListYears" runat="server">
    </asp:DropDownList>

    &nbsp&nbsp&nbsp&nbsp&nbsp

    <asp:Button ID="SearchByDateButton" runat="server" 
        Text="Search By Date Specified" onclick="SearchByDateButton_Click" />

    <br />    <br />
    <asp:Button ID="AddOrder" Visible="false" runat="server" Text="Add an order" OnClick="AddOrder_Click" />
    <br />    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />




    <br />
    <br />
    <asp:DataGrid ID="DataGrid1" runat="Server" AutoGenerateColumns="false" 
         Visible="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="324px" 
         OnItemCommand="CustomerClick" >
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        
        
        
        <Columns>
        
        <asp:BoundColumn HeaderText="מספר קבלה" DataField="idOrder"></asp:BoundColumn>

        <asp:TemplateColumn HeaderText="לקוח">
        <ItemTemplate>
        <asp:HyperLink runat="server" NavigateUrl='<%# AssistiveMethods.GetLinkForHyperLinkUsingName(Costumers.Get1Costumer(""+DataBinder.Eval(Container,"DataItem.Costumer")).GetCostumerName(),"costumer")%>' Text='<%# Costumers.Get1Costumer(""+DataBinder.Eval(Container,"DataItem.Costumer")).GetCostumerName()%>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="תאריך">
        <ItemTemplate>
        <asp:Label runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"DateOfOrder","{0:D}")) %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="מוצר">
        <ItemTemplate>
        <asp:Label runat="server" Text='<%# AssistiveMethods.GetProductNameById(DataBinder.Eval(Container,"DataItem.OrderTypeWanted"))%>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:BoundColumn HeaderText="כמות דרושה" DataField="Amount"></asp:BoundColumn>
        <asp:BoundColumn HeaderText="מחיר סופי" DataField="ActualPrice"></asp:BoundColumn>
        
        <asp:TemplateColumn HeaderText="-משלוח ל">
        <ItemTemplate>
        <asp:Label runat="server" Text='<%# AssistiveMethods.GetYeshovNameById(DataBinder.Eval(Container,"DataItem.Distination"))%>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="שם עובד">
        <ItemTemplate>
        <asp:HyperLink runat="server" NavigateUrl='<%# AssistiveMethods.GetLinkForHyperLinkUsingName(Workers.Get1Worker(""+DataBinder.Eval(Container,"DataItem.OvedDriver")).GetWorkerName(),"worker")%>' Text='<%# Workers.Get1Worker(""+DataBinder.Eval(Container,"DataItem.OvedDriver")).GetWorkerName() %>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateColumn>
        </Columns>

    </asp:DataGrid>
        <br />
    <br />
    <br />
    <br />
    
</asp:Content>

