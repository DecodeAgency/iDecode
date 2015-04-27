using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_publications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        try
        {
            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
            this.Page.Title = "iDecode | Publications";

            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        } 
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/app/admin/dashboard.aspx", true);

            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }         
    }
}