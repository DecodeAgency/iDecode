<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="communicators.aspx.cs" Inherits="app_admin_communicators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Communicators</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div style="float:right">
    <asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
</div>
<div></div>
<asp:GridView runat="server" ID="grvJournalists" DataSourceID="dsJournalists" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" CssClass="GridViewTable" AlternatingRowStyle-CssClass="GridViewAlternatingRow">
    <Columns>
        <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="310px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:HiddenField runat="server" ID="hidAssessmentID" Value='<%# Eval("UserID") %>' />
                <asp:Literal ID="litLastName" runat="server" Text='<%# Eval("LastName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Name" ItemStyle-Width="310px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Literal ID="litFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email Address" ItemStyle-Width="310px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Literal ID="litEmailAddress" runat="server" Text='<%# Eval("EmailAddress") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="320px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hypEdit" Text="edit" NavigateUrl='<%#"communicatoredit.aspx?pid=" + Eval("UserID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="dsJournalists" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
    SELECT U.UserID, ISNULL(U.FirstName,'') AS FirstName,ISNULL(U.LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, 
        ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE U.TwitterProfileImageURL END) AS ProfileImage , 
        ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress FROM Users U 
        WHERE U.UserTypeID = 3 ORDER BY LastName" >
</asp:SqlDataSource>
</asp:Content>

