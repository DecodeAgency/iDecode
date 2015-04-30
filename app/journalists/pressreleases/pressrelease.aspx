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
        <div class="Block" runat="server" id="divSendThatThing" visible="false">
            <h3>Send That Thing</h3>
            <center>
                <asp:Button runat="server" ID="btnSendTestCampaign" OnClick="btnSendTestCampaign_Click" Text="Send Test Campaign" CssClass="Pinky" />
                <asp:Button runat="server" ID="btnSendCampaign" OnClick="btnSendCampaign_Click" Text="Send Campaign" CssClass="Pinky" />
                <ej:DateTimePicker ID="dtScheduleDateTime" runat="server" Value="7/18/2014" Width="180px"></ej:DateTimePicker>
                <asp:Button runat="server" ID="btnScheduleCampaign" OnClick="btnScheduleCampaign_Click" Text="Schedule Campaign" CssClass="Pinky" />
                <asp:Button runat="server" ID="btnCancelSchedule" OnClick="btnCancelSchedule_Click" Text="Cancel Schedule" CssClass="Pinky" />
                <asp:Button runat="server" ID="btnDeleteCampaign" OnClick="btnDeleteCampaign_Click" Text="Delete Campaign" CssClass="Pinky" />
            </center>
        </div>               
        <div class="Block">
            <h3>Campaign Options</h3>
            <asp:DropDownList runat="server" ID="ddUserCampaignGroups" DataSourceID="dsUserCampaignGroups" DataValueField="CampaignGroupName" DataTextField="CampaignGroupName" CssClass="SearchDropDowns" Width="279" />
            <asp:TextBox runat="server" ID="txtSubject" Text="Subject" /><br />
            <asp:TextBox runat="server" ID="txtFromEmail" Text="From Email Address"  /><br />
            <asp:TextBox runat="server" ID="txtFromName" Text="From Name" /><br />
            <center>
                <asp:Button runat="server" ID="btnCreateCampaign" OnClick="btnCreateCampaign_Click" Text="Create Campaign" CssClass="Pinky" />
                <asp:Button runat="server" ID="btnUpdateCampaign" OnClick="btnUpdateCampaign_Click" Text="Update Campaign" CssClass="Pinky" Visible="false" />
            </center>       
        </div>
    </div>
    <div class="MiddleBlockContainer">
        <div class="Block" style="width: 620px;">
            <h3>Campaign Content</h3>
            <ej:RTE ID="rteSample" Width="620" Height="440" ShowFooter="true" runat="server">
            </ej:RTE>
        </div>
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
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

