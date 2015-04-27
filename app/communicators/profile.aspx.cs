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

public partial class app_journo_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        try
        {
              
            XmlNode XmlResult = null;


            var oDecode = new za.co.idecode.test.idecode();
            XmlResult = oDecode.LoadUser(Convert.ToInt32(Request.QueryString["uid"].ToString()), "");
        
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

            this.Page.Title = "iDecode | Communication Officer - " + sFirstName + " " + sLastName;

            if (sTwitterUsername != "")
            {
                string sBearer = "AAAAAAAAAAAAAAAAAAAAAEhjewAAAAAA6%2B3HZJ5tpzcHEXobNTo%2F7%2BYT7Oc%3D06JMFvVxeHslrlLo5azQ5tmOBfiAo0eyCgHebQSfmgl3dtQY4a";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?count=30&exclude_replies=true&screen_name=" + sTwitterUsername);
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
                        //string name = p.Name;
                        //string value = p.Value.ToString();

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
                            divShowTweets.InnerHtml += "<div class='JobHistoryContainer'><div class='PublicationImage' style='background-image:url(" + getImageURL(sTwitterProfileImageURL, sImageFormat) + ")'></div><div style='float:right'>" + sDate.ToString() + "</div><div class='PublicationName'>" + sname + "</div><div style='margin-top:10px'>" + ParseTweet((string)o["text"]) + "</div></div>";
                        }
                    }
                }
            }



            divProfileImage.Style.Add("background-image", "url('" + getImageURL(sTwitterProfileImageURL,sImageFormat) + "')");
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
            litContactWebsiteAddress.Text = sWebsiteAddress;
            litFaxNumber.Text = sFaxNumber;
            litEmailAddress.Text = sEmailAddress;

            litShortBio.Text = sShortBiography;
            litBio.Text = sBiography;

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
            output =  sTwitterProfileImageURL;
        }
        else if (sImageFormat != "")
        {
            output =  "../images/profileimages/" + Convert.ToInt32(Request.QueryString["uid"].ToString()) + "." + sImageFormat;
        }
        else
        {
            output = "../images/profileimages/0.png')";
        }
        return output;
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