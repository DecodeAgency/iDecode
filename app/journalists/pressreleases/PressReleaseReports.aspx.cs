using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

using MailChimp;
using MailChimp.Lists;


public partial class app_journalists_pressreleases_PressReleaseReports : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        this.Page.Title = "iDecode | Press Release Reports";
        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID);
        string  sReport = "";
       
        sReport = mc.GetListAbuseReports(oUserCampaign.MailChimpListID.ToString()).ToString();
       sReport += mc.GetReportClickDetail(oUserCampaign.MailChimpCampaignID.ToString(),Convert.ToInt16(oUserCampaign.TemplateID)).ToString();
        mc.GetLocationsForList(oUserCampaign.MailChimpListID.ToString());
        mc.GetReportOpened(oUserCampaign.MailChimpCampaignID.ToString());
        mc.GetReportNotOpened(oUserCampaign.MailChimpCampaignID.ToString());
        mc.GetReportClickDetail(oUserCampaign.MailChimpCampaignID.ToString(), Convert.ToInt16(oUserCampaign.TemplateID));
        mc.GetReportSentTo(oUserCampaign.UserCampaignID.ToString());


    }
}