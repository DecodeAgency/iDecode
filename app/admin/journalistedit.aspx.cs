using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HtmlAgilityPack;
using System.Text.RegularExpressions; 
using System.Net;

public partial class app_journo_profileedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
            //var oGeneralFunctions = new GeneralFunctions();
            //oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
                        
            if (Request.Cookies["idecode"] != null)
            {
                if (Request.Cookies["idecode"]["uid"] != null)
                {
                    Session["iUserID"] = Convert.ToInt32(Request.Cookies["idecode"]["uid"]);
                }
            }

            int iJournalistID = Convert.ToInt32(Request.QueryString["uid"].ToString());

            var oDecode = new za.co.idecode.test.idecode();
            XmlNode XmlResult = oDecode.LoadUser(iJournalistID, "");
            string sFirstName = "", sLastName = "", sCurrentCity = "", sContactMobile = "", sContactOffice = "", sFaxNumber = "", sEmailAddress = "", sWebsiteAddress = "", sFacebookUsername = "", sTwitterUsername = "", sLinkedInUsername = "", sImageFormat = "", sTwitterProfileImageURL = "", sShortBiography = "", sBiography = "", sCurrentJobTitle = "", sCurrentJobPublication = "";
            string sPassword = "", sTwitterOauthToken = "", sTwitterOauthTokenSecret = "", sTwitterScreenName = "", sEditorName = "", sEditorEmal = "";
            int iUserID = 0, iGenderID = 0, iAge = 0, iCountryID = 0, iUserTypeID = 0, iBeatID = 0;
            ulong iTwitterUserID = 0;
            bool bActive = false;
            DateTime dLastUpdateddate = DateTime.Now, dDateTimeStamp = DateTime.Now;


            foreach (XmlNode Nodes in XmlResult)
            {
                iUserID = Convert.ToInt16(Nodes["userid"].InnerText);
                sFirstName = Nodes["firstname"].InnerText;
                sLastName = Nodes["lastname"].InnerText;
                iGenderID = Convert.ToInt16(Nodes["genderid"].InnerText);
                iAge = Convert.ToInt16(Nodes["age"].InnerText);
                sCurrentCity = Nodes["currentcity"].InnerText;
                iCountryID = Convert.ToInt16(Nodes["countryid"].InnerText);
                sContactMobile = Nodes["contactmobile"].InnerText;
                sContactOffice = Nodes["contactoffice"].InnerText;
                sFaxNumber = Nodes["faxnumber"].InnerText;
                sEmailAddress = Nodes["emailaddress"].InnerText;
                sPassword = Nodes["password"].InnerText;
                sWebsiteAddress = Nodes["websiteaddress"].InnerText;
                bActive = Convert.ToBoolean(Nodes["active"].InnerText);
                dDateTimeStamp = Convert.ToDateTime(Nodes["datetimestamp"].InnerText);
                dLastUpdateddate = Convert.ToDateTime(Nodes["lastupdateddate"].InnerText);
                iUserTypeID = Convert.ToInt32(Nodes["usertypeid"].InnerText);
                sFacebookUsername = Nodes["facebookusername"].InnerText;
                sTwitterUsername = Nodes["twitterusername"].InnerText;
                sLinkedInUsername = Nodes["linkedinusername"].InnerText;
                sImageFormat = Nodes["imageformat"].InnerText;
                sTwitterOauthToken = Nodes["twitteroauthtoken"].InnerText;
                sTwitterOauthTokenSecret = Nodes["twitteroauthtokensecret"].InnerText;
                sTwitterScreenName = Nodes["twitterscreenname"].InnerText;
                sTwitterProfileImageURL = Nodes["twitterprofileimageurl"].InnerText;
                iTwitterUserID = Convert.ToUInt64(Nodes["twitteruserid"].InnerText);
                sTwitterProfileImageURL = Nodes["twitterprofileimageurl"].InnerText;
                sShortBiography = Nodes["shortbiography"].InnerText;
                sBiography = Nodes["biography"].InnerText;
                sCurrentJobTitle = Nodes["currentjobtitle"].InnerText;
                sCurrentJobPublication = Nodes["currentjobpublication"].InnerText;
                iBeatID = Convert.ToInt32(Nodes["beatid"].InnerText);
                sEditorName = Nodes["editorname"].InnerText;
                sEditorEmal = Nodes["editoremail"].InnerText;    
            }

                        
            if (iUserTypeID == 2) {
                divArticles.Visible = true;
                divBeat.Visible = true;
                litHeading.Text = "Manage Journalist: ";
            }
            else if (iUserTypeID == 3)
            {
                divArticles.Visible = false;
                divBeat.Visible = false;
                litHeading.Text = "Manage Communicator: ";
            }

            this.Page.Title = "iDecode | Manage Journalist Profile - " + sFirstName + " " + sLastName;

            if (sTwitterProfileImageURL != "")
            {
                divProfileImage.Style.Add("background-image", "url('" + sTwitterProfileImageURL + "')");
            }
            else if (sImageFormat != "")
            {
                divProfileImage.Style.Add("background-image", "url('../images/profileimages/" + iJournalistID + "." + sImageFormat + "')");
            }
            else
            {
                divProfileImage.Style.Add("background-image", "url('../images/profileimages/0.png')");
            }

            litFirstName.Text = sFirstName + " " + sLastName;
            litCurrentCity.Text = sCurrentCity + ", South Africa <br />";
            if (sCurrentCity == "")
            {
                litCurrentCity.Visible = false;
            }
            litAge.Text = iAge.ToString() + ",&nbsp; years old <br />";
            if (iAge == 0)
            {
                litAge.Visible = false;
            }
            litGender.Text = iGenderID == 1 ? "Male" : "Female" + "<br />";
            if (iGenderID == 0)
            {
                litGender.Visible = false;
            }
            litWebsiteAddress.Text = sWebsiteAddress + "<br />";
            if (sWebsiteAddress == "")
            {
                litWebsiteAddress.Visible = false;
            }
            litCurrentJobPublication.Text = sCurrentJobPublication;
            litCurrentJobTitle.Text = sCurrentJobTitle;

            aTwitterShare.HRef = "https://twitter.com/intent/tweet?related=Decode Media&text=" + sFirstName + " " + sLastName;
            aFacebookShare.HRef = "https://www.facebook.com/sharer/sharer.php?u=http://test.idecode.co.za/";
            aLinkedInShare.HRef = "http://www.linkedin.com/shareArticle?mini=true&url=http%3A//muckrack.com/CassandraVinograd&title=Cassandra%20Vinograd%27s%20Muck%20Rack%20portfolio&summary=Cassandra%20Vinograd%27s%20Muck%20Rack%20profile&source=";

            aProfileSocialButtonFacebook.HRef = "https://" + sFacebookUsername;
            aProfileSocialButtonTwitter.HRef = "https://" + sTwitterUsername;
            aProfileSocialButtonLinkedIn.HRef = "https://" + sLinkedInUsername;
            aProfileSocialButtonWebsite.HRef = "http://" + sWebsiteAddress;
            aProfileSocialButtonEmail.HRef = "mailto:" + sEmailAddress;

            if (!IsPostBack)
            {
                //Bio and Title
                txtFirstName.Text = sFirstName;
                txtLastName.Text = sLastName;
                txtAge.Text = Convert.ToString(iAge);
                txtCurrentCity.Text = sCurrentCity;
                txtOneLineBio.Text = sShortBiography;
                txtLongBiography.Text = sBiography;
                txtCurrentJobTitle.Text = sCurrentJobTitle;
                txtCurrentJobPublication.Text = sCurrentJobPublication;
                dBeats.SelectedValue = Convert.ToInt32(iBeatID).ToString();

                //Social Links
                txtTwitterURL.Text = sTwitterUsername;
                txtFacebookURL.Text = sFacebookUsername;
                txtLinkedInURL.Text = sLinkedInUsername;

                txtMobileNumber.Text = sContactMobile;
                txtOfficeNumber.Text = sContactOffice;
                txtEmailAddress.Text = sEmailAddress;
                txtFaxNumber.Text = sFaxNumber;
                txtWebsiteAddress.Text = sWebsiteAddress;
            }

            XmlDocument doc = new XmlDocument();
            string s = Convert.ToString(oDecode.LoadUserArticles(iJournalistID).InnerXml);
            doc.LoadXml(s);

            XmlDataSource xDataSource = new XmlDataSource();
            xDataSource.Data = doc.OuterXml;
            xDataSource.DataBind();
            xDataSource.ID = "XmlSource1";

            dsUserArticles.Data = xDataSource.Data;
            dsUserArticles.DataBind();
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
    }

    protected void btnSaveBio_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            int iJournalistID = Convert.ToInt32(Request.QueryString["uid"].ToString());
            var oDecode = new za.co.idecode.test.idecode();
            XmlNode XmlResult = oDecode.LoadUser(iJournalistID, "");
            string sFirstName = "", sLastName = "", sCurrentCity = "", sContactMobile = "", sContactOffice = "", sFaxNumber = "", sEmailAddress = "", sWebsiteAddress = "", sFacebookUsername = "", sTwitterUsername = "", sLinkedInUsername = "", sImageFormat = "", sTwitterProfileImageURL = "", sShortBiography = "", sBiography = "", sCurrentJobTitle = "", sCurrentJobPublication = "";
            string sPassword = "", sTwitterOauthToken = "", sTwitterOauthTokenSecret = "", sTwitterScreenName = "", sEditorname = "", sEditorEmail = "";
            int iUserID = 0, iGenderID = 0, iAge = 0, iCountryID = 0, iUserTypeID = 0, iBeatID = 0, iPackageID = 0;
            ulong iTwitterUserID = 0;
            bool bActive = false;
            DateTime dLastUpdateddate = DateTime.Now, dDateTimeStamp = DateTime.Now;

            foreach (XmlNode Nodes in XmlResult)
            {
                iUserID = Convert.ToInt16(Nodes["userid"].InnerText);
                sFirstName = Nodes["firstname"].InnerText;
                sLastName = Nodes["lastname"].InnerText;
                iGenderID = Convert.ToInt16(Nodes["genderid"].InnerText);
                iAge = Convert.ToInt16(Nodes["age"].InnerText);
                sCurrentCity = Nodes["currentcity"].InnerText;
                iCountryID = Convert.ToInt16(Nodes["countryid"].InnerText);
                sContactMobile = Nodes["contactmobile"].InnerText;
                sContactOffice = Nodes["contactoffice"].InnerText;
                sFaxNumber = Nodes["faxnumber"].InnerText;
                sEmailAddress = Nodes["emailaddress"].InnerText;
                sPassword = Nodes["password"].InnerText;
                sWebsiteAddress = Nodes["websiteaddress"].InnerText;
                bActive = Convert.ToBoolean(Nodes["active"].InnerText);
                dDateTimeStamp = Convert.ToDateTime(Nodes["datetimestamp"].InnerText);
                dLastUpdateddate = Convert.ToDateTime(Nodes["lastupdateddate"].InnerText);
                iUserTypeID = Convert.ToInt32(Nodes["usertypeid"].InnerText);
                sFacebookUsername = Nodes["facebookusername"].InnerText;
                sTwitterUsername = Nodes["twitterusername"].InnerText;
                sLinkedInUsername = Nodes["linkedinusername"].InnerText;
                sImageFormat = Nodes["imageformat"].InnerText;
                sTwitterOauthToken = Nodes["twitteroauthtoken"].InnerText;
                sTwitterOauthTokenSecret = Nodes["twitteroauthtokensecret"].InnerText;
                sTwitterScreenName = Nodes["twitterscreenname"].InnerText;
                sTwitterProfileImageURL = Nodes["twitterprofileimageurl"].InnerText;
                iTwitterUserID = Convert.ToUInt64(Nodes["twitteruserid"].InnerText);
                sTwitterProfileImageURL = Nodes["twitterprofileimageurl"].InnerText;
                sShortBiography = Nodes["shortbiography"].InnerText;
                sBiography = Nodes["biography"].InnerText;
                sCurrentJobTitle = Nodes["currentjobtitle"].InnerText;
                sCurrentJobPublication = Nodes["currentjobpublication"].InnerText;
                iBeatID = Convert.ToInt32(Nodes["beatid"].InnerText);
                iPackageID = Convert.ToInt32(Nodes["packageid"].InnerText);
                sEditorname = Nodes["editorname"].InnerText;
                sEditorEmail = Nodes["editoremail"].InnerText;
            }

            if (upProImage.HasFile)
            {
                sImageFormat = System.IO.Path.GetExtension(upProImage.PostedFile.FileName).Replace(".", "");
                upProImage.PostedFile.SaveAs(Server.MapPath("/app/images/profileimages/") + iJournalistID + "." + sImageFormat);
            }

            oDecode = new za.co.idecode.test.idecode();
            bool bSaveResult = oDecode.UpdateUser(iJournalistID, txtFirstName.Text, txtLastName.Text, iGenderID, Convert.ToInt32(txtAge.Text), txtCurrentCity.Text, iCountryID, txtMobileNumber.Text, txtOfficeNumber.Text, txtFaxNumber.Text, txtEmailAddress.Text, sPassword, txtWebsiteAddress.Text, iUserTypeID, txtFacebookURL.Text, txtTwitterURL.Text, txtLinkedInURL.Text, sImageFormat, sTwitterOauthToken, sTwitterOauthTokenSecret, sTwitterScreenName, iTwitterUserID, sTwitterProfileImageURL, txtOneLineBio.Text, txtLongBiography.Text, txtCurrentJobTitle.Text, txtCurrentJobPublication.Text, Convert.ToInt32(dBeats.SelectedValue), iPackageID, sEditorname, sEditorEmail);
            Response.Redirect(Request.Url.AbsoluteUri,false);
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }  

    }
    protected void btnProcessArticleLink_Click(object sender, EventArgs e)
    {
        try
        {
            //var oGeneralFunctions = new GeneralFunctions();
            //oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            
            String url = txtArticleLink.Text;
            WebClient x = new WebClient();
            string sourcedata = x.DownloadString(url);
            txtArticleTitle.Text = Regex.Match(sourcedata, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            GetMetaTagValue(url);
            trArticleLinkURL.Visible = false;
            divArticleDetails.Visible = true;
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
    }
 

    protected void btnSaveUserArticle_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            
            int iJournalistID = Convert.ToInt32(Request.QueryString["uid"].ToString());
            var oDecode = new za.co.idecode.test.idecode();
            bool bSaveUserArticle = oDecode.NewUserArticle(iJournalistID, txtArticleTitle.Text, txtArticleMediaOutlet.Text, txtDescription.Text, txtArticleURL.Text, Convert.ToDateTime(txtArticleDatePublished.Text), "", "", Convert.ToBoolean(1), txtArticleImageURL.Text);
            dsUserArticles.DataBind();
            rptUserArticles.DataBind();
            trArticleLinkURL.Visible = true;
            divArticleDetails.Visible = false;
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            //var oGeneralFunctions = new GeneralFunctions();
            //oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            Response.Redirect("~/app/admin/journalists.aspx", true);
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
    }

    private void GetMetaTagValue(string url)
    {
        var getHtmlDoc = new HtmlWeb();
        var document = getHtmlDoc.Load(url);
        var metaTags = document.DocumentNode.SelectNodes("//meta");
        if (metaTags != null)
        {
            foreach (var sitetag in metaTags)
            {

                if (sitetag.Attributes["property"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["property"].Value == "og:title")
                {
                    txtArticleTitle.Text = sitetag.Attributes["content"].Value;
                }

                if (sitetag.Attributes["property"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["property"].Value == "og:description")
                {
                    txtDescription.Text = sitetag.Attributes["content"].Value;
                }


                if (sitetag.Attributes["property"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["property"].Value == "og:site_name")
                {
                    txtArticleMediaOutlet.Text = sitetag.Attributes["content"].Value;
                }
                //For EyeWitnessNews
                if (sitetag.Attributes["name"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["name"].Value == "twitter:app:name:iphone")
                {
                    txtArticleMediaOutlet.Text = sitetag.Attributes["content"].Value;
                }
                if (sitetag.Attributes["property"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["property"].Value == "og:url")
                {
                    txtArticleURL.Text = sitetag.Attributes["content"].Value;
                }
                

                if (sitetag.Attributes["name"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["name"].Value == "publicationdate")
                {
                    txtArticleDatePublished.Text = sitetag.Attributes["content"].Value;
                }
                //For EyeWitnessNews
                if (sitetag.Attributes["name"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["name"].Value == "twitter:url")
                {
                    txtArticleURL.Text = sitetag.Attributes["content"].Value;
                }

                if (sitetag.Attributes["property"] != null && sitetag.Attributes["content"] != null && sitetag.Attributes["property"].Value == "og:image")
                {
                    txtArticleImageURL.Text = sitetag.Attributes["content"].Value;
                }
            }
        }
    }

}