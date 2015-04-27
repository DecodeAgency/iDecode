<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="publicationedit.aspx.cs" Inherits="app_admin_publicationedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Manage Publication</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="float:right">
        <asp:Button runat="server" ID="btnSave" Text="Save Changes" OnClick="btnSave_Click" Width="130" CssClass="SaveButton" />&nbsp;&nbsp;<asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
    </div>
    <div style="clear:both; height:10px"></div>
    <div runat="server" id="divMessage" class="Message SuccessMessage" visible="false">
        <asp:Literal runat="server" ID="txtSuccessMessage" Text="Changes successfully saved." Visible="false" />
        <asp:Literal runat="server" ID="txtErrorMessage" Text ="An error occured. Changes not saved." Visible="false" />
    </div>
    <div class="SearchItemsContainer">
        <table>
            <tr>
                <td style="width:100px">Publication</td>
                <td><asp:TextBox runat="server" ID="txtPublication" /></td>
            </tr>
            <tr>
                <td>Website</td>
                <td><asp:TextBox runat="server" ID="txtWebsite" /></td>
            </tr>
            <tr>
                <td>Language</td>
                <td><asp:DropDownList runat="server" ID="ddLanguage" DataSourceID="dsLanguages" DataTextField="Language" DataValueField="LanguageID" CssClass="SearchDropDowns" /></td>
            </tr>
        </table>    
    </div> 
    <asp:SqlDataSource ID="dsLanguages" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT LanguageID, ISNULL(Language,'') AS Language FROM Languages" >
    </asp:SqlDataSource>
</asp:Content>

