<%@ Page Language="C#" AutoEventWireup="true" CodeFile="encoding.aspx.cs" Inherits="app_admin_encoding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>Base64 encoded bearer token credentials:</td>
            <td><asp:Literal runat="server" ID="litEncodedConsumerKey" /></td>
        </tr>
        <tr>
            <td>Bearer Token</td>
            <td><asp:Literal runat="server" ID="litBearerToken" /></td>
        </tr>
        <tr>
            <td>Access Token</td>
            <td>AAAAAAAAAAAAAAAAAAAAAEhjewAAAAAA6%2B3HZJ5tpzcHEXobNTo%2F7%2BYT7Oc%3D06JMFvVxeHslrlLo5azQ5tmOBfiAo0eyCgHebQSfmgl3dtQY4a</td>
        </tr>
    </table>
    Tweets<br />
    <asp:Literal runat="server" ID="litTweets" />
    </div>
    </form>
</body>
</html>
