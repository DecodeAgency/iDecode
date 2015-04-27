<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="app_admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Dashboard</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="LeftBlockContainer">
        <div class="Block">
            <h3>Journalists</h3>
            <h4><asp:literal runat="server" ID="litJournalistCount" /></h4>
            <center>
                <asp:Button runat="server" ID="btnJournalists" Text="Find Journalists" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnJournalists_Click" />
            </center>
        </div>
        <div class="Block">
            <h3>Press Releases</h3>
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
            <h3>Latest Tweets</h3>
             <div runat="server" id="divShowTweets"></div>
        </div>
    </div>
    <div class="RightBlockContainer">
        <div class="Block">
           <h3>Profile Complete (%)</h3>
            <div runat="server" class="dvOuterComplete" id="dvOuterComplete">
                <div runat="server" class="dvInnerComplete" id="dvInnerComplete"></div>
            </div> 
            <div class="divShortBio" style="text-align:center;margin-top:20px;display: inline-block;">
            <asp:literal runat="server" ID="litPercentage">your profile is 0% complete</asp:literal></div>
        </div>
        <div class="Block">
            <h3>Journalist Groups</h3>
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
    </div>
</asp:Content>

