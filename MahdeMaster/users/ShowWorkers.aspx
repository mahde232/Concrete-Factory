<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowWorkers.aspx.cs" Inherits="ShowWorkers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table runat="server">

    <asp:TableRow>
    <asp:TableCell>
    <asp:Button ID="Button1" runat="server" Text="Show all workers" onclick="Button1_Click" />
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>Search by location:</asp:TableCell>
    <asp:TableCell>
    <asp:ListBox ID="ListBoxLocations" runat="Server" AutoPostBack="True" onselectedindexchanged="ListBoxLocations_SelectedIndexChanged"></asp:ListBox>
    </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
    <asp:TableCell>Search by specific name:</asp:TableCell>
    <asp:TableCell>
    <asp:ListBox ID="ListBox1" runat="Server" AutoPostBack="True" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    </asp:TableCell>
    </asp:TableRow>

    </asp:Table>

    <br />
    <br />
    <br />

        <asp:Button ID="AddWorker" runat="server" Text="Add a worker" 
                onclick="AddWorker_Click" Visible="false"/>
    <br />
    <br />
    <br />

    <asp:HyperLink ID="hyperLink" Text="Go to Worker page" Visible="false" runat="server" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
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

        <asp:BoundColumn HeaderText="מספר עובד" DataField="idOved"></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="שם עובד">
        <ItemTemplate>
        <asp:HyperLink runat="server" NavigateUrl='<%# AssistiveMethods.GetLinkForHyperLinkUsingName(Workers.Get1Worker(""+DataBinder.Eval(Container,"DataItem.idOved")).GetWorkerName(),"worker")%>' Text='<%# Workers.Get1Worker(""+DataBinder.Eval(Container,"DataItem.idOved")).GetWorkerName() %>'></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateColumn>
        <asp:BoundColumn HeaderText="פלאפון" DataField="OvedPhone" ></asp:BoundColumn>
        <asp:TemplateColumn HeaderText="תפקיד">
        <ItemTemplate>
        <asp:Label runat="server" Text='<%# AssistiveMethods.GetTafkedNameById(DataBinder.Eval(Container,"DataItem.OvedTafked")) %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="כלי רכב">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# AssistiveMethods.GetVehicleNameById(DataBinder.Eval(Container,"DataItem.VehicleOwned")) %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="יישוב">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# AssistiveMethods.GetYeshovNameById(DataBinder.Eval(Container,"DataItem.Yeshov")) %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateColumn>

        </Columns>

    </asp:DataGrid>

    
</asp:Content>

