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
        }
        if (Session["iUserID"] != null) {
            if (Convert.ToInt16(Session["iUserID"].ToString()) != 0)
            {

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
                if (oUser.UserTypeID == 1)
                {
                    aPricePlans.HRef = "~/app/communicators/profileedit.aspx";
                    txtGeneralSearch.Text = "Search for Journalists, Keywords and Topics";                    
                }
                else if (oUser.UserTypeID == 2)
                {
                    aPricePlans.HRef = "~/app/journalists/profileedit.aspx";
                    txtGeneralSearch.Text = "Search for Communicators, Keywords and Department";
                }
            }
        }

        if (Request.RawUrl.Contains("admin"))
        {
            aPricePlans.HRef = "#";
        }
        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

    }
}
