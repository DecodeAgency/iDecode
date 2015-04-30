using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

using MailChimp;
using MailChimp.Lists;

public partial class app_admin_dashboard : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {            
            if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
            int iUserID = Convert.ToInt16(Session["iUserID"].ToString());
            this.Page.Title = "iDecode | Dashboard";
            var oUser = new User(iUserID,"");
            
            litJournalistCount.Text = Convert.ToString(oUser.Count(2));
            litCampaignGroupsCount.Text = Convert.ToString(CountCampaignGroups(iUserID));
            litTotalPressReleases.Text = Convert.ToString(CountUserCampaigns(iUserID));

            divProfileImage.Style.Add("background-image", "url('" + getImageURL(oUser.TwitterProfileImageURL, oUser.ImageFormat, iUserID) + "')");
            litFullName.Text = oUser.FirstName + " " + oUser.LastName;
            litShortBio.Text = oUser.ShortBiography;
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            SetProgressBar();

            if (oUser.TwitterUsername != "")
            {
                LoadTweets(oUser.TwitterUsername.ToString());
            }
            else
                    {
                        dvTwitterHandle.Style.Add(HtmlTextWriterStyle.Display, "block;");
                    }
       
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }   
    }

    protected void btnJournalists_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            Response.Redirect("search.aspx",false);
            HttpContext.Current.ApplicationInstance.CompleteRequest(); 
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }        
    }

    protected void btnCommunicators_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            Response.Redirect("communicators.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }        
    }

    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            List<InterestGrouping> results = mc.GetListInterestGroupings(sListID);

            mc.AddListInterestGroup(sListID, txtCampaignGroupName.Text,results[0].Id);
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

    protected void btnCreatePressRelease_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            Response.Redirect("pressreleases/pressrelease.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
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

    public void SetProgressBar()
    {
        
        int iUserID = Convert.ToInt16(Session["iUserID"].ToString());
        var oUser = new User(iUserID, "");
        double dPercentage = 0;
        string sList = "";
        int iCount = 0;

        sList = "<h1>Kindly fill the following to complete your Profile </h1> <br/>";
        if (!(String.IsNullOrEmpty(oUser.FirstName)))
        {
            dPercentage += 6.25;
        }
        else
        {
         
            sList += "<a href='./profileedit.aspx'>First Name </a><br/>";
            iCount++;
        }
        
        if (!(String.IsNullOrEmpty(oUser.LastName)))
        {
            dPercentage += 6.25;
        }
        else
        {
          
            sList += "<a href='./profileedit.aspx'>Last Name </a><br/>";
            iCount++;
        }
        if (!(oUser.TwitterUserID == null || oUser.TwitterUserID == 0))
        {
            dPercentage += 6.25;
        }
        else
        {
           
            sList += "<a href='./profileedit.aspx'>Twitter ID </a><br/>";
            iCount++;
        }
        if (!(String.IsNullOrEmpty(oUser.TwitterUsername)))
        {
            dPercentage += 6.25;
        }
        else
        {
           
            sList += "<a href='./profileedit.aspx'>Twitter Handle </a><br/>";
            iCount++;
        }
        if (!(String.IsNullOrEmpty(oUser.FacebookUsername)))
        {
            dPercentage += 6.25;
        }
        else
        {
            iCount++;
            sList += "<a href='./profileedit.aspx'>Facebook Username </a><br/>";
        }
        if (!(String.IsNullOrEmpty(oUser.LinkedInUsername)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
            iCount++;
            sList += "<a href='./profileedit.aspx'>LinkedIn Username </a><br/>";
            }
        }
        if(!(String.IsNullOrEmpty(oUser.TwitterProfileImageURL)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Twitter Profile Image </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.CurrentCity)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Current City</a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.ContactMobile)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Contact Number </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.ContactOffice)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Office Number</a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.FaxNumber)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Fax Number </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.EmailAddress)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Email Address </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.WebsiteAddress)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Website Address </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.ShortBiography)))
        {
            dPercentage += 0;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Short Biography </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.CurrentJobTitle)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Current Job Title </a><br/>";
            }
        }
        if (!(String.IsNullOrEmpty(oUser.CurrentJobPublication)))
        {
            dPercentage += 6.25;
        }
        else
        {
            if (iCount < 5)
            {
                iCount++;
                sList += "<a href='./profileedit.aspx'>Current Publication </a><br/>";
            }
        }
        string sPercentage = "";
        sPercentage = dPercentage + "%";
        dvInnerComplete.Style[HtmlTextWriterStyle.Width] = sPercentage;
        litPercentage.Text = "your profile is " + sPercentage + " complete";
        litInCompleteList.Text = sList;
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

    public int CountUserCampaigns(int UserID)
    {
        string sSQL;
        int iCount = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {

            sSQL = "SELECT COUNT(UserCampaignID) As Count FROM UserCampaigns WHERE UserID = " + UserID;

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

    protected void rptRecentUpdates_DataBinding(object sender, EventArgs e)
    {
        
    }
    protected void rptRecentUpdates_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hidUpdatedProfileID = e.Item.FindControl("hidUpdatedProfileID") as HiddenField;
        Literal litUpdateStatus = e.Item.FindControl("litUpdateStatus") as Literal;
        Literal litDatePosted = e.Item.FindControl("litDatePosted") as Literal;

        int iUpdatedProfileID = Convert.ToInt32(hidUpdatedProfileID.Value);
        var oUser = new User(iUpdatedProfileID, "");
        //TimeSpan ts = TimeSpan.Parse(Convert.ToDateTime(litDatePosted.Text).ToString("dd:MM:yyyy:h:m"));

        //litDatePosted.Text = Convert.ToDateTime(litDatePosted.Text).ToString("dd:MM:yyyy:hh:mm");// ToLongString(ts);
        string sDate = ToLongString(DateTime.Now - DateTime.ParseExact(Convert.ToDateTime(litDatePosted.Text).ToString("ddd MMM dd HH:mm:ss zzz yyyy"), "ddd MMM dd HH:mm:ss zzz yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeLocal));

        litDatePosted.Text = sDate + " ago";

        if (oUser.UserTypeID == 1) 
        {
            litUpdateStatus.Text = "Communicator: <a href='profile.aspx?uid=" + oUser.UserID  + "'>" + oUser.FirstName + " " + oUser.LastName + "</a> profile was updated.";
        }
        else if (oUser.UserTypeID == 2)
        {
            litUpdateStatus.Text = "Journalist: <a href='../communicators/profile.aspx?uid=" + oUser.UserID + "'>" + oUser.FirstName + " " + oUser.LastName + "</a> profile was updated.";
        }       
    }

    protected void LoadTweets (string UserName)
    {
        string sBearer = "AAAAAAAAAAAAAAAAAAAAAEhjewAAAAAA6%2B3HZJ5tpzcHEXobNTo%2F7%2BYT7Oc%3D06JMFvVxeHslrlLo5azQ5tmOBfiAo0eyCgHebQSfmgl3dtQY4a";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?count=5&exclude_replies=true&screen_name=" + UserName);
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
                    //if (sCurrentCity == "")
                    //{
                    //    sCurrentCity = ou["location"].ToString();
                    //}
                    //if (sShortBiography == "")
                    //{
                    //    sShortBiography = ou["description"].ToString();
                    //}

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
                    string sDate = ToLongString(DateTime.Now - DateTime.ParseExact((string)o["created_at"], "ddd MMM dd HH:mm:ss zzz yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeLocal));
                    divShowTweets.InnerHtml += "<div class='JobHistoryContainer'><div style='margin-top:10px'>" + ParseTweet((string)o["text"]) + "</div><div style='float:right'>" + sDate.ToString() + " ago</div></div>";
                }
            }
        }

    }
    protected void btnLoadTweets_Click (object sender, EventArgs e)
    {
        try
        {
        LoadTweets(txtTwitterHandle.Text.ToString());   
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            string sTwitterhandle = txtTwitterHandle.Text;
            sTwitterhandle = sTwitterhandle.Replace("@", "");
            sSQL = "UPDATE Users SET TwitterUserName = '"+sTwitterhandle +"' WHERE UserID = " + Convert.ToInt32(Session["iUserID"].ToString());

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            cm.ExecuteScalar();
            
            cm.Connection.Close();
            cm.Dispose();
            dvTwitterHandle.Style.Add(HtmlTextWriterStyle.Display, "none;");
        }
        catch (Exception ex)
        {
          
        }
    }

}