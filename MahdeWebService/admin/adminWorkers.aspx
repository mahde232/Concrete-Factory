<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminWorkers.aspx.cs" Inherits="admin_adminWorkers" %>

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
            <asp:Label ID="aslkd" runat="server" Text="עובדים שפועלים ->" />
            <asp:DropDownList ID="workers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Close"/>
            <asp:Button ID="update1Worker" runat="server" OnClick="UpdateWorker" Text="עדכן עובד" />
            <asp:Button ID="delete1Worker" runat="server" Text="מחק עובד" OnClick="Delete1Worker" />
            <asp:Button ID="add1Worker" runat="server" Text="הוסף עובד" OnClick="addPart1" />
            <br />
            <asp:Label ID="asdasd" runat="server" Text="עובדים שפוטר ->" />
            <asp:DropDownList ID="deletedWorkers" runat="server" AutoPostBack="true" />
            <asp:Button ID="Button1" runat="server" OnClick="ReturnWorker" Text="שחזר עובד" />
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

        <td>
        </td>

        <td>
        <asp:Label ID="Label1" runat="server" Text="הוספת ימי עבודה" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="name" runat="server" Text="שם העובד - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="nameL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="nameT" runat="server" />
        </td>

        <td>
        <asp:Label ID="day" runat="server" Text="יום - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:DropDownList ID="dayDDL" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="position" runat="server" Text="מעמד - " ForeColor="#0000cc" BackColor="#c0c0c0"  />
        <asp:Label ID="positionL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:DropDownList ID="positionDDL" runat="server" />
        </td>

        <td>
        <asp:Label ID="startH" runat="server" Text="שעת ההתחלה - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:TextBox ID="hourST" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="telephone" runat="server" Text="פלפון - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="telephoneL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="teleT" runat="server" />
        </td>

        <td>
        <asp:Label ID="endH" runat="server" Text="שעת הסיום - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:TextBox ID="hourET" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="salary" runat="server" Text="משכורת - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        <asp:Label ID="salaryL" runat="server" ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="salaryT" runat="server" />
        </td>

        <td>
        <asp:Button ID="addDay" runat="server" Text="הוסף" OnClick="Add1Day" />
        </td>
    </tr>
 </table>
</asp:Panel>

<asp:DataGrid ID="dataGrid1" runat="server" BackColor="White" Visible="false"
        BorderColor="#999999"  AutoGenerateColumns="true"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  
        Width="55%" align="Right">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>

<asp:DataGrid ID="dataGrid2" runat="server" BackColor="White" Visible="false"
        BorderColor="#999999"  AutoGenerateColumns="false"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  
        Width="55%" align="Right" 
        OnCancelCommand="Cancel" OnEditCommand="Edit" OnUpdateCommand="Update" DataKeyField="idrow">
    <AlternatingItemStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center"/>
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
    <ItemStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
        Mode="NumericPages" />
    <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

    <Columns>

    <asp:EditCommandColumn CancelText="בטל" EditText="שנה" UpdateText="עדכן" />

    <asp:TemplateColumn HeaderText="מחיקה">
        <ItemTemplate>
            <a href="Delete.aspx?idRow=<%# DataBinder.Eval(Container, "DataItem.idRow") %>&worker=<%# DataBinder.Eval(Container, "DataItem.idWorker") %>" >
            <asp:Label ID="delete" runat="server"
                Text="מחק" /> </a>
        </ItemTemplate>
    </asp:TemplateColumn>

    <asp:BoundColumn DataField="idRow" Visible="true" HeaderText="מספר השורה" />
    <asp:TemplateColumn HeaderText="יום">
            <ItemTemplate>
                <asp:Label ID="dayEL" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.idDay") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="dayET" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.idDay") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="שעת ההתחלה">
            <ItemTemplate>
                <asp:Label ID="shEL" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.startsAt") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="shET" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.startsAt") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>

    <asp:TemplateColumn HeaderText="שעת הסיום">
            <ItemTemplate>
                <asp:Label ID="ehEL" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.endsAt") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="ehET" runat="server" 
                    Text='<%# DataBinder.Eval(Container, "DataItem.endsAt") %>'></asp:TextBox>
            </EditItemTemplate>
    </asp:TemplateColumn>



    </Columns>
</asp:DataGrid>

<asp:Panel ID="adding" Visible="false" runat="server">
<table>
    <tr>
        <td>
        <asp:Label ID="Label5" runat="server" Text="שם העובד - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="TextBox1" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="Label8" runat="server" Text="מעמד - " ForeColor="#0000cc" BackColor="#c0c0c0"  />
        </td>

        <td>
        <asp:DropDownList ID="DropDownList2" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="Label11" runat="server" Text="פלפון - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="TextBox3" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="Label14" runat="server" Text="משכורת - " ForeColor="#0000cc" BackColor="#c0c0c0" />
        </td>

        <td>
        <asp:TextBox ID="TextBox5" runat="server" />
        </td>
    </tr>
 </table>
 <asp:Button ID="add" runat="server" Text="הוסף" OnClick="addPart2" />
</asp:Panel>
</asp:Content>

