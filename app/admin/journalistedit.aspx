<%@ Page Language="C#" MasterPageFile="~/app/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="journalistedit.aspx.cs" Inherits="app_journo_profileedit" %>
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

        input[type='submit'] {
          float: right;
          width: 200px !Important;
        }

        .ProfileImage {
            height: 125px;
            width: 125px;
            background-position: center;
            background-size: cover;
            float: left;
            margin-right: 20px;
            border-radius: 100%;
            border: 3px solid #545885;
            margin-top: 3px;
            margin-left: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="page-inner">
        <div class="row">
            <div class="col-md-12">
                <h1 class="page-header">
                    <asp:Literal runat="server" ID="litHeading" /> <asp:Literal runat="server" id="litFirstName" />&nbsp;&nbsp;<asp:Literal runat="server" id="litLastName" /><small style="display:none">Summary of your App</small>
                </h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="table-responsive">                        
                        <div class="form-group" id="divBio">
                            <h2>Bio & Title</h2><br />
                            <div class="ProfileImage" runat="server" id="divProfileImage"></div>
                            <div style="clear:both"></div>
                            <label>Profile Image</label> 
                            <asp:FileUpload runat="server" ID="upProImage" CssClass="form-control" />
                            <br />
                            <label>First Name</label>
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <label>Last Name</label>
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <label>Short Biography (80 characters)</label>
                            <asp:TextBox runat="server" ID="txtOneLineBio" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <label>Biography (1000 characters)</label>
                            <asp:TextBox runat="server" ID="txtLongBiography" TextMode="MultiLine" CssClass="form-control" />
                            <br />
                            <label>Current Job Title</label>
                            <asp:TextBox runat="server" ID="txtCurrentJobTitle" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <label>Current Job Publication</label>
                            <asp:TextBox runat="server" ID="txtCurrentJobPublication" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <label>Current City</label>
                            <asp:TextBox runat="server" ID="txtCurrentCity" CssClass="SearchTextBoxes form-control" />
                            <br />
                            <div runat="server" id="divBeat">
                            <label>Beat</label>
                            <asp:DropDownList runat="server" ID="dBeats" DataSourceID="dsBeats" DataTextField="BeatName" DataValueField="BeatID" CssClass="form-control" />
                            </div>
                            <div style="display:none">
                                <br />
                                <label>Age</label>
                                <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" />
                            </div>
                            <br />
                            <asp:Button runat="server" ID="btnSaveBio" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="form-control btn-danger" />
                        </div>
                    
                        <div class="form-group" id="divArticles" runat="server">
                            <h2>Articles</h2><br />
                            <div runat="server" id="trArticleLinkURL">                            
                                <label>Enter the URL for one of your article and iDecode will automatically grab the title, description, thumbnail image, and outlet name. You'll be able to edit these fields.</label>
                                <br /> 
                                <asp:TextBox runat="server" ID="txtArticleLink" CssClass="form-control"></asp:TextBox><br />
                                <asp:Button runat="server" ID="btnProcessArticleLink" OnClick="btnProcessArticleLink_Click" Text="Add" CssClass="form-control btn-success" />
                            </div>
                            <div runat="server" id="divArticleDetails" visible="false">
                                <label>Title</label>
                                <asp:TextBox runat="server" ID="txtArticleTitle" CssClass="form-control" />
                                <br />
                                <label>Media Outlet</label>
                                <asp:TextBox runat="server" ID="txtArticleMediaOutlet" CssClass="form-control" />
                                <br />
                                <label>Article URL</label>
                                <asp:TextBox runat="server" ID="txtArticleURL" CssClass="form-control" />
                                <br />
                                <label>Date Published</label>
                                <asp:TextBox runat="server" ID="txtArticleDatePublished" CssClass="form-control" />
                                <br />
                                <label>Image URL</label>
                                <asp:TextBox runat="server" ID="txtArticleImageURL" CssClass="form-control" />
                                <br />
                                <label>Description</label>
                                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="form-control"  />
                                <br />
                                <asp:Button runat="server" ID="btnSaveUserArticle" Text="Save Changes" OnClick="btnSaveUserArticle_Click" CssClass="form-control btn-danger" />
                            </div>
                        </div> 
                    
                        <div class="form-group" id="divSocialLinks">
                            <h2>Social Links</h2><br />
                            <label>Twitter Handle</label>
                            <asp:TextBox runat="server" ID="txtTwitterURL" CssClass="form-control" />
                            <p class="help-block">Hint: Molebatsi_O (exclude '@')</p>
                            <br />
                            <label>Facebook Username</label>
                            <asp:TextBox runat="server" ID="txtFacebookURL" CssClass="form-control" />
                            <p class="help-block">Hint: Baxitoo</p>
                            <br />
                            <label>LinkedIn URL</label>
                            <asp:TextBox runat="server" ID="txtLinkedInURL" CssClass="form-control"/>
                            <p class="help-block">Hint: https://za.linkedin.com/in/obakengmolebatsi </p>
                            <br />
                            <asp:Button runat="server" ID="btnSocialSave" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="form-control btn-danger" />
                        </div>
                    
                        <div class="form-group" id="divContactDetails">
                            <h2>Contact Details</h2><br />
                            <label>Mobile Number</label>
                            <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="form-control" />
                            <br />
                            <label>Office Number</label>
                            <asp:TextBox runat="server" ID="txtOfficeNumber" CssClass="form-control" />
                            <br />
                            <label>Fax Number</label>
                            <asp:TextBox runat="server" ID="txtFaxNumber" CssClass="form-control" />
                            <br />
                            <label>Email Address</label>
                            <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" />
                            <br />
                            <label>Website Address</label>
                            <br />
                            <asp:TextBox runat="server" ID="txtWebsiteAddress" CssClass="form-control" />
                             <br />
                            <asp:Button runat="server" ID="btnContactsSave" Text="Save Changes" OnClick="btnSaveBio_Click" CssClass="form-control btn-danger" />
                        </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="dsBeats" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT BeatID, ISNULL(BeatName,'') AS BeatName FROM Beats UNION SELECT 0,'----------' ORDER BY BeatName" >
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div style="display:none">
    <div style="float:right; display:none">
        <asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
    </div>
    <div class="HeaderWrapper">
        <div class="ProfileHeader">
            
            <div style="background-color: #cc324c;margin-bottom: 5px;border-top-left-radius: 5px;border-top-right-radius: 5px;padding-bottom: 1px;">
                <span style="line-height: 45px;font-size: 25px !important;padding-top: 20px !Important; color:#fff"></span>
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
            </ul>
            <div class="tab">
                <div id="tab-1" class="tab-content">

                </div>
                <div id="tab-2" class="tab-content">

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
                </div>
                <div id="tab-4" class="tab-content">
                    <p>Proin sollicitudin tincidunt quam, in egestas dui tincidunt non. Maecenas tempus condimentum mi, sed convallis tortor iaculis eu. Cras dui dui, tempor quis tempor vitae, ullamcorper in justo. Integer et lorem diam. Quisque consequat lectus eget urna molestie pharetra. Cras risus lectus, lobortis sit amet imperdiet sit amet, eleifend a erat. Suspendisse vel luctus lectus. Sed ac arcu nisi, sit amet ornare tellus. Pellentesque nec augue a nibh pharetra scelerisque quis sit amet felis. Nullam at enim at lacus pretium iaculis sit amet vel nunc. Praesent sapien felis, tincidunt vitae blandit ut, mattis at diam. Suspendisse ac sapien eget eros venenatis tempor quis id odio. Donec lacus leo, tincidunt eget molestie at, pharetra cursus odio. </p>
                </div>
                <div id="tab-5" class="tab-content">
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
</div>
</asp:Content>
