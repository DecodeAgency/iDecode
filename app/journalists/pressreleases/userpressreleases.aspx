<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="userpressreleases.aspx.cs" Inherits="app_journalists_pressreleases_userpressreleases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .Block {
              margin: 10px 8px !Important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Press Releases</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<asp:Repeater runat="server" ID="rptPressReleases" DataSourceID="dsPressReleases">
    <ItemTemplate>
        <div class="Block">
            <h3><%# Eval("Subject") %></h3>
            <a href='<%# "pressrelease.aspx?prid=" + Eval("UserCampaignID") %>'>manage</a>
            <a href="pressrelease.aspx">reports</a>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:SqlDataSource ID="dsPressReleases" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT UserCampaignID, ISNULL(UserID,0) AS UserID, ISNULL(MailChimpListID,'') AS MailChimpListID, ISNULL(Subject,'') AS Subject,
	        ISNULL(FromEmail,'') AS FromEmail, ISNULL(FromName,'') AS FromName, ISNULL(ToName,'') AS ToName,
	        ISNULL(TemplateID,0) AS TemplateID, ISNULL(Title,'') AS Title, ISNULL(CampaignContent,'') AS CampaignContent,
	        ISNULL(DateTimeStamp,GETDATE()) AS DateTimeStamp, ISNULL(LastUpdatedDate,GETDATE()) AS LastUpdatedDate
        FROM UserCampaigns WHERE UserID = @UserID" >
    <SelectParameters>
        <asp:SessionParameter SessionField="iUserID" Name="UserID" DefaultValue="0" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

