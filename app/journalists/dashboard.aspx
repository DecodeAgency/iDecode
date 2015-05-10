<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="app_admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>

        .btnProgress {
            margin-left: 45px;
            background-color: #4FC5F7 !important;
            border: 1px solid #4FC5F7 !important;
            text-transform: uppercase;
            color: rgb(255, 255, 255) !important;
            float: none !important;
            border-radius: 3px;
            padding: 2px 5px;
        }

        .JobHistoryContainer span {
            width: 190px;
            display: inline-block;
            text-transform: lowercase;
            margin-bottom: 10px;
            text-transform:capitalize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Dashboard</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="LeftBlockContainer">
        <div class="Block" runat="server" id="divJournalistsCounter" visible="false">
            <h3 style="background-color:#fbb152">Journalists</h3>
            <h4><asp:literal runat="server" ID="litJournalistCount" /></h4>
            <center>
                <asp:Button runat="server" ID="btnJournalists" Text="Find Journalists" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnJournalists_Click" />
            </center>
        </div>
        <div class="Block" id="divCommunicatorsCounter" runat="server" visible="false">
            <h3>Communicators</h3>
            <h4><asp:literal runat="server" ID="litCommunicatorsCounter" /></h4>
            <center>
                <asp:Button runat="server" ID="btnCommunicators" Text="Find Communicators" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnCommunicators_Click" />
            </center>
        </div>
        <div class="Block">
            <h3 style="background-color:#cb334c">Recent Updates</h3>
            <asp:Repeater runat="server" ID="rptRecentUpdates" DataSourceID="dsRecentUpdates" OnDataBinding="rptRecentUpdates_DataBinding" OnItemDataBound="rptRecentUpdates_ItemDataBound">
                <ItemTemplate>
                    <div class="<%# Container.ItemIndex % 2 == 0 ? "JobHistoryContainer" : "JobHistoryContainer JobHistoryContainerAlt" %>">
                        <div style='margin-top:10px'><asp:literal runat="server" ID="litUpdateStatus" /></div>
                        <div style='float:right'><asp:literal runat="server" ID="litDatePosted" Text='<%# Eval ("DateTimeStamp") %>' /></div>
                    </div>
                    <div class="ListDivider"></div>
                    <asp:HiddenField runat="server" ID="hidUpdatedProfileID" Value='<%# Eval ("UpdatedProfileID") %>' />                   
                </ItemTemplate>
            </asp:Repeater>  
        </div>
        <div class="Block" runat="server" id="divPressReleases">
            <h3 style="background-color:#3668af">Press Releases</h3>
            <h4><asp:literal runat="server" ID="litTotalPressReleases" Text="0" /></h4>
            <center>
                <asp:Button runat="server" ID="btnCreatePressRelease" Text="Create Press Release" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnCreatePressRelease_Click" />
            </center>
        </div>
    </div>
    <div class="MiddleBlockContainer">
        <div class="Block">
            <div class="ProfileImage" runat="server" id="divProfileImage"></div>
            <h3><asp:Literal runat="server" ID="litFullName" /></h3>
            <div class="divShortBio">
                 <asp:Literal runat="server" ID="litShortBio" Text="update your profile to display a short bio here." />
            </div>      
        </div>
        <div class="Block">
            <h3 style="background-color:#35abdd">Latest Tweets</h3>
             <div runat="server" id="divShowTweets"></div>
            <div runat="server" id="dvTwitterHandle" style="display:none;">
                <div class="divShortBio">
                <asp:TextBox runat="server" ID="txtTwitterHandle"></asp:TextBox>
                    </div>
                <asp:Button runat="server" ID="btnLoadTweets" Text="Load Tweets" CssClass="SignInButton" OnClick="btnLoadTweets_Click" />         
            </div>
        </div>
    </div>
    <div class="RightBlockContainer">
        <div class="Block">
           <h3 style="background-color:#1c4e95">Profile Complete (%)</h3>
            <div runat="server" class="dvOuterComplete" id="dvOuterComplete">
                <div runat="server" class="dvInnerComplete" id="dvInnerComplete"></div>
            </div> 
            <div class="divShortBio" style="text-align:center;margin-top:20px;display: inline-block;float: left;">
            <asp:literal runat="server" ID="litPercentage">Your profile is 0% complete</asp:literal></div>
            <div class="JobHistoryContainer" runat="server" id="divCompleteList" style="text-align:left;margin-top:20px;display: inline-block;">
                <asp:literal runat="server" ID="litInCompleteList"></asp:literal>
            </div>
        </div>
        <div class="Block" runat="server" id="divJournalistGroups">
            <h3 style="background-color:#11a9ac">Journalist Groups</h3>
            <div runat="server" id="divMessage" class="Message SuccessMessage" visible="false">
                <asp:Literal runat="server" ID="txtSuccessMessage" Text="Campaign group added" Visible="false" />
                <asp:Literal runat="server" ID="txtErrorMessage" Text ="An error occured. Campaign group added." Visible="false" />
            </div>
            <h4><asp:literal runat="server" ID="litCampaignGroupsCount" Text="0" /></h4>
            <asp:TextBox runat="server" ID="txtCampaignGroupName" CssClass="SearchTextBoxes" Text="Group Name" onfocus='if (this.value == "Group Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "Group Name"}'  />
            <center>
                <asp:Button runat="server" ID="btnAddGroup" Text="Add Group" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnAddGroup_Click" />
            </center>
        </div>
        <div class="Block" runat="server" id="divPublicJournalistGroups">
            <h3 style="background-color:#e54d66">Public Media Groups</h3>
            <asp:Repeater runat="server" ID="rptPublicMediaGroups" DataSourceID="dsPublicMediaGroups" OnItemDataBound="rptPublicMediaGroups_ItemDataBound" OnItemCommand="rptPublicMediaGroups_ItemCommand">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hidBeatID" Value='<%#Eval("BeatID") %>' />
                    <div class="<%# Container.ItemIndex % 2 == 0 ? "JobHistoryContainer" : "JobHistoryContainer JobHistoryContainerAlt" %>">
                        <asp:Literal runat="server" ID="litBeatName" />
                        <asp:Button runat="server" ID="btnSendCampaign" Text="Send PR" CommandArgument='<%#Eval("BeatID") %>' CommandName="SendPR" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:SqlDataSource ID="dsRecentUpdates" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT TOP 5 *, RIGHT(Trail,LEN(Trail) - CHARINDEX('=',Trail)) AS UpdatedProfileID FROM UserSessionTrails WHERE UserSessionTrailID IN (
	        SELECT MIN(UserSessionTrailID) FROM UserSessionTrails WHERE Trail LIKE '%edit%' GROUP BY Trail, DateTimeStamp  
        )
        ORDER BY DateTimeStamp DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPublicMediaGroups" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT BeatID, ISNULL(BeatName,'') AS BeatName FROM Beats WHERE IsPublic = 1 ORDER BY BeatName">
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

