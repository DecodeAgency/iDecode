using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

using MailChimp;
using MailChimp.Lists;

public partial class app_search : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        //querystrings kqy = Keyword, jn = jounalist name, bid = beatid, mid = mediaoutletid, l=location, t = topic
        //or store values in session variables
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        this.Page.Title = "iDecode | Search for Journalists";
        

        try
        {
            if (Request.QueryString["sci"] != null) {
                if (Request.QueryString["sci"].ToString() != "")
                {
                    int iUserJournalistSearchID = Convert.ToInt32(Request.QueryString["sci"].ToString());
                    var oUserJournalistSearch = new UserJournalistSearch(iUserJournalistSearchID);
                    txtkeyword.Text = oUserJournalistSearch.Keywords;
                    txtJournoName.Text = oUserJournalistSearch.Journalist;
                    txtLocation.Text = oUserJournalistSearch.Location;
                    ddPublication.SelectedValue = oUserJournalistSearch.MediaOutletID.ToString();
                    JornoSearch(oUserJournalistSearch.Keywords, oUserJournalistSearch.Journalist, oUserJournalistSearch.MediaOutletID, oUserJournalistSearch.Location);
                }
            }
           
            XmlNode XmlResult = null;
            var oDecode = new za.co.idecode.test.idecode();
            XmlResult = oDecode.LoadUser(Convert.ToInt32(Request.Cookies["idecode"]["uid"]), "");
            
            string sFirstName = "", sLastName = "", sCurrentCity = "", sContactMobile = "", sContactOffice = "", sFaxNumber = "", sEmailAddress = "", sWebsiteAddress = "", sFacebookUsername = "", sTwitterUsername = "", sLinkedInUsername = "", sImageFormat = "", sTwitterProfileImageURL = "", sShortBiography = "", sBiography = "", sCurrentJobTitle = "", sCurrentJobPublication = "";
            string sPassword = "", sTwitterOauthToken = "", sTwitterOauthTokenSecret = "", sTwitterScreenName = "";
            int iUserID = 0, iGenderID = 0, iAge = 0, iCountryID = 0, iUserTypeID = 0;
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
            }

            var oUser = new User(iUserID, "");
            litJournalistCount.Text = Convert.ToString(oUser.Count(2));
            litCampaignGroupsCount.Text = Convert.ToString(CountCampaignGroups(iUserID));
        }
        catch (Exception ex) { 
        
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        JornoSearch(txtkeyword.Text, txtJournoName.Text, Convert.ToInt32(ddPublication.SelectedValue), txtLocation.Text); 
    }


    public void JornoSearch(string keyword, string journalist, int publicationid, string location)
    {
        litSearchHeading.Text = "Search Results";

        Session["kqy"] = "aabbcc";
        Session["jn"] = "aabbcc";
        Session["bid"] = 0;
        Session["mid"] = 0;
        Session["l"] = "aabbcc";
        Session["t"] = "aabbcc";

        Session["kqy"] = keyword.ToLower();
        Session["jn"] = journalist.ToLower();
        //Session["bid"] = Convert.ToInt32(ddBeatID.SelectedValue);
        Session["mid"] = publicationid;
        Session["l"] = location.ToLower();
        //Session["t"] = txtTopic.Text.ToLower();

        var oUserJournalistSearch = new UserJournalistSearch();
        oUserJournalistSearch.UserID = Convert.ToInt16(Session["iUserID"].ToString());
        oUserJournalistSearch.DateTimeStamp = DateTime.Now;

        string sSQL = "";
        sSQL = "SELECT U.UserID, ISNULL(U.FirstName,'') AS FirstName, ISNULL(LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE U.TwitterProfileImageURL END) AS ProfileImage ";
        sSQL += " , ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress";

        sSQL += " FROM Users U INNER JOIN Publications P ON LOWER(P.Publication) = LOWER(U.CurrentJobPublication) LEFT OUTER JOIN UserArticles UA ON UA.UserID = U.UserID WHERE U.UserTypeID = 2 AND U.Active = 1 ";
        //if (Convert.ToInt32(Session["bid"].ToString()) != 0)
        //{
        //    sSQL += " AND BeatID = @BeatID";
        //}
        if (Session["l"].ToString() != "e.g. johannesburg" && Session["l"].ToString() != "")
        {
            oUserJournalistSearch.Location = txtLocation.Text;
            sSQL += " AND LOWER(CurrentCity) = @Location";
        }
        if (Session["jn"].ToString() != "e.g. karima brown" && Session["jn"].ToString() != "")
        {
            oUserJournalistSearch.Journalist = txtJournoName.Text;
            sSQL += " AND LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @JounalistName + '%'";
        }
        if (Convert.ToInt32(Session["mid"].ToString()) != 0)
        {
            oUserJournalistSearch.MediaOutletID = Convert.ToInt32(ddPublication.SelectedValue);
            sSQL += " AND P.PublicationID = @MediaOutletID";
        }

        if (Session["kqy"].ToString() != "e.g. editor" && Session["kqy"].ToString() != "")
        {
            oUserJournalistSearch.Keywords = txtkeyword.Text;
            sSQL += " AND UA.Description LIKE '%' + @Keyword + '%' OR UA.Title LIKE '%' + @Keyword + '%' OR LOWER(CurrentCity) = @Keyword OR LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @Keyword + '%' OR U.CurrentJobTitle LIKE '%' + @Keyword + '%' OR U.CurrentJobPublication LIKE '%' + @Keyword + '%'";
        }

        //if (Session["t"].ToString() != "e.g. fifa world cup")
        //{
        //    sSQL += " AND UA.Description LIKE '%' + @Topic + '%' OR UA.Title LIKE '%' + @Topic + '%'";
        //}
        sSQL += " GROUP BY U.UserID, U.FirstName, U.CurrentJobTitle, U.CurrentJobPublication, U.BeatID, U.CurrentCity, U.TwitterProfileImageURL, U.LastName, U.ImageFormat, U.ContactMobile, U.ContactOffice, U.EmailAddress, U.FaxNumber";

        dsJournalists.SelectCommand = sSQL;

        dsBeats.DataBind();
        dsPublications.DataBind();

        if (Request.QueryString["sci"] != null)
        {
            oUserJournalistSearch.Save(2);
        }
        else {
            oUserJournalistSearch.Save(1);
        }
        

        rptJournalists.DataBind();
        rptUserJournalistSearches.DataBind();

        if (rptJournalists.Items.Count == 0)
        {
            litSearchResult.Visible = true;
        }
        else
        {
            litSearchResult.Visible = false;
        }

        if (rptUserJournalistSearches.Items.Count == 0)
        {
            litUserJournalistSearchesResult.Visible = true;
        }
        else
        {
            litUserJournalistSearchesResult.Visible = false;
        }
    }

    protected void rptJournalists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl divProImage = e.Item.FindControl("divProImage") as System.Web.UI.HtmlControls.HtmlGenericControl;
        HiddenField hidUser = e.Item.FindControl("hidUserID") as HiddenField;

        var oUser = new User(Convert.ToInt32(hidUser.Value), "");
        divProImage.Style.Add("background-image", "url('" + getImageURL(oUser.TwitterProfileImageURL, oUser.ImageFormat, Convert.ToInt32(hidUser.Value)) + "')");
    }

    public string getImageURL(string sTwitterProfileImageURL, string sImageFormat, int iUserID)
    {
        string output = "";
        if (sTwitterProfileImageURL != "")
        {
            output = sTwitterProfileImageURL;
        }
        else if (sImageFormat != "")
        {
            output = "../images/profileimages/" + iUserID + "." + sImageFormat;
        }
        else
        {
            output = "../images/profileimages/0.png";
        }
        return output;
    }
    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            List<InterestGrouping> results = mc.GetListInterestGroupings(sListID);

            mc.AddListInterestGroup(sListID, txtCampaignGroupName.Text, results[0].Id);
            var oUserCampaignGroup = new UserCampaignGroup();
            oUserCampaignGroup.UserID = Convert.ToInt32(Session["iUserID"].ToString());
            oUserCampaignGroup.CampaignGroupName = txtCampaignGroupName.Text;
            oUserCampaignGroup.Save(1);

            txtSuccessMessage.Visible = true;
            divMessage.Visible = true;

            txtCampaignGroupName.Text = "";
        }
        catch (Exception ex)
        {
            divMessage.Visible = true;
            txtErrorMessage.Visible = true;

            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }

    }

    public int CountCampaignGroups(int UserID)
    {
        string sSQL;
        int iCount = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {

            sSQL = "SELECT COUNT(UserCampaignGroupID) As Count FROM UserCampaignGroups WHERE UserID = " + UserID;

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iCount = Convert.ToInt32(dr["Count"].ToString());
            }
            else
            {
                iCount = 0;
            }

            dr.Close();
            cm.Connection.Close();
            cm.Dispose();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        dr = null;
        cm.Connection = null;
        cm = null;
        return iCount;
    }
}