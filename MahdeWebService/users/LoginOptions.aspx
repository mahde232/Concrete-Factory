<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="LoginOptions.aspx.cs" Inherits="users_LoginOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<asp:Panel ID="LogingInChecking" runat="server" >

<asp:Label ID="UserName" runat="server" Text="שם משתמש" ForeColor="#0000cc" Font-Bold="true" Font-Size="Large" BackColor="#c0c0c0" /><br />
<asp:TextBox ID="UserNameT" runat="server" /><br /><br />

<asp:Label ID="PassWord" runat="server" Text="סיסמה" ForeColor="#0000cc" Font-Bold="true" Font-Size="Large" BackColor="#c0c0c0" /><br />
<asp:TextBox ID="PassWordT" runat="server" TextMode="Password"/><br /><br />

<asp:Button ID="LogIn" runat="server" Text="היכנס" OnClick="LogInCheck" />
<asp:Button ID="RegisterButton" runat="server" Text="הירשם לאתר" OnClick="GoToRegister"/> <br />

<asp:Label ID="error" runat="server" Text="" />

</asp:Panel>


<asp:Panel ID="loginOptions" runat="server" HorizontalAlign="Right" Visible="false" >
<asp:Label ID="user" runat="server" />
<asp:Button ID="MyHistoryButton" runat="server" Text="היסטורית הקניות"  OnClick="MyHistoryM"/>
<asp:Button ID="CartButton" runat="server" Text="לקנות"  OnClick="MyCartM"/>
<br /><br /><br />
</asp:Panel>

</asp:Content>

