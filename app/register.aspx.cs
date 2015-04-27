using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LinqToTwitter;
using System.Configuration;
using System.Threading.Tasks;

public partial class app_register : System.Web.UI.Page
{
    //PR - UID 1, JOURNO - UID 2, COMMUNI - UID 3
    AspNetAuthorizer auth;
    HttpCookie iDecodeCookie = new HttpCookie("idecode");
    string sTwitterProfileImageURL = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            this.Page.Title = "iDecode | Create Your iDecode Account";
            if (Session["iUserID"] != null)
            {
                if (Convert.ToInt16(Session["iUserID"].ToString()) != 0)
                {
                    var oUser = new User(Convert.ToInt16(Session["iUserID"].ToString()), "");
                    int iUserTypeID = oUser.UserTypeID;
                    if (iUserTypeID == 1)
                    {
                        Response.Redirect("~/app/journalists/search.aspx", false);
                    }
                    else if (iUserTypeID == 2)
                    {
                        Response.Redirect("~/app/communicators/search.aspx", false);
                    }
                }
            }        
        }
        catch (Exception ex) 
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }

        //if (Request.Cookies["idecode"] != null)
        //{
        //    if (Request.Cookies["idecode"]["uid"] != null)
        //    {
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
        //if (GetUserIdByTwitterID(credentials.UserID) != 0)
        //{
        //    iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
        //    iDecodeCookie.Expires = DateTime.Now.AddDays(180);
        //    Response.Cookies.Add(iDecodeCookie);

        //    Session["iUserID"] = GetUserIdByTwitterID(credentials.UserID);

        //    var oUser = new User(GetUserIdByTwitterID(credentials.UserID), "");
        //    if (oUser.UserTypeID == 1)
        //    {
        //        Response.Redirect("~/app/journalists/search.aspx", false); //Search Journos
        //    }
        //    else if (oUser.UserTypeID == 2)
        //    {
        //        Response.Redirect("~/app/communicators/search.aspx", false); //Search Communicators
        //    }
        //}
    }

    protected void btnSignInWithTwitter_Click(object sender, EventArgs e)
    {

    }

    protected void btnPRRegister_Click(object sender, EventArgs e)
    {
        try 
        {
            var oUser = new User(0, txtPREmail.Text);
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
                    oUser.FirstName = txtPRFirstName.Text;
                    oUser.LastName = txtPRLastName.Text;
                    oUser.EmailAddress = txtPREmail.Text;
                    oUser.Password = "##########";
                    oUser.TwitterOauthToken = oauthToken;
                    oUser.TwitterOauthTokenSecret = oauthTokenSecret;
                    oUser.TwitterScreenName = screenName;
                    oUser.TwitterUserID = userID;
                    oUser.Active = true;
                    oUser.UserTypeID = 1;
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
                    oUser.FirstName = txtPRFirstName.Text;
                    oUser.LastName = txtPRLastName.Text;
                    oUser.EmailAddress = txtPREmail.Text;
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
                Response.Redirect("~/app/journalists/search.aspx", false);
            }
            else
            {
                if (oUser.UserID != 0)
                {
                    oUser = new User(oUser.UserID);
                    oUser.FirstName = txtPRFirstName.Text;
                    oUser.LastName = txtPRLastName.Text;
                    oUser.EmailAddress = txtPREmail.Text;
                    oUser.Password = txtPRPassword.Text;
                    oUser.Active = true;
                    oUser.UserTypeID = 1;
                    oUser.Save(2);

                    iDecodeCookie["uid"] = GetUserIdByName(txtPRFirstName.Text, txtPRLastName.Text, txtPREmail.Text).ToString();
                    iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                    Response.Cookies.Add(iDecodeCookie);
                    Session["iUserID"] = GetUserIdByName(txtPRFirstName.Text, txtPRLastName.Text, txtPREmail.Text);
                }
                else if (oUser.UserID == 0)
                {
                    oUser = new User();
                    oUser.FirstName = txtPRFirstName.Text;
                    oUser.LastName = txtPRLastName.Text;
                    oUser.EmailAddress = txtPREmail.Text;
                    oUser.Password = txtPRPassword.Text;
                    oUser.Active = true;
                    oUser.UserTypeID = 1;
                    oUser.Save(1);

                    iDecodeCookie["uid"] = GetUserIdByName(txtPRFirstName.Text, txtPRLastName.Text, txtPREmail.Text).ToString();
                    iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                    Response.Cookies.Add(iDecodeCookie);
                    Session["iUserID"] = GetUserIdByName(txtPRFirstName.Text, txtPRLastName.Text, txtPREmail.Text);
                }
                oUser = new User(GetUserIdByName(txtPRFirstName.Text, txtPRLastName.Text, txtPREmail.Text), "");
                Response.Redirect("~/app/journalists/search.aspx", false);
            } 
        }
        catch (Exception ex) 
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }

    }
    protected void btnJRegister_Click(object sender, EventArgs e)
    {
        var oUser = new User(0, txtJEmail.Text);
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
                oUser.FirstName = txtJFirstName.Text;
                oUser.LastName = txtJLastName.Text;
                oUser.EmailAddress = txtJEmail.Text;
                oUser.Password = "##########";
                oUser.TwitterOauthToken = oauthToken;
                oUser.TwitterOauthTokenSecret = oauthTokenSecret;
                oUser.TwitterScreenName = screenName;
                oUser.TwitterUserID = userID;
                oUser.Active = true;
                oUser.UserTypeID = 2;
                oUser.TwitterProfileImageURL = imgJProImage.Src;
                oUser.Save(2);
                iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByTwitterID(userID);
            }
            else if (oUser.UserID == 0)
            {
                oUser = new User();
                oUser.FirstName = txtJFirstName.Text;
                oUser.LastName = txtJLastName.Text;
                oUser.EmailAddress = txtJEmail.Text;
                oUser.Password = "##########";
                oUser.TwitterOauthToken = oauthToken;
                oUser.TwitterOauthTokenSecret = oauthTokenSecret;
                oUser.TwitterScreenName = screenName;
                oUser.TwitterUserID = userID;
                oUser.Active = true;
                oUser.UserTypeID = 2;
                oUser.TwitterProfileImageURL = imgJProImage.Src;
                oUser.Save(1);
                iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByTwitterID(userID);
            }

            oUser = new User(GetUserIdByTwitterID(userID), "");
            Response.Redirect("~/app/communicators/search.aspx", false);


        }
        else
        {
            if (oUser.UserID != 0)
            {
                oUser = new User(oUser.UserID);
                oUser.FirstName = txtJFirstName.Text;
                oUser.LastName = txtJLastName.Text;
                oUser.EmailAddress = txtJEmail.Text;
                oUser.Password = txtJPassword.Text;
                oUser.Active = true;
                oUser.UserTypeID = 2;
                oUser.Save(2);

                iDecodeCookie["uid"] = GetUserIdByName(txtJFirstName.Text, txtJLastName.Text, txtJEmail.Text).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByName(txtJFirstName.Text, txtJLastName.Text, txtJEmail.Text);
            }
            else if (oUser.UserID == 0)
            {
                oUser = new User();
                oUser.FirstName = txtJFirstName.Text;
                oUser.LastName = txtJLastName.Text;
                oUser.EmailAddress = txtJEmail.Text;
                oUser.Password = txtJPassword.Text;
                oUser.Active = true;
                oUser.UserTypeID = 2;
                oUser.Save(1);

                iDecodeCookie["uid"] = GetUserIdByName(txtJFirstName.Text, txtJLastName.Text, txtJEmail.Text).ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = GetUserIdByName(txtJFirstName.Text, txtJLastName.Text, txtJEmail.Text);
            }
            oUser = new User(GetUserIdByName(txtJFirstName.Text, txtJLastName.Text, txtJEmail.Text), "");
            Response.Redirect("~/app/communicators/search.aspx", false);
        }
    }
    protected void btnJSignupWithTwitter_Click(object sender, EventArgs e)
    {

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

            if (iUserID == 0)
            {
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
}