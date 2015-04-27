<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailChimpTests.aspx.cs" Inherits="app_MailChimpTests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnCreateListGroup" Text="Create List Group" OnClick="btnCreateListGroup_Click" />
        <asp:Button runat="server" ID="btnUpdateListGroup" Text="Update List Group" OnClick="btnUpdateListGroup_Click" />
        <asp:Button runat="server" ID="btnDeleteListGroup" Text="Delete List Group" OnClick="btnDeleteListGroup_Click" />

        <asp:Literal runat="server" ID="litResul" />
    </div>
    </form>
</body>
</html>
