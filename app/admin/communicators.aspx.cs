using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_communicators : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        try
        {
            this.Page.Title = "iDecode | Communication Officers";
            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
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
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());

            Response.Redirect("~/app/admin/dashboard.aspx", true);
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        } 
    }
}