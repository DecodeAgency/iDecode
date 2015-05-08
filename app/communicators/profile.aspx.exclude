<%@ Page Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="app_journo_profile" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
        <div class="Width960">
            <div style="float:right; margin-top: 3px;"><a href="search.aspx" runat="server" id="a1"><div class="ProfileSocialButton ProfileContactButton" style="background-color:#72a69b; border-radius: 5px;">Return to Search</div></a></div>
            <h1>Communication Officer</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="HeaderWrapper">
        <div class="ProfileHeader">
            <div class="ProfileImage" runat="server" id="divProfileImage"></div>
            <div style="background-color: #cc324c;margin-bottom: 5px;border-top-left-radius: 5px;border-top-right-radius: 5px;padding-bottom: 1px;">
                <span style="line-height: 45px;font-size: 25px !important;padding-top: 20px !Important; color:#fff"><asp:Literal runat="server" id="litFirstName" />&nbsp;&nbsp;<asp:Literal runat="server" id="litLastName" /></span>
            </div>
            <asp:Literal runat="server" ID="litGender" /><asp:Literal runat="server" ID="litAge" />
            <asp:Literal runat="server" ID="litCurrentJobTitle" /> <br />
            <asp:Literal runat="server" ID="litCurrentJobPublication" /><br/>
            <asp:Literal runat="server" id="litCurrentCity" />     
            <asp:Literal runat="server" ID="litWebsiteAddress" />
        </div>
        <div style="width:330px;float:left;height:135px">
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonFacebook"><div class="ProfileSocialButton" style="background-color:#3b5998; border-top-left-radius: 5px;">Facebook</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonTwitter"><div class="ProfileSocialButton" style="background-color:#55acee; border-top-right-radius: 5px;">Twitter</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonLinkedIn"><div class="ProfileSocialButton" style="background-color:#0976b4">LinkedIn</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonWebsite"><div class="ProfileSocialButton" style="background-color:#645357">Website</div></a>
            <a href="#" runat="server" id="aProfileSocialButtonEmail"><div class="ProfileSocialButton ProfileContactButton" style="background-color:#72a69b; border-bottom-left-radius: 5px;border-bottom-right-radius: 5px;">Email</div></a>
        </div>
    </div>
    <div class="RightContainer">
         <h3 style="background-color:#1a4e95">Contact Details</h3>
        <br />
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
    <div class="ResultsContainer" style="min-height:100px; margin-bottom:10px">
        <h3 style="background-color:#fcb150">About</h3>
        <br />
        <asp:Literal runat="server" ID="litShortBio" /><br />        
    </div>
    <div class="ResultsContainer">
        <h3 style="border-top-left-radius: 0px;border-top-right-radius: 0px;background-color:#35aadc; border-top-left-radius: 5px;border-top-right-radius: 5px;">Twitter Feed</h3>
        <div runat="server" id="divShowTweets"></div>
    </div>

    
    <div class="HeaderWrapper" style="display:none">             
        <div id="tabs-container">
            <ul class="tabs-menu">
                <li ><a href="#tab-1">OVERVIEW</a></li>
                <li><a href="#tab-2">ARTICLES</a></li>
                <li><a href="#tab-3">RECENT TWEETS</a></li>
                <li><a href="#tab-4">AWARDS</a></li>
                <li class="current"><a href="#tab-5">CONTACTS</a></li>
            </ul>
            <div class="tab" style="margin-top:-30px;">
                <div id="tab-1" class="tab-content">
                    <table>
                        <tr>
                            <td><h2>About</h2></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td><h2>Biography</h2></td>
                        </tr>
                        <tr>
                            <td><asp:Literal runat="server" ID="litBio" /></td>
                        </tr>
                    </table>
                </div>
                <div id="tab-2" class="tab-content">
                    <table>
                        <tr>
                            <td><h2>Articles</h2></td>
                        </tr>
                    </table>
                    <asp:repeater runat="server" id="rptUserArticles" DataSourceID="dsUserArticles">
                        <itemtemplate>
                            <div class="JobHistoryContainer">
                                <div class="PublicationImage" style='<%# "background-image:url(" + XPath ("imageurl") + ")" %>'></div>
                                <div class="PublicationName"><a href='<%# XPath ("url") %>'><%# XPath ("title") %></a></div>
                                <div class="Position"><%# XPath ("description") %> </div>
                            </div>
                        </itemtemplate>
                    </asp:repeater>
                </div>
                <div id="tab-3" class="tab-content">
                    <asp:Literal runat="server" ID="litTweets" />
                    <table>
                        <tr>
                            <td><h2>Twitter Feed</h2></td>
                        </tr>
                    </table>
                    <div runat="server" id="divTweets"></div>
                    <asp:repeater runat="server" id="rptUserJobs" DataSourceID="dsUserJobs" Visible="false">
                        <itemtemplate>
                            <div class="JobHistoryContainer">
                                <div class="PublicationImage" style='<%# "background-image:url(../images/publications/" + (XPath ("publication")).ToString().Replace(" ","") + ".png)" %>'></div>
                                <div class="PublicationName"><a href='<%# XPath ("url") %>'><%# XPath ("publication") %></a></div>
                                <div class="Position"><%# XPath ("position") %>, <%# XPath ("department") %> </div>
                                <div class="Duration"><%#  Convert.ToDateTime(XPath("startdate")).ToString("MMM yyyy") %> - <%# Convert.ToDateTime(XPath("enddate")).ToString("MMM yyyy") %></div>
                            </div>
                        </itemtemplate>
                    </asp:repeater>
                </div>
                <div id="tab-4" class="tab-content">
                    <p>Proin sollicitudin tincidunt quam, in egestas dui tincidunt non. Maecenas tempus condimentum mi, sed convallis tortor iaculis eu. Cras dui dui, tempor quis tempor vitae, ullamcorper in justo. Integer et lorem diam. Quisque consequat lectus eget urna molestie pharetra. Cras risus lectus, lobortis sit amet imperdiet sit amet, eleifend a erat. Suspendisse vel luctus lectus. Sed ac arcu nisi, sit amet ornare tellus. Pellentesque nec augue a nibh pharetra scelerisque quis sit amet felis. Nullam at enim at lacus pretium iaculis sit amet vel nunc. Praesent sapien felis, tincidunt vitae blandit ut, mattis at diam. Suspendisse ac sapien eget eros venenatis tempor quis id odio. Donec lacus leo, tincidunt eget molestie at, pharetra cursus odio. </p>
                </div>
                <div id="tab-5" class="tab-content" style="display:block">
                    <table>
                        <tr>
                            <td><h2>Contact Details</h2></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>Mobile Number:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Office Number:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Fax Number:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Email Address:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Website Address:</td>
                            <td><asp:Literal runat="server" ID="litContactWebsiteAddress" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="ProfileShareContainer">
            <span style="font-size:16px;">SHARE THIS PROFILE</span><br />
            <a runat="server" id="aTwitterShare" href="#"><img src="../../styling/images/64-twitter.png" width="35" /></a>&nbsp;&nbsp;
            <a runat="server" id="aFacebookShare" href="#"><img src="../../styling/images/64-facebook.png" width="35" /></a>&nbsp;&nbsp;
            <a runat="server" id="aLinkedInShare" href="#"><img src="../../styling/images/64-linkedin.png" width="35" /></a>&nbsp;&nbsp;
        </div>    
    </div>

    <asp:XmlDataSource runat="server" id="dsUserJobs">

    </asp:XmlDataSource>
    <asp:XmlDataSource runat="server" id="dsUserArticles">

    </asp:XmlDataSource>
    </form>
    <script>
        $(document).ready(function () {
            $(".tabs-menu a").click(function (event) {
                event.preventDefault();
                $(this).parent().addClass("current");
                $(this).parent().siblings().removeClass("current");
                var tab = $(this).attr("href");
                $(".tab-content").not(tab).css("display", "none");
                $(tab).fadeIn();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

