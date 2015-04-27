<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="pressrelease.aspx.cs" Inherits="app_journalists_pressreleases_pressrelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Create Press Release</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="LeftBlockContainer">
        <center>
            <asp:DropDownList runat="server" ID="ddUserCampaignGroups" DataSourceID="dsUserCampaignGroups" DataValueField="CampaignGroupName" DataTextField="CampaignGroupName" CssClass="SearchDropDowns" Width="279" />
            <asp:TextBox runat="server" ID="txtSubject" Text="Subject" /><br />
            <asp:TextBox runat="server" ID="txtFromEmail" Text="From Email Address"  /><br />
            <asp:TextBox runat="server" ID="txtFromName" Text="From Name" /><br />
            <asp:Button runat="server" ID="btnCreateCampaign" OnClick="btnCreateCampaign_Click" Text="Create Campaign" CssClass="Pinky" />
        </center>
    </div>
    <asp:SqlDataSource ID="dsUserCampaignGroups" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
            SELECT UserCampaignGroupID, ISNULL(UserID,0) AS UserID, 
                ISNULL(CampaignGroupName,'') AS CampaignGroupName FROM UserCampaignGroups
                WHERE UserID = @UserID ORDER BY CampaignGroupName DESC" >
        <SelectParameters>
            <asp:SessionParameter SessionField="iUserID" Name="UserID" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

