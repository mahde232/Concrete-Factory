<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminItems.aspx.cs" Inherits="admin_adminItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Button ID="return" runat="server" OnClick="ReturnToAdmin" Text="חזור" />

<center>
<asp:Label Text="המוצר הזה אינו קיים במלאי כרגע" runat="server" ID="Label1" Visible="false" />

<asp:DataGrid ID="dataGrid1" runat="server" BackColor="White"
        BorderColor="#999999"  AutoGenerateColumns="False"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  
        Width="100%" 
        OnCancelCommand="Cancel" OnEditCommand="Edit" OnUpdateCommand="Update" 
        DataKeyField="idItem">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

    <Columns>

    <asp:EditCommandColumn CancelText="בטל" EditText="שנה" UpdateText="עדכן" />

        <asp:TemplateColumn HeaderText="קוד">
            <ItemTemplate>
                <asp:Label ID="id" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.idItem") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="שם">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" 
       
                    Text='<%# ConvertIdItem(DataBinder.Eval(Container.DataItem,"idItem")) %>'
                />
            </ItemTemplate>
        </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="מחיר ב-שח">
            <ItemTemplate>
                <asp:Label ID="costL" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.cost") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="costT" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.cost") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="עובי הלוח">
            <ItemTemplate>
                <asp:Label ID="wid" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.wid_cm") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="widT" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.wid_cm") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="רוחב הלוח">
            <ItemTemplate>
                <asp:Label ID="len" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.len_cm") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lenT" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.len_cm") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>

   </Columns>

  </asp:DataGrid>  

 </center>

</asp:Content>

