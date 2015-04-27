using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToTwitter;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public partial class app_default : System.Web.UI.Page
{
    AspNetAuthorizer auth;
    HttpCookie iDecodeCookie = new HttpCookie("idecode");
    string sTwitterProfileImageURL = "";

    protected void Page_Load(object sender, EventArgs e)
   
    {
        Response.Redirect("register.aspx", false);
        //if (Request.Cookies["idecode"] != null)
        //{
        //    if (Request.Cookies["idecode"]["uid"] != null) {
        //        Session["iUserID"] = Convert.ToInt32(Request.Cookies["idecode"]["uid"]);
        //    } 
        //    Response.Redirect("~/app/search.aspx", false);
        //}
        //auth = new AspNetAuthorizer
        //{
        //    CredentialStore = new SessionStateCredentialStore()
        //    {
        //        ConsumerKey = "Sdmp3Oasby5SYAyjXmZd4KvpP",
        //        ConsumerSecret = "13hWlwE66cH6TGFozTXmL8d4i4GdEN5GylPSeBb3ojcnV8guNp" 
        //    },
        //    GoToTwitterAuthorization = twitterUrl => Response.Redirect(twitterUrl, false)
        //};


        //var twitterCtx = new TwitterContext(auth);
        //var credentials = auth.CredentialStore;
        
        //if (!Page.IsPostBack && Request.QueryString["oauth_token"] != null)
        //{

        //    await auth.CompleteAuthorizeAsync(Request.Url);

        //    string oauthToken = credentials.OAuthToken;
        //    string oauthTokenSecret = credentials.OAuthTokenSecret;
        //    string screenName = credentials.ScreenName;
        //    ulong userID = credentials.UserID;
            
        //    var users =
        //        from tweet in twitterCtx.User
        //        where tweet.Type == UserType.Show &&
        //              tweet.UserID == userID
        //        select tweet;

            
        //    var user = users.SingleOrDefault();
        //    sTwitterProfileImageURL = user.ProfileImageUrl.Replace("_normal", "");
        //    imgProImage.Src = sTwitterProfileImageURL;
        //    //txtFullName.Text = user.Name;
        //    trProfileImage.Visible = true;
        //    trPassword.Visible = false;
        //    trSignInWithTwitter.Visible = false;
        //    trSeparator.Visible = false;

            
        //}
        //if (GetUserIdByTwitterID(credentials.UserID) != 0) {

        //    iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
        //    iDecodeCookie.Expires = DateTime.Now.AddDays(180);
        //    Response.Cookies.Add(iDecodeCookie);

        //    Session["iUserID"] = GetUserIdByTwitterID(credentials.UserID);

        //    var oUser = new User(GetUserIdByTwitterID(credentials.UserID), "");
        //    if (oUser.UserTypeID == 1)
        //    {
        //        Response.Redirect("~/app/search.aspx", false);
        //    }
        //    else if (oUser.UserTypeID == 2)
        //    {
        //        Response.Redirect("~/app/journo/profileedit.aspx?uid=" + oUser.UserID, false);
        //    }
        //}
    }

    protected async void btnSignInWithTwitter_Click(object sender, EventArgs e)
    {
        await auth.BeginAuthorizeAsync(Request.Url);
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        var oUser = new User(0, txtEmail.Text);
        if (Request.QueryString["oauth_token"] != null)
        {
            var credentials = auth.CredentialStore;
            string oauthToken = credentials.OAuthToken;
            string oauthTokenSecret = credentials.OAuthTokenSecret;
            string screenName = credentials.ScreenName;
            ulong userID = credentials.UserID;
            Session["iUserID"] = GetUserIdByTwitterID(userID);

            if (oUser.UserID != 0)
            {
                oUser = new User(oUser.UserID);
                oUser.FirstName = txtFirstName.Text;
                oUser.LastName = txtLastName.Text;
                oUser.EmailAddress = txtEmail.Text;
                oUser.Password = "##########";
                oUser.TwitterOauthToken = oauthToken;
                oUser.TwitterOauthTokenSecret = oauthTokenSecret;
                oUser.TwitterScreenName = screenName;
                oUser.TwitterUserID = userID;
                oUser.Active = true;
                //oUser.UserTypeID = 1;
                oUser.TwitterProfileImageURL = imgProImage.Src;
                oUser.Save(2);
                iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByTwitterID(userID);
            }
            else if (oUser.UserID == 0)
            {
                oUser = new User();
                oUser.FirstName = txtFirstName.Text;
                oUser.LastName = txtLastName.Text;
                oUser.EmailAddress = txtEmail.Text;
                oUser.Password = "##########";
                oUser.TwitterOauthToken = oauthToken;
                oUser.TwitterOauthTokenSecret = oauthTokenSecret;
                oUser.TwitterScreenName = screenName;
                oUser.TwitterUserID = userID;
                oUser.Active = true;
                oUser.UserTypeID = 1;
                oUser.TwitterProfileImageURL = imgProImage.Src;
                oUser.Save(1);
                iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByTwitterID(userID);
            }

            oUser = new User(GetUserIdByTwitterID(userID), "");
            if (oUser.UserTypeID == 1)
            {
                Response.Redirect("~/app/search.aspx", false);
            }
            else if (oUser.UserTypeID == 2)
            {
                Response.Redirect("~/app/journo/profileedit.aspx?uid=" + oUser.UserID, false);
            }
            
        }
        else
        {
            if (oUser.UserID != 0)
            {
                oUser = new User(oUser.UserID);
                oUser.FirstName = txtFirstName.Text;
                oUser.LastName = txtLastName.Text;
                oUser.EmailAddress = txtEmail.Text;
                oUser.Password = txtPassword.Text;
                oUser.Active = true;
                oUser.UserTypeID = 1;
                oUser.Save(2);

                iDecodeCookie["uid"] = GetUserIdByName(txtFirstName.Text, txtLastName.Text, txtEmail.Text).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByName(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            }
            else if (oUser.UserID == 0)
            {
                oUser = new User();
                oUser.FirstName = txtFirstName.Text;
                oUser.LastName = txtLastName.Text;
                oUser.EmailAddress = txtEmail.Text;
                oUser.Password = txtPassword.Text;
                oUser.Active = true;
                oUser.UserTypeID = 1;
                oUser.Save(1);

                iDecodeCookie["uid"] = GetUserIdByName(txtFirstName.Text, txtLastName.Text, txtEmail.Text).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByName(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            }
            oUser = new User(GetUserIdByName(txtFirstName.Text, txtLastName.Text, txtEmail.Text), "");
            if (oUser.UserTypeID == 1)
            {
                Response.Redirect("~/app/search.aspx", false);
            }
            else if (oUser.UserTypeID == 2)
            {
                Response.Redirect("~/app/journo/profileedit.aspx?uid=" + oUser.UserID, false);
            }
        }
    }

    public int GetUserIdByTwitterID(ulong TwitterId)
    {
        string sSQL;
        int iUserID = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            sSQL = "SELECT UserID FROM Users WHERE ISNULL(TwitterOauthToken,'') <> '' AND TwitterUserID = " + TwitterId;

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
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

        return iUserID;
    }

    public int GetUserIdByName(string FirstName, string LastName, string EmailAddress)
    {
        string sSQL;
        int iUserID = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            sSQL = "SELECT UserID FROM Users WHERE LOWER(FirstName) = '" + FirstName.ToString().ToLower() + "' AND LOWER(LastName)='" + LastName.ToString().ToLower() + "'";

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
            }

            if (iUserID == 0) {
                sSQL = "SELECT UserID FROM Users WHERE LOWER(EmailAddress) = '" + EmailAddress.ToString().ToLower() + "'";

                cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
                cm.Connection.Open();
                dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    iUserID = Convert.ToInt32(dr["UserID"].ToString());
                }
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

        return iUserID;
    }
}