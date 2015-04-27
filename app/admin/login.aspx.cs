using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using LinqToTwitter;
using System.Data;
using System.Data.SqlClient;

public partial class app_login : System.Web.UI.Page
{
    AspNetAuthorizer auth;
    HttpCookie iDecodeCookie = new HttpCookie("idecode");

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["logout"] != null) { Session["iUserID"] = null; Response.Cookies.Remove("idecode"); }
            this.Page.Title = "iDecode | Control Panel Log in";
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(0), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(0), ex.ToString());
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(0), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            var oDecode = new za.co.idecode.test.idecode();

            XmlNode XmlResult = oDecode.LoadUser(0, txtEmail.Text.ToLower());
            Boolean isLoggedIn = false;
            Boolean isActive = false;
            string sPassword = "";
            ulong iTwitterUserID = 0;
            int iUserID = 0;
            int iUserTypeID = 0;

            foreach (XmlNode Nodes in XmlResult)
            {
                iUserID = Convert.ToInt16(Nodes["userid"].InnerText);
                sPassword = Nodes["password"].InnerText;
                iTwitterUserID = Convert.ToUInt32(Nodes["twitteruserid"].InnerText);
                isActive = Convert.ToBoolean(Nodes["active"].InnerText);
                iUserTypeID = Convert.ToInt16(Nodes["usertypeid"].InnerText);
            }

            if (sPassword == txtPassword.Text)
            {
                isLoggedIn = true;
            }

            if (isLoggedIn == true && iTwitterUserID == 0 && isActive == true)
            {
                iDecodeCookie["uid"] = iUserID.ToString();
                iDecodeCookie.Expires = DateTime.Now.AddDays(180);
                Response.Cookies.Add(iDecodeCookie);
                Session["iUserID"] = iUserID.ToString();

                if (iUserTypeID == 5)
                {
                    Response.Redirect("dashboard.aspx", false);
                }
            }

        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(0), ex.ToString());
        }
    }

    protected async  void btnSignInWithTwitter_Click(object sender, EventArgs e)
    {

        int a = Convert.ToInt32(Request.Cookies["idecode"]["uid"]);
        var oUser = new User(Convert.ToInt32(Request.Cookies["idecode"]["uid"]), "");
        var auth = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "Sdmp3Oasby5SYAyjXmZd4KvpP",
                ConsumerSecret = "13hWlwE66cH6TGFozTXmL8d4i4GdEN5GylPSeBb3ojcnV8guNp",
                OAuthToken = oUser.TwitterOauthToken,
                OAuthTokenSecret = oUser.TwitterOauthTokenSecret,
                UserID = oUser.TwitterUserID
            }          
        };

        var ctxTwitterContext = new TwitterContext(auth);
        //ctxTwitterContext.("test text"); 
        var tweets =
                await
                (from tweet in ctxTwitterContext.Status
                 where tweet.Type == StatusType.Home
                 select tweet)
                .ToListAsync();

        //TwitterListView.DataSource = tweets;
        //TwitterListView.DataBind();

        var credentials = auth.CredentialStore;
        if (GetUserIdByTwitterID(credentials.UserID) != 0)
        {

            iDecodeCookie["uid"] = GetUserIdByTwitterID(credentials.UserID).ToString();
            iDecodeCookie.Expires = DateTime.Now.AddDays(180);
            Response.Cookies.Add(iDecodeCookie);

            Session["iUserID"] = GetUserIdByTwitterID(credentials.UserID);
            Response.Redirect("~/app/search.aspx", false);
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
}