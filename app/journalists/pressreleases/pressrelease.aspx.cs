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

using System.Security;
using System.Security.Permissions;

[assembly: AllowPartiallyTrustedCallers]
public partial class app_journalists_pressreleases_pressrelease : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/login.aspx", true); }
        this.Page.Title = "iDecode | Create Press Release";

        if (Request.QueryString["prid"] != null) {
            int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
            var oUserCampaign = new UserCampaign(iUserCampaignID);

            btnCreateCampaign.Visible = false;
            btnUpdateCampaign.Visible = true;
            divSendThatThing.Visible = true;

            txtSubject.Text = oUserCampaign.Subject;
            txtFromEmail.Text = oUserCampaign.FromEmail;
            txtFromName.Text = oUserCampaign.FromName;

            rteSample.Value = oUserCampaign.CampaignContent;

            if (oUserCampaign.StatusID == 1) { //sent
                btnSendCampaign.Text = "Campaign Sent Successfully.";
                btnSendCampaign.Enabled = false;
            }

            //Scheduled
            if (oUserCampaign.StatusID == 2)
            {
                btnScheduleCampaign.Enabled = false;
                btnScheduleCampaign.Text = "Scheduled for " + oUserCampaign.ScheduleDateTime.ToString("dd-MMM-yyyy HH:mm");
                dtScheduleDateTime.Visible = false;
            }

            //Scheduled
            if (oUserCampaign.StatusID == 0)
            {
                btnScheduleCampaign.Visible = true;
                dtScheduleDateTime.Visible = true;
                btnCancelSchedule.Visible = false;
            }

            //ddUserCampaignGroups
        }
    }
    protected void btnCreateCampaign_Click(object sender, EventArgs e)
    {
            CreatePressRelease(ddUserCampaignGroups.SelectedValue);
    }

    protected void btnDeleteCampaign_Click(object sender, EventArgs e)
    {
        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID);
        if (oUserCampaign.MailChimpCampaignID != ""){
            mc.DeleteCampaign(oUserCampaign.MailChimpCampaignID);
        }        
        oUserCampaign.Delete();

        Response.Redirect("~/app/journalists/pressreleases/userpressreleases.aspx", true);
    }

    protected void btnSendCampaign_Click(object sender, EventArgs e)
    {
        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID);
        mc.SendCampaign(oUserCampaign.MailChimpCampaignID);
        oUserCampaign.StatusID = 1; //Sent
        oUserCampaign.Save(2);
    }

    protected void btnScheduleCampaign_Click(object sender, EventArgs e)
    {
        DateTime dScheduleDateTime = DateTime.Now;

        dScheduleDateTime = dtScheduleDateTime.Value.AddHours(-3);

        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID);
        mc.ScheduleCampaign(oUserCampaign.MailChimpCampaignID,dScheduleDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        oUserCampaign.StatusID = 2; //Scheduled
        oUserCampaign.ScheduleDateTime = dScheduleDateTime;
        oUserCampaign.Save(2);
    }

    protected void btnUpdateCampaign_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelSchedule_Click(object sender, EventArgs e)
    {
        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID); 
        mc.UnscheduleCampaign(oUserCampaign.MailChimpCampaignID);
        oUserCampaign.StatusID = 0; //Nothing
        oUserCampaign.Save(2);
    }

    protected void btnSendTestCampaign_Click(object sender, EventArgs e)
    {
        System.Collections.Generic.List<string> listEmails = new System.Collections.Generic.List<string>();
        listEmails.Add("obakeng@decode.co.za");

        int iUserCampaignID = Convert.ToInt32(Request.QueryString["prid"].ToString());
        var oUserCampaign = new UserCampaign(iUserCampaignID);
        mc.SendCampaignTest(oUserCampaign.MailChimpCampaignID,listEmails);
    }

    public void CreatePressRelease(string sCampaignGroupName)
    {

        var oUserCampaign = new UserCampaign();

        MailChimp.Campaigns.CampaignFilter listfilter = new MailChimp.Campaigns.CampaignFilter();
        MailChimp.Campaigns.CampaignListResult lists = mc.GetCampaigns();


        MailChimp.Campaigns.CampaignCreateOptions options = new MailChimp.Campaigns.CampaignCreateOptions();
        MailChimp.Campaigns.CampaignCreateContent content = new MailChimp.Campaigns.CampaignCreateContent();
        MailChimp.Campaigns.CampaignSegmentOptions segmentoptions = new MailChimp.Campaigns.CampaignSegmentOptions();

        segmentoptions.Match = "All";
        segmentoptions.Conditions = new List<MailChimp.Campaigns.CampaignSegmentCriteria>();
        segmentoptions.Conditions.Add(new MailChimp.Campaigns.CampaignSegmentCriteria { Field = "interests-8309", Operator = "one", Value = sCampaignGroupName });

        oUserCampaign.UserID = Convert.ToInt32(Session["iUserID"].ToString());
        options.ListId = sListID;
        oUserCampaign.MailChimpListID = sListID;
        options.Subject = txtSubject.Text;

        oUserCampaign.Subject = txtSubject.Text;
        options.FromEmail = txtFromEmail.Text;

        oUserCampaign.FromEmail = txtFromEmail.Text;
        options.FromName = txtFromName.Text;
        oUserCampaign.FromName = txtFromName.Text;

        options.ToName = "*|FNAME|" + " " + "*|LNAME|";
        oUserCampaign.ToName = "*|FNAME|" + " " + "*|LNAME|";
        //options.TemplateID = 32;
        options.Title = txtSubject.Text;
        oUserCampaign.Title = txtSubject.Text;
        content.HTML = rteSample.Value;
        oUserCampaign.CampaignContent = rteSample.Value;

        mc.CreateCampaign("regular", options, content, segmentoptions, null);

        //int i = Convert.ToInt32(oUserCampaign.Save(1));

        listfilter.FromEmail = txtFromEmail.Text;
        listfilter.Subject = txtSubject.Text; ;
        listfilter.FromName = txtFromName.Text;


        lists = mc.GetCampaigns(listfilter);
        string sMailChimpCampaignID = lists.Data[0].Id;
        oUserCampaign.MailChimpCampaignID = sMailChimpCampaignID;
        Convert.ToInt32(oUserCampaign.Save(1));

        //oUserCampaign.Save(2);
    }

    public string GetListID(string sListGroupName)
    {
        string sResult = "";

        try
        {
            sPostURL += "/lists/list.format?apikey=" + sAPIKey + "&list_name=" + sListGroupName;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sPostURL);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "GET";


            WebResponse response = httpWebRequest.GetResponse();
            String responseString = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            //litResul.Text = responseString.ToString();

            return sResult;
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());

            return ex.ToString();
        }
    }

}