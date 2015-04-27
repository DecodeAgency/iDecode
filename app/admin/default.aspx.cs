using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(0), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
            Response.Redirect("login.aspx");            
        }
        catch (Exception ex) 
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(0), ex.ToString());
        }       
    }
}