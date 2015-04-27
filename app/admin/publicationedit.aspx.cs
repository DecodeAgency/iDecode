using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_publicationedit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
            this.Page.Title = "iDecode | Manage Publications";

            if (!IsPostBack)
            {
                int iPublicationID = Convert.ToInt32(Request.QueryString["pid"].ToString());
                var oPublication = new PublicationClass(iPublicationID);
                txtPublication.Text = oPublication.Publication;
                txtWebsite.Text = oPublication.Website;
                ddLanguage.SelectedValue = Convert.ToString(oPublication.LanguageID);
            }

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
            
            Response.Redirect("~/app/admin/publications.aspx", true);
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try{
            int iPublicationID = Convert.ToInt32(Request.QueryString["pid"].ToString());
            var oPublication = new PublicationClass(iPublicationID);
            oPublication.Publication = txtPublication.Text;
            oPublication.Website = txtWebsite.Text;
            oPublication.Save(2);
            txtSuccessMessage.Visible = true;
            divMessage.Visible = true;
        }
        catch (Exception ex) {
            divMessage.Visible = true;
            txtErrorMessage.Visible = true;

            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }        
    }
}