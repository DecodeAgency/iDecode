using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;
using System.Data.SqlClient;


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
    protected void btnRemoveBrackets_Click(object sender, EventArgs e)
    {
        var input = "User Name (email@address.com)";
        var output = System.Text.RegularExpressions.Regex.Replace(input, @" ?\(.*?\)", string.Empty);

        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        sSQL = "SELECT PublicationID, ISNULL(Publication,'') AS Publication, ISNULL(Website,'') AS Website, ISNULL(LanguageID,0) AS LanguageID FROM Publications ";


        cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
        cm.Connection.Open();
        dr = cm.ExecuteReader();

        nonqueryCommand.Connection.Open();

        nonqueryCommand.Parameters.Add("@Publication", SqlDbType.VarChar);

        while (dr.Read())
        {
            int publicationid = Convert.ToInt32(dr["PublicationID"].ToString());
            input = dr["Publication"].ToString();


            nonqueryCommand.CommandText = "UPDATE Publications SET Publication = @Publication WHERE PublicationID = " + publicationid.ToString();

            

            nonqueryCommand.Parameters["@Publication"].Value = System.Text.RegularExpressions.Regex.Replace(input, @" ?\(.*?\)", string.Empty); ;

            nonqueryCommand.ExecuteNonQuery();
        }
        

        dr = null;
        cm.Connection = null;
        cm = null;
    }
}