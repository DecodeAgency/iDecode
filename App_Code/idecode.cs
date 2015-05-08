using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Security.Cryptography;

/// <summary>
/// Summary description for idecode
/// </summary>
[WebService(Namespace = "http://test.idecode.co.za")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class idecode : System.Web.Services.WebService {

    [WebMethod]
    public bool NewUser(string FirstName, string LastName, int GenderID, int Age, string CurrentCity, int CountryID, string ContactMobile, string ContactOffice, string FaxNumber, string EmailAddress, string Password, string WebsiteAddress, int UserTypeID, string FacebookUsername, string TwitterUsername, string LinkedInUsername, string ImageFormat, string TwitterOauthToken, string TwitterOauthTokenSecret, string TwitterScreenName, ulong TwitterUserID, string TwitterProfileImageURL, string ShortBiography, string Biography, string CurrentJobTitle, string CurrentJobPublication, int BeatID, int PackageID, string EditorName, string EditorEmail)
    {
        var oUser = new User();
        try
        {
            oUser.FirstName = FirstName.ToString();
            oUser.LastName = LastName.ToString();
            oUser.GenderID = Convert.ToInt32(GenderID);
            oUser.Age = Convert.ToInt32(Age);
            oUser.CurrentCity = CurrentCity;
            oUser.CountryID = Convert.ToInt32(CountryID);
            oUser.ContactMobile = ContactMobile;
            oUser.ContactOffice = ContactOffice;
            oUser.FaxNumber = FaxNumber;
            oUser.EmailAddress = EmailAddress;
            oUser.Password = Password;
            oUser.WebsiteAddress = WebsiteAddress;
            oUser.Active = true;
            oUser.DateTimeStamp = DateTime.Now;
            oUser.LastUpdatedDate = DateTime.Now;
            oUser.UserTypeID = Convert.ToInt32(UserTypeID);
            oUser.FacebookUsername = FacebookUsername;
            oUser.TwitterUsername = TwitterUsername;
            oUser.LinkedInUsername = LinkedInUsername;
            oUser.ImageFormat = ImageFormat;
            oUser.TwitterOauthToken = TwitterOauthToken;
            oUser.TwitterOauthTokenSecret = TwitterOauthTokenSecret;
            oUser.TwitterScreenName = TwitterScreenName;
            oUser.TwitterUserID = TwitterUserID;
            oUser.TwitterProfileImageURL = TwitterProfileImageURL;
            oUser.ShortBiography = ShortBiography;
            oUser.Biography = Biography;
            oUser.CurrentJobTitle = CurrentJobTitle;
            oUser.CurrentJobPublication = CurrentJobPublication;
            oUser.BeatID = BeatID;
            oUser.PackageID = PackageID;
            oUser.EditorName = EditorName;
            oUser.EditorEmail = EditorEmail;

            oUser.Save(1);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);
        }  
    }

    [WebMethod]
    public XmlNode LoadUser(int UserID, string EmailAddress = "")
    {
        string sReturn = "";
        XmlDocument doc = new XmlDocument();
        var oUser = new User(UserID, EmailAddress);
        XmlDocument xdoc = new XmlDocument();
        
        sReturn += "<user>"; 
            sReturn += "<userid>" + oUser.UserID  + "</userid>";
            sReturn += "<firstname>" + HttpUtility.HtmlEncode(oUser.FirstName) + "</firstname>";
            sReturn += "<lastname>" + HttpUtility.HtmlEncode(oUser.LastName) + "</lastname>";
            sReturn += "<genderid>" + oUser.GenderID + "</genderid>";
            sReturn += "<age>" + oUser.Age + "</age>";
            sReturn += "<currentcity>" + HttpUtility.HtmlEncode(oUser.CurrentCity) + "</currentcity>";
            sReturn += "<countryid>" + oUser.CountryID + "</countryid>";
            sReturn += "<contactmobile>" + HttpUtility.HtmlEncode(oUser.ContactMobile) + "</contactmobile>";
            sReturn += "<contactoffice>" + HttpUtility.HtmlEncode(oUser.ContactOffice) + "</contactoffice>";
            sReturn += "<faxnumber>" + HttpUtility.HtmlEncode(oUser.FaxNumber) + "</faxnumber>";
            sReturn += "<emailaddress>" + HttpUtility.HtmlEncode(oUser.EmailAddress) + "</emailaddress>";
            sReturn += "<password>" + HttpUtility.HtmlEncode(oUser.Password) + "</password>";
            sReturn += "<websiteaddress>" + HttpUtility.HtmlEncode(oUser.WebsiteAddress) + "</websiteaddress>";
            sReturn += "<active>" + oUser.Active + "</active>";
            sReturn += "<datetimestamp>" + oUser.DateTimeStamp + "</datetimestamp>";
            sReturn += "<lastupdateddate>" + oUser.LastUpdatedDate + "</lastupdateddate>";
            sReturn += "<usertypeid>" + oUser.UserTypeID + "</usertypeid>";
            sReturn += "<facebookusername>" + HttpUtility.HtmlEncode(oUser.FacebookUsername) + "</facebookusername>";
            sReturn += "<twitterusername>" + HttpUtility.HtmlEncode(oUser.TwitterUsername) + "</twitterusername>";
            sReturn += "<linkedinusername>" + HttpUtility.HtmlEncode(oUser.LinkedInUsername) + "</linkedinusername>";
            sReturn += "<imageformat>" + HttpUtility.HtmlEncode(oUser.ImageFormat) + "</imageformat>";
            sReturn += "<twitteroauthtoken>" + HttpUtility.HtmlEncode(oUser.TwitterOauthToken) + "</twitteroauthtoken>";
            sReturn += "<twitteroauthtokensecret>" + HttpUtility.HtmlEncode(oUser.TwitterOauthTokenSecret) + "</twitteroauthtokensecret>";
            sReturn += "<twitterscreenname>" + HttpUtility.HtmlEncode(oUser.TwitterScreenName) + "</twitterscreenname>";
            sReturn += "<twitteruserid>" + HttpUtility.HtmlEncode(oUser.TwitterUserID) + "</twitteruserid>";
            sReturn += "<twitterprofileimageurl>" + HttpUtility.HtmlEncode(oUser.TwitterProfileImageURL) + "</twitterprofileimageurl>";
            sReturn += "<shortbiography>" + HttpUtility.HtmlEncode(oUser.ShortBiography) + "</shortbiography>";
            sReturn += "<biography>" + HttpUtility.HtmlEncode(oUser.Biography) + "</biography>";
            sReturn += "<currentjobtitle>" + HttpUtility.HtmlEncode(oUser.CurrentJobTitle) + "</currentjobtitle>";
            sReturn += "<currentjobpublication>" + HttpUtility.HtmlEncode(oUser.CurrentJobPublication) + "</currentjobpublication>";
            sReturn += "<beatid>" + oUser.BeatID + "</beatid>";
            sReturn += "<packageid>" + oUser.PackageID + "</packageid>";
            sReturn += "<editorname>" + oUser.EditorName + "</editorname>";
            sReturn += "<editoremail>" + oUser.EditorEmail + "</editoremail>";
        sReturn += "</user>";
        doc.LoadXml("<envelope>" + sReturn + "</envelope>");
        return doc.DocumentElement;
    }

    [WebMethod]
    public bool UpdateUser(int iUserID, string FirstName, string LastName, int GenderID, int Age, string CurrentCity, int CountryID, string ContactMobile, string ContactOffice, string FaxNumber, string EmailAddress, string Password, string WebsiteAddress, int UserTypeID, string FacebookUsername, string TwitterUsername, string LinkedInUsername, string ImageFormat, string TwitterOauthToken, string TwitterOauthTokenSecret, string TwitterScreenName, ulong TwitterUserID, string TwitterProfileImageURL, string ShortBiography, string Biography, string CurrentJobTitle, string CurrentJobPublication, int BeatID, int PackageID, string EditorName, string EditorEmail)
    {
        var oUser = new User(iUserID);

        try
        {
            oUser.FirstName = FirstName;
            oUser.LastName = LastName;
            oUser.GenderID = GenderID;
            oUser.Age = Age;
            oUser.CurrentCity = CurrentCity;
            oUser.CountryID = CountryID;
            oUser.ContactMobile = ContactMobile;
            oUser.ContactOffice = ContactOffice;
            oUser.FaxNumber = FaxNumber;
            oUser.EmailAddress = EmailAddress;
            oUser.Password = Password;
            oUser.WebsiteAddress = WebsiteAddress;
            oUser.Active = true;
            oUser.LastUpdatedDate = DateTime.Now;
            oUser.UserTypeID = UserTypeID;
            oUser.FacebookUsername = FacebookUsername;
            oUser.TwitterUsername = TwitterUsername;
            oUser.LinkedInUsername = LinkedInUsername;
            oUser.ImageFormat = ImageFormat;
            oUser.TwitterOauthToken = TwitterOauthToken;
            oUser.TwitterOauthTokenSecret = TwitterOauthTokenSecret;
            oUser.TwitterScreenName = TwitterScreenName;
            oUser.TwitterUserID = TwitterUserID;
            oUser.TwitterProfileImageURL = TwitterProfileImageURL;
            oUser.ShortBiography = ShortBiography;
            oUser.Biography = Biography;
            oUser.CurrentJobTitle = CurrentJobTitle;
            oUser.CurrentJobPublication = CurrentJobPublication;
            oUser.BeatID = BeatID;
            oUser.PackageID = PackageID;
            oUser.EditorName = EditorName;
            oUser.EditorEmail = EditorEmail;

            oUser.Save(2);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);

        }
    }

    [WebMethod]
    public bool NewUserJob(int UserID, string Publication, DateTime StartDate, DateTime EndDate, string URL, string Position, string Department, Boolean CurrentJob)
    {
        var oUserJob = new UserJob();
        try
        {

            oUserJob.UserID = UserID;
            oUserJob.Publication = Publication;
            oUserJob.StartDate = StartDate;
            oUserJob.EndDate = EndDate;
            oUserJob.URL = URL;
            oUserJob.Position = Position;
            oUserJob.Department = Department;
            oUserJob.CurrentJob = CurrentJob;

            oUserJob.Save(1);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);
        }  
    }

    [WebMethod]
    public bool UpdateUserJob(int iUserJobID, int UserID, string Publication, DateTime StartDate, DateTime EndDate, string URL, string Position, string Department, Boolean CurrentJob)
    {
        var oUserJob = new UserJob(iUserJobID);
        try
        {

            oUserJob.UserID = UserID;
            oUserJob.Publication = Publication;
            oUserJob.StartDate = StartDate;
            oUserJob.EndDate = EndDate;
            oUserJob.URL = URL;
            oUserJob.Position = Position;
            oUserJob.Department = Department;
            oUserJob.CurrentJob = CurrentJob;

            oUserJob.Save(1);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);
        }
    }

    [WebMethod]
    public XmlNode LoadUserJob(int UserJobID) {
        string sReturn = "";
        XmlDocument doc = new XmlDocument();
        var oUserJob = new UserJob(UserJobID);
        XmlDocument xdoc = new XmlDocument();
        sReturn += "<userjob>";
            sReturn += "<userjobid>" + oUserJob.UserJobID + "</userjobid>";
            sReturn += "<userid>" + oUserJob.UserID + "</userid>";
            sReturn += "<publication>" + oUserJob.Publication + "</publication>";
            sReturn += "<startdate>" + oUserJob.StartDate + "</startdate>";
            sReturn += "<enddate>" + oUserJob.StartDate + "</enddate>";
            sReturn += "<url>" + oUserJob.URL + "</url>";
            sReturn += "<position>" + oUserJob.URL + "</position>";
            sReturn += "<department>" + oUserJob.URL + "</department>";
            sReturn += "<currentjob>" + oUserJob.CurrentJob + "</currentjob>";
        sReturn += "</userjob>";
        doc.LoadXml("<envelope>" + sReturn + "</envelope>");
        return doc.DocumentElement;
    }

    [WebMethod]
    public XmlNode LoadUserJobs(int UserID)
    {
        string sReturn = "";
        XmlDocument doc = new XmlDocument();
        var oUserJob = new UserJob(0,UserID);
        
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        sSQL = "SELECT UserJobID, ISNULL(UserID,0) AS UserID, ISNULL(Publication,'') AS Publication, ISNULL(StartDate,GETDATE()) AS StartDate, ISNULL(EndDate, GETDATE()) AS EndDate, ISNULL(URL,'') AS URL, ISNULL(Position,'') AS Position, ISNULL(Department,'') AS Department, ISNULL(CurrentJob,'false') AS CurrentJob FROM UserJobs WHERE UserID = " + UserID.ToString();
        cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
        cm.Connection.Open();
        dr = cm.ExecuteReader();

        XmlDocument xdoc = new XmlDocument();
        sReturn += "<userjobs>";
        while (dr.Read()){ 
            sReturn += "<userjob>";
            sReturn += "<userjobid>" + Convert.ToInt32(dr["UserJobID"].ToString()) + "</userjobid>";
            sReturn += "<userid>" + Convert.ToInt32(dr["UserID"].ToString()) + "</userid>";
            sReturn += "<publication>" + dr["Publication"].ToString() + "</publication>";
            sReturn += "<startdate>" + Convert.ToDateTime(dr["StartDate"].ToString()) + "</startdate>";
            sReturn += "<enddate>" + Convert.ToDateTime(dr["EndDate"].ToString()) + "</enddate>";
            sReturn += "<url>" + dr["URL"].ToString() + "</url>";
            sReturn += "<position>" + dr["position"].ToString() + "</position>";
            sReturn += "<department>" + dr["department"].ToString() + "</department>";
            sReturn += "<currentjob>" + Convert.ToBoolean(dr["CurrentJob"]) + "</currentjob>";
            sReturn += "</userjob>";
        }
        sReturn += "</userjobs>";
        
        doc.LoadXml("<envelope>" + sReturn + "</envelope>");
        return doc.DocumentElement;
    }

    [WebMethod]
    public bool NewUserArticle(int UserID, string Title, string MediaOutlet, string Description, string URL, DateTime DatePublished, string ImageFormat, string DocumentFormat, bool Active, string ImageURL)
    {
        var oUserArticle = new UserArticle();
        try
        {

            oUserArticle.UserID = UserID;
            oUserArticle.Title = Title;
            oUserArticle.MediaOutlet = MediaOutlet;
            oUserArticle.Description = Description;
            oUserArticle.URL = URL;
            oUserArticle.DatePublished = DatePublished;
            oUserArticle.ImageFormat = ImageFormat;
            oUserArticle.DocumentFormat = DocumentFormat;
            oUserArticle.Active = Active;
            oUserArticle.ImageURL = ImageURL;

            oUserArticle.Save(1);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);
        }
    }

    [WebMethod]
    public bool UpdateUserArticle(int UserArticleID, int UserID, string Title, string MediaOutlet, string Description, string URL, DateTime DatePublished, string ImageFormat, string DocumentFormat, bool Active, string ImageURL)
    {
        var oUserArticle = new UserArticle(UserArticleID,0);
        try
        {

            oUserArticle.UserID = UserID;
            oUserArticle.Title = Title;
            oUserArticle.MediaOutlet = MediaOutlet;
            oUserArticle.Description = Description;
            oUserArticle.URL = URL;
            oUserArticle.DatePublished = DatePublished;
            oUserArticle.ImageFormat = ImageFormat;
            oUserArticle.DocumentFormat = DocumentFormat;
            oUserArticle.Active = Active;
            oUserArticle.ImageURL = ImageURL;

            oUserArticle.Save(2);
            return true;
        }
        catch (InvalidCastException e)
        {
            return false;
            throw (e);
        }
    }

    [WebMethod]
    public XmlNode LoadUserArticles(int UserID)
    {
        string sReturn = "";
        XmlDocument doc = new XmlDocument();
        var oUserJob = new UserJob(0, UserID);

        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        sSQL = "SELECT UserArticleID, ISNULL(UserID,0) AS UserID, ISNULL(Title,'') AS Title, ISNULL(MediaOutlet,'') AS MediaOutlet, ISNULL(Description,'') AS Description, ISNULL(URL,'') AS URL, ISNULL(DatePublished,GETDATE()) AS DatePublished, ISNULL(ImageFormat,'') AS ImageFormat, ISNULL(DocumentFormat,'') AS DocumentFormat, ISNULL(Active,'false') AS Active, ISNULL(ImageURL,'') AS ImageURL FROM UserArticles WHERE UserID = " + UserID.ToString();
        cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
        cm.Connection.Open();
        dr = cm.ExecuteReader();

        XmlDocument xdoc = new XmlDocument();
        sReturn += "<userarticles>";
        while (dr.Read())
        {
            sReturn += "<userarticle>";
            sReturn += "<userarticleid>" + Convert.ToInt32(dr["UserArticleID"].ToString()) + "</userarticleid>";
            sReturn += "<userid>" + Convert.ToInt32(dr["UserID"].ToString()) + "</userid>";
            sReturn += "<title>" + dr["Title"].ToString() + "</title>";
            sReturn += "<mediaoutlet>" + dr["MediaOutlet"].ToString() + "</mediaoutlet>";
            sReturn += "<description>" + dr["Description"].ToString() + "</description>";
            sReturn += "<url>" + dr["URL"].ToString() + "</url>";
            sReturn += "<datepublished>" + Convert.ToDateTime(dr["DatePublished"].ToString()) + "</datepublished>";
            sReturn += "<imageformat>" + dr["ImageFormat"].ToString() + "</imageformat>";
            sReturn += "<documentformat>" + dr["DocumentFormat"].ToString() + "</documentformat>";
            sReturn += "<active>" + Convert.ToBoolean(dr["Active"].ToString()) + "</active>";
            sReturn += "<imageurl>" + dr["ImageURL"].ToString() + "</imageurl>";
            sReturn += "</userarticle>";
        }
        sReturn += "</userarticles>";

        doc.LoadXml("<envelope>" + sReturn + "</envelope>");
        return doc.DocumentElement;
    }
}
