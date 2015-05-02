<%@ Page Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="profileedit.aspx.cs" Inherits="app_journo_profileedit" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/styling/css/decode.css" rel="stylesheet"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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
    <style>
        body {
            background-color:#ebebeb;
            color:#777
        }
        input, textarea {
            border:1px solid #ccc;
        }
            textarea {
                  height: 188px;
            }
            input[type='submit'] {
                float: right;
                width: 100px;
            }
        table tr td {
          width: 300px;
        }
    </style>
</head>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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
    <style>
        textarea {
                height: 188px;
        }
        input[type='submit'] {
            float: right;
            width: 100px;
        }
        table tr td {
          width: 300px;
        }

        .tabs-menu {
            height: 30px;
            float: left;
            clear: both;
            margin-bottom: 0px;
        }

        .tabs-menu li {
            height: 30px;
            line-height: 30px;
            float: left;
            background-color: #f6f6f6;
            list-style-type: none;
            font-size: 16px;
            font-weight: normal;
            padding: 10px;
            width: 104px;
            text-align: center;
        }

        .tabs-menu li.current {
            position: relative;
            background-color: #fff;
            z-index: 5;
            background-color: #fcb150;
            color: #fff !Important;
        }

        .tabs-menu li a {
            padding: 5px;
            text-transform: uppercase;
            color: #888;
            text-decoration: none; 
        }

        .tabs-menu .current a {
            color: #fff !Important;
        }

        .tab {
            background-color: transparent;
            float: left;
            margin-bottom: 20px;
            width: auto;
            margin-top: 20px;
        }

        .tab-content {
            width: 580px;
            padding: 20px !Important;
            display: none;
            color: #fff;
        }

        #tab-1 {
         display: block;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Manage Journalist Profile</h1></div>
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
            <asp:Literal runat="server" ID="litCurrentJobTitle" /><br />
            <asp:Literal runat="server" ID="litCurrentJobPublication" /><br />
            <asp:Literal runat="server" id="litCurrentCity" />     
            <asp:Literal runat="server" ID="litWebsiteAddress" />
        </div>
        <div style="width:330px;float:left; background-color:red;height:135px">
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonFacebook"><div class="ProfileSocialButton" style="background-color:#3b5998">Facebook</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonTwitter"><div class="ProfileSocialButton" style="background-color:#55acee">Twitter</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonLinkedIn"><div class="ProfileSocialButton" style="background-color:#0976b4">LinkedIn</div></a>
            <a href="#" runat="server" target="_blank" id="aProfileSocialButtonWebsite"><div class="ProfileSocialButton" style="background-color:#645357">Website</div></a>
            <a href="#" runat="server" id="aProfileSocialButtonEmail"><div class="ProfileSocialButton ProfileContactButton" style="background-color:#72a69b">Email</div></a>
        </div>
    </div>
    <div class="HeaderWrapper">             
        <div id="tabs-container">
            <ul class="tabs-menu">
                <li class="current"><a href="#tab-1">BIO & TITLE</a></li>
                <li><a href="#tab-2">ARTICLES</a></li>
                <li><a href="#tab-3">SOCIAL LINKS</a></li>
                <li><a href="#tab-4">SETTINGS</a></li>
                <li><a href="#tab-5">CONTACTS</a></li>
                <li><a href="#tab-6">JOB HISTORY</a></li>
            </ul>
            <div class="tab">
                <div id="tab-1" class="tab-content">
                    <table>
                        <tr>
                            <td>Profile Image</td>
                            <td><asp:FileUpload runat="server" ID="upProImage" /></td>
                        </tr>
                        <tr>
                            <td>First Name</td>
                            <td><asp:TextBox runat="server" ID="txtFirstName" CssClass="SearchTextBoxes" /></td>
                        </tr>
                         <tr>
                            <td>Last Name</td>
                            <td><asp:TextBox runat="server" ID="txtLastName" CssClass="SearchTextBoxes" /></td>
                        </tr>
                        <tr>
                            <td>Short Biography (80 characters)</td>
                            <td><asp:TextBox runat="server" ID="txtOneLineBio" CssClass="SearchTextBoxes" /></td>
                        </tr>
                        <tr>
                            <td style="vertical-align:top">Biography (1000 characters)</td>
                            <td><asp:TextBox runat="server" ID="txtLongBiography" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                            <td>Current Job Title</td>
                            <td><asp:TextBox runat="server" ID="txtCurrentJobTitle" CssClass="SearchTextBoxes" /></td>
                        </tr>
                        <tr>
                            <td>Current Job Publication</td>
                            <td><asp:TextBox runat="server" ID="txtCurrentJobPublication" CssClass="SearchTextBoxes" /></td>
                        </tr>
                        <tr>
                            <td>Current City</td>
                            <td><asp:TextBox runat="server" ID="txtCurrentCity" CssClass="SearchTextBoxes" /></td>
                        </tr>
                        <tr style="display:none">
                            <td>Age</td>
                            <td><asp:TextBox runat="server" ID="txtAge" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" ID="btnSaveBio" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="SearchButton MoveRight15" /></td>
                        </tr>
                    </table>
                </div>
                <div id="tab-2" class="tab-content">
                    <table>
                        <tr runat="server" id="trArticleLinkURL">                            
                            <td colspan="2" style="width: 550px;">Enter the URL for one of your article and iDecode will automatically grab the title, description, thumbnail image, and outlet name. You'll be able to edit these fields.<br /><asp:TextBox runat="server" ID="txtArticleLink"></asp:TextBox><asp:Button runat="server" ID="btnProcessArticleLink" OnClick="btnProcessArticleLink_Click" Text="Add" CssClass="SearchButton MoveRight15" /></td>
                        </tr>
                        <div runat="server" id="divArticleDetails" visible="false">
                            <tr>
                                <td>Title</td>
                                <td><asp:TextBox runat="server" ID="txtArticleTitle" /></td>
                            </tr>
                            <tr>
                                <td>Media Outlet</td>
                                <td><asp:TextBox runat="server" ID="txtArticleMediaOutlet" /></td>
                            </tr>
                            <tr>
                                <td>Article URL</td>
                                <td><asp:TextBox runat="server" ID="txtArticleURL" /></td>
                            </tr>
                            <tr>
                                <td>Date Published</td>
                                <td><asp:TextBox runat="server" ID="txtArticleDatePublished" /></td>
                            </tr>
                            <tr>
                                <td>Image URL</td>
                                <td><asp:TextBox runat="server" ID="txtArticleImageURL" /></td>
                            </tr>
                            <tr>
                                <td>Description</td>
                                <td><asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine"  /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button runat="server" ID="btnSaveUserArticle" Text="Save Changes" OnClick="btnSaveUserArticle_Click" CssClass="SearchButton MoveRight15" /></td>
                            </tr>
                        </div>
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
                    <table>
                        <tr>
                            <td>Twitter URL:</td>
                            <td><asp:TextBox runat="server" ID="txtTwitterURL" /></td>
                        </tr>
                        <tr>
                            <td>Facebook URL:</td>
                            <td><asp:TextBox runat="server" ID="txtFacebookURL" /></td>
                        </tr>
                        <tr>
                            <td>LinkedIn URL:</td>
                            <td><asp:TextBox runat="server" ID="txtLinkedInURL"/></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" ID="btnSocialSave" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="SearchButton MoveRight15" /></td>
                        </tr>
                    </table>
                </div>
                <div id="tab-4" class="tab-content">
                    <p>Proin sollicitudin tincidunt quam, in egestas dui tincidunt non. Maecenas tempus condimentum mi, sed convallis tortor iaculis eu. Cras dui dui, tempor quis tempor vitae, ullamcorper in justo. Integer et lorem diam. Quisque consequat lectus eget urna molestie pharetra. Cras risus lectus, lobortis sit amet imperdiet sit amet, eleifend a erat. Suspendisse vel luctus lectus. Sed ac arcu nisi, sit amet ornare tellus. Pellentesque nec augue a nibh pharetra scelerisque quis sit amet felis. Nullam at enim at lacus pretium iaculis sit amet vel nunc. Praesent sapien felis, tincidunt vitae blandit ut, mattis at diam. Suspendisse ac sapien eget eros venenatis tempor quis id odio. Donec lacus leo, tincidunt eget molestie at, pharetra cursus odio. </p>
                </div>
                <div id="tab-5" class="tab-content">
                    <table>
                        <tr>
                            <td>Mobile Number:</td>
                            <td><asp:TextBox runat="server" ID="txtMobileNumber" /></td>
                        </tr>
                        <tr>
                            <td>Office Number:</td>
                            <td><asp:TextBox runat="server" ID="txtOfficeNumber" /></td>
                        </tr>
                        <tr>
                            <td>Fax Number:</td>
                            <td><asp:TextBox runat="server" ID="txtFaxNumber" /></td>
                        </tr>
                        <tr>
                            <td>Email Address:</td>
                            <td><asp:TextBox runat="server" ID="txtEmailAddress" /></td>
                        </tr>
                        <tr>
                            <td>Website Address:</td>
                            <td><asp:TextBox runat="server" ID="txtWebsiteAddress" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" ID="btnContactsSave" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="SearchButton MoveRight15" /></td>
                        </tr>
                    </table>
                </div>
                 <div id="tab-6" class="tab-content">
                     <table class="tbNewJob" runat="server">
                         <tr>
                            <td>Publication:</td>
                            <td><asp:TextBox runat="server" ID="txtPublication" /></td>
                        </tr>
                        <tr>
                            <td>Web Address</td>
                            <td><asp:TextBox runat="server" ID="txtWebAddress" /></td>
                        </tr>
                        <tr>
                            <td>Position</td>
                            <td><asp:TextBox runat="server" ID="txtPosition" /></td>
                        </tr>
                          <tr>
                            <td>Department</td>
                            <td><asp:TextBox runat="server" ID="txtDepartment" /></td>
                        </tr>
                         <tr>
                            <td>Start Date</td>
                            <td>
                               <asp:TextBox runat="server" ID="txtStartDate" TextMode="DateTime"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>End Date</td>
                            <td>
                               <asp:TextBox runat="server" ID="txtEndDate" TextMode="DateTime"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" ID="btnAddJob" Text="Add Job" OnClick="btnAddJob_Click" CssClass="SearchButton MoveRight15" /></td>
                        </tr>
                     </table>
                     <table>
                         <tr>
                             <td>
                                 <asp:Repeater runat="server" ID="rptUserJobs" DataSourceID="dsUserJobs">
                                     <ItemTemplate>
                                         <div class="JobHistoryContainer">
                                             <div class="PublicationImage" style='<%# "background-image:url(../images/publications/" + (XPath ("publication")).ToString().Replace(" ","") + ".png)" %>'></div>
                                             <div class="PublicationName"><a href='<%# XPath ("url") %>'><%# XPath ("publication") %></a></div>
                                             <div class="Position"><%# XPath ("position") %>, <%# XPath ("department") %> </div>
                                             <div class="Duration">  
                                               <asp:TextBox runat="server" textmode="DateTime" Text='<%#  Convert.ToDateTime(XPath("startdate")).ToString("MMM yyyy") %>'> </asp:TextBox>
                                                 <asp:TextBox runat="server" textmode="DateTime" Text='<%# Convert.ToDateTime(XPath("enddate")).ToString("MMM yyyy") %>'> </asp:TextBox>
                                         </div></div>
                                         <div class="CurrentJob"><asp:checkbox runat="server" ID="chkCurrent" Checked='<%# Convert.ToBoolean(XPath("currentjob")) %>'/></div>
                                     </ItemTemplate>
                                 </asp:Repeater>
                             </td>
                         </tr>
                         <tr>
                             <td></td>
                             <td>
                                 <asp:Button runat="server" ID="btnSaveJobs" Text="Save Changes" OnClick="btnSaveJobs_Click" CssClass="SearchButton MoveRight15" />
                             </td>
                         </tr>
                     </table>
                 </div> 
            </div>
        </div>
        <div class="ProfileShareContainer" style="display:none">
            <span style="font-size:16px;">SHARE THIS PROFILE</span><br />
            <a runat="server" id="aTwitterShare" href="#"><img src="../../styling/images/64-twitter.png" width="35" /></a>&nbsp;&nbsp;
            <a runat="server" id="aFacebookShare" href="#"><img src="../../styling/images/64-facebook.png" width="35" /></a>&nbsp;&nbsp;
            <a runat="server" id="aLinkedInShare" href="#"><img src="../../styling/images/64-linkedin.png" width="35" /></a>&nbsp;&nbsp;
        </div>    
    </div>

    <asp:XmlDataSource runat="server" id="dsUserArticles">

    </asp:XmlDataSource>
    <asp:XmlDataSource runat="server" id="dsUserJobs">

    </asp:XmlDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
