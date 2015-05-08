using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class app_communicators_search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        this.Page.Title = "iDecode | Search for Communication Officers";
        if (Request.QueryString["sci"] != null)
        {
            if (Request.QueryString["sci"].ToString() != "")
            {
                int iUserJournalistSearchID = Convert.ToInt32(Request.QueryString["sci"].ToString());
                var oUserJournalistSearch = new UserJournalistSearch(iUserJournalistSearchID);
                txtkeyword.Text = oUserJournalistSearch.Keywords;
                txtCommunicatorName.Text = oUserJournalistSearch.Journalist;
                txtLocation.Text = oUserJournalistSearch.Location;
                txtDepartment.Text = oUserJournalistSearch.Department;
                SearchCommunicators(oUserJournalistSearch.Keywords, oUserJournalistSearch.Journalist, oUserJournalistSearch.Location,oUserJournalistSearch.Department);
            }
        }

        var oUser = new User();
        litJournalistCount.Text = Convert.ToString(oUser.Count(3));
    }

    public void SearchCommunicators(string keywords, string communicator, string location, string department) {
        
        litSearchHeading.Text = "Search Results";

        Session["kqy"] = "aabbcc";
        Session["cn"] = "aabbcc";
        Session["l"] = "aabbcc";
        Session["d"] = "aabbcc";

        Session["kqy"] = keywords.ToLower();
        Session["cn"] = communicator.ToLower();
        Session["l"] = location.ToLower();
        Session["d"] = department.ToLower();

        var oUserJournalistSearch = new UserJournalistSearch();
        oUserJournalistSearch.UserID = Convert.ToInt16(Session["iUserID"].ToString());
        oUserJournalistSearch.DateTimeStamp = DateTime.Now;

        string sSQL = "";
        sSQL = "SELECT U.UserID, ISNULL(U.FirstName,'') AS FirstName, ISNULL(LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE U.TwitterProfileImageURL END) AS ProfileImage ";
        sSQL += ",ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress";

        sSQL += " FROM Users U WHERE U.UserTypeID = 3 AND U.Active = 1 ";
        if (Session["l"].ToString() != "e.g. eastern cape" && Session["l"].ToString() != "")
        {
            oUserJournalistSearch.Location = txtLocation.Text;
            sSQL += " AND LOWER(CurrentCity) = @Location";
        }
        if (Session["cn"].ToString() != "e.g. margaret dingalo" && Session["cn"].ToString() != "")
        {
            oUserJournalistSearch.Journalist = txtCommunicatorName.Text;
            sSQL += " AND LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @JounalistName + '%'";
        }
        if (Session["kqy"].ToString() != "e.g. spokesperson" && Session["kqy"].ToString() != "")
        {
            oUserJournalistSearch.Keywords = txtkeyword.Text;
            sSQL += " AND LOWER(CurrentCity) = @Keyword OR LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @Keyword + '%' OR LOWER(U.CurrentJobPublication) LIKE '%' + @Keyword + '%' OR LOWER(U.CurrentJobTitle) LIKE '%' + @Keyword + '%'";
        }

        if (Session["d"].ToString() != "e.g. gauteng provincial government" && Session["d"].ToString() != "")
        {
            sSQL += " AND LOWER(U.CurrentJobPublication) LIKE '%' + @Department + '%'";
        }
        sSQL += " GROUP BY U.UserID, U.FirstName, U.CurrentJobTitle, U.CurrentJobPublication, U.BeatID, U.CurrentCity, U.TwitterProfileImageURL, U.LastName, U.ImageFormat, U.ContactMobile, U.ContactOffice, U.EmailAddress, U.FaxNumber";

        dsJournalists.SelectCommand = sSQL;

        //dsBeats.DataBind();
        if (Request.QueryString["sci"] != null)
        {
            oUserJournalistSearch.Save(2);
        }
        else
        {
            oUserJournalistSearch.Save(1);
        }

        rptJournalists.DataBind();
        rptUserJournalistSearches.DataBind();

        if (rptJournalists.Items.Count == 0)
        {
            litSearchResult.Visible = true;
        }
        else
        {
            litSearchResult.Visible = false;
        }

        if (rptUserJournalistSearches.Items.Count == 0)
        {
            litUserJournalistSearchesResult.Visible = true;
        }
        else
        {
            litUserJournalistSearchesResult.Visible = false;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCommunicators(txtkeyword.Text, txtCommunicatorName.Text, txtLocation.Text, txtDepartment.Text);
        
        //litSearchHeading.Text = "Search Results";

        //Session["kqy"] = "aabbcc";
        //Session["cn"] = "aabbcc";
        //Session["l"] = "aabbcc";
        //Session["d"] = "aabbcc";

        //Session["kqy"] = txtkeyword.Text.ToLower();
        //Session["cn"] = txtCommunicatorName.Text.ToLower();
        //Session["l"] = txtLocation.Text.ToLower();
        //Session["d"] = txtDepartment.Text.ToLower();

        //string sSQL = "";
        //sSQL = "SELECT U.UserID, ISNULL(U.FirstName,'') AS FirstName, ISNULL(LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE U.TwitterProfileImageURL END) AS ProfileImage ";
        //sSQL += ",ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress";

        //sSQL += " FROM Users U WHERE U.UserTypeID = 3 AND U.Active = 1 ";
        //if (Session["l"].ToString() != "e.g. eastern cape")
        //{
        //    sSQL += " AND LOWER(CurrentCity) = @Location";
        //}
        //if (Session["cn"].ToString() != "e.g. margaret dingalo")
        //{
        //    sSQL += " AND LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @JounalistName + '%'";
        //}
        //if (Session["kqy"].ToString() != "e.g. spokesperson")
        //{
        //    sSQL += " AND LOWER(CurrentCity) = @Keyword OR LOWER(U.FirstName + ' ' + U.LastName) LIKE '%' + @Keyword + '%' OR LOWER(U.CurrentJobPublication) LIKE '%' + @Keyword + '%' OR LOWER(U.CurrentJobTitle) LIKE '%' + @Keyword + '%'";
        //}

        //if (Session["d"].ToString() != "e.g. gauteng provincial government")
        //{
        //    sSQL += " AND LOWER(U.CurrentJobPublication) LIKE '%' + @Department + '%'";
        //}
        //sSQL += " GROUP BY U.UserID, U.FirstName, U.CurrentJobTitle, U.CurrentJobPublication, U.BeatID, U.CurrentCity, U.TwitterProfileImageURL, U.LastName, U.ImageFormat, U.ContactMobile, U.ContactOffice, U.EmailAddress, U.FaxNumber";

        //dsJournalists.SelectCommand = sSQL;

        ////dsBeats.DataBind();
        //rptJournalists.DataBind();

        //if (rptJournalists.Items.Count == 0)
        //{
        //    litSearchResult.Visible = true;
        //}
        //else
        //{
        //    litSearchResult.Visible = false;
        //}
    }

    protected void rptJournalists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl divProImage = e.Item.FindControl("divProImage") as System.Web.UI.HtmlControls.HtmlGenericControl;
        HiddenField hidUser = e.Item.FindControl("hidUserID") as HiddenField;

        var oUser = new User(Convert.ToInt32(hidUser.Value), "");
        divProImage.Style.Add("background-image", "url('" + getImageURL(oUser.TwitterProfileImageURL, oUser.ImageFormat, Convert.ToInt32(hidUser.Value)) + "')");
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
            output = "../images/profileimages/" + iUserID + "." + sImageFormat;
        }
        else
        {
            output = "../images/profileimages/0.png";
        }
        return output;
    }
}