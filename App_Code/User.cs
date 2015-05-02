using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class User
{
    private int iUserID;
    private string sFirstName = "";
    private string sLastName = "";
    private int iGenderID = 0;
    private int iAge = 0;
    private string sCurrentCity = "";
    private int iCountryID = 0;
    private string sContactMobile = "";
    private string sContactOffice = "";
    private string sFaxNumber = "";
    private string sEmailAddress = "";
    private string sPassword = "";
    private string sWebsiteAddress = "";
    private Boolean bActive = false;    
    private DateTime dDateTimeStamp = DateTime.Now;
    private DateTime dLastUpdatedDate = DateTime.Now;
    private int iUserTypeID = 0;
    private string sFacebookUsername = "";
    private string sTwitterUsername = "";
    private string sLinkedInUsername = "";
    private string sImageFormat = "";
    private string sTwitterOauthToken = "";
    private string sTwitterOauthTokenSecret = "";
    private string sTwitterScreenName = "";
    private ulong iTwitterUserID = 0;
    private string sTwitterProfileImageURL = "";
    private string sShortBiography = "";
    private string sBiography = "";
    private string sCurrentJobTitle = "";
    private string sCurrentJobPublication = "";
    private int iBeatID = 0;
    private int iPackageID = 0;

    public int UserID{
        get { return iUserID; }
    }

    public string FirstName {
        get { return sFirstName; }
        set { sFirstName = value; }
    }

    public string LastName {
        get { return sLastName; }
        set { sLastName = value; }
    }

    public int GenderID {
        get { return iGenderID; }
        set { iGenderID = value; }
    }

    public int Age {
        get { return iAge; }
        set { iAge = value; }
    }

    public string CurrentCity {
        get { return sCurrentCity; }
        set { sCurrentCity = value; }
    }

    public int CountryID  {
        get { return iCountryID; }
        set { iCountryID = value; }
    }

    public string ContactMobile {
        get { return sContactMobile; }
        set { sContactMobile = value; }
    }

    public string ContactOffice {
        get { return sContactOffice; }
        set { sContactOffice = value; }
    }

    public string FaxNumber
    {
        get { return sFaxNumber; }
        set { sFaxNumber = value; }
    }

    public string EmailAddress
    {
        get { return sEmailAddress; }
        set { sEmailAddress = value; }
    }

    public string Password {
        get { return sPassword; }
        set { sPassword = value; }        
    }

    public string WebsiteAddress
    {
        get { return sWebsiteAddress; }
        set { sWebsiteAddress = value; }
    }

    public Boolean Active {
        get { return bActive; }
        set { bActive = value; }
    }

    public DateTime DateTimeStamp {
        get { return dDateTimeStamp;}
        set { dDateTimeStamp = value; }
    }

    public DateTime LastUpdatedDate {
        get { return dLastUpdatedDate; }
        set { dLastUpdatedDate = value;}
    }

    public int UserTypeID {
        get { return iUserTypeID; }
        set { iUserTypeID = value; }
    }

    public string FacebookUsername
    {
        get { return sFacebookUsername; }
        set { sFacebookUsername = value; }
    }

    public string TwitterUsername
    {
        get { return sTwitterUsername; }
        set { sTwitterUsername = value; }
    }

    public string LinkedInUsername
    {
        get { return sLinkedInUsername; }
        set { sLinkedInUsername = value; }
    }

    public string ImageFormat
    {
        get { return sImageFormat; }
        set { sImageFormat = value; }
    }

    public string TwitterOauthToken 
    {
        get { return sTwitterOauthToken; }
        set { sTwitterOauthToken = value; }
    }

    public string TwitterOauthTokenSecret
    {
        get { return sTwitterOauthTokenSecret; }
        set { sTwitterOauthTokenSecret = value; }
    }

    public string TwitterScreenName {
        get { return sTwitterScreenName; }
        set { sTwitterScreenName = value; }
    }

    public ulong TwitterUserID 
    {
        get { return iTwitterUserID; }
        set { iTwitterUserID = value; }
    }
    public string TwitterProfileImageURL
    {
        get { return sTwitterProfileImageURL; }
        set { sTwitterProfileImageURL = value; }
    }

    public string ShortBiography
    {
        get { return sShortBiography; }
        set { sShortBiography = value; }
    }

    public string Biography
    {
        get { return sBiography; }
        set { sBiography = value; }
    }

    public string CurrentJobTitle
    {
        get { return sCurrentJobTitle; }
        set { sCurrentJobTitle = value; }
    }

    public string CurrentJobPublication
    {
        get { return sCurrentJobPublication; }
        set { sCurrentJobPublication = value; }
    }

    public int BeatID {
        get { return iBeatID; }
        set { iBeatID = value; }
    }

    public int PackageID
    {
        get { return iPackageID; }
        set { iPackageID = value; }
    }

	public User(){	
	}

    public User(int ID, string Email = "")
    {
        Load(ID, Email);
    }

    public void Load(int ID, string Email = "")
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserID = ID;
            sEmailAddress = Email;

            sSQL = "SELECT UserID, ISNULL(FirstName,'') AS FirstName, ISNULL(LastName,'') AS LastName, ISNULL(GenderID,0) AS GenderID, ISNULL(Age,0) AS Age, " ;
            sSQL += "ISNULL(CurrentCity,'') AS CurrentCity, ISNULL(CountryID,0) AS CountryID, ISNULL(ContactMobile,'') AS ContactMobile, ISNULL(ContactOffice,'') AS ContactOffice, ";
            sSQL += "ISNULL(FaxNumber,'') AS FaxNumber, ISNULL(EmailAddress,'') AS EmailAddress, ISNULL(Password,'') AS Password, ISNULL(WebsiteAddress,'') AS WebsiteAddress, ISNULL(Active,'false') AS Active, ";
            sSQL += "ISNULL(DateTimeStamp,GETDATE()) AS DateTimeStamp, ISNULL(LastUpdatedDate,GETDATE()) AS LastUpdatedDate, ISNULL(UserTypeID,0) AS UserTypeID, ";
            sSQL += "ISNULL(FacebookUsername,'') AS FacebookUsername, ISNULL(TwitterUsername,'') AS TwitterUsername, ISNULL(LinkedInUsername,'') AS LinkedInUsername, ISNULL(ImageFormat,'') AS ImageFormat, ISNULL(TwitterOauthToken,'') AS TwitterOauthToken, ISNULL(TwitterOauthTokenSecret,'') AS TwitterOauthTokenSecret, ISNULL(TwitterScreenName,'') AS TwitterScreenName, ISNULL(TwitterUserID,0) AS TwitterUserID, ISNULL(TwitterProfileImageURL,'') AS TwitterProfileImageURL, ";
            sSQL += "ISNULL(ShortBiography,'') AS ShortBiography, ISNULL(Biography,'') AS Biography, ISNULL(CurrentJobTitle,'') AS CurrentJobTitle, ISNULL(CurrentJobPublication,'') AS CurrentJobPublication, ISNULL(BeatID,0) AS BeatID, ISNULL(PackageID,0) AS PackageID ";
            sSQL += "FROM Users";
            
            if (ID != 0){
                sSQL += " WHERE UserID = " + ID.ToString();
            }else{
                sSQL += " WHERE LOWER(EmailAddress) = '" + Email.ToString().ToLower() + "'";
            }
            

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sFirstName = dr["FirstName"].ToString();
                sLastName = dr["LastName"].ToString();
                iGenderID = Convert.ToInt32(dr["GenderID"].ToString());
                iAge = Convert.ToInt32(dr["Age"].ToString());
                sCurrentCity = dr["CurrentCity"].ToString();
                iCountryID = Convert.ToInt32(dr["CountryID"].ToString());
                sContactMobile = dr["ContactMobile"].ToString();
                sContactOffice = dr["ContactOffice"].ToString();
                sFaxNumber = dr["FaxNumber"].ToString();
                sEmailAddress = dr["EmailAddress"].ToString();
                sPassword = dr["Password"].ToString();
                sWebsiteAddress = dr["WebsiteAddress"].ToString();
                bActive = Convert.ToBoolean(dr["Active"].ToString());
                dDateTimeStamp = Convert.ToDateTime(dr["DateTimeStamp"].ToString()); ;
                dLastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"].ToString()); ;
                iUserTypeID = Convert.ToInt32(dr["UserTypeID"].ToString());
                sFacebookUsername = dr["FacebookUsername"].ToString();
                sTwitterUsername = dr["TwitterUsername"].ToString();
                sLinkedInUsername = dr["LinkedInUsername"].ToString();
                sImageFormat = dr["ImageFormat"].ToString();
                sTwitterOauthToken = dr["TwitterOauthToken"].ToString();
                sTwitterOauthTokenSecret = dr["TwitterOauthTokenSecret"].ToString();
                sTwitterScreenName = dr["TwitterScreenName"].ToString();
                iTwitterUserID = Convert.ToUInt64(dr["TwitterUserID"].ToString());
                sTwitterProfileImageURL = dr["TwitterProfileImageURL"].ToString();
                sShortBiography = dr["ShortBiography"].ToString();
                sBiography = dr["Biography"].ToString();
                sCurrentJobTitle = dr["CurrentJobTitle"].ToString();
                sCurrentJobPublication = dr["CurrentJobPublication"].ToString();
                iBeatID = Convert.ToInt32(dr["BeatID"].ToString());
                iPackageID = Convert.ToInt32(dr["PackageID"].ToString());
            }
            else
            {
                iUserID = 0;
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

    }/*End Load Sub*/

    public Boolean Save(int TypeID)
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            if (TypeID == 1)
            {
                nonqueryCommand.CommandText = "INSERT INTO Users (FirstName, LastName, GenderID, Age, CurrentCity, CountryID, ContactMobile, ContactOffice, FaxNumber, EmailAddress, Password, WebsiteAddress, Active, DateTimeStamp, LastUpdatedDate, UserTypeID, FacebookUsername, TwitterUsername, LinkedInUsername, ImageFormat,TwitterOauthToken,TwitterOauthTokenSecret,TwitterScreenName,TwitterUserID, TwitterProfileImageURL, ShortBiography, Biography, CurrentJobTitle, CurrentJobPublication, BeatID, PackageID) VALUES (@FirstName, @LastName, @GenderID, @Age, @CurrentCity, @CountryID, @ContactMobile, @ContactOffice, @FaxNumber, @EmailAddress, @Password, @WebsiteAddress, @Active, @DateTimeStamp, @LastUpdatedDate, @UserTypeID, @FacebookUsername, @TwitterUsername, @LinkedInUsername, @ImageFormat, @TwitterOauthToken,@TwitterOauthTokenSecret,@TwitterScreenName,@TwitterUserID, @TwitterProfileImageURL, @ShortBiography, @Biography, @CurrentJobTitle, @CurrentJobPublication, @BeatID, @PackageID) ";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, GenderID = @GenderID, Age = @Age, CurrentCity = @CurrentCity, CountryID = @CountryID, ContactMobile = @ContactMobile, ContactOffice = @ContactOffice, FaxNumber = @FaxNumber, EmailAddress = @EmailAddress, Password = @Password, WebsiteAddress = @WebsiteAddress, Active = @Active, DateTimeStamp = @DateTimeStamp, LastUpdatedDate = @LastUpdatedDate, UserTypeID = @UserTypeID, FacebookUsername = @FacebookUsername, TwitterUsername = @TwitterUsername, LinkedInUsername = @LinkedInUsername, ImageFormat = @ImageFormat, TwitterOauthToken = @TwitterOauthToken, TwitterOauthTokenSecret = @TwitterOauthTokenSecret, TwitterScreenName = @TwitterScreenName, TwitterUserID = @TwitterUserID, TwitterProfileImageURL = @TwitterProfileImageURL, ShortBiography = @ShortBiography, Biography = @Biography, CurrentJobTitle = @CurrentJobTitle, CurrentJobPublication = @CurrentJobPublication, BeatID = @BeatID, PackageID = @PackageID WHERE UserID = " + iUserID.ToString();
            }

            nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@LastName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@GenderID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Age", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@CurrentCity", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@CountryID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@ContactMobile", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@ContactOffice", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@FaxNumber", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Password", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@WebsiteAddress", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Active", SqlDbType.Bit);
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@LastUpdatedDate", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@UserTypeID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@FacebookUsername", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TwitterUsername", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@LinkedInUsername", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@ImageFormat", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TwitterOauthToken", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TwitterOauthTokenSecret", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TwitterScreenName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TwitterUserID", SqlDbType.BigInt);
            nonqueryCommand.Parameters.Add("@TwitterProfileImageURL", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@ShortBiography", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Biography", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@CurrentJobTitle", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@CurrentJobPublication", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@BeatID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@PackageID", SqlDbType.Int);

            nonqueryCommand.Parameters["@FirstName"].Value = sFirstName;
            nonqueryCommand.Parameters["@LastName"].Value = sLastName;
            nonqueryCommand.Parameters["@GenderID"].Value = iGenderID;
            nonqueryCommand.Parameters["@Age"].Value = iAge;
            nonqueryCommand.Parameters["@CurrentCity"].Value = sCurrentCity;
            nonqueryCommand.Parameters["@CountryID"].Value = iCountryID;
            nonqueryCommand.Parameters["@ContactMobile"].Value = sContactMobile;
            nonqueryCommand.Parameters["@ContactOffice"].Value = sContactOffice;
            nonqueryCommand.Parameters["@FaxNumber"].Value = sFaxNumber;
            nonqueryCommand.Parameters["@EmailAddress"].Value = sEmailAddress;
            nonqueryCommand.Parameters["@Password"].Value = sPassword;
            nonqueryCommand.Parameters["@WebsiteAddress"].Value = sWebsiteAddress;
            nonqueryCommand.Parameters["@Active"].Value = bActive;
            nonqueryCommand.Parameters["@DateTimeStamp"].Value = dDateTimeStamp;
            nonqueryCommand.Parameters["@LastUpdatedDate"].Value = dLastUpdatedDate;
            nonqueryCommand.Parameters["@UserTypeID"].Value = iUserTypeID;
            nonqueryCommand.Parameters["@FacebookUsername"].Value = sFacebookUsername;
            nonqueryCommand.Parameters["@TwitterUsername"].Value = sTwitterUsername;
            nonqueryCommand.Parameters["@LinkedInUsername"].Value = sLinkedInUsername;
            nonqueryCommand.Parameters["@ImageFormat"].Value = sImageFormat;
            nonqueryCommand.Parameters["@TwitterOauthToken"].Value = sTwitterOauthToken;
            nonqueryCommand.Parameters["@TwitterOauthTokenSecret"].Value = sTwitterOauthTokenSecret;
            nonqueryCommand.Parameters["@TwitterScreenName"].Value = sTwitterScreenName;
            nonqueryCommand.Parameters["@TwitterUserID"].Value = iTwitterUserID;
            nonqueryCommand.Parameters["@TwitterProfileImageURL"].Value = sTwitterProfileImageURL;
            nonqueryCommand.Parameters["@ShortBiography"].Value = sShortBiography;
            nonqueryCommand.Parameters["@Biography"].Value = sBiography;
            nonqueryCommand.Parameters["@CurrentJobTitle"].Value = sCurrentJobTitle;
            nonqueryCommand.Parameters["@CurrentJobPublication"].Value = sCurrentJobPublication;
            nonqueryCommand.Parameters["@BeatID"].Value = iBeatID;
            nonqueryCommand.Parameters["@PackageID"].Value = iPackageID;

            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return true;
    } /*End Save*/

    public Boolean Delete()
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "DELETE FROM Users WHERE UserID = " + iUserID.ToString();
            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return true;
    }

    public int Count(int UserTypeID)
    {
        string sSQL;
        int iCount = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserTypeID = UserTypeID;

            sSQL = "SELECT COUNT(UserID) AS Count FROM Users WHERE UserTypeID = " + UserTypeID;

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iCount = Convert.ToInt32(dr["Count"].ToString());
            }
            else
            {
                iUserID = 0;
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
    }/*End Load Sub*/

}