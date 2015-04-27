<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportJournalists.aspx.cs" Inherits="app_admin_ImportJournalists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal runat="server" ID="litResult" />
    <asp:FileUpload runat="server" ID="fulExcelFile" />
    </div>
    </form>
</body>
</html>
