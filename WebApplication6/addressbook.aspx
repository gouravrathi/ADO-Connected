<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addressbook.aspx.cs" Inherits="WebApplication6.addressbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            FIRST NAME<asp:TextBox ID="fname" runat="server"></asp:TextBox>
            <br />
            <br />
            LAST NAME<asp:TextBox ID="lname" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            PHONE NO.<asp:TextBox ID="phnno" runat="server" OnTextChanged="phnno_TextChanged"></asp:TextBox>
            <br />
            <br />
            ADDRESS ID<asp:TextBox ID="addressid" runat="server"></asp:TextBox>
            <br />
            <br />
            EMAIL&nbsp;&nbsp;
            <asp:TextBox ID="Textemail" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" OnClick="Unnamed1_Click" Text="update" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="delete" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="insert" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="search" />
        </div>
    </form>
</body>
</html>
