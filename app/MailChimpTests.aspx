<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailChimpTests.aspx.cs" Inherits="app_MailChimpTests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://cdn.syncfusion.com/js/web/flat-azure/ej.web.all-latest.min.css" rel="stylesheet"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="http://borismoore.github.io/jsrender/jsrender.min.js" type="text/javascript"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src=" http://cdnjs.cloudflare.com/ajax/libs/globalize/0.1.1/globalize.min.js"></script>
    <script src="http://cdn.syncfusion.com/js/web/ej.web.all-latest.min.js"></script>
    <script src="http://cdn.syncfusion.com/js/web/ej.webform-latest.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:Button runat="server" ID="btnCreateListGroup" Text="Create List Group" OnClick="btnCreateListGroup_Click" />
        <asp:Button runat="server" ID="btnUpdateListGroup" Text="Update List Group" OnClick="btnUpdateListGroup_Click" />
        <asp:Button runat="server" ID="btnDeleteListGroup" Text="Delete List Group" OnClick="btnDeleteListGroup_Click" />

        <asp:Literal runat="server" ID="litResul" />
    </div>

    <ej:RTE ID="FeedbackEditor" runat="server">

    </ej:RTE>
    </form>
</body>
</html>
