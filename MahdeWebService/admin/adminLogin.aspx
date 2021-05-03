<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="admin_adminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table>

    <tr>
        <td>
        <asp:Label ID="name" runat="server" Text="שם משתמש" />
        </td>

        <td>
        <asp:TextBox ID="TextBox1" runat="server" Text="1"/>
        </td>
    </tr>

    <tr>
        <td>
        <asp:Label ID="password" runat="server" Text="סיסמה" />
        </td>

        <td>
            <input id="Password1" type="password" name="Password1" /> 
        </td>
    </tr>
    <tr>
        <td colspan="2">
         <asp:Label ID="Label1" runat="server" visible="False"
         Text="שם משתמש או סיסמה שגואים"></asp:Label>
     </td></tr>
    <tr>
   
        <td colspan="2">
        
    <asp:Button ID="Button1"
        runat="server" Text="הכנס כאדמן" OnClick="Button1_Click" />
 </td></tr>

</asp:Content>

