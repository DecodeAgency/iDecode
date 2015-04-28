<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="app_communicators_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Search for Communication Officers</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="SearchItemsContainer">
        <table>
            <tr> 
                <td colspan="6">Search for any keyword, company, topic, phrase and more within journalists' tweets, linked stories, published articles and social media profiles.</td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="width:100px">Keyword</td>
                <td><asp:TextBox runat="server" ID="txtkeyword" CssClass="SearchTextBoxes" Text="e.g. Spokesperson" onfocus='if (this.value == "e.g. Spokesperson"){this.value = "";}' onblur='if (this.value == ""){this.value = "e.g. Spokesperson"}' /></td>
                <td style="width:100px"></td>
                <td style="width:100px">Communicator</td>
                <td style="text-align:right"><asp:TextBox runat="server" ID="txtCommunicatorName" ClientIDMode="Static" CssClass="SearchTextBoxes" Text="e.g. Margaret Dingalo" onfocus='if (this.value == "e.g. Margaret Dingalo"){this.value = "";}' onblur='if (this.value == ""){this.value = "e.g. Margaret Dingalo"}'/></td>
            </tr>
            <tr>
                <td>Department</td>
                <td><asp:TextBox runat="server" ID="txtDepartment" CssClass="SearchTextBoxes" Text="e.g. Gauteng Provincial Government" onfocus='if (this.value == "e.g. Gauteng Provincial Government"){this.value = "";}' onblur='if (this.value == ""){this.value = "e.g. Gauteng Provincial Government"}' /></td>
                <td style="width:100px"></td>
                <td >Location</td>
                <td style="text-align:right"><asp:TextBox runat="server" ID="txtLocation" CssClass="SearchTextBoxes" Text="e.g. Eastern Cape" onfocus='if (this.value == "e.g. Eastern Cape"){this.value = "";}' onblur='if (this.value == ""){this.value = "e.g. Eastern Cape"}' /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="width:100px"></td>
                <td></td>
                <td><asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" CssClass="SearchButton" /></td>
            </tr>
        </table>
    </div>
    <div class="RightContainer">
        <div>
            <h3>Last 5 Searches</h3>
            <asp:Literal runat="server" ID="litUserJournalistSearchesResult" Text="You do not have any saved searches." Visible="false"></asp:Literal>
            <asp:Repeater runat="server" ID="rptUserJournalistSearches" DataSourceID="dsUserJournalistSearch">          
                <ItemTemplate>
                    <a href='<%# "/app/communicators/search.aspx?sci=" + Eval("UserJournalistSearchID") %>'>
                        <div class="JournalistSearches">
                            <div class="PublicationName"> <%# Convert.ToDateTime(Eval("DateTimeStamp")).ToString("dd MMM yyyy") %> </div>
                            <div class="PublicationName"> <%# Eval("SearchCriteria") %> </div>
                        </div>
                     </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div> 
    <div class="ResultsContainer">
        <div style="">
            <h3><asp:Literal runat="server" ID="litSearchHeading" Text="Recently Added Communicators" /></h3>
            <asp:Literal runat="server" ID="litSearchResult" Text="No communication officers found. Please refine your search criteria." Visible="false" />
            <asp:repeater runat="server" id="rptJournalists" DataSourceID="dsJournalists">
                <itemtemplate>
                    <div class="JobHistoryContainer">
                        <div class="PublicationImage" style='<%# "background-image:url(" + Eval("ProfileImage") + ")" %>'></div>
                        <div class="CommunicatorName"> <%# Eval ("FirstName") + " " + Eval("LastName") %> </div>
                        <div class="PublicationName"> <%# Eval ("CurrentJobTitle")%> </div>
                        <div class="PublicationName"> <%# Eval ("CurrentJobPublication")  %> </div>
                        <a class="ViewProfile" href='<%# "profile.aspx?uid=" + Eval("UserID") %>'>view profile</a> 
                    </div>
                </itemtemplate>
            </asp:repeater>
        </div>
    </div>
    <style>
    </style>
    <asp:SqlDataSource ID="dsJournalists" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT TOP 15 U.UserID, ISNULL(U.FirstName,'') AS FirstName,ISNULL(U.LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, 
        ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE 'http://test.idecode.co.za/app/images/profileimages/' + CONVERT(varchar(20),U.UserID) + '.' + U.ImageFormat END) AS ProfileImage , 
        ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress FROM Users U 
        WHERE U.UserTypeID = 3 AND U.Active = 1" >
        <SelectParameters>
            <asp:SessionParameter SessionField="kqy" Name="Keyword" DefaultValue="aabbcc" />
            <asp:SessionParameter SessionField="cn" Name="JounalistName" DefaultValue="aabbcc" />
            <asp:SessionParameter SessionField="l" Name="Location" DefaultValue="aabbcc" />
            <asp:SessionParameter SessionField="d" Name="Department" DefaultValue="aabbcc" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsUserJournalistSearch" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
            SELECT TOP 5 UserJournalistSearchID, ISNULL(UserID,0) AS UserID, 
                ISNULL(Keywords,'') AS Keywords, ISNULL(Journalist,'') AS Journalist,
                ISNULL(Location,'') AS Location, ISNULL(MediaOutletID,0) AS MediaOutletID,
                ISNULL(DateTimeStamp,GETDATE()) AS DateTimeStamp, 
                (ISNULL(Keywords,'') + ' ' + ISNULL(Journalist,'') + ' ' + ISNULL(Location,'')) AS SearchCriteria 
                FROM UserJournalistSearches
                WHERE UserID = @UserID ORDER BY UserJournalistSearchID DESC" >
        <SelectParameters>
            <asp:SessionParameter SessionField="iUserID" Name="UserID" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
    <script>
        $(function () {
            var availableTags = [ document.getElementById("ContentPlaceHolder3_litUsernames").innerText ];
            $("#txtCommunicatorName").autocomplete({
                source: availableTags,
                minLength:2
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

