<%@ Page Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="app_journo_profile" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Journalist</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="LeftBlockContainer">
        <div class="Block">
            <h3>Contact  Details</h3>
            <table>
                <tr>
                    <td style="width:80px; height: 30px;vertical-align: middle;">Mobile</td>
                    <td style="height: 30px;vertical-align: middle;"><asp:Literal runat="server" id="litContactMobile" /></td>
                </tr>
                <tr>
                    <td style="height: 30px;vertical-align: middle;">Office</td>
                    <td style="height: 30px;vertical-align: middle;"><asp:Literal runat="server" id="litContactOffice" /></td>
                </tr>
                <tr>
                    <td style="height: 30px;vertical-align: middle;">Fax</td>
                    <td style="height: 30px;vertical-align: middle;"><asp:Literal runat="server" id="litFaxNumber" /></td>
                </tr>
                <tr>
                    <td style="height: 30px;vertical-align: middle;">Email</td>
                    <td style="height: 30px;vertical-align: middle;"><asp:Literal runat="server" ID="litEmailAddress" /></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="MiddleBlockContainer">
       <div class="Block">
            <div class="ProfileImage" runat="server" id="divProfileImage"></div>
            <h3><asp:Literal runat="server" id="litFirstName" />&nbsp;&nbsp;<asp:Literal runat="server" id="litLastName" /></h3>
            <div class="divShortBio">           
                <asp:Literal runat="server" ID="litGender" /><asp:Literal runat="server" ID="litAge" />
                <asp:Literal runat="server" ID="litCurrentJobTitle" /><br />
                <asp:Literal runat="server" ID="litCurrentJobPublication" /><br />
                <asp:Literal runat="server" id="litCurrentCity" />     
                <asp:Literal runat="server" ID="litWebsiteAddress" />                
            </div>
       </div>
        <div class="Block">
            <h3>About</h3>
            <asp:Literal runat="server" ID="litShortBio" />
        </div>
        <div class="Block">
            <h3>Latest Tweets</h3>
             <div runat="server" id="divShowTweets"></div>
        </div>
    </div>
    <div class="RightBlockContainer">
        <div class="Block">
            <h3>Follow</h3>
            <div style="width:330px;float:left; height:135px;">
                <a href="#" runat="server" target="_blank" id="aProfileSocialButtonFacebook"><div class="ProfileSocialButton" style="background-color:#3b5998; border-top-left-radius: 5px;">Facebook</div></a>
                <a href="#" runat="server" target="_blank" id="aProfileSocialButtonTwitter"><div class="ProfileSocialButton" style="background-color:#55acee; border-top-right-radius: 5px;">Twitter</div></a>
                <a href="#" runat="server" target="_blank" id="aProfileSocialButtonLinkedIn"><div class="ProfileSocialButton" style="background-color:#0976b4">LinkedIn</div></a>
                <a href="#" runat="server" target="_blank" id="aProfileSocialButtonWebsite"><div class="ProfileSocialButton" style="background-color:#645357">Website</div></a>
                <a href="#" runat="server" id="aProfileSocialButtonEmail"><div class="ProfileSocialButton ProfileContactButton" style="background-color:#72a69b; border-bottom-left-radius: 5px;border-bottom-right-radius: 5px;">Email</div></a>
            </div>
        </div>
    </div> 
    <div class="ProfileShareContainer" style="display:none">
        <span style="font-size:16px;">SHARE THIS PROFILE</span><br />
        <a runat="server" id="aTwitterShare" href="#"><img src="../../styling/images/64-twitter.png" width="35" /></a>&nbsp;&nbsp;
        <a runat="server" id="aFacebookShare" href="#"><img src="../../styling/images/64-facebook.png" width="35" /></a>&nbsp;&nbsp;
        <a runat="server" id="aLinkedInShare" href="#"><img src="../../styling/images/64-linkedin.png" width="35" /></a>&nbsp;&nbsp;
    </div> 
    <div class="ResultsContainer" style="display:none">
        <h3 style="border-top-left-radius: 0px;border-top-right-radius: 0px;background-color:#35aadc; border-top-left-radius: 5px;border-top-right-radius: 5px;">Twitter Feed</h3>       
    </div>  

    <asp:XmlDataSource runat="server" id="dsUserJobs">

    </asp:XmlDataSource>
    <asp:XmlDataSource runat="server" id="dsUserArticles">

    </asp:XmlDataSource>
    <div class="Block">
        <h3>Add to Campaign Group</h3>
        <div runat="server" id="divMessage" class="Message SuccessMessage" visible="false">
            <asp:Literal runat="server" ID="txtSuccessMessage" Text="Journalist added to campaign group." Visible="false" />
            <asp:Literal runat="server" ID="txtErrorMessage" Text ="An error occured. Journalist not added to group." Visible="false" />
        </div>
	    <center>
            <asp:TextBox runat="server" ID="txtGroupName" Text="Enter group name" />
            <asp:Button runat="server" ID="btnAddSubscriberToList" Text="Add Me" OnClick="btnAddSubscriberToList_Click" CssClass="Pinky" />
<%--            <ul>
                <input type="button" id="btnTryMe" value="Add Me" class="Pinky" />
            </ul>--%>
	    </center>					    
    </div>
    <script>
        $("#btnTryM").click(function(){
            swal({
                title: "Add Journalist to Group!",
                text: "Enter name of already existing group:",
                type: "input",
                showCancelButton: true,
                closeOnConfirm: false,
                animation: "slide-from-top",
                inputPlaceholder: "e.g Tech Startups Group"
            }, function (inputValue) {
                if (inputValue === false)
                    return false;
                if (inputValue === "") {
                    swal.showInputError("You need to write name of existing group!");
                    return false
                } swal("Nice!", "Journalist added to group!", "success");
            });
        });        
    </script>
</asp:Content>

