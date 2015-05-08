using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_AppMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        aLogin.HRef = "~/app/login.aspx";
        aPricePlans.InnerText = "Register";
        aPricePlans.HRef = "~/app/register.aspx";
        imgLogo.Src = "~/app/styling/images/logo.png";
        txtGeneralSearch.Visible = false;
        if (Request.RawUrl.Contains("admin"))
        {
            aLogin.HRef = "~/app/admin/login.aspx";
            divAppNavMenu.Visible = false;
        }
        if (Session["iUserID"] != null) {
            divAppNavMenu.Visible = true;
            if (Convert.ToInt16(Session["iUserID"].ToString()) != 0)
            {
                //appNav

                aDashboard.HRef = "~/app/journalists/dashboard.aspx";
                aLogout.HRef = "~/app/login.aspx?logout=true";
                aSettings.HRef = "~/app/journalists/profileedit.aspx";

                //txtGeneralSearch.Visible = true;
                aPricePlans.HRef = "~/register.aspx";
                aPricePlans.InnerText = "My Profile";

                aLogin.InnerText = "Logout"; 
                aLogin.HRef = "~/app/login.aspx?logout=true";
                if (Request.RawUrl.Contains("admin"))
                {
                    aLogin.HRef = "~/app/admin/login.aspx?logout=true";
                }
                var oUser = new User(Convert.ToInt16(Session["iUserID"].ToString()), "");
                litWhosLoggedIn.Text = "Yoh, " + oUser.FirstName;
                divSmaillProfileImage.Style.Add("background-image", "url('" + getImageURL(oUser.TwitterProfileImageURL, oUser.ImageFormat, oUser.UserID) + "')");
                if (oUser.UserTypeID == 1)
                {
                    //aPricePlans.HRef = "~/app/communicators/profileedit.aspx";
                    //txtGeneralSearch.Text = "Search for Journalists, Keywords and Topics";
                    aPressRelease.HRef = "~/app/journalists/pressreleases/userpressreleases.aspx";
                    aSearch.HRef = "~/app/journalists/search.aspx";
                    
                }
                else if (oUser.UserTypeID == 2)
                {
                    //aPricePlans.HRef = "~/app/journalists/profileedit.aspx";
                    //txtGeneralSearch.Text = "Search for Communicators, Keywords and Department";
                    aSearch.HRef = "~/app/communicators/search.aspx";
                    aPressRelease.Visible = false;
                }
            }
        }

        if (Request.RawUrl.Contains("admin"))
        {
            aPricePlans.HRef = "#";
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
            output = "../images/profileimages/" + Convert.ToInt32(iUserID) + "." + sImageFormat;
        }
        else
        {
            output = "../images/profileimages/0.png";
        }
        return output;
    }
}
