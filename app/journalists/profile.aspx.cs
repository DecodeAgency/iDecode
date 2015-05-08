using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using LinqToTwitter;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

using MailChimp.Campaigns;
using MailChimp.Lists;
//using MailChimp.Helper;

using MailChimp;
using MailChimp.Lists;

public partial class app_journo_profile : System.Web.UI.Page
{
    AspNetAuthorizer auth;
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        try
            {
            XmlNode XmlResult = null;
            var oDecode = new za.co.idecode.test.idecode();
                //var oDecode = new za.co.idecode.temp.idecode();
            //if (Convert.ToInt32(Request.QueryString["uid"].ToString()) != 0) {
            //    XmlResult = oDecode.LoadUser(Convert.ToInt32(Request.QueryString["uid"].ToString()), "");
            //}else if (Convert.ToInt16(Session["iUserID"].ToString()) != 0){
            XmlResult = oDecode.LoadUser(Convert.ToInt32(Request.QueryString["uid"].ToString()), "");
            //}else{
            //    Response.Redirect("",true);
            //}
        
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

            this.Page.Title = "iDecode | Journalist - " + sFirstName + " " + sLastName;


            if (iUserTypeID == 3)
            {
                divAddtoGroup.Visible = false;
            }

            if (sTwitterUsername != "")
            {
                string sBearer = "AAAAAAAAAAAAAAAAAAAAAEhjewAAAAAA6%2B3HZJ5tpzcHEXobNTo%2F7%2BYT7Oc%3D06JMFvVxeHslrlLo5azQ5tmOBfiAo0eyCgHebQSfmgl3dtQY4a";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?count=5&exclude_replies=true&screen_name=" + sTwitterUsername);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + sBearer);
                WebResponse response = request.GetResponse();
                String responseString = "";
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    responseString = reader.ReadToEnd();
                }


                JArray jArray = JArray.Parse(responseString);
                JObject ou = new JObject();
                string sTweet = "";
                string sname = "";
                foreach (JObject o in jArray.Children<JObject>())
                {
                    foreach (JProperty p in o.Properties())
                    {
                        if (p.Name == "user")
                        {
                           
                            ou = JObject.Parse(p.Value.ToString());
                            sname = "<a href='http://twitter.com/" + (string)ou["screen_name"] + "'>" + (string)ou["name"] + "</a>";
                            if (sCurrentCity == "")
                            {
                                sCurrentCity = ou["location"].ToString();
                            }
                            if (sShortBiography == "")
                            {
                                sShortBiography = ou["description"].ToString();
                            }

                        }
                    }
                }

                foreach (JObject o in jArray.Children<JObject>())
                {
                    foreach (JProperty p in o.Properties())
                    {

                        if (p.Name == "text")
                        {
                            //sTweet = p.Value.ToString();
                            string sDate = ToLongString(DateTime.Now - DateTime.ParseExact((string)o["created_at"], "ddd MMM dd HH:mm:ss zzz yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal));
                            divShowTweets.InnerHtml += "<div class='JobHistoryContainer'><div style='margin-top:10px'>" + ParseTweet((string)o["text"]) + "</div><div style='float:right'>" + sDate.ToString() + " ago</div></div>";
                        }
                    }
                }
            }

            divProfileImage.Style.Add("background-image", "url('" + getImageURL(sTwitterProfileImageURL, sImageFormat) + "')");
            //if (sTwitterProfileImageURL != "")
            //{
            //    divProfileImage.Style.Add("background-image", "url('" + sTwitterProfileImageURL + "')");
            //}
            //else if (sImageFormat != "")
            //{
            //    divProfileImage.Style.Add("background-image", "url('../images/profileimages/" + Convert.ToInt32(Request.QueryString["uid"].ToString()) + "." + sImageFormat + "')");
            //}
            //else
            //{
            //    divProfileImage.Style.Add("background-image", "url('../images/profileimages/0.png')");
            //}

            litFirstName.Text = sFirstName + " " + sLastName;
            litCurrentCity.Text = sCurrentCity + ", South Africa <br />";
            if (sCurrentCity == "") {
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
            litCurrentJobTitle.Text =  sCurrentJobTitle;

            litContactMobile.Text = sContactMobile;
            litContactOffice.Text = sContactOffice;
            //litContactWebsiteAddress.Text = sWebsiteAddress;
            litFaxNumber.Text = sFaxNumber;
            litEmailAddress.Text = sEmailAddress;

            litShortBio.Text = sShortBiography;
            //litBio.Text = sBiography;

            if (sTwitterUsername == "") {
                aProfileSocialButtonTwitter.HRef = "#";
            }
            aTwitterShare.HRef = "https://twitter.com/intent/tweet?related=Decode Media&text=" + sFirstName + " " + sLastName;
            aFacebookShare.HRef = "https://www.facebook.com/sharer/sharer.php?u=http://test.idecode.co.za/";
            aLinkedInShare.HRef = "http://www.linkedin.com/shareArticle?mini=true&url=http%3A//muckrack.com/CassandraVinograd&title=Cassandra%20Vinograd%27s%20Muck%20Rack%20portfolio&summary=Cassandra%20Vinograd%27s%20Muck%20Rack%20profile&source=";

            aProfileSocialButtonFacebook.HRef = "https://facebook.com/" + sFacebookUsername;
            aProfileSocialButtonTwitter.HRef = "https://twitter.com/" + sTwitterUsername;
            aProfileSocialButtonLinkedIn.HRef = sLinkedInUsername;
            aProfileSocialButtonWebsite.HRef = "http://" + sWebsiteAddress;
            aProfileSocialButtonEmail.HRef = "mailto:" + sEmailAddress;

            XmlResult = oDecode.LoadUserJobs(Convert.ToInt32(Request.QueryString["uid"].ToString()));
            XmlDocument doc = new XmlDocument();
            string s = Convert.ToString(oDecode.LoadUserJobs(Convert.ToInt32(Request.QueryString["uid"].ToString())).InnerXml);
            doc.LoadXml(s);

            XmlDataSource xDataSource = new XmlDataSource();
            xDataSource.Data = doc.OuterXml;
            xDataSource.DataBind();
            xDataSource.ID = "XmlSource1";

            dsUserJobs.Data = xDataSource.Data;
            dsUserJobs.DataBind();

            //Get UserArticles
            //XmlResult = oDecode.LoadUserArticles(Convert.ToInt16(Session["iUserID"].ToString()));
            doc = new XmlDocument();
            s = Convert.ToString(oDecode.LoadUserArticles(Convert.ToInt32(Request.QueryString["uid"].ToString())).InnerXml);
            doc.LoadXml(s);

            xDataSource = new XmlDataSource();
            xDataSource.Data = doc.OuterXml;
            xDataSource.DataBind();
            xDataSource.ID = "XmlSource2";

            dsUserArticles.Data = xDataSource.Data;
            dsUserArticles.DataBind();

            //var auth = new SingleUserAuthorizer
            //{
            //    CredentialStore = new SingleUserInMemoryCredentialStore
            //    {
            //        ConsumerKey = "Sdmp3Oasby5SYAyjXmZd4KvpP",
            //        ConsumerSecret = "13hWlwE66cH6TGFozTXmL8d4i4GdEN5GylPSeBb3ojcnV8guNp",
            //        OAuthToken = "2252165823-QOZaEzrdv0YSkM3LTB7AKCWQzhbmCzP8AhIq9zx",
            //        OAuthTokenSecret = "EMoX9JyjBaEt0DVXusZ64Eo5oZWny79umogeo4vujOpSN",
            //    }
            //};
        
            ////Get User Tweets
            //string[] a = new string [50]; //Tweet
            //string[] b = new string [50]; //Name
            //string[] c = new string[50]; //Date
            //string[] d = new string[50]; //Image

            //int i = 0;
            //var twitterCtx = new TwitterContext(auth);
            //var tweets = await (from tweet in twitterCtx.Status where tweet.Type == StatusType.User && tweet.Count == 50 && tweet.UserID == iTwitterUserID select tweet).ToListAsync();
            ////Initialise array
            //for (i = 0; i < tweets.Count; i++) {
            //    a[i] = "";
            //    b[i] = "";
            //    c[i] = "";
            //    d[i] = "";
            //}

            //tweets.ToList().ForEach(tweet =>  a[tweets.IndexOf(tweet)] = (tweet.Text).ParseURL().ParseUsername().ParseHashtag());
            //tweets.ToList().ForEach(tweet =>  b[tweets.IndexOf(tweet)] = (tweet.User.Name).ParseURL().ParseUsername().ParseHashtag());
            //tweets.ToList().ForEach(tweet => c[tweets.IndexOf(tweet)] = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(tweet.CreatedAt.AddHours(2))).TotalHours) > 24 ? Convert.ToInt32((DateTime.Now - Convert.ToDateTime(tweet.CreatedAt.AddHours(2))).TotalDays).ToString() + " days ago" : Convert.ToInt32((DateTime.Now - Convert.ToDateTime(tweet.CreatedAt.AddHours(2))).TotalHours).ToString() + " hours ago");
            //tweets.ToList().ForEach(tweet => d[tweets.IndexOf(tweet)] = (tweet.User.ProfileImageUrl).ToString().Replace("_normal",""));
        
            //for (i = 0; i < tweets.Count; i++) {
            //    HtmlGenericControl div = new HtmlGenericControl("div");
            //    div.Attributes.Add("class", "divRecentTweetItem");
            //    div.Controls.Add(new Image { ImageUrl = d[i], Width = 64, Height = 85, CssClass="RecentTweetImage" });
            //    div.Controls.Add(new Label() { Text = b[i], CssClass = "divRecentTweetName" });
            //    div.Controls.Add(new Label() { Text = c[i], CssClass = "divRecentTweetDate" });
            //    div.Controls.Add(new Label() { Text = a[i], CssClass = "divRecentTweetTweet" });
            
            //    divTweets.Controls.Add(div);
            //} 
        }
        catch (Exception ex)
        {

        }
    }

    private string ParseTweet(string rawTweet)
    {
        Regex link = new Regex(@"http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?");
        Regex screenName = new Regex(@"@\w+");
        Regex hashTag = new Regex(@"#\w+");

        string formattedTweet = link.Replace(rawTweet, delegate(Match m)
        {
            string val = m.Value;
            return "<a target='blank' href='" + val + "'>" + val + "</a>";
        });

        formattedTweet = screenName.Replace(formattedTweet, delegate(Match m)
        {
            string val = m.Value.Trim('@');
            return string.Format("@<a target='blank' href='http://twitter.com/{0}'>{1}</a>", val, val);
        });

        formattedTweet = hashTag.Replace(formattedTweet, delegate(Match m)
        {
            string val = m.Value;
            return string.Format("<a target='blank' href='http://twitter.com/#search?q=%23{0}'>{1}</a>", val, val);
        });

        return formattedTweet;
    }

    public string ToLongString(TimeSpan time)
    {
        string output = String.Empty;

        if (time.Days > 0)
            output += time.Days + " days ";

        if ((time.Days == 0 || time.Days == 1) && time.Hours > 0)
            output += time.Hours + " hr ";

        if (time.Days == 0 && time.Minutes > 0)
            output += time.Minutes + " min ";

        if (output.Length == 0)
            output += time.Seconds + " sec";

        return output.Trim();
    }

    public string getImageURL(string sTwitterProfileImageURL, string sImageFormat)
    {
        string output = "";
        if (sTwitterProfileImageURL != "")
        {
            output = sTwitterProfileImageURL;
        }
        else if (sImageFormat != "")
        {
            output = "../images/profileimages/" + Convert.ToInt32(Request.QueryString["uid"].ToString()) + "." + sImageFormat;
        }
        else
        {
            output = "../images/profileimages/0.png";
        }
        return output;
    }
    protected void btnAddSubscriberToList_Click(object sender, EventArgs e)
    {
        try
        {
            
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            var oUser = new User(Convert.ToInt32(Request.QueryString["uid"].ToString()), "");

            List<InterestGrouping> results = mc.GetListInterestGroupings(sListID);
            ListResult lists = mc.GetLists();

            MailChimp.Helper.EmailParameter email = new MailChimp.Helper.EmailParameter()
            {
                Email = oUser.EmailAddress
            };

            string strListID = null;
            int nGroupingID = 0;
            string strGroupName = null;
            foreach (ListInfo li in lists.Data)
            {
                List<InterestGrouping> interests = mc.GetListInterestGroupings(li.Id);
                if (interests != null)
                {
                    if (interests.Count > 0)
                    {
                        if (interests[0].GroupNames.Count > 0)
                        {
                            strListID = li.Id;
                            nGroupingID = interests[0].Id;
                            for (int i = 0; i < interests[0].GroupNames.Count;i++)                               
                                if (interests[0].GroupNames[i].Name == txtGroupName.Text.Trim()){                                                                      
                                    strGroupName = interests[0].GroupNames[i].Name;                                    
                            }
                            break;    
                        }
                    }
                }
            }

            MyMergeVar mvso = new MyMergeVar();
            mvso.Groupings = new List<Grouping>();
            mvso.Groupings.Add(new Grouping());
            mvso.Groupings[0].Id = nGroupingID;
            mvso.Groupings[0].GroupNames = new List<string>();
            mvso.Groupings[0].GroupNames.Add(strGroupName);
            mvso.FirstName = oUser.FirstName;
            mvso.LastName = oUser.LastName;

            MailChimp.Helper.EmailParameter results2 = mc.Subscribe(strListID, email, mvso,"html",false,true);

            List<MailChimp.Helper.EmailParameter> emails = new List<MailChimp.Helper.EmailParameter>();
            emails.Add(results2);
            MemberInfoResult memberInfos = mc.GetMemberInfo(strListID, emails);

            //var oUserCampaignGroup = new UserCampaignGroup();
            //oUserCampaignGroup.UserID = Convert.ToInt32(Session["iUserID"].ToString());
            //oUserCampaignGroup.CampaignGroupName = txtCampaignGroupName.Text;
            //oUserCampaignGroup.Save(1);

            txtSuccessMessage.Visible = true;
            divMessage.Visible = true;

            //txtCampaignGroupName.Text = "";
        }
        catch (Exception ex)
        {
            divMessage.Visible = true;
            txtErrorMessage.Visible = true;

            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }

    }
}

[System.Runtime.Serialization.DataContract]
public class MyMergeVar : MergeVar
{
    [System.Runtime.Serialization.DataMember(Name = "FNAME")]
    public string FirstName
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember(Name = "LNAME")]
    public string LastName
    {
        get;
        set;
    }
}
//Beat: e.g General, Technology, Health, Education etc.
//UserTypes - if PR to Advanced Search, if journo to Profile Edit

//Watch Movie
//The 5th Estate

// Block Ip to access
// Media List
// mandlam@idc.co.za
// mandla123