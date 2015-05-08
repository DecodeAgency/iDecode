using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class app_admin_newdashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
            this.Page.Title = "iDecode | Dashboard";
            var oUser = new User();
            litJournalistCount.Text = Convert.ToString(oUser.Count(2));
            litCommunicatorsCount.Text = Convert.ToString(oUser.Count(3));
            litPublicationsCount.Text = Convert.ToString(CountPublications());
            litUpdatedToday.Text = Convert.ToString(CountUpdatedToday());
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserSessionTrail(Convert.ToInt32(Session["iUserID"].ToString()), HttpContext.Current.Session.SessionID.ToString(), Request.RawUrl.ToString());
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        } 
    }

    protected void rptRecentUpdates_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hidUpdatedProfileID = e.Item.FindControl("hidUpdatedProfileID") as HiddenField;
        HiddenField hidActivityCreator = e.Item.FindControl("hidActivityCreator") as HiddenField;
        Literal litUpdateStatus = e.Item.FindControl("litUpdateStatus") as Literal;
        Literal litDatePosted = e.Item.FindControl("litDatePosted") as Literal;

        int iUpdatedProfileID = Convert.ToInt32(hidUpdatedProfileID.Value);
        var oUser = new User(iUpdatedProfileID, "");
        var oCreater = new User(Convert.ToInt32(hidActivityCreator.Value));
        //TimeSpan ts = TimeSpan.Parse(Convert.ToDateTime(litDatePosted.Text).ToString("dd:MM:yyyy:h:m"));

        //litDatePosted.Text = Convert.ToDateTime(litDatePosted.Text).ToString("dd:MM:yyyy:hh:mm");// ToLongString(ts);
        string sDate = ToLongString(DateTime.Now - DateTime.ParseExact(Convert.ToDateTime(litDatePosted.Text).ToString("ddd MMM dd HH:mm:ss zzz yyyy"), "ddd MMM dd HH:mm:ss zzz yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeLocal));

        litDatePosted.Text = sDate + " ago";


        //if (oLoggedInUser.UserTypeID == 2)
        //{
        //    if (oUser.UserTypeID == 3)
        //    {

        litUpdateStatus.Text = oCreater.FirstName + " updated " + oUser.FirstName + " " + oUser.LastName;
        //    }
        //}
        //else if (oLoggedInUser.UserTypeID == 3 || oLoggedInUser.UserTypeID == 1)
        //{
        //    if (oUser.UserTypeID == 2)
        //    {
        //        litUpdateStatus.Text = "Journalist: <a href='profile.aspx?uid=" + oUser.UserID + "'>" + oUser.FirstName + " " + oUser.LastName + "</a> profile was updated.";
        //    }
        //}
    }

    public string ToLongString(TimeSpan time)
    {
        string output = String.Empty;

        if (time.Days > 0)
            output += time.Days + " days ";

        if ((time.Days == 0 || time.Days == 1) && time.Hours > 0)
            output += time.Hours + " hr ";

        if (time.Days == 0 && time.Minutes > 0)
            output += time.Minutes + " min ";

        if (output.Length == 0)
            output += time.Seconds + " sec";

        return output.Trim();
    }

    public int CountPublications()
    {
        string sSQL;
        int iCount = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {

            sSQL = "SELECT COUNT(PublicationID) As Count FROM Publications ";

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iCount = Convert.ToInt32(dr["Count"].ToString());
            }
            else
            {
                iCount = 0;
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
        return iCount;
    }/*End Load Sub*/

    public int CountUpdatedToday()
    {
        string sSQL;
        int iCount = 0;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {

            sSQL = "SELECT COUNT(UserID) As Count FROM Users WHERE LastUpdatedDate > '" + DateTime.Now.AddHours(-24) + "'";

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iCount = Convert.ToInt32(dr["Count"].ToString());
            }
            else
            {
                iCount = 0;
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
        return iCount;
    }/*End Load Sub*/
}